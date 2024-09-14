using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TemplateRevit2025.Core;
using TemplateRevit2025.View.PutFamilyByLine;
using MediatR;
using TemplateRevit2025.Mediator.PutFamilyByLine;
using TemplateRevit2025.ViewModel.PutFamilyByLine;
using Autodesk.Revit.DB;

namespace TemplateRevit2025.RevitHandler.PutFamilyByLine
{
    public class TypeFamilyHandler : ExternalEventHandler
    {

        public TypeFamilyHandler(Window mainForm, System.Windows.Controls.UserControl sourceControl,
            System.Windows.Controls.UserControl targetControl, string nameHandler) 
            : base(mainForm, sourceControl, targetControl, nameHandler)
        {
        }

        public override void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            var dataSelected = (SourcControl as Top).ComboboxFamily.SelectedItem as FamilyVM;
            Family family = doc.GetElement(dataSelected.Id) as Family;

            List<TypeVM> listTypeVM = family.GetFamilySymbolIds().Select(id =>
            {
                FamilySymbol sy = doc.GetElement(id) as FamilySymbol;
                return new TypeVM { Id = sy.Id, TypeName = sy.Name };

            }).ToList();
            BottomVM bottomVm= new BottomVM();
            bottomVm.ListTypeVM= listTypeVM;
            (TargetControl as Bottom).DataContext = bottomVm;

            return;
        }

       
    }
}
