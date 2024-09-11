using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace TemplateRevit2025.Interfaces
{
    public interface ITestService
    {
        IEnumerable<Family> GetFamilies(Document doc);
    }
}
