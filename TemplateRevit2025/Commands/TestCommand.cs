using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Internal.InfoCenter;

namespace TemplateRevit2025.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class TestCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;

            #region mep
            /*
             * Duct
             */

            // ve duct

            // duct type
            //IEnumerable<DuctType> listDuctType = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_DuctCurves)
            //     .WhereElementIsElementType().OfClass(typeof(DuctType)).Cast<DuctType>();

            //IEnumerable<DuctType> listDuctTypeV = listDuctType.Where(x => x.Shape == ConnectorProfileType.Rectangular);

            //IEnumerable<DuctType> listDuctTpeT = listDuctType.Where(x => x.Shape == ConnectorProfileType.Round);

            //DuctType ductTypeV = listDuctTypeV.FirstOrDefault();

            //Duct duct1 = null;
            //ConnectorManager connectorManager = duct1.ConnectorManager;
            //ConnectorSet connectorSet = connectorManager.Connectors;

            //Connector startConnector = null;
            //Connector endConnector = null;
            //foreach (Connector connector in connectorSet)
            //{
            //    if (startConnector == null) startConnector = connector;
            //    else endConnector = connector;
            //}

            //IEnumerable<MEPSystemType> listMEPSystemType = new FilteredElementCollector(doc).OfClass(typeof(MEPSystemType))
            //   .Cast<MEPSystemType>();


            //MEPSystemType returnAir = listMEPSystemType.FirstOrDefault(x => x.SystemClassification == MEPSystemClassification.ReturnAir);

            //IEnumerable<MechanicalSystemType> ductSystems = new FilteredElementCollector(doc).OfClass(typeof(MechanicalSystemType))
            //   .Cast<MechanicalSystemType>();

            //MechanicalSystemType ductReturnAir = ductSystems.FirstOrDefault(x => x.SystemClassification == MEPSystemClassification.ReturnAir);

            //IEnumerable<PipingSystemType> pipingSystems = new FilteredElementCollector(doc).OfClass(typeof(PipingSystemType))
            //   .Cast<PipingSystemType>();
            //PipingSystemType pipeSanitary = pipingSystems.FirstOrDefault(x => x.SystemClassification == MEPSystemClassification.Sanitary);


            //IEnumerable<MEPSystem> listMepSystem = new FilteredElementCollector(doc).OfClass(typeof(MEPSystem))
            //   .Cast<MEPSystem>(); // he thong system ket noi voi nhau

            ////Duct newDuct = Duct.Create(doc, ductTypeV.Id, doc.ActiveView.GenLevel.Id,);
            ////Pipe newPipe= Pipe.Create(doc, )

            //// duct fitting

            ////doc.Create.NewFlexDuct()
            ////doc.Create.NewFamilyInstance()


            ////Wire newWrite = Wire.Create(doc, ElementId.InvalidElementId, doc.ActiveView, WiringType.Arc,);

            ////CableTray cableTrace = CableTray.Create();


            //CableTray cableTray = null;
            //ConnectorManager cableTrayConnectorManager = cableTray.ConnectorManager;
            //ConnectorSet cableTrayConnectorSet = cableTrayConnectorManager.Connectors;
            //foreach (Connector connector in cableTrayConnectorSet)
            //{

            //}

            ////ConnectorElement connectorElement= ConnectorElement.CreateConduitConnector()
            //IEnumerable<ConduitType> conduitTypes = new FilteredElementCollector(doc).OfClass(typeof(ConduitType))
            //    .Cast<ConduitType>();

            ////Conduit conduit = Conduit.Create(doc, conduitTypes.First().Id,);

            //DuctSettings ductSetting = DuctSettings.GetDuctSettings(doc);
            //ductSetting.FittingAngleUsage = FittingAngleUsage.UseAnAngleIncrement;
            ////var parameters = ductSetting.Parameters;
            //ductSetting.SetSpecificFittingAngleStatus(60, false);

            //DuctSizeSettings ductSizeSettting = DuctSizeSettings.GetDuctSizeSettings(doc);
            //MEPSize mepSize = new MEPSize(3000 / 304.8, 2950 / 304.8, 3050 / 304.8, true, true);
            //ductSizeSettting.AddSize(DuctShape.Rectangular, mepSize);
            //ductSizeSettting.AddSize(DuctShape.Round, mepSize);

            //PipeSettings pipeSetting = PipeSettings.GetPipeSettings(doc);
            //IEnumerable<Segment> allSegment = new FilteredElementCollector(doc).OfClass(typeof(Segment)).Cast<Segment>();

            //foreach (Segment segment in allSegment)
            //{
            //    Material material = doc.GetElement(segment.MaterialId) as Material;
            //    ICollection<MEPSize> listSize = segment.GetSizes();
            //    foreach (MEPSize sizeItem in listSize)
            //    {
            //        if (Math.Abs(sizeItem.NominalDiameter - 10 / 304.8) < 0.0001)
            //        {

            //        }
            //        //MEPSize segmentSize= new MEPSize()
            //        //segment.AddSize()
            //    }
            //}


            //ElectricalSetting electricalSetting = ElectricalSetting.GetElectricalSettings(doc);
            //DistributionSysTypeSet distributeSystems = electricalSetting.DistributionSysTypes;
            //foreach (DistributionSysType system in distributeSystems)
            //{

            //}

            //VoltageTypeSet voltageSet = electricalSetting.VoltageTypes;
            //VoltageType vot120 = null;
            //foreach (VoltageType voltageType in voltageSet)
            //{
            //    if (Math.Abs(voltageType.ActualValue - 120) < 0.000001)
            //    {
            //        vot120 = voltageType;
            //        break;
            //    }
            //}

            //electricalSetting.AddVoltageType("150", 150, 140, 160);

            //electricalSetting.RemoveVoltageType(vot120);

            ////IEnumerable<TemperatureRatingType> temperateRatingType = new FilteredElementCollector(doc)
            ////    .OfClass(typeof(TemperatureRatingType)).Cast<TemperatureRatingType>();

            ////TemperatureRatingType temperate55 = null;
            ////foreach (TemperatureRatingType ratingType in temperateRatingType)
            ////{
            ////    if (ratingType.Name == "55")
            ////    {
            ////        temperate55 = ratingType;
            ////        break;
            ////    }
            ////}


            //WireMaterialTypeSet wireMaterialSet = doc.Settings.ElectricalSetting.WireMaterialTypes;

            //WireMaterialType mateialAluminium = null;
            //foreach (WireMaterialType wireMat in wireMaterialSet)
            //{
            //    if (wireMat.Name == "Aluminium")
            //    {
            //        mateialAluminium = wireMat;
            //        break;
            //    }
            //}

            //TemperatureRatingTypeSet temperateSet = mateialAluminium.TemperatureRatings;
            //TemperatureRatingType temperateType55 = null;
            //foreach (TemperatureRatingType tempItem in temperateSet)
            //{
            //    if (tempItem.Name == "55")
            //    {
            //        temperateType55 = tempItem;
            //        break;
            //    }
            //}

            //InsulationTypeSet insulationSet = temperateType55.InsulationTypes;
            //InsulationType insulateTT = null;
            //foreach (InsulationType insulateItem in insulationSet)
            //{
            //    if (insulateItem.Name == "TT")
            //    {
            //        insulateTT = insulateItem;
            //        break;
            //    }
            //}

            //WireSizeSet wireSizeSet = temperateType55.WireSizes;
            //WireSize wireSize99 = null;
            //foreach (WireSize wireSizeItem in wireSizeSet)
            //{
            //    if (wireSizeItem.Ampacity == 99)
            //    {
            //        wireSize99 = wireSizeItem;
            //        break;
            //    }
            //}

            //CableTraySizes cableTraySize = CableTraySizes.GetCableTraySizes(doc);
            //var iteratorCableTraysize = cableTraySize.GetEnumerator();
            //iteratorCableTraysize.Reset();
            //MEPSize size175 = null;
            //while (iteratorCableTraysize.MoveNext())
            //{
            //    MEPSize mepSizeItem = iteratorCableTraysize.Current;
            //    if (Math.Abs(mepSizeItem.NominalDiameter - 175 / 304.8) < 0.0001)
            //    {
            //        size175 = mepSizeItem;
            //        break;
            //    }
            //}

            //DuctSizeSettings ductSizeStting = DuctSizeSettings.GetDuctSizeSettings(doc);
            //IEnumerator<KeyValuePair<DuctShape, DuctSizes>> ductSizeIterator = ductSizeStting.GetEnumerator();
            //DuctSizes sizeRectangle = null;
            //ductSizeIterator.Reset();
            //while (ductSizeIterator.MoveNext())
            //{
            //    KeyValuePair<DuctShape, DuctSizes> keyValue = ductSizeIterator.Current;
            //    if (keyValue.Key == DuctShape.Rectangular)
            //    {
            //        sizeRectangle = keyValue.Value;
            //        break;
            //    }
            //}

            //ConduitSettings conduitSetting = ConduitSettings.GetConduitSettings(doc);
            //ConduitSizeSettings conduitSizeSetting = ConduitSizeSettings.GetConduitSizeSettings(doc);

            //IEnumerator<KeyValuePair<string, ConduitSizes>> conduitSizeIterator = conduitSizeSetting.GetEnumerator();
            //conduitSizeIterator.Reset();
            //ConduitSize conduitSize78RMC = null;
            //while (conduitSizeIterator.MoveNext())
            //{
            //    KeyValuePair<string, ConduitSizes> pairSize = conduitSizeIterator.Current;
            //    string key = pairSize.Key;
            //    if (key == "RMC")
            //    {
            //        ConduitSizes valueSize = pairSize.Value;
            //        IEnumerator<ConduitSize> iteratorSizeRMC = valueSize.GetEnumerator();
            //        iteratorSizeRMC.Reset();
            //        while (iteratorSizeRMC.MoveNext())
            //        {
            //            ConduitSize conduitSize = iteratorSizeRMC.Current;
            //            if (Math.Abs(conduitSize.NominalDiameter - 78 / 304.8) < 0.0001)
            //            {
            //                conduitSize78RMC = conduitSize;
            //                break;
            //            }
            //        }
            //    }
            //}




            //PipeSettings pipeSettting = PipeSettings.GetPipeSettings(doc);


            //PipeType pipeTypeStandard = new FilteredElementCollector(doc).OfClass(typeof(PipeType)).Cast<PipeType>().
            //    FirstOrDefault(x => x.Name == "Standard");


            //// cat tung doan line

            //var ids = uiDoc.Selection.GetElementIds();
            //List<Line> listLineBandau = new List<Line>();
            //foreach (ElementId id in ids)
            //{
            //    DetailLine lineItem = doc.GetElement(id) as DetailLine;
            //    if (lineItem != null)
            //    {
            //        listLineBandau.Add(lineItem.GeometryCurve as Line);
            //    }
            //}
            //List<Line> listLineCatReult = new List<Line>();
            //foreach (Line lineCanCat in listLineBandau)
            //{
            //    List<Line> listLineCanCat = new List<Line>();
            //    listLineCanCat.Add(lineCanCat);
            //    while (listLineCanCat.Count > 0)
            //    {
            //        Line lineCancatItem = listLineCanCat[0];
            //        XYZ sp = lineCancatItem.GetEndPoint(0);
            //        XYZ ep = lineCancatItem.GetEndPoint(1);
            //        listLineCanCat.RemoveAt(0);
            //        bool isCat = false;
            //        foreach (Line lineCheck in listLineBandau)
            //        {
            //            if (lineCancatItem == lineCheck) continue;
            //            lineCancatItem.Intersect(lineCheck, out IntersectionResultArray resultIntersection);
            //            if (resultIntersection != null && resultIntersection.Size == 1)
            //            {
            //                XYZ interecion = resultIntersection.get_Item(0).XYZPoint;
            //                if (!(interecion.IsAlmostEqualTo(sp, 0.0001) || interecion.IsAlmostEqualTo(ep, 0.0001)))
            //                {
            //                    Line line1 = Line.CreateBound(sp, interecion);
            //                    Line line2 = Line.CreateBound(interecion, ep);
            //                    listLineCanCat.Add(line1);
            //                    listLineCanCat.Add(line2);
            //                    isCat = true;
            //                    break;
            //                }
            //            }
            //        }
            //        if (isCat == false) listLineCatReult.Add(lineCancatItem);

            //    }
            //}

            //MEPSystemType mepSystemType = new FilteredElementCollector(doc).OfClass(typeof(MEPSystemType)).Cast<MEPSystemType>()
            //    .First(x => x.SystemClassification == MEPSystemClassification.Sanitary);

            //List<Pipe> listAllPipe = new List<Pipe>();
            //using (TransactionGroup tg = new TransactionGroup(doc, "GorupTran"))
            //{
            //    tg.Start();
            //    foreach (Line line in listLineCatReult)
            //    {
            //        using (Transaction t = new Transaction(doc, "CreatePipe"))
            //        {
            //            t.Start();
            //            var pipe = Pipe.Create(doc, mepSystemType.Id, pipeTypeStandard.Id, doc.ActiveView.GenLevel.Id, line.GetEndPoint(0), line.GetEndPoint(1));
            //            listAllPipe.Add(pipe);
            //            t.Commit();
            //        }
            //    }
            //    tg.Assimilate();
            //}


            //List<ConnectData> listConnectResult = new List<ConnectData>();


            //foreach (Pipe pipe in listAllPipe)
            //{
            //    ConnectorManager connectorManager = pipe.ConnectorManager;
            //    Connector startConnector = connectorManager.Lookup(0);
            //    Connector endConnector = connectorManager.Lookup(1);

            //    XYZ startConnectorPoint = startConnector.Origin;
            //    XYZ endConnectorPoint = endConnector.Origin;


            //    List<Connector> listConectorStart = new List<Connector>();
            //    listConectorStart.Add(startConnector);

            //    List<Connector> listConectorEnd = new List<Connector>();
            //    listConectorEnd.Add(endConnector);

            //    foreach (Pipe otherPipe in listAllPipe)
            //    {
            //        if (otherPipe.Id == pipe.Id) continue;
            //        ConnectorManager otherConnectorManager = otherPipe.ConnectorManager;
            //        Connector startConnectorOther = otherConnectorManager.Lookup(0);
            //        Connector endConnectorOther = otherConnectorManager.Lookup(1);

            //        XYZ startPointConnectorOther = startConnectorOther.Origin;
            //        XYZ endPointConnectorOther = endConnectorOther.Origin;

            //        if (startConnectorPoint.IsAlmostEqualTo(startPointConnectorOther, 0.0001))
            //        {
            //            listConectorStart.Add(startConnectorOther);
            //        }
            //        if (startConnectorPoint.IsAlmostEqualTo(endPointConnectorOther, 0.0001))
            //        {
            //            listConectorStart.Add(endConnectorOther);
            //        }

            //        if (endConnectorPoint.IsAlmostEqualTo(startPointConnectorOther, 0.0001))
            //        {
            //            listConectorEnd.Add(startConnectorOther);
            //        }
            //        if (endConnectorPoint.IsAlmostEqualTo(endPointConnectorOther, 0.0001))
            //        {
            //            listConectorEnd.Add(endConnectorOther);
            //        }
            //    }

            //    if (listConectorStart.Count >= 2)
            //    {
            //        if (!listConnectResult.Exists(x => x.PointConnect.IsAlmostEqualTo(startConnectorPoint, 0.0001)))
            //        {
            //            ConnectData connectorData = new ConnectData();
            //            connectorData.Connectors = listConectorStart;
            //            connectorData.PointConnect = startConnectorPoint;
            //            listConnectResult.Add(connectorData);
            //        }
            //    }
            //    if (listConectorEnd.Count >= 2)
            //    {
            //        if (!listConnectResult.Exists(x => x.PointConnect.IsAlmostEqualTo(endConnectorPoint, 0.00001)))
            //        {
            //            ConnectData connectorData = new ConnectData();
            //            connectorData.Connectors = listConectorEnd;
            //            connectorData.PointConnect = endConnectorPoint;
            //            listConnectResult.Add(connectorData);
            //        }
            //    }
            //}

            //using (Transaction t = new Transaction(doc, "CreateConnect"))
            //{
            //    t.Start();
            //    foreach (ConnectData data in listConnectResult)
            //    {
            //        if (data.Connectors.Count == 2) //ebow
            //        {
            //            doc.Create.NewElbowFitting(data.Connectors[0], data.Connectors[1]);
            //        }
            //        else if (data.Connectors.Count == 3) //tee
            //        {
            //            Connector connector1 = data.Connectors[0];
            //            Connector connector2 = data.Connectors[1];
            //            Connector connector3 = data.Connectors[2];
            //            Transform transform1 = connector1.CoordinateSystem;
            //            Transform transform2 = connector2.CoordinateSystem;
            //            Transform transform3 = connector3.CoordinateSystem;

            //            Connector subConnector = null;
            //            Connector mainConnector1 = null;
            //            Connector mainConnector2 = null;
            //            if (Math.Abs(Math.Abs(transform1.BasisZ.DotProduct(transform2.BasisZ)) - 1) < 0.0001)
            //            {
            //                subConnector = connector3;
            //                mainConnector1 = connector1;
            //                mainConnector2 = connector2;
            //            }
            //            else if (Math.Abs(Math.Abs(transform1.BasisZ.DotProduct(transform3.BasisZ)) - 1) < 0.0001)
            //            {
            //                subConnector = connector2;
            //                mainConnector1 = connector1;
            //                mainConnector2 = connector3;
            //            }
            //            else
            //            {
            //                subConnector = connector1;
            //                mainConnector1 = connector2;
            //                mainConnector2 = connector3;
            //            }

            //            doc.Create.NewTeeFitting(mainConnector1, mainConnector2, subConnector);
            //        }
            //    }
            //    t.Commit();
            //}
            #endregion




            return Result.Succeeded;

        }
    }

    public class ConnectData
    {
        public List<Connector> Connectors { set; get; }

        public XYZ PointConnect { set; get; }
    }
}