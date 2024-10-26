using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Numerics;
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

            //Document doc = commandData.Application.ActiveUIDocument.Document;

            ////var listFamily = Host.GetService<ITestService>().GetFamilies(doc);

            ////List<InstanceCus> listWall = new Autodesk.Revit.DB.FilteredElementCollector(doc)
            ////    .OfCategory(BuiltInCategory.OST_Walls)
            ////    .WhereElementIsNotElementType().OfClass(typeof(Wall)).Cast<Wall>()
            ////    .Select(x => new InstanceCus {Id = x.Id, Name = x.Name}).ToList();

            ////List<InstanceCus> listDoor = new Autodesk.Revit.DB.FilteredElementCollector(doc)
            ////    .OfCategory(BuiltInCategory.OST_Doors)
            ////    .WhereElementIsNotElementType().OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>()
            ////    .Select(x => new InstanceCus {Id = x.Id, Name = x.Name}).ToList();



            ////Main frmMain = new Main();
            ////TopVM topVM = new TopVM();
            ////topVM.ListWall = listWall;
            ////topVM.ListDoor = listDoor;
            ////(frmMain.ContentTopView.Content as Top).DataContext = topVM;

            ////ColumnSelectHandler columnGetHandler = new ColumnSelectHandler(null,
            ////    frmMain.ContentTopView.Content as System.Windows.Controls.UserControl, 
            ////    frmMain.ContentBottomView.Content as System.Windows.Controls.UserControl,
            ////    "SelectColumnHandler");
            ////ExternalEvent columnEvent = ExternalEvent.Create(columnGetHandler);
            ////Top topView = frmMain.ContentTopView.Content as Top;
            ////topView.ColumnSelectEvent = columnEvent;

            ////FinishHandler finishHandler = new FinishHandler(frmMain,null, null, "FinishTestHandler");
            ////ExternalEvent finishEvent = ExternalEvent.Create(finishHandler);
            ////frmMain.FinishEvent = finishEvent;

            ////frmMain.Show();


            //XYZ point =  new XYZ(10,10,10);
            //XYZ vector = new XYZ(4,1,0).Normalize();

            //XYZ p2 = point + vector;


            //double extend = 100;

            //// move a point follow a vector by distance
            //XYZ p3 = point + vector * extend;

            //XYZ vector1 = new XYZ(2, 0,0);
            //XYZ vector2 = new XYZ(4, 1, 0);

            //double dotProduct= vector1.Normalize().DotProduct(vector2.Normalize());

            //XYZ crossVector = vector2.CrossProduct(vector2);

            //Line line1= Line.CreateBound(new XYZ(1,1,0), new XYZ(2,2,0));

            //Transform transform1 = Transform.CreateTranslation(new XYZ(10, 0, 0));

            //Line lineNew= line1.CreateTransformed(transform1) as Line;

            //XYZ center = lineNew.GetEndPoint(0).Add(lineNew.GetEndPoint(1)).Divide(2);

            //Transform transfor2 = Transform.CreateRotationAtPoint(XYZ.BasisZ, Math.PI / 2,center);

            //Line lineResult= lineNew.CreateTransformed(transfor2) as Line;

            ////Line line2 = Line.CreateUnbound(new XYZ(1, 3, 0), XYZ.BasisX);

            //Line lineOrigin= Line.CreateBound(new XYZ(1, 1, 0), new XYZ(2, 2, 0));

            //XYZ vectorMove = new XYZ(0, 0, 0) - center;
            //Transform tranform3 = Transform.CreateTranslation(vectorMove);
            //Line lineAtZero= lineOrigin.CreateTransformed(tranform3) as Line;

            //XYZ vectorTotal = -vectorMove + new XYZ(10, 0, 0);

            //Transform rotationTransform = Transform.CreateRotation(XYZ.BasisZ, Math.PI / 4);
            //XYZ vectoX= rotationTransform.OfVector(XYZ.BasisX);
            //XYZ vectorY = rotationTransform.OfVector(XYZ.BasisY);
            //XYZ vecctorZ = rotationTransform.OfVector(XYZ.BasisZ);

            //Transform transformNew = Transform.Identity;
            //transformNew.BasisX = vectoX;
            //transformNew.BasisY = vectorY;
            //transformNew.BasisZ = vecctorZ;
            //transformNew.Origin = vectorTotal;

            //Line line33 = lineAtZero.CreateTransformed(transformNew) as Line;

            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;

            Element familyInstance = null;
            try
            {
                Reference refElement = uiDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, "Pick a table");
                familyInstance = doc.GetElement(refElement);

            }
            catch { }

            Options geoOption = new Options();
            geoOption.IncludeNonVisibleObjects = false; //chi lay nhung hinh hoc dang hien thi
            geoOption.DetailLevel = ViewDetailLevel.Fine;
            geoOption.ComputeReferences = true; // tham chieu doi tuong
            //geoOption.View = doc.ActiveView;

            #region
            //geoOption.View = doc.ActiveView;

            //GeometryElement geometryElement = familyInstance.get_Geometry(geoOption);

            //List<Solid> listSolid = new List<Solid>();
            //foreach(GeometryObject geoObj in geometryElement)
            //{
            //    Solid solid = geoObj as Solid;
            //    if (solid != null && solid.Volume > 0.00001)
            //    {
            //        listSolid.Add(solid);
            //    }
            //    else
            //    {
            //        GeometryInstance geoInst = geoObj as GeometryInstance;
            //        if (geoInst != null)
            //        {
            //            GeometryElement geoElemeetOfInstance = geoInst.GetInstanceGeometry();
            //            foreach(GeometryObject geoObj2 in geoElemeetOfInstance)
            //            {
            //                if(geoObj2 is Solid solid2  && solid2.Volume> 0.00001)
            //                {
            //                    listSolid.Add(solid2);
            //                }
            //            }
            //        }
            //    }
            //}
            #endregion
            List<Solid> listSolid = new List<Solid>();
            GeometryHelper.GetGeometryAll(familyInstance, geoOption, ref listSolid);

            PlanarFace topPlannarFace = null;
            Solid solidTopFace = null;
            double zMax = -11000000000;
            foreach (Solid solid in listSolid)
            {
                foreach (Face face in solid.Faces)
                {
                    if (face is PlanarFace plannarFace)
                    {
                        if (plannarFace.FaceNormal.Normalize().IsAlmostEqualTo(XYZ.BasisZ, 0.00001))
                        {
                            double zMaxFace = -11111;
                            foreach (CurveLoop curveLoop in face.GetEdgesAsCurveLoops())
                            {
                                foreach (Curve curve in curveLoop)
                                {
                                    double z1 = curve.GetEndPoint(0).Z;
                                    double z2 = curve.GetEndPoint(1).Z;
                                    double zMaxItem = Math.Max(z1, z2);
                                    zMaxFace = Math.Max(zMaxItem, zMaxFace);
                                }
                            }
                            if (zMaxFace > zMax)
                            {
                                zMax = zMaxFace;
                                topPlannarFace = plannarFace;
                                solidTopFace = solid;
                            }
                        }
                    }
                }
            }

            double aRea = UnitUtils.ConvertFromInternalUnits(topPlannarFace.Area, UnitTypeId.SquareMeters);

            List<PlanarFace> listPlanner = new List<PlanarFace>();
            foreach(Face face in solidTopFace.Faces)
            {
                PlanarFace plannerFace = face as PlanarFace;
                if (plannerFace == null) continue;
                double dotProdcut = plannerFace.FaceNormal.Normalize().DotProduct(XYZ.BasisZ);
                if(Math.Abs(dotProdcut)< 0.00001)
                {
                    listPlanner.Add(plannerFace);
                }
            }

            ReferenceArray referenceArray1 = new ReferenceArray();
            ReferenceArray referenceArray2 = new ReferenceArray();

            XYZ directionPlaner1 = listPlanner.First().FaceNormal.Normalize();
            foreach(PlanarFace p in listPlanner)
            {
                if (directionPlaner1.IsAlmostEqualTo(p.FaceNormal.Normalize(), 0.0001)|| directionPlaner1.IsAlmostEqualTo(-p.FaceNormal.Normalize(), 0.0001))
                {
                    referenceArray1.Append(p.Reference);
                }
                else
                {
                    referenceArray2.Append(p.Reference);
                }
            }

           
            

            using(Transaction t= new Transaction(doc, "CreateDim"))
            {
                t.Start();
                Line line1 = Line.CreateUnbound(new XYZ(-87.264242562, -10.517173744, 0.000000000), directionPlaner1);
                Dimension dim1 = doc.Create.NewDimension(doc.ActiveView, line1, referenceArray1);
                //Dimension dim2 = doc.Create.NewDimension(doc.ActiveView, , referenceArray2);
                t.Commit();
            }


            Curve curve2 = null;
            Curve curve1 = null;

            SetComparisonResult compareResult=  curve1.Intersect(curve2, out IntersectionResultArray resultArray);

            if (resultArray != null)
            {
                int count = resultArray.Size;
                var inumertator = resultArray.GetEnumerator(); 
                while (inumertator.MoveNext())
                {
                    XYZ point = ((inumertator.Current) as IntersectionResult).XYZPoint;
                }
                for (int i = 0; i < count; i++)
                {
                    XYZ pont = resultArray.get_Item(i).XYZPoint;
                }
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
