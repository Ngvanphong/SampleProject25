using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TemplateRevit2025.Core;
using TemplateRevit2025.Interfaces;
using TemplateRevit2025.View.PutFamilyByLine;
using TemplateRevit2025.ViewModel.PutFamilyByLine;

namespace TemplateRevit2025.RevitHandler.PutFamilyByLine
{
    public class PutFamilybyLineHandler : ExternalEventHandler
    {
        public Main mainForm;
        public PutFamilybyLineHandler(Window mainForm, System.Windows.Controls.UserControl sourceControl, 
            System.Windows.Controls.UserControl targetControl, string nameHandler) 
            : base(mainForm, sourceControl, targetControl, nameHandler)
        {
        }

        public override void Execute(UIApplication app)
        {
            UIDocument uiDoc = app.ActiveUIDocument;
            Document doc= uiDoc.Document;
            IEnumerable<ElementId> ids = uiDoc.Selection.GetElementIds();
            List<ModelCurve> listCurve= new List<ModelCurve>();
            foreach (ElementId id in ids)
            {
                ModelCurve modelCurve = doc.GetElement(id) as ModelCurve;
                if(modelCurve != null)
                {
                    listCurve.Add(modelCurve);
                }
            }

            double divide = 3000;
            divide = UnitUtils.ConvertToInternalUnits(divide, UnitTypeId.Millimeters);

            var service = Host.GetService<IPutFamilyByLineService>();
            List<PointDirection> listPointDirection =service.GetPointDirectionByLine(doc,listCurve,divide);

            Bottom bottomView= mainForm.ContentBottom.Content as Bottom;
            var typeVm = bottomView.ComboboxTypeFamily.SelectedItem as TypeVM;
            FamilySymbol faSy= doc.GetElement(typeVm.Id) as FamilySymbol;


            using (Transaction t=  new Transaction(doc, "PutFamily"))
            {
                t.Start();
                if (!faSy.IsActive) faSy.Activate();
                foreach(PointDirection pointDir in listPointDirection)
                {
                   FamilyInstance familyInstance= doc.Create.NewFamilyInstance(pointDir.Point, faSy, 
                        Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
                    service.RotaionElementToVector(doc, familyInstance,pointDir);
                }
                
                t.Commit();
            }

            return;


        }
    }
}
