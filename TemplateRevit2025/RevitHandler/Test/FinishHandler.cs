
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TemplateRevit2025.Core;
using TemplateRevit2025.Model.Test;
using TemplateRevit2025.View.Test;

namespace TemplateRevit2025.RevitHandler.Test
{
    public class FinishHandler : ExternalEventHandler
    {
        public FinishHandler(Window window, System.Windows.Controls.UserControl userControl, string nameHandler)
            : base(window, userControl, nameHandler)
        {
        }

        public override void Execute(UIApplication app)
        {
            Main frmMain = WindowForm as Main;
            Top topContentView = frmMain.ContentTopView.Content as Top;
            InstanceCus wallSelected = topContentView.ComboboxWall.SelectedItem as InstanceCus;
            return;

        }
    }
}
