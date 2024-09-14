using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using TemplateRevit2025.Interfaces;
using TemplateRevit2025.RevitHandler.PutFamilyByLine;
using TemplateRevit2025.View.PutFamilyByLine;
using TemplateRevit2025.ViewModel.PutFamilyByLine;

namespace TemplateRevit2025.Commands;

[Transaction(TransactionMode.Manual)]
public class PutFamilyByLineCommand : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        Document doc = commandData.Application.ActiveUIDocument.Document;
        IPutFamilyByLineService putService= Host.GetService<IPutFamilyByLineService>();
        IEnumerable<Family> listFamily = putService.GetFamilyFurniture(doc);

       
        MainVM mainVm= new MainVM();
        TopVM topVM = new TopVM();
        topVM.FamilyList = listFamily.Select(x => new FamilyVM { Id = x.Id, NameFamily = x.Name }).ToList();
        mainVm.TopVM = topVM;



        Main frmMain = new Main();
        frmMain.DataContext = mainVm;

        TypeFamilyHandler typeFamilyHandler = new TypeFamilyHandler(null,null, "TypeFamilyHandler");

        ExternalEvent familyEvent= ExternalEvent.Create(typeFamilyHandler);
        Top topView= frmMain.TopView.Content as Top;
        topView.FamilyTypeEvent = familyEvent;

        frmMain.Show();
        



        return Result.Succeeded;
    }
}