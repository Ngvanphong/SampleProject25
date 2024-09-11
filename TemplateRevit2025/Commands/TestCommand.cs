﻿using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using TemplateRevit2025.Interfaces;
using TemplateRevit2025.Model.Test;
using TemplateRevit2025.RevitHandler.Test;
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

            var listFamily = Host.GetService<ITestService>().GetFamilies(doc);

            List<InstanceCus> listWall = new Autodesk.Revit.DB.FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Walls)
                .WhereElementIsNotElementType().OfClass(typeof(Wall)).Cast<Wall>()
                .Select(x => new InstanceCus {Id = x.Id, Name = x.Name}).ToList();
            
            List<InstanceCus> listDoor = new Autodesk.Revit.DB.FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Doors)
                .WhereElementIsNotElementType().OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>()
                .Select(x => new InstanceCus {Id = x.Id, Name = x.Name}).ToList();
            
            

            MainVM mainVm = new MainVM();

            TopVM topVm = new TopVM();
            topVm.ListWall = listWall;
            topVm.ListDoor = listDoor;
            mainVm.TopVM = topVm;
            Main frmMain = new Main();
            frmMain.DataContext = mainVm;

            ColumnSelectHandler columnGetHandler = new ColumnSelectHandler(frmMain,
                frmMain.ContentTopView.Content as System.Windows.Controls.UserControl, "SelectColumnHandler");
            ExternalEvent columnEvent = ExternalEvent.Create(columnGetHandler);
            Top topView = frmMain.ContentTopView.Content as Top;
            topView.ColumnSelectEvent = columnEvent;

            FinishHandler finishHandler = new FinishHandler(frmMain, null, "FinishTestHandler");
            ExternalEvent finishEvent = ExternalEvent.Create(finishHandler);
            frmMain.FinishEvent = finishEvent;

            frmMain.Show();
            
            return Result.Succeeded;
        }
    }
}
