using Autodesk.Revit.UI;
using MediatR;
using System.Windows;
using TemplateRevit2025.Mediator.Test;
using TemplateRevit2025.Model.Test;
using TemplateRevit2025.NetEvent.Test;
using TemplateRevit2025.RevitHandler.Test;
using TemplateRevit2025.ViewModel.Test;
using UserControl = System.Windows.Controls.UserControl;

namespace TemplateRevit2025.View.Test;

public partial class Top : UserControl
{
    private IMediator _mediator;
    public ExternalEvent ColumnSelectEvent { set; get; }
    public WallDataEvent NetWallDataEvent { set; get; }
    public Top()
    {
        InitializeComponent();
        NetWallDataEvent= new WallDataEvent();
        _mediator= Host.GetService<IMediator>();
    }

    private async void ComboboxWallChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        Main frmMain = Window.GetWindow(this) as Main;
        WallDataReachedEventArgs args = new WallDataReachedEventArgs();
        args.WallData = ComboboxWall.SelectedItem as InstanceCus;
        NetWallDataEvent.Raise(args);
        
        TopDataSend topDataSend= new TopDataSend();
        topDataSend.Wall= (sender as System.Windows.Controls.ComboBox).SelectedItem as InstanceCus;
        await _mediator.Send(topDataSend);
        
        ColumnSelectEvent.Raise();

    }
}