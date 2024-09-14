using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using TemplateRevit2025.Interfaces;
using TemplateRevit2025.RevitHandler.PutFamilyByLine;
using TemplateRevit2025.View.PutFamilyByLine;
using TemplateRevit2025.ViewModel.PutFamilyByLine;
using System.Windows.Controls;
using UserControl = System.Windows.Controls.UserControl;

namespace TemplateRevit2025.Commands;

[Transaction(TransactionMode.Manual)]
public class PutFamilyByLineCommand : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        Document doc = commandData.Application.ActiveUIDocument.Document;
        IPutFamilyByLineService putService= Host.GetService<IPutFamilyByLineService>();
        IEnumerable<Family> listFamily = putService.GetFamilyFurniture(doc);

        Main frmMain = new Main();
        TopVM topVM = new TopVM();
        topVM.FamilyList = listFamily.Select(x => new FamilyVM { Id = x.Id, NameFamily = x.Name }).ToList();
        Top topView = frmMain.ContentTop.Content as Top;
        topView.DataContext = topVM;

        TypeFamilyHandler typeFamilyHandler = new TypeFamilyHandler(null,frmMain.ContentTop.Content as UserControl,
            frmMain.ContentBottom.Content as UserControl, "TypeFamilyHandler");
        ExternalEvent familyEvent= ExternalEvent.Create(typeFamilyHandler);
        topView.FamilyTypeEvent = familyEvent;

        frmMain.Show();
        



        return Result.Succeeded;
    }
}