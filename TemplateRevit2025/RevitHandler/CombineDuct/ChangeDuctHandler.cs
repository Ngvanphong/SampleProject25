using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateRevit2025.RevitHandler.CombineDuct
{
    public class ChangeDuctHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            UIDocument uiDoc = app.ActiveUIDocument;
            Document doc= uiDoc.Document;
            if (ChangeDuctAppShow.IndexButton == 0)
            {

            }
            else if (ChangeDuctAppShow.IndexButton == 1)
            {

            }
        }

        public string GetName()
        {
            return "ChangeDuctHeightEvent";
        }
    }
}
