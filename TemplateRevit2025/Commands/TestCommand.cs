using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Configuration;

namespace TemplateRevit2025.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class TestCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;

            FamilyInstance beam = null;
            BoundingBoxXYZ boundingBox = beam.get_BoundingBox(null);

            

            ElementId markId = new ElementId((long)BuiltInParameter.ALL_MODEL_MARK);
            FilterRule filterRuleMark = ParameterFilterRuleFactory.CreateEqualsRule(markId, "1");
            ElementParameterFilter filterMark= new ElementParameterFilter(filterRuleMark);


            ElementId commentId= new ElementId((long)BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
            FilterRule commentRule = ParameterFilterRuleFactory.CreateContainsRule(commentId, "a");
            ElementParameterFilter commentFitler = new ElementParameterFilter(commentRule);


            ElementId volumeId = new ElementId((long)BuiltInParameter.HOST_VOLUME_COMPUTED);
            double volumeMet = 0.5;
            double volumeInch= UnitUtils.ConvertToInternalUnits(volumeMet, UnitTypeId.CubicMeters);
            FilterRule volumeRule = ParameterFilterRuleFactory.CreateGreaterRule(volumeId,volumeInch, 0.000001);
            ElementParameterFilter volumeFIlter= new ElementParameterFilter(volumeRule);

            LogicalAndFilter logicalChild2 = new LogicalAndFilter(new List<ElementFilter> { commentFitler, volumeFIlter });


            LogicalOrFilter logicalOrFilter = new LogicalOrFilter(new List<ElementFilter> { filterMark, logicalChild2 });

            Category structuralColumnCate = doc.Settings.Categories.get_Item(BuiltInCategory.OST_StructuralColumns);


            FillPatternElement fillPattern = new FilteredElementCollector(doc).OfClass(typeof(FillPatternElement))
                .Cast<FillPatternElement>().FirstOrDefault(x => x.GetFillPattern().IsSolidFill);

            using(Transaction t= new Transaction(doc, "AddFilter"))
            {
                t.Start();

                Element wall = doc.GetElement(uiDoc.Selection.GetElementIds().First());
                wall.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS).Set("GGGG");

                wall.get_Parameter(BuiltInParameter.WALL_ATTR_ROOM_BOUNDING).Set(0);

                ParameterFilterElement filterCustom= ParameterFilterElement.Create(doc, "CustomFilter",
                    new List<ElementId> { structuralColumnCate.Id },logicalOrFilter);

                ParameterFilterElement filterCustom2 = ParameterFilterElement.Create(doc, "CustomFilter2",
                    new List<ElementId> { structuralColumnCate.Id }, logicalOrFilter);

                doc.ActiveView.AddFilter(filterCustom.Id);
                doc.ActiveView.AddFilter(filterCustom2.Id);


                OverrideGraphicSettings settingColor = new OverrideGraphicSettings();
                settingColor.SetSurfaceBackgroundPatternColor(new Autodesk.Revit.DB.Color(255, 0, 0));
                settingColor.SetSurfaceBackgroundPatternId(fillPattern.Id);

                settingColor.SetSurfaceForegroundPatternColor(new Autodesk.Revit.DB.Color(255, 0, 0));
                settingColor.SetSurfaceForegroundPatternId(fillPattern.Id);


                doc.ActiveView.SetFilterOverrides(filterCustom.Id, settingColor);


                t.Commit();
            }


            return Result.Succeeded;
        }
    }
}