using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateRevit2025.Interfaces;

namespace TemplateRevit2025.Services
{
    public class PutFamilyByLineService : IPutFamilyByLineService
    {
        public IEnumerable<Family> GetFamilyFurniture(Document doc)
        {
            return new FilteredElementCollector(doc).OfClass(typeof(Family)).Cast<Family>()
                .Where(x => x.FamilyCategory.Id.Value == (long)BuiltInCategory.OST_Furniture);
        }
    }
}
