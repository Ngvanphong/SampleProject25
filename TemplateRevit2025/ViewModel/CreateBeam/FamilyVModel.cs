using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateRevit2025.Utilities;
using Autodesk.Revit.DB;

namespace TemplateRevit2025.ViewModel.CreateBeam
{
    class FamilyVModel : ViewModelBase
    {
        private readonly Family _family;
        public long Id
        {
            get { return _family.Id.Value; }
        }
        public string Name { get; set; }    
    }
}
