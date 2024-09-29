using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using TemplateRevit2025.Interfaces;
using TemplateRevit2025.RevitHandler.PutFamilyByLine;
using TemplateRevit2025.View.PutFamilyByLine;
using TemplateRevit2025.ViewModel.PutFamilyByLine;
using System.Windows.Controls;
using UserControl = System.Windows.Controls.UserControl;
using TemplateRevit2025.Services;

namespace TemplateRevit2025.Commands;

[Transaction(TransactionMode.Manual)]
public class PutFamilyByLineCommand : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        IPutFamilyByLineService putService=  new PutFamilyByLineService();
        Document doc = commandData.Application.ActiveUIDocument.Document;
        
        IEnumerable<Family> listFamily = putService.GetFamilyFurniture(doc);

        PutFamilybyLineHandler putFamilyHandler = new PutFamilybyLineHandler(null, null, null,
            "PutFmailyHanler");
        ExternalEvent putFamilyEvent = ExternalEvent.Create(putFamilyHandler);
        Main frmMain = new Main(putFamilyEvent);
        
        TopVM topVM = new TopVM();
        topVM.FamilyList = listFamily.Select(x => new FamilyVM { Id = x.Id, NameFamily = x.Name }).ToList();
        Top topView = frmMain.ContentTop.Content as Top;
        topView.DataContext = topVM;

        SelectTypeHandler selectTypeHandler = new SelectTypeHandler(null,topView,
            frmMain.ContentBottom.Content as UserControl,"SelectTypeHandler1");
        ExternalEvent selectEvent= ExternalEvent.Create(selectTypeHandler);
        topView.SelectTypeEvent = selectEvent;

        frmMain.Show();
        
        return Result.Succeeded;
    }
}