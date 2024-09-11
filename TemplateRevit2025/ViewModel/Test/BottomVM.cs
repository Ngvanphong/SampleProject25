using TemplateRevit2025.Model.Test;
using TemplateRevit2025.Utilities;

namespace TemplateRevit2025.ViewModel.Test;

class BottomVM : ViewModelBase
{
    private List<InstanceCus> listColumn;

    public List<InstanceCus> ListColumn
    {
        get { return listColumn; }
        set
        {
            listColumn = value; OnPropertyChanged(nameof(ListColumn));
            
        }
    }

    private List<InstanceCus> listBeam;
    public List<InstanceCus> ListBeam
    {
        get { return listBeam; }
        set
        {
            listBeam = value; OnPropertyChanged(nameof(ListBeam));
            
        }
    }
}
