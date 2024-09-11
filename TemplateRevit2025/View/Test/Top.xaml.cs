using Autodesk.Revit.UI;
using TemplateRevit2025.RevitHandler.Test;
using UserControl = System.Windows.Controls.UserControl;

namespace TemplateRevit2025.View.Test;

public partial class Top : UserControl
{
    public ExternalEvent ColumnSelectEvent { set; get; }
    public Top()
    {
        InitializeComponent();
    }

    private void ComboboxWallChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        ColumnSelectEvent.Raise();

    }
}