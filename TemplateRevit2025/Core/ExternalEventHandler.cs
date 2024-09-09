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
        private string _nameHandler;
        public ExternalEventHandler(Window window,string nameHandler)
        {
            WindowForm = window;
            _nameHandler = nameHandler;
        }
        
        public abstract void Execute(UIApplication app);
        public virtual string GetName()
        {
            return _nameHandler;
        }
    }
}
