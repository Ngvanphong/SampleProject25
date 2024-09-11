using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using TemplateRevit2025.Model.Test;
using TemplateRevit2025.View.Test;
using TemplateRevit2025.ViewModel.Test;

namespace TemplateRevit2025.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class TestCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            
            List<InstanceCus> listWall = new Autodesk.Revit.DB.FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Walls)
                .WhereElementIsNotElementType().OfClass(typeof(Wall)).Cast<Wall>()
                .Select(x => new InstanceCus {Id = x.Id, Name = x.Name}).ToList();
            
            List<InstanceCus> listDoor = new Autodesk.Revit.DB.FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Doors)
                .WhereElementIsNotElementType().OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>()
                .Select(x => new InstanceCus {Id = x.Id, Name = x.Name}).ToList();
            
            List<InstanceCus> listColumn = new Autodesk.Revit.DB.FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_StructuralColumns)
                .WhereElementIsNotElementType().OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>()
                .Select(x => new InstanceCus {Id = x.Id, Name = x.Name}).ToList();
            
            List<InstanceCus> listBeam = new Autodesk.Revit.DB.FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_StructuralFraming)
                .WhereElementIsNotElementType().OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>()
                .Select(x => new InstanceCus {Id = x.Id, Name = x.Name}).ToList();

            MainVM mainVm = new MainVM();

            TopVM topVm = new TopVM();
            topVm.ListWall = listWall;
            topVm.ListDoor = listDoor;

            BottomVM bottomVm = new BottomVM();
            bottomVm.ListColumn = listColumn;
            bottomVm.ListBeam = listBeam;

            mainVm.TopVM = topVm;
            mainVm.BottomVM = bottomVm;

            Main frmMain = new Main();
            frmMain.DataContext = mainVm;
            frmMain.Show();
            
            return Result.Succeeded;
        }
    }
}
