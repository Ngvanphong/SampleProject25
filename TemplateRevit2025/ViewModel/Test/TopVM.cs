using TemplateRevit2025.Model.Test;
using TemplateRevit2025.Utilities;

namespace TemplateRevit2025.ViewModel.Test;

class TopVM : ViewModelBase
{
    private List<InstanceCus> listWall;
    public List<InstanceCus> ListWall
    {
        get { return listWall; }
        set { listWall = value; OnPropertyChanged(nameof(ListWall)); }
    }

    private List<InstanceCus> listDoor;

    public List<InstanceCus> ListDoor
    {
        get { return listDoor; }
        set
        {
            listDoor = value; OnPropertyChanged(nameof(ListDoor));
            
        }
    }
    
}