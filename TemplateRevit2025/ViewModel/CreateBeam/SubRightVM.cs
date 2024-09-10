using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateRevit2025.Utilities;

namespace TemplateRevit2025.ViewModel.CreateBeam
{
    class SubRightVM : ViewModelBase
    {
        public ElementId Id { set; get; }
        public string SyName { set; get; }    
    }
}
