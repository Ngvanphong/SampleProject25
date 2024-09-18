using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateRevit2025.Buttons;

namespace TemplateRevit2025
{
    public class App : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            Host.Stop();
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            Host.Start();
            new TestButton().Create(application);
            new PutFamilyByLineButton().Create(application);    
            new CreatePipeButton().Create(application);
            return Result.Succeeded;
        }
    }
}
