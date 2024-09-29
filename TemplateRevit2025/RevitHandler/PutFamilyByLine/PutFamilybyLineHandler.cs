using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TemplateRevit2025.Core;

namespace TemplateRevit2025.RevitHandler.PutFamilyByLine
{
    public class PutFamilybyLineHandler : ExternalEventHandler
    {
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


        }
    }
}
