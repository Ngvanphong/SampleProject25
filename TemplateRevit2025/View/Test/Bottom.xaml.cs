using MediatR;
using System.Windows;
using TemplateRevit2025.NetEvent.Test;
using UserControl = System.Windows.Controls.UserControl;
using TemplateRevit2025.Mediator.Test;

namespace TemplateRevit2025.View.Test;

public partial class Bottom : UserControl, IRequestHandler<TopDataSend, bool>
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

    public Task<bool> Handle(TopDataSend request, CancellationToken cancellationToken)
    {
        var wallSelected = request.Wall;
        var door = request.Door;

        return Task.FromResult(true);
    }
}