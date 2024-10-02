using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TemplateRevit2025.ViewModel.ChairFamily
{
    public class ChairFamilyVM : INotifyPropertyChanged
    {

        private List<FamillyVm> families;
        public List<FamillyVm> Families
        {
            get { return families; }
            set { families = value; OnPropertyChanged(nameof(Families)); }
        }

        public List<TypeVm> types;
        public List<TypeVm> Types
        {
            get { return types; }
            set { types = value; OnPropertyChanged(nameof(Types)); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
    public class FamillyVm
    {
        public ElementId Id { set; get; }
        public string NameChair { set; get; }
    }

    public class TypeVm
    {
        public ElementId Id { set; get; }
        public string TypeName { set; get; }
    }
}
