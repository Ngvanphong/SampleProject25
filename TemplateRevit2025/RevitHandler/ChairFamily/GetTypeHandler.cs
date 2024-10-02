using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateRevit2025.View.ChairFamily;
using TemplateRevit2025.ViewModel.ChairFamily;

namespace TemplateRevit2025.RevitHandler.ChairFamily
{
    public class GetTypeHandler : IExternalEventHandler
    {
        public FamillyVm SelectedFamily;

        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            
            Family family = doc.GetElement(SelectedFamily.Id) as Family;
            List<TypeVm> listType = new List<TypeVm>();
            foreach(ElementId id in family.GetFamilySymbolIds())
            {
                TypeVm typeVm = new TypeVm { Id = id, TypeName = doc.GetElement(id).Name };
                listType.Add(typeVm);
            }

            


            return;
        }

        public string GetName()
        {
            return "GetTypeHandler1";
        }
    }
}
