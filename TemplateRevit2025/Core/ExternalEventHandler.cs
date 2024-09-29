using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TemplateRevit2025.Core
{
    public abstract class ExternalEventHandler : IExternalEventHandler
    {
        public Window MainForm { get;private set; }
        public System.Windows.Controls.UserControl SourceControl { get; private set; }
        public System.Windows.Controls.UserControl TargetControl { get; private set; }

        private string _nameHandler;

        public ExternalEventHandler(Window mainForm, 
            System.Windows.Controls.UserControl sourceControl,
            System.Windows.Controls.UserControl targetControl,
            string nameHandler)
        {
            MainForm = mainForm;
            SourceControl = sourceControl;
            TargetControl = targetControl;
            _nameHandler = nameHandler;

        }
        
        public abstract void Execute(UIApplication app);
        public virtual string GetName()
        {
            return _nameHandler;
        }
    }
}
