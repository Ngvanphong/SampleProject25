using Autodesk.Revit.UI;
using System.Windows;
using TemplateRevit2025.Model.Test;
using TemplateRevit2025.NetEvent.Test;
using TemplateRevit2025.RevitHandler.Test;
using TemplateRevit2025.ViewModel.Test;
using UserControl = System.Windows.Controls.UserControl;

namespace TemplateRevit2025.View.Test;

public partial class Top : UserControl
{
    public ExternalEvent ColumnSelectEvent { set; get; }
    public WallDataEvent NetWallDataEvent { set; get; }
    public Top()
    {
        InitializeComponent();
        NetWallDataEvent= new WallDataEvent();
    }

    private void ComboboxWallChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        Main frmMain = Window.GetWindow(this) as Main;
        Bottom bottom= frmMain.ContentBottomView.Content as Bottom;
        WallDataReachedEventArgs args = new WallDataReachedEventArgs();
        args.WallData = ComboboxWall.SelectedItem as InstanceCus;
        NetWallDataEvent.Raise(args);

        ColumnSelectEvent.Raise();

    }
}