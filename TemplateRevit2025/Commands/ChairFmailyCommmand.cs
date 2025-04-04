using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xaml;
using TemplateRevit2025.RevitHandler.ChairFamily;
using TemplateRevit2025.View.ChairFamily;
using TemplateRevit2025.ViewModel.ChairFamily;

namespace TemplateRevit2025.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class ChairFmailyCommmand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;

            var listFamily = new FilteredElementCollector(doc).OfClass(typeof(Family)).
                Cast<Family>().Where(x => x.FamilyCategoryId.Value == (long)BuiltInCategory.OST_Furniture)
                .ToList();

            ChairFamilyVM chairFamilyVM = new ChairFamilyVM();
            chairFamilyVM.Families = listFamily.Select(x => new FamillyVm { Id = x.Id, NameChair = x.Name })
                .ToList();

            //var form = new ChairFamilyView();

            //form.DataContext = chairFamilyVM;

            //GetTypeHandler getTypeHandler = new GetTypeHandler();
            //ExternalEvent getTypeEvent = ExternalEvent.Create(getTypeHandler);

            //form._familySendEvent.FamilyComboboxChangeEvent += getTypeHandler.SetDataFromEvent;
            //form.GetTypeEvent = getTypeEvent;

            //getTypeHandler.SendEventToForm.FamilyComboboxChangeEvent += form.SetListTypeVm;

            //form.Show();

            return Result.Succeeded;
        }
    }
}
