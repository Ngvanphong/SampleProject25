using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateRevit2025.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class VectorCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc= uiDoc.Document;

            Pipe pipe = null;
            try
            {
                Reference refElement = uiDoc.Selection.PickObject(
                    Autodesk.Revit.UI.Selection.ObjectType.Element, new ILineFitler(),
                    "Pick a line");
                pipe = doc.GetElement( refElement ) as Pipe;
            }
            catch { }
            LocationCurve locationCurve = pipe.Location as LocationCurve;

            Curve curve = locationCurve.Curve;
            Line line = curve as Line;
            XYZ ps = line.GetEndPoint(0);
            XYZ pe = line.GetEndPoint(1);
            XYZ pMid= ps.Add(pe).Divide(2);

            XYZ viewDirection = doc.ActiveView.ViewDirection.Normalize();
            XYZ direction= line.Direction.Normalize();
            XYZ normalLine= viewDirection.CrossProduct(direction).Normalize();

            double lengthMili = 5;
            double lenthInch = UnitUtils.ConvertToInternalUnits(lengthMili, UnitTypeId.Meters);

            XYZ pMidEnd = pMid + normalLine * lenthInch;

            var systemType= pipe.MEPSystem;
            
            using(Transaction t= new Transaction(doc, "CreatePipe"))
            {
                t.Start();
                Level level = doc.ActiveView.GenLevel;
                var pipeType = pipe.GetType();
                Pipe.Create(doc,pipe.MEPSystem.GetTypeId(), pipe.PipeType.Id,
                    doc.ActiveView.GenLevel.Id,pMid,pMidEnd);
                t.Commit();
            }


            


            return Result.Succeeded;

        }

        public class ILineFitler : ISelectionFilter
        {
            public bool AllowElement(Element elem)
            {
                if(elem.Category!= null && elem.Category.Id.Value==(long)BuiltInCategory.OST_PipeCurves)
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
}
