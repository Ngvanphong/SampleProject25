using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateRevit2025.Interfaces
{
    interface IPutFamilyByLineService
    {
        IEnumerable<Family> GetFamilyFurniture(Document doc);
    }
}
