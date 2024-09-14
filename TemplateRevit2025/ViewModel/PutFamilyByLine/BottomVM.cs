using Autodesk.Revit.DB;
using TemplateRevit2025.Utilities;

namespace TemplateRevit2025.ViewModel.PutFamilyByLine;

class BottomVM
{
    public List<TypeVM> ListTypeVM { get; set; }
}

class TypeVM :ViewModelBase
{
    private ElementId id;
    public ElementId Id
    {
        get {return id;}
        set
        {
            id = value;
            OnPropertyChanged(nameof(Id));
        }
    }

    private string typeName;
    public string TypeName
    {
        get{return typeName;}
        set
        {
            typeName = value; OnPropertyChanged(nameof(TypeName));
        }
    }
}