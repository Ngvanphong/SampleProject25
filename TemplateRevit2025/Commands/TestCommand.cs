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

            //Room room = null;
            //try
            //{
            //    var refRoom = uiDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, "Pick room");
            //    room = doc.GetElement(refRoom) as Room;
            //}
            //catch { }

            //SpatialElementBoundaryOptions roomOption = new SpatialElementBoundaryOptions();
            //roomOption.SpatialElementBoundaryLocation = SpatialElementBoundaryLocation.Finish;
            //IList<IList<BoundarySegment>> roomBoundarySegment = room.GetBoundarySegments(roomOption);

            //List<CurveLoop> listCurveloop = new List<CurveLoop>();
            //List<Element> listHostELement = new List<Element>();
            //foreach(IList<BoundarySegment> listSegment in roomBoundarySegment)
            //{
            //    CurveLoop curveloopListSemgent = new CurveLoop();
            //    foreach(BoundarySegment segment in listSegment)
            //    {
            //        Element hostOfSegment = doc.GetElement(segment.ElementId);
            //        listHostELement.Add(hostOfSegment);
            //        Curve curveOfSegment = segment.GetCurve();
            //        curveloopListSemgent.Append(curveOfSegment);
            //    }
            //    listCurveloop.Add(curveloopListSemgent);
            //}

            //FloorType typeFloor = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Floors)
            //    .WhereElementIsElementType().OfClass(typeof(FloorType)).Cast<FloorType>().First();

            //Level activeLevel = doc.ActiveView.GenLevel;

            //using(Transaction t= new Transaction(doc, "CreateFloor"))
            //{
            //    t.Start();
            //    Floor.Create(doc, listCurveloop, typeFloor.Id, activeLevel.Id);
            //    t.Commit();
            //}

            Toposolid topoSolid = null;
            try
            {
                var refRoom = uiDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, "Pick room");
                topoSolid = doc.GetElement(refRoom) as Toposolid;
            }
            catch { }

            SlabShapeEditor slabShapeEditor = topoSolid.GetSlabShapeEditor();
            SlabShapeVertexArray vertexArray = slabShapeEditor.SlabShapeVertices;

            List<(int indexVertext,SlabShapeVertex)> listVextexInterior = new List<(int,SlabShapeVertex)>();
            int index = 0;
            foreach(SlabShapeVertex vertex in vertexArray)
            {
                if(vertex.VertexType== SlabShapeVertexType.Interior)
                {
                    listVextexInterior.Add((index,vertex));
                }
                index++;
            }

            using (Transaction t = new Transaction(doc, "ModifyTopo"))
            {
                t.Start();
                slabShapeEditor.Enable();
                foreach(var vertexItemPair in listVextexInterior)
                {
                    XYZ position = vertexItemPair.Item2.Position;

                    //slabShapeEditor.SlabShapeVertices.set_Item(vertexItemPair.indexVertext,)
                    slabShapeEditor.ModifySubElement(vertexItemPair.Item2,vertexItemPair.Item2.Position.Z + 4000 / 304.8);
                    //slabShapeEditor.SlabShapeVertices.set_Item()
                    slabShapeEditor.AddPoint(position.Add(new XYZ(1000 / 304.8, 0, 4000 / 304.8)));
                    //slabShapeEditor.AddSplitLine()
                    

                }
                

                t.Commit();
            }





            return Result.Succeeded;
        }
    }
}