using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TemplateRevit2025.FamilyMananger
{
    public class FamilyVm
    {
        public ElementId Id { get; set; }
        public string NameFamily { set;get; }
        public ImageSource Image { set; get; }
    }
}
