using System.Windows;
using TemplateRevit2025.NetEvent.Test;
using UserControl = System.Windows.Controls.UserControl;

namespace TemplateRevit2025.View.Test;

public partial class Bottom : UserControl
{
    public Bottom()
    {
        InitializeComponent();

       
    }
    void ComboboxWallChanged(object sender, WallDataReachedEventArgs e)
    {
        var data = e;
        return;
    }

    private void bottomLoaded(object sender, System.Windows.RoutedEventArgs e)
    {
        Main main = Window.GetWindow(this) as Main;
        Top top = main.ContentTopView.Content as Top;
        top.NetWallDataEvent.EventWallDataReached += ComboboxWallChanged;
    }

}