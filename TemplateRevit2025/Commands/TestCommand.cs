using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Windows;
using System.Security.Cryptography;
using TemplateRevit2025.Interfaces;
using TemplateRevit2025.Model.Test;
using TemplateRevit2025.RevitHandler.Test;
using TemplateRevit2025.Utilities;
using TemplateRevit2025.View.Test;
using TemplateRevit2025.ViewModel.Test;

namespace TemplateRevit2025.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class TestCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc= uiDoc.Document;

            IEnumerable<ElementId> ids = uiDoc.Selection.GetElementIds();
            List<Wall> listWall = new List<Wall>();
            
            foreach(ElementId id in ids)
            {
                Wall item = doc.GetElement(id) as Wall;
                if (item != null)
                {
                    Location locationWall = item.Location;
                    if(locationWall!=null && locationWall is LocationCurve)
                    {
                        LocationCurve locationCurve = locationWall as LocationCurve;
                        if(locationCurve!=null && locationCurve.Curve is Line)
                        {
                            listWall.Add(item);
                        }
                    }
                    
                }
            }

            Options options = new Options();
            options.IncludeNonVisibleObjects = false;
            options.DetailLevel = ViewDetailLevel.Fine;
            options.ComputeReferences = true;
            foreach (Wall wall in listWall)
            {
                List<PlanarFace> listPlanarFace = new List<PlanarFace>();
                GeometryElement geoElemnt = wall.get_Geometry(options);
                XYZ wallOrientation = wall.Orientation.Normalize();
                foreach (GeometryObject geoObj in geoElemnt)
                {
                    Solid solid = geoObj as Solid;
                    if (solid != null && solid.Volume > 0.000001)
                    {
                        foreach (Face face in solid.Faces)
                        {
                            if (face is PlanarFace plannarFace)
                            {
                                XYZ noramlPlan = plannarFace.FaceNormal.Normalize();
                                double dotProduct1 = wallOrientation.DotProduct(noramlPlan);
                                if (Math.Abs(dotProduct1) < 0.00001)
                                {
                                    double dotProduct2 = noramlPlan.DotProduct(XYZ.BasisZ);
                                    if (Math.Abs(dotProduct2) < 0.00001)
                                    {
                                        listPlanarFace.Add(plannarFace);
                                    }
                                }
                            }
                        }
                    }
                }

                ReferenceArray dimRef = new ReferenceArray();
                foreach (PlanarFace planar in listPlanarFace) dimRef.Append(planar.Reference);


                LocationCurve locaitonCurve = wall.Location as LocationCurve;

                Curve curve = locaitonCurve.Curve;
                Line lineWall = curve as Line;
                XYZ direcitonWall = lineWall.Direction.Normalize();

                XYZ firstPoint = curve.GetEndPoint(0);
                XYZ vectorMove = wallOrientation * 1000 / 304.8;
                XYZ movePoint = firstPoint + vectorMove;
                Line linePutDim = Line.CreateUnbound(movePoint, direcitonWall);

                using (Transaction t = new Transaction(doc, "CreateDim"))
                {
                    t.Start();
                    doc.Create.NewDimension(doc.ActiveView, linePutDim, dimRef);
                    t.Commit();
                }


                //FamilyInstance door = null;
                //Reference doorRef = door.GetReferenceByName("ffff");
                //List<Reference> refDoor2 = door.GetReferences(FamilyInstanceReferenceType.CenterLeftRight).ToList();
            }

            return Result.Succeeded;
        }
    }

    class FurnitureFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if(elem.Category !=null && elem.Category.Id.Value == (long)BuiltInCategory.OST_Furniture)
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
