using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TemplateRevit2025.Core;
using TemplateRevit2025.View.PutFamilyByLine;
using TemplateRevit2025.ViewModel.PutFamilyByLine;

namespace TemplateRevit2025.RevitHandler.PutFamilyByLine
{
    public class SelectTypeHandler : ExternalEventHandler
    {
        public SelectTypeHandler(Window mainForm, System.Windows.Controls.UserControl sourceControl,
            System.Windows.Controls.UserControl targetControl, string nameHandler) 
            : base(mainForm, sourceControl, targetControl, nameHandler)
        {
        }

        public override void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            Top topView = SourceControl as Top;
            FamilyVM familyVmChoose= topView.ComboboxFamily.SelectedItem as FamilyVM;

            Family familyChoose = doc.GetElement(familyVmChoose.Id) as Family;
            var typeIds = familyChoose.GetFamilySymbolIds();
            List<FamilySymbol> listFamilySymbol= new List<FamilySymbol>();
            foreach(ElementId id in typeIds)
            {
                FamilySymbol faSy= doc.GetElement(id) as FamilySymbol;
                listFamilySymbol.Add(faSy);
            }

            List<TypeVM> listTypes = listFamilySymbol
                .Select(item=>new TypeVM { Id= item.Id,TypeName=item.Name }).ToList();
            Bottom bottomView= TargetControl as Bottom;
            BottomVM bottomVm = new BottomVM();
            bottomVm.ListTypeVM = listTypes;
            bottomView.DataContext = bottomVm;


        }
    }
}
