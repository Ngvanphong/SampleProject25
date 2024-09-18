using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;

namespace TemplateRevit2025.ViewModel.CreatePipe;

public class TopVM
{
    
    public List<PipeTypeVM> ListTypes { get; set; }
}

public class PipeTypeVM
{
    public ElementId Id { get; set; }
    public string TypeName { get; set; }
}