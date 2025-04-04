using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateRevit2025.FamilyMananger
{
    [Transaction(TransactionMode.Manual)]
    public class FamilyManagerBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Category category = null;
            //category.Nam
            return Result.Succeeded;
        }
    }
}
