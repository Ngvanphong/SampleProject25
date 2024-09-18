using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using TemplateRevit2025.Interfaces;

namespace TemplateRevit2025.Services;

public class CreatePipeService : ICreatePipeService
{
    public IEnumerable<PipeType> GetPipeTypes(Document doc)
    {
        var listPipeTypes = new FilteredElementCollector(doc)
            .OfCategory(BuiltInCategory.OST_PipeCurves).WhereElementIsElementType()
            .Cast<PipeType>();
        return listPipeTypes;
    }

    public List<MEPSize> GetSizeType(Document doc,PipeType pipeType)
    {
        RoutingPreferenceManager rountingManager = pipeType.RoutingPreferenceManager;
        RoutingPreferenceRule segmentRule = rountingManager.GetRule(RoutingPreferenceRuleGroupType.Segments, 0);
        PipeSegment pipeSegment = doc.GetElement(segmentRule.MEPPartId) as PipeSegment;
        return pipeSegment.GetSizes().ToList();
    }

    public Pipe CreatePipe(Document doc)
    {
        throw new NotImplementedException();
    }
}