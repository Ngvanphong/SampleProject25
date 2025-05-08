using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateRevit2025.View.DuctToAirTerminal;
using TemplateRevit2025.ViewModel.DuctToAirTerminal;

namespace TemplateRevit2025.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class DuctToAirTerminalCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc= uiDoc.Document;
            var ids= uiDoc.Selection.GetElementIds();
            FamilyInstance airTermainal = null;
            Duct duct = null;
            foreach(ElementId id in ids)
            {
                Element el = doc.GetElement(id);
                if(el is FamilyInstance)
                {
                    FamilyInstance fa= el as FamilyInstance;
                    if(fa.Symbol.Family.FamilyCategory.Id.Value== (long)BuiltInCategory.OST_DuctTerminal) airTermainal = fa;
                }
                else if(el is Duct) duct = el as Duct;
            }
            if (airTermainal == null || duct == null) return Result.Succeeded;

            //FlexDuctType roundFlexType = null;
            //List<FlexDuctType> listAllType = new FilteredElementCollector(doc)
            //    .OfCategory(BuiltInCategory.OST_FlexDuctCurves).WhereElementIsElementType()
            //    .Cast<FlexDuctType>().ToList();
            //foreach(FlexDuctType flexType in listAllType)
            //{
            //    ConnectorProfileType shapeType = flexType.Shape;
            //    if (shapeType == ConnectorProfileType.Round)
            //    {
            //        roundFlexType= flexType;
            //        break;  
            //    }
            //}


            //DuctSettings ductSetting = Autodesk.Revit.DB.Mechanical.DuctSettings.GetDuctSettings(doc);

            List<FlexDuctSize> listSizeCombobox= new List<FlexDuctSize>();
            DuctSizeSettings ductSizeSetting = Autodesk.Revit.DB.Mechanical.DuctSizeSettings.GetDuctSizeSettings(doc);
            foreach(KeyValuePair<DuctShape, DuctSizes> pair in ductSizeSetting)
            {
                if(pair.Key== DuctShape.Round)
                {
                    foreach(MEPSize size in pair.Value)
                    {
                        FlexDuctSize flexDuctSize= new FlexDuctSize();
                        double sizeInch = size.NominalDiameter;
                        double sizeMili = UnitUtils.ConvertFromInternalUnits(sizeInch, UnitTypeId.Millimeters);
                        flexDuctSize.DuctSize =  Math.Round(sizeMili);
                        listSizeCombobox.Add(flexDuctSize);
                    }
                }
            }

            var form = new DuctToAirTermialWpf();
            form.ComboboxSizeFlexDuct.ItemsSource= listSizeCombobox;
            form.Show();


            return Result.Succeeded;
                
        }
    }
}
