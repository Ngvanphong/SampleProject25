using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TemplateRevit2025.Core
{
    public class ExternalEventHandler : IExternalEventHandler
    {
        private string _nameHandler = string.Empty;
        public Window _form { get; private set; }
        public ExternalEventHandler(Window form, string nameHandler)
        {
            _form= form;
            _nameHandler= nameHandler;
        }

        public virtual void Execute(UIApplication app)
        {

        }


        public string GetName()
        {
           return _nameHandler;
        }
    }
}
