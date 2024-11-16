using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Electrical;

namespace TemplateRevit2025.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class TestCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;

            /*
             * Duct
             */

            // ve duct

            // duct type
            IEnumerable<DuctType> listDuctType = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_DuctCurves)
                 .WhereElementIsElementType().OfClass(typeof(DuctType)).Cast<DuctType>();

            IEnumerable<DuctType> listDuctTypeV = listDuctType.Where(x => x.Shape == ConnectorProfileType.Rectangular);

            IEnumerable<DuctType> listDuctTpeT= listDuctType.Where(x => x.Shape == ConnectorProfileType.Round);

            DuctType ductTypeV = listDuctTypeV.FirstOrDefault();

            Duct duct1 = null;
            ConnectorManager connectorManager = duct1.ConnectorManager;
            ConnectorSet connectorSet = connectorManager.Connectors;

            Connector startConnector = null;
            Connector endConnector = null;
            foreach(Connector connector in connectorSet)
            {
                if (startConnector == null) startConnector = connector;
                else endConnector = connector;
            }

            IEnumerable<MEPSystemType> listMEPSystemType = new FilteredElementCollector(doc).OfClass(typeof(MEPSystemType))
               .Cast<MEPSystemType>();
           

            MEPSystemType returnAir = listMEPSystemType.FirstOrDefault(x=>x.SystemClassification == MEPSystemClassification.ReturnAir);

            IEnumerable<MechanicalSystemType> ductSystems= new FilteredElementCollector(doc).OfClass(typeof(MechanicalSystemType))
               .Cast<MechanicalSystemType>();
            MechanicalSystemType ductReturnAir = ductSystems.FirstOrDefault(x => x.SystemClassification == MEPSystemClassification.ReturnAir);

            IEnumerable<PipingSystemType> pipingSystems = new FilteredElementCollector(doc).OfClass(typeof(PipingSystemType))
               .Cast<PipingSystemType>();
            PipingSystemType pipeSanitary = pipingSystems.FirstOrDefault(x => x.SystemClassification == MEPSystemClassification.Sanitary);


            IEnumerable<MEPSystem> listMepSystem = new FilteredElementCollector(doc).OfClass(typeof(MEPSystem))
               .Cast<MEPSystem>(); // he thong system ket noi voi nhau

            //Duct newDuct = Duct.Create(doc, ductTypeV.Id, doc.ActiveView.GenLevel.Id,);
            //Pipe newPipe= Pipe.Create(doc, )

            // duct fitting

            //doc.Create.NewFlexDuct()
            //doc.Create.NewFamilyInstance()


            //Wire newWrite = Wire.Create(doc, ElementId.InvalidElementId, doc.ActiveView, WiringType.Arc,);

            //CableTray cableTrace = CableTray.Create();


            CableTray cableTray = null;
            ConnectorManager cableTrayConnectorManager = cableTray.ConnectorManager;
            ConnectorSet cableTrayConnectorSet = cableTrayConnectorManager.Connectors;
            foreach(Connector connector in cableTrayConnectorSet)
            {

            }

            //ConnectorElement connectorElement= ConnectorElement.CreateConduitConnector()







            return Result.Succeeded;
        }
    }
}