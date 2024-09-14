﻿using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TemplateRevit2025.Core;
using TemplateRevit2025.Model.Test;
using TemplateRevit2025.View.Test;
using TemplateRevit2025.ViewModel.Test;

namespace TemplateRevit2025.RevitHandler.Test
{
    public class ColumnSelectHandler : ExternalEventHandler
    {
        public ColumnSelectHandler(Window mainForm, System.Windows.Controls.UserControl sourceControl,
            System.Windows.Controls.UserControl targetControl, string nameHandler) : 
            base(mainForm, sourceControl, targetControl, nameHandler)
        {
        }

        public override void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            List<InstanceCus> listColumn = new Autodesk.Revit.DB.FilteredElementCollector(doc)
           .OfCategory(BuiltInCategory.OST_Columns)
           .WhereElementIsNotElementType().OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>()
           .Select(x => new InstanceCus { Id = x.Id, Name = x.Name }).ToList();

            List<InstanceCus> listBeam = new Autodesk.Revit.DB.FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Columns)
                .WhereElementIsNotElementType().OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>()
                .Select(x => new InstanceCus { Id = x.Id, Name = x.Name }).ToList();

            BottomVM bottomVm= new BottomVM();
            bottomVm.ListColumn= listColumn;
            bottomVm.ListBeam= listBeam;
            Bottom bottomView = TargetControl as Bottom;
            bottomView.DataContext= bottomVm;
            
        }
    }
}
