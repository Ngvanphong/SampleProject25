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
