using Autodesk.Revit.UI;
using System.Windows;

namespace TemplateRevit2025.View.PutFamilyByLine;

public partial class Main : Window
{
    private ExternalEvent _putFamilyEvent;
    public Main(ExternalEvent putFamilyEvent)
    {
        InitializeComponent();
        _putFamilyEvent = putFamilyEvent;
    }

    private void btnOk(object sender, RoutedEventArgs e)
    {
        _putFamilyEvent.Raise();
    }
}