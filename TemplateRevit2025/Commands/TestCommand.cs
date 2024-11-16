using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using System.Configuration;

namespace TemplateRevit2025.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class TestCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;

            Room room = null;
            try
            {
                var refRoom = uiDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, "Pick room");
                room = doc.GetElement(refRoom) as Room;
            }
            catch { }

            SpatialElementBoundaryOptions roomOption = new SpatialElementBoundaryOptions();
            roomOption.SpatialElementBoundaryLocation = SpatialElementBoundaryLocation.Finish;
            IList<IList<BoundarySegment>> roomBoundarySegment = room.GetBoundarySegments(roomOption);

            List<CurveLoop> listCurveloop = new List<CurveLoop>();
            List<Element> listHostELement = new List<Element>();
            foreach(IList<BoundarySegment> listSegment in roomBoundarySegment)
            {
                CurveLoop curveloopListSemgent = new CurveLoop();
                foreach(BoundarySegment segment in listSegment)
                {
                    Element hostOfSegment = doc.GetElement(segment.ElementId);
                    listHostELement.Add(hostOfSegment);
                    Curve curveOfSegment = segment.GetCurve();
                    curveloopListSemgent.Append(curveOfSegment);
                }
                listCurveloop.Add(curveloopListSemgent);
            }

            

            return Result.Succeeded;
        }
    }
}