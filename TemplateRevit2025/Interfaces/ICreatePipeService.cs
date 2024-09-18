using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB;

namespace TemplateRevit2025.Interfaces;

public interface ICreatePipeService
{
    IEnumerable<PipeType> GetPipeTypes(Document doc);
    
    List<MEPSize> GetSizeType(Document doc,PipeType pipeType);
    
    Pipe CreatePipe(Document doc);
    
}