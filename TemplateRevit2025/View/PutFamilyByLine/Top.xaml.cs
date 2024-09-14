using Autodesk.Revit.UI;
using MediatR;
using TemplateRevit2025.Mediator.PutFamilyByLine;
using TemplateRevit2025.ViewModel.PutFamilyByLine;
using UserControl = System.Windows.Controls.UserControl;

namespace TemplateRevit2025.View.PutFamilyByLine;

public partial class Top : UserControl
{
    private IMediator _mediator;
    public ExternalEvent FamilyTypeEvent { set; get; }
    public Top()
    {
        InitializeComponent();
        _mediator = Host.GetService<IMediator>();
    }

    private async void ComboboxFamilyChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        
        FamilySend familySend = new FamilySend();
        familySend.FamilyChoose = (sender as System.Windows.Controls.ComboBox).SelectedItem as FamilyVM;
        bool success= await _mediator.Send(familySend);
        if(success)
        {
            FamilyTypeEvent.Raise();
        }
        
    }
}