using Autodesk.Revit.UI;
using TemplateRevit2025.Utilities;

namespace TemplateRevit2025.ViewModel.Test;

class MainVM : ViewModelBase
{
    private TopVM topVM;
    public TopVM TopVM
    {
        get { return topVM; }
        set
        {
            topVM = value;
            OnPropertyChanged(nameof(TopVM));
        }
    }

    private BottomVM bottomVM;

    public BottomVM BottomVM
    {
        get { return bottomVM; }
        set
        {
            bottomVM = value;
            OnPropertyChanged(nameof(BottomVM));
        }
    }
}