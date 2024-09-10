﻿using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TemplateRevit2025.Core;
using TemplateRevit2025.Interfaces;
using TemplateRevit2025.RevitHandler.CreateBeam;
using TemplateRevit2025.View.CreateBeam;
using TemplateRevit2025.ViewModel.CreateBeam;

namespace TemplateRevit2025.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class CreateColumnBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //var listFamily= Host.GetService<ICreateColumnService>().GetFamilies(commandData.Application.ActiveUIDocument.Document);
            Document doc = commandData.Application.ActiveUIDocument.Document;
            var listFamily= new FilteredElementCollector(doc).OfClass(typeof(Family)).Cast<Family>();
            var form = new frmCreateBeamMain();
            CreateBeamHandler createBeamHandler = new CreateBeamHandler(form, "CreateBeamHandler2");
            ExternalEvent createBeamEvent= ExternalEvent.Create(createBeamHandler);
            form._createBeamEvent = createBeamEvent;
            
            List<SubLeftVM> listSubLeft = new List<SubLeftVM>();
            listFamily.ToList().ForEach(x => listSubLeft.Add(new SubLeftVM { Id = x.Id, Name = x.Name }));
            form.subLeft.DataContext = listSubLeft;

            

            form.Show();





            return Result.Succeeded;
        }
    }
}
