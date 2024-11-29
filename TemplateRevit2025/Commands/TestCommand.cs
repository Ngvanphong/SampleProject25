using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Architecture;

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

            IEnumerable<DuctType> listDuctTpeT = listDuctType.Where(x => x.Shape == ConnectorProfileType.Round);

            DuctType ductTypeV = listDuctTypeV.FirstOrDefault();

            Duct duct1 = null;
            ConnectorManager connectorManager = duct1.ConnectorManager;
            ConnectorSet connectorSet = connectorManager.Connectors;

            Connector startConnector = null;
            Connector endConnector = null;
            foreach (Connector connector in connectorSet)
            {
                if (startConnector == null) startConnector = connector;
                else endConnector = connector;
            }

            IEnumerable<MEPSystemType> listMEPSystemType = new FilteredElementCollector(doc).OfClass(typeof(MEPSystemType))
               .Cast<MEPSystemType>();


            MEPSystemType returnAir = listMEPSystemType.FirstOrDefault(x => x.SystemClassification == MEPSystemClassification.ReturnAir);

            IEnumerable<MechanicalSystemType> ductSystems = new FilteredElementCollector(doc).OfClass(typeof(MechanicalSystemType))
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
            foreach (Connector connector in cableTrayConnectorSet)
            {

            }

            //ConnectorElement connectorElement= ConnectorElement.CreateConduitConnector()
            IEnumerable<ConduitType> conduitTypes = new FilteredElementCollector(doc).OfClass(typeof(ConduitType))
                .Cast<ConduitType>();

            Conduit conduit = Conduit.Create(doc, conduitTypes.First().Id,);



            DuctSettings ductSetting = DuctSettings.GetDuctSettings(doc);
            ductSetting.FittingAngleUsage = FittingAngleUsage.UseAnAngleIncrement;
            //var parameters = ductSetting.Parameters;
            ductSetting.SetSpecificFittingAngleStatus(60, false);

            DuctSizeSettings ductSizeSettting = DuctSizeSettings.GetDuctSizeSettings(doc);
            MEPSize mepSize = new MEPSize(3000 / 304.8, 2950 / 304.8, 3050 / 304.8, true, true);
            ductSizeSettting.AddSize(DuctShape.Rectangular, mepSize);
            ductSizeSettting.AddSize(DuctShape.Round, mepSize);

            PipeSettings pipeSetting = PipeSettings.GetPipeSettings(doc);


            IEnumerable<Segment> allSegment = new FilteredElementCollector(doc).OfClass(typeof(Segment)).Cast<Segment>();

            foreach (Segment segment in allSegment)
            {
                Material material = doc.GetElement(segment.MaterialId) as Material;
                ICollection<MEPSize> listSize = segment.GetSizes();
                foreach (MEPSize sizeItem in listSize)
                {
                    if (Math.Abs(sizeItem.NominalDiameter - 10 / 304.8) < 0.0001)
                    {

                    }
                    //MEPSize segmentSize= new MEPSize()
                    //segment.AddSize()
                }


                ElectricalSetting electricalSetting = ElectricalSetting.GetElectricalSettings(doc);
                DistributionSysTypeSet distributeSystems = electricalSetting.DistributionSysTypes;
                foreach (DistributionSysType system in distributeSystems)
                {

                }

                VoltageTypeSet voltageSet = electricalSetting.VoltageTypes;
                VoltageType vot120 = null;
                foreach (VoltageType voltageType in voltageSet)
                {
                    if (Math.Abs(voltageType.ActualValue - 120) < 0.000001)
                    {
                        vot120 = voltageType;
                        break;
                    }
                }

                electricalSetting.AddVoltageType("150", 150, 140, 160);

                electricalSetting.RemoveVoltageType(vot120);

                //IEnumerable<TemperatureRatingType> temperateRatingType = new FilteredElementCollector(doc)
                //    .OfClass(typeof(TemperatureRatingType)).Cast<TemperatureRatingType>();

                //TemperatureRatingType temperate55 = null;
                //foreach (TemperatureRatingType ratingType in temperateRatingType)
                //{
                //    if (ratingType.Name == "55")
                //    {
                //        temperate55 = ratingType;
                //        break;
                //    }
                //}


                WireMaterialTypeSet wireMaterialSet = doc.Settings.ElectricalSetting.WireMaterialTypes;

                WireMaterialType mateialAluminium = null;
                foreach (WireMaterialType wireMat in wireMaterialSet)
                {
                    if (wireMat.Name == "Aluminium")
                    {
                        mateialAluminium = wireMat;
                        break;
                    }
                }

                TemperatureRatingTypeSet temperateSet = mateialAluminium.TemperatureRatings;
                TemperatureRatingType temperateType55 = null;
                foreach (TemperatureRatingType tempItem in temperateSet)
                {
                    if (tempItem.Name == "55")
                    {
                        temperateType55 = tempItem;
                        break;
                    }
                }

                InsulationTypeSet insulationSet = temperateType55.InsulationTypes;
                InsulationType insulateTT = null;
                foreach (InsulationType insulateItem in insulationSet)
                {
                    if (insulateItem.Name == "TT")
                    {
                        insulateTT = insulateItem;
                        break;
                    }
                }

                WireSizeSet wireSizeSet = temperateType55.WireSizes;
                WireSize wireSize99 = null;
                foreach (WireSize wireSizeItem in wireSizeSet)
                {
                    if (wireSizeItem.Ampacity == 99)
                    {
                        wireSize99 = wireSizeItem;
                        break;
                    }
                }

                CableTraySizes cableTraySize = CableTraySizes.GetCableTraySizes(doc);
                var iteratorCableTraysize = cableTraySize.GetEnumerator();
                iteratorCableTraysize.Reset();
                MEPSize size175 = null;
                while (iteratorCableTraysize.MoveNext())
                {
                    MEPSize mepSizeItem = iteratorCableTraysize.Current;
                    if (Math.Abs(mepSizeItem.NominalDiameter - 175 / 304.8) < 0.0001)
                    {
                        size175 = mepSizeItem;
                        break;
                    }
                }



                DuctSizeSettings ductSizeStting = DuctSizeSettings.GetDuctSizeSettings(doc);
                IEnumerator<KeyValuePair<DuctShape, DuctSizes>> ductSizeIterator = ductSizeStting.GetEnumerator();

                DuctSizes sizeRectangle = null;
                ductSizeIterator.Reset();
                while (ductSizeIterator.MoveNext())
                {
                    KeyValuePair<DuctShape, DuctSizes> keyValue = ductSizeIterator.Current;
                    if (keyValue.Key == DuctShape.Rectangular)
                    {
                        sizeRectangle = keyValue.Value;
                        break;
                    }
                }



                ConduitSettings conduitSetting = ConduitSettings.GetConduitSettings(doc);
                ConduitSizeSettings conduitSizeSetting = ConduitSizeSettings.GetConduitSizeSettings(doc);

                IEnumerator<KeyValuePair<string, ConduitSizes>> conduitSizeIterator = conduitSizeSetting.GetEnumerator();
                conduitSizeIterator.Reset();
                ConduitSize conduitSize78RMC = null;
                while (conduitSizeIterator.MoveNext())
                {
                    KeyValuePair<string, ConduitSizes> pairSize = conduitSizeIterator.Current;
                    string key = pairSize.Key;
                    if (key == "RMC")
                    {
                        ConduitSizes valueSize = pairSize.Value;

                        IEnumerator<ConduitSize> iteratorSizeRMC = valueSize.GetEnumerator();
                        iteratorSizeRMC.Reset();
                        while (iteratorSizeRMC.MoveNext())
                        {
                            ConduitSize conduitSize = iteratorSizeRMC.Current;
                            if (Math.Abs(conduitSize.NominalDiameter - 78 / 304.8) < 0.0001)
                            {
                                conduitSize78RMC = conduitSize;
                                break;
                            }
                        }
                    }
                }



                PipeSettings pipeSettting = PipeSettings.GetPipeSettings(doc);










                return Result.Succeeded;
            }
        }
    }