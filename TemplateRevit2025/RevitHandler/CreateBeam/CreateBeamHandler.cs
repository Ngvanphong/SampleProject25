using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TemplateRevit2025.Core;
using TemplateRevit2025.View.CreateBeam;

namespace TemplateRevit2025.RevitHandler.CreateBeam
{
    public class CreateBeamHandler : ExternalEventHandler
    {
        public CreateBeamHandler(Window form, string nameHandler) : base(form, nameHandler)
        {
        }
        public override void Execute(UIApplication app)
        {
            var form = base._form as frmCreateBeamMain;
            var selectedCombobox = form.comboboxFamily.SelectedItem as Family;
            return;
        }


    }
}
