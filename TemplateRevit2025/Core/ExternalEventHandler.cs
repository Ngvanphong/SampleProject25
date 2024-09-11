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
        public Window WindowForm { get;private set; }
        public System.Windows.Controls.UserControl UserControlForm { get; private set; }

        private string _nameHandler;


        public ExternalEventHandler(Window window, System.Windows.Controls.UserControl userControl,string nameHandler)
        {
            WindowForm = window;
            UserControlForm = userControl;
            _nameHandler = nameHandler;

        }
        
        public abstract void Execute(UIApplication app);
        public virtual string GetName()
        {
            return _nameHandler;
        }
    }
}
