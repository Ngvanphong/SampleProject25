using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateRevit2025.Commands;
using TemplateRevit2025.Utilities;

namespace TemplateRevit2025.Buttons
{
    public class TestButton
    {
        private const string PanelName = "Revit 25";
        public  void Create(UIControlledApplication application)
        {
            RibbonPanel addinPanel = application.CreateRibbonPanel(PanelName);
            var pushButton = addinPanel.AddPushButton(typeof(TestCommand),"RevitButton");
            pushButton.SetImage("/TemplateRevit2025;component/Resources/Images/icons8-crop-24 (3).png");
            pushButton.SetLargeImage("/TemplateRevit2025;component/Resources/Images/icons8-crop-24 (3).png");
        }
    }
}
