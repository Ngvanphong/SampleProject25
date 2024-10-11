using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateRevit2025.Model.Test;
using TemplateRevit2025.NetEvent.ChairFamily;
using TemplateRevit2025.ViewModel.ChairFamily;

namespace TemplateRevit2025.RevitHandler.ChairFamily
{
    public class GetTypeHandler : IExternalEventHandler
    {
        public FamilyDataEvent SendEventToForm { set; get; }

        public GetTypeHandler()
        {
            SendEventToForm = new FamilyDataEvent();
        }


        private FamillyVm SelecteFamilyVm;

        public void SetDataFromEvent(object sender, FamilyVmEventArgs sendData)
        {
            SelecteFamilyVm = sendData.DataSend;
        }

        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;


            IEnumerable<ElementId> ids = (doc.GetElement(SelecteFamilyVm.Id) as Family).GetFamilySymbolIds();

            List<TypeVm> listTypeVm = new List<TypeVm>();
            foreach(ElementId id in ids)
            {
                FamilySymbol sy = doc.GetElement(id) as FamilySymbol;
                listTypeVm.Add(new TypeVm { Id = sy.Id, TypeName = sy.Name });
            }


           
            FamilyVmEventArgs args= new FamilyVmEventArgs();
            args.ListTypeVm = listTypeVm;
            SendEventToForm.Raise(args);
            

            // send data to form;


           
        }

       

        public string GetName()
        {
            return "GetTypeHandler1";
        }
    }
}
