using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
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

           

            List<Pipe> listAllPipe = new List<Pipe> ();
            var ids = uiDoc.Selection.GetElementIds();
            foreach(ElementId id in ids)
            {
                Pipe pipe = doc.GetElement(id) as Pipe;
                if (pipe != null)
                {
                    listAllPipe.Add(pipe);
                }
            }


            Options geoOption = new Options();

            geoOption.IncludeNonVisibleObjects = false;
            geoOption.ComputeReferences = true;
            geoOption.DetailLevel = ViewDetailLevel.Fine;

            //geoOption.View = doc.ActiveView;

            List<Solid> listSolidOfPipe= new List<Solid>();
            foreach(Pipe pipe in listAllPipe)
            {
                GeometryElement geoElment = pipe.get_Geometry(geoOption);
                foreach(GeometryObject geoObj in geoElment)
                {
                    Solid solid= geoObj as Solid;
                    if(solid != null)
                    {
                        listSolidOfPipe.Add(solid);
                    }
                }
            }

            List<PlanarFace> listPlannarFace = new List<PlanarFace>();
            foreach (Solid solid in listSolidOfPipe)
            {
                foreach(Face face in solid.Faces)
                {
                    PlanarFace plannarFace = face as PlanarFace;
                    if (plannarFace!= null)
                    {
                        listPlannarFace.Add(plannarFace);
                    }
                }
            }

            ReferenceArray dimReferreceArray= new ReferenceArray();
            foreach(PlanarFace planarFace in listPlannarFace)
            {
                Reference referrence = planarFace.Reference;
                dimReferreceArray.Append(referrence);
            }

            XYZ point = uiDoc.Selection.PickPoint("Pick a point");

            XYZ directionRef = listPlannarFace.First().FaceNormal;
            Line lineDim = Line.CreateUnbound(point, directionRef);

            using(Transaction t= new Transaction(doc, "CreateDimPipe"))
            {
                t.Start();
                doc.Create.NewDimension(doc.ActiveView, lineDim, dimReferreceArray);
                t.Commit();
            }
            


            ////GeometryElement geoElement = pipe.get_Geometry(geoOption);
            ////List<Solid> listSolid = new List<Solid>();
            ////List<Curve> listCurve = new List<Curve>();
            ////foreach(GeometryObject geoObj in geoElement)
            ////{
            ////    Solid solid = geoObj as Solid;
            ////    if (solid != null)
            ////    {
            ////        listSolid.Add(solid);
            ////    }
            ////    else
            ////    {
            ////        Curve curve = geoObj as Curve;
            ////        if (curve != null)
            ////        {
            ////            listCurve.Add(curve);
            ////        }
            ////    }
            ////}

            ////List<PlanarFace> listPlannarFace = new List<PlanarFace>();
            ////List<Face> listNotPlannarFace = new List<Face>();
            ////foreach(Solid solid in listSolid)
            ////{
            ////    foreach (Face face in solid.Faces)
            ////    {
            ////        PlanarFace plannerFa = face as PlanarFace;
            ////        if (plannerFa != null)
            ////        {
            ////            listPlannarFace.Add(plannerFa);
            ////        }
            ////        else
            ////        {
            ////            listNotPlannarFace.Add(face);
            ////        }
            ////    }
            ////}

            ////double areaFace = listNotPlannarFace.First().Area;
            ////double areaFaceCitimet = UnitUtils.ConvertFromInternalUnits(areaFace, UnitTypeId.SquareMeters);

            ////List<CurveLoop> listCurveLoopFace = new List<CurveLoop>();
            ////foreach(PlanarFace plannar in listPlannarFace)
            ////{
            ////    List<CurveLoop> listCurveloopItem = plannar.GetEdgesAsCurveLoops().ToList();
            ////    //foreach(CurveLoop cuveLo in listCurveloopItem)
            ////    //{
            ////    //    listCurveLoopFace.Add(cuveLo);
            ////    //}
            ////    listCurveLoopFace.AddRange(listCurveloopItem);
            ////}
            ////List<Curve> listAllCurve = new List<Curve>();
            ////foreach(CurveLoop curveloop in listCurveLoopFace)
            ////{
            ////    foreach(Curve curve in curveloop)
            ////    {
            ////        listAllCurve.Add(curve);
            ////    }
            ////}


            //GeometryElement geoElement = pipe.get_Geometry(geoOption);

            //List<Solid> listSolid = new List<Solid>();
            //foreach(GeometryObject geoObj in geoElement)
            //{
            //    Solid solid = geoObj as Solid;
            //    if (solid != null)
            //    {
            //        listSolid.Add(solid);
            //    }
            //    else
            //    {
            //        GeometryInstance geoInst = geoObj as GeometryInstance;
            //        if (geoInst != null)
            //        {
            //            GeometryElement geoElentOfFamily = geoInst.GetInstanceGeometry();
            //            foreach(GeometryObject geObjOfFa in geoElentOfFamily)
            //            {
            //                Solid solidOfFa = geObjOfFa as Solid;
            //                if (solidOfFa != null && solidOfFa.Volume > 0.00001)
            //                {
            //                    listSolid.Add(solidOfFa);
            //                }
            //            }
            //        }
            //    }
            //}


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
