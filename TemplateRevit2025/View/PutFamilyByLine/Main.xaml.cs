using Autodesk.Revit.UI;
using System.Windows;

namespace TemplateRevit2025.View.PutFamilyByLine;

public partial class Main : Window
{
    public ExternalEvent _putFamilyEvent;
    public Main()
    {
        InitializeComponent();
    }

    private void btnOk(object sender, RoutedEventArgs e)
    {
        _putFamilyEvent.Raise();
    }
}