using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateRevit2025.View.ChairFamily;

namespace TemplateRevit2025.RevitHandler.CombineDuct
{
    public static class ChangeDuctAppShow
    {
        public static ChairFamilyView formDuctChange;
        public static int IndexButton = -1;

        public static List<Duct> SubDuct = null;
        public static Duct MainDuct = null;
        public static void ShowForm()
        {
            try
            {
                formDuctChange.Close();
            }
            catch { }
            ChangeDuctHandler changeDuctHandler = new ChangeDuctHandler();
            ExternalEvent changeDuctEvent= ExternalEvent.Create(changeDuctHandler);
            formDuctChange = new ChairFamilyView(changeDuctEvent);
            formDuctChange.Show();

        }
    }
}
