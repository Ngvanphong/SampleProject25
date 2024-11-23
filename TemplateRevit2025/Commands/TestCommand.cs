using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB.Structure;

namespace TemplateRevit2025.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class TestCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;

            FamilyInstance beam = null;
            try
            {
                var bemRef = uiDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, "Pick Beam");
                beam = doc.GetElement(bemRef) as FamilyInstance;
            }
            catch { }

            double widthBeam = beam.Symbol.LookupParameter("b").AsDouble();
            double heightBeam= beam.Symbol.LookupParameter("h").AsDouble();
            if (beam.Location == null) return Result.Succeeded;
            LocationCurve locationCurve = beam.Location as LocationCurve;
            double cover = 50 / 304.8;
            RebarBarType rebarBatType22 = new FilteredElementCollector(doc).OfClass(typeof(RebarBarType)).Cast<RebarBarType>()
                .First(x => Math.Abs(x.BarNominalDiameter - 22.2 / 304.8) < 0.0001);

            if(locationCurve != null)
            {
                Curve curveBeam = locationCurve.Curve;
                Line lineBeam = curveBeam as Line;
                if(lineBeam != null)
                {

                    // lop tren

                    XYZ directionBeam = lineBeam.Direction.Normalize();
                    XYZ normalRebar = directionBeam.CrossProduct(XYZ.BasisZ).Normalize();
                    XYZ vectorMove = directionBeam.CrossProduct(normalRebar).Normalize();
                    Transform transformDown = Transform.CreateTranslation(vectorMove* cover);
                    Line lineMoveDown = lineBeam.CreateTransformed(transformDown) as Line;

                    double sPara = lineMoveDown.GetEndParameter(0);
                    double ePara= lineMoveDown.GetEndParameter(1);

                    double sParaTrim = sPara + cover / lineMoveDown.Length * (ePara - sPara);
                    double eParaTrim = ePara - cover/ lineMoveDown.Length * (ePara - sPara);
                    lineMoveDown.MakeBound(sParaTrim, eParaTrim);

                    XYZ pLT = lineMoveDown.GetEndPoint(0);
                    XYZ pRT = lineMoveDown.GetEndPoint(1);

                    Transform transformMoveDown2 = Transform.CreateTranslation(vectorMove* (heightBeam - 200 / 304.8));
                    XYZ pLB = transformMoveDown2.OfPoint(pLT);
                    XYZ pRB = transformMoveDown2.OfPoint(pRT);

                    Line line1 = Line.CreateBound(pLB, pLT);
                    Line line2 = lineMoveDown;
                    Line line3 = Line.CreateBound(pRT, pRB);
                    Transform moveLeft = Transform.CreateTranslation(-normalRebar * (widthBeam / 2 - cover));

                    using (Transaction t= new Transaction(doc, "CreateStandardRebar"))
                    {
                        t.Start();
                        Rebar rebar= Rebar.CreateFromCurves(doc, RebarStyle.Standard, rebarBatType22, null, null, beam, normalRebar,
                            new List<Curve> { line1,line2,line3 }, RebarHookOrientation.Left, RebarHookOrientation.Left, true, true);
                        ElementTransformUtils.MoveElement(doc, rebar.Id, -normalRebar * (widthBeam / 2 - cover));
                        rebar.GetShapeDrivenAccessor().SetLayoutAsFixedNumber(3, widthBeam - 2 * cover, true, true, true);
                        rebar.SetUnobscuredInView(doc.ActiveView, true);
                        t.Commit();
                    }

                    // lop duoi
                    Transform transformBot = Transform.CreateTranslation(vectorMove * (heightBeam - cover));
                    Line lineBot = lineBeam.CreateTransformed(transformBot) as Line;
                    lineBot.MakeBound(sParaTrim, eParaTrim);

                    var hocks = new FilteredElementCollector(doc).OfClass(typeof(RebarHookType)).Cast<RebarHookType>();
                    RebarHookType hock180 = hocks.First(x => Math.Abs(x.HookAngle - Math.PI) < 0.0001);

                    Rebar rebarBottom = null;
                    using (Transaction t = new Transaction(doc, "CreateStandardRebar"))
                    {
                        t.Start();


                        Line lineBotMoveLeft = lineBot.CreateTransformed(moveLeft) as Line;

                        rebarBottom = Rebar.CreateFromCurves(doc, RebarStyle.Standard, rebarBatType22, hock180, hock180, beam, normalRebar,
                            new List<Curve> { lineBotMoveLeft }, RebarHookOrientation.Left, RebarHookOrientation.Left, true, true);
                        rebarBottom.SetUnobscuredInView(doc.ActiveView, true);

                        //rebarBottom.GetShapeDrivenAccessor().SetLayoutAsFixedNumber(4, widthBeam - 2 * cover, true, true, true);

                        rebarBottom.GetShapeDrivenAccessor().SetLayoutAsMaximumSpacing(50 / 304.8, widthBeam - 2 * cover, true, true, true);

                        t.Commit();
                    }
                    var listCenterCurve = rebarBottom.GetCenterlineCurves(true, false, false, MultiplanarOption.IncludeAllMultiplanarCurves, 0);

                    //using (Transaction t = new Transaction(doc, "RebarContainer"))
                    //{
                    //    t.Start();
                    //    ElementId iddRebarContainerType = RebarContainerType.CreateDefaultRebarContainerType(doc);
                    //    RebarContainer rebarContainer = RebarContainer.Create(doc, beam, iddRebarContainerType);
                    //    rebarContainer.PresentItemsAsSubelements = true;

                    //    Line lineBotMoveLeft = lineBot.CreateTransformed(moveLeft) as Line;
                    //    rebarContainer.AppendItemFromCurves(RebarStyle.Standard, rebarBatType22, hock180, hock180, normalRebar,
                    //        new List<Curve> { lineBotMoveLeft }, RebarHookOrientation.Left, RebarHookOrientation.Left, true, true);


                    //    t.Commit();
                    //}


                }
            }


            
            





            return Result.Succeeded;
        }
    }
}