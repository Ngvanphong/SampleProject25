using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateRevit2025.Utilities;

namespace TemplateRevit2025.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class VectorCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            List<(int, string)> listAllColumnParamter = new System.Collections.Generic.List<(int, string)>();

            listAllColumnParamter.Add((1, "Para 1"));
            listAllColumnParamter.Add((2, "Para 2"));
            listAllColumnParamter.Add((4, "Para 3"));

            foreach((int,string) columnPara in listAllColumnParamter)
            {
                int indexCol = columnPara.Item1;
                string namePara= columnPara.Item2;

            }



            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc= uiDoc.Document;

            Category pipeCategory = doc.Settings.Categories.get_Item(BuiltInCategory.OST_PipeCurves);

            ElementId parameterId = new ElementId((long)BuiltInParameter.ALL_MODEL_TYPE_NAME);
            FilterRule rule1 = ParameterFilterRuleFactory.CreateEqualsRule(parameterId, "Chilled Water");

            ElementId parameterId2 = new ElementId((long)BuiltInParameter.RBS_PIPE_DIAMETER_PARAM);
            double valueFilter = UnitUtils.ConvertToInternalUnits(250, UnitTypeId.Millimeters);
            FilterRule rule2 = ParameterFilterRuleFactory.CreateEqualsRule(parameterId2, valueFilter, 0.0000001);

            ElementId parameterId3 = new ElementId((long)BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
            FilterRule rule3 = ParameterFilterRuleFactory.CreateContainsRule(parameterId3, "m");

            ParameterFilterElement filter = null;
            using (Transaction t1= new Transaction(doc, "CreateFilter"))
            {
                t1.Start();
                List<ElementId> listCategory = new List<ElementId>();
                listCategory.Add(pipeCategory.Id);

                filter = ParameterFilterElement.Create(doc, "PipeFilter", listCategory);

                ElementParameterFilter elementFilterRule1 = new ElementParameterFilter(rule1);
                ElementParameterFilter elementFilterRule2 = new ElementParameterFilter(rule2);
                ElementParameterFilter elementFilterRule3 = new ElementParameterFilter(rule3);


                List<ElementFilter> listElementFitlerParent = new List<ElementFilter>();

                listElementFitlerParent.Add(elementFilterRule1);

                List<ElementFilter> listElementFilterChild = new List<ElementFilter>();
                listElementFilterChild.Add(elementFilterRule2);
                listElementFilterChild.Add(elementFilterRule3);
                ElementFilter logicalChildOr = new LogicalOrFilter(listElementFilterChild);

                listElementFitlerParent.Add(logicalChildOr);

                ElementFilter logicalAndFilterParent = new LogicalAndFilter(listElementFitlerParent);

                filter.SetElementFilter(logicalAndFilterParent);
                t1.Commit();
            }

            var solidPatten = new FilteredElementCollector(doc).OfClass(typeof(FillPatternElement)).Cast<FillPatternElement>()
                .Where(x => x.GetFillPattern().IsSolidFill == true).First();
            using(Transaction t= new Transaction(doc, "AddFilter"))
            {
                t.Start();
                doc.ActiveView.AddFilter(filter.Id);
                doc.ActiveView.SetFilterVisibility(filter.Id, true);
                OverrideGraphicSettings overrideGraphicSettings = new OverrideGraphicSettings();
                overrideGraphicSettings.SetSurfaceForegroundPatternColor(new Autodesk.Revit.DB.Color(255, 0, 0));
                overrideGraphicSettings.SetSurfaceForegroundPatternId(solidPatten.Id);
                doc.ActiveView.SetFilterOverrides(filter.Id, overrideGraphicSettings);
                t.Commit();
            }

            ElementCategoryFilter pipeCateFitler = new ElementCategoryFilter(BuiltInCategory.OST_PipeCurves, true);
            ElementCategoryFilter ductCatFilter = new ElementCategoryFilter(BuiltInCategory.OST_DuctCurves, true);
            List<ElementFilter> listCateFilter = new List<ElementFilter>{ pipeCateFitler, ductCatFilter };
            
            LogicalOrFilter logicalOrFilterCate = new LogicalOrFilter(listCateFilter);

            XYZ min1= new XYZ(0, 0, 0);
            XYZ max1 = XYZ.Zero;
            Outline outlineFilter= new Outline(min1, max1);

            BoundingBoxIntersectsFilter boundIntersectionFilter = new BoundingBoxIntersectsFilter(outlineFilter);

            IList<ElementFilter> listInterFilter= new List<ElementFilter> { boundIntersectionFilter, logicalOrFilterCate };

            LogicalAndFilter logicalAndFilter= new LogicalAndFilter(listInterFilter);

            var colleciton= new FilteredElementCollector(doc).WherePasses(logicalAndFilter);


            var colleciton2 = new FilteredElementCollector(doc).WherePasses(boundIntersectionFilter).ToElements();
            List<Element> listPipeDuct = new List<Element>();
            foreach(Element el in colleciton2)
            {
                if(el.Category!=null && 
                    (el.Category.Id.Value== (long)BuiltInCategory.OST_PipeCurves 
                    || el.Category.Id.Value ==(long)BuiltInCategory.OST_DuctCurves)
                    )
                {
                    listPipeDuct.Add(el);
                }
            }





            Pipe pipe = null;
            PickedBox pickBox = null;
            try
            {
                Reference refElement = uiDoc.Selection.PickObject(
                    Autodesk.Revit.UI.Selection.ObjectType.PointOnElement, new ILineFitler(),
                    "Pick a line");
                Element el = doc.GetElement((refElement));

                //var pickObject = uiDoc.Selection.PickPoint("Pick a point");
                //var pickRec = uiDoc.Selection.PickElementsByRectangle();
                var pickObjects = uiDoc.Selection.PickObjects(ObjectType.Element, "Pick pipe");
                pickBox = uiDoc.Selection.PickBox(PickBoxStyle.Enclosing);


                //pipe = doc.GetElement(refElement) as Pipe;
            }
            catch { }

            XYZ min = pickBox.Min;
            XYZ max = pickBox.Max;

            double xMin = Math.Min(min.X, max.X);
            double yMin = Math.Min(min.Y, max.Y);
            double zMin = Math.Min(min.Z, max.Z);

            double xMax = Math.Max(min.X, max.X);
            double yMax = Math.Max(min.Y, max.Y);
            double zMax = Math.Max(min.Z, max.Z);

            XYZ minTrue = new XYZ(xMin, yMin, zMin);
            XYZ maxTrue = new XYZ(xMax, yMax, zMax);

            Outline outline = new Outline(minTrue, maxTrue);
            BoundingBoxIntersectsFilter boundingIntersectionFilter = new BoundingBoxIntersectsFilter(outline);
            var allelemenInBox = new FilteredElementCollector(doc, doc.ActiveView.Id)
                .WherePasses(boundingIntersectionFilter).ToList();

            







            LocationCurve locationCurve = pipe.Location as LocationCurve;

            Curve curve = locationCurve.Curve;
            Line line = curve as Line;
            XYZ ps = line.GetEndPoint(0);
            XYZ pe = line.GetEndPoint(1);
            XYZ pMid = ps.Add(pe).Divide(2);

            XYZ viewDirection = doc.ActiveView.ViewDirection.Normalize();
            XYZ direction = line.Direction.Normalize();
            XYZ normalLine = viewDirection.CrossProduct(direction).Normalize();

            double lengthMili = 5;
            double lenthInch = UnitUtils.ConvertToInternalUnits(lengthMili, UnitTypeId.Meters);

            XYZ pMidEnd = pMid + normalLine * lenthInch;

            var systemType = pipe.MEPSystem;

            using (Transaction t = new Transaction(doc, "CreatePipe"))
            {
                t.Start();
                Level level = doc.ActiveView.GenLevel;
                var pipeType = pipe.GetType();
                Pipe.Create(doc, pipe.MEPSystem.GetTypeId(), pipe.PipeType.Id,
                    doc.ActiveView.GenLevel.Id, pMid, pMidEnd);
                t.Commit();
            }

            Plane plane = Plane.CreateByNormalAndOrigin(normalLine, pMidEnd);

            XYZ pSPipe = curve.GetEndPoint(0);
            XYZ pEPipe = curve.GetEndPoint(1);

            XYZ pSInter = XYZCalculator.IntersectionPlaneByVector(plane, normalLine, pSPipe);
            XYZ pEInter = XYZCalculator.IntersectionPlaneByVector(plane, normalLine, pEPipe);

            using (Transaction t = new Transaction(doc, "CreatePipe"))
            {
                t.Start();
                Level level = doc.ActiveView.GenLevel;
                var pipeType = pipe.GetType();
                Pipe.Create(doc, pipe.MEPSystem.GetTypeId(), pipe.PipeType.Id,
                    doc.ActiveView.GenLevel.Id, pSInter, pEInter);
                t.Commit();
            }


            return Result.Succeeded;

        }
       
    }
    public class ILineFitler : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem.Category != null && elem.Category.Id.Value == (long)BuiltInCategory.OST_PipeCurves)
            {
                return true;
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return true;
        }
    }
}
