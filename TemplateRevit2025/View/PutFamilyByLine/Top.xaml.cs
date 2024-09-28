using Autodesk.Revit.UI;
using MediatR;
using TemplateRevit2025.Mediator.PutFamilyByLine;
using TemplateRevit2025.ViewModel.PutFamilyByLine;
using UserControl = System.Windows.Controls.UserControl;

namespace TemplateRevit2025.View.PutFamilyByLine;

public partial class Top : UserControl
{

    public ExternalEvent SelectTypeEvent { set; get; }
    public Top()
    {
        InitializeComponent();

    }

    private  void ComboboxFamilyChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        SelectTypeEvent.Raise();
    }
}