using Autodesk.Revit.UI;
using System.Windows;

namespace TemplateRevit2025.View.Test;

public partial class Main : Window
{
    public ExternalEvent FinishEvent { set;get; }
    public Main()
    {
        InitializeComponent();
    }

    private void btnClickOk(object sender, RoutedEventArgs e)
    {
        FinishEvent.Raise();
    }
}