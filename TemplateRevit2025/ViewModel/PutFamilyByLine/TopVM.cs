using Autodesk.Revit.DB;
using TemplateRevit2025.Utilities;

namespace TemplateRevit2025.ViewModel.PutFamilyByLine;

class TopVM : ViewModelBase
{
    private List<FamilyVM> familyList;
    public List<FamilyVM> FamilyList
    {
        get { return familyList; }
        set{familyList = value;OnPropertyChanged(nameof(FamilyList));}
    }
}

public class FamilyVM : ViewModelBase
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

    private string nameFamily;
    public string NameFamily
    {
        get{return nameFamily;}
        set
        {
            nameFamily = value; OnPropertyChanged(nameof(NameFamily));
            
        }
    }
}