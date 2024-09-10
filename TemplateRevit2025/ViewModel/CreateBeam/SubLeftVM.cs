using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateRevit2025.Utilities;
using Autodesk.Revit.DB;

namespace TemplateRevit2025.ViewModel.CreateBeam
{
    class SubLeftVM : ViewModelBase
    {
        public List<FamilyVM> Items { set; get; }
    }

    class FamilyVM
    {
        public ElementId Id { set; get; }
        public string Name { set; get; }
    }
}
