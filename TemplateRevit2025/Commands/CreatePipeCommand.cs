using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using TemplateRevit2025.Interfaces;
using TemplateRevit2025.View.CreatePipe;
using TemplateRevit2025.ViewModel.CreatePipe;

namespace TemplateRevit2025.Commands;

[Transaction(TransactionMode.Manual)]
public class CreatePipeCommand : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        Document doc = commandData.Application.ActiveUIDocument.Document;
        var listType = Host.GetService<ICreatePipeService>().GetPipeTypes(doc);
        var mainForm = new Main();
        TopVM topVm= new TopVM();
        topVm.ListTypes = listType.Select(item=>new PipeTypeVM{Id = item.Id,TypeName = item.Name}).ToList();
        Top topView= mainForm.ContentTop.Content as Top;
        topView.DataContext = topVm;
        mainForm.Show();
        return Result.Succeeded;
    }
}