using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Internal.InfoCenter;
using TemplateRevit2025.Utilities;

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
            //            connectorData.PointConnect = startConnectorPoint;``
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

            //Transform transfomrLeft = null;
            //XYZ subDirection = null;
            //double length = 1000/304.8;
            //XYZ directionLeft = -subDirection.Normalize() * length / 2;
            //Transform transformLeft = Transform.CreateTranslation(directionLeft);
            //XYZ leftPOint= transfomrLeft.OfPoint(midPoint);

            //double angle = Math.PI / 2 - 30 / 180 * Math.PI;

            // length/Math.Tan(angle)

            #region lay connector out of family
            FamilyInstance plumpingFixture = null;
            MEPModel mepModel = plumpingFixture.MEPModel;
            ConnectorManager connectorManager= mepModel.ConnectorManager;
            Connector connectorOut = null;
            foreach(Connector connector in connectorManager.Connectors)
            {
                if(connector.Direction== FlowDirectionType.Out)
                {
                    connectorOut = connector;
                    break;
                }
            }

            XYZ positionConnectorOut = connectorOut.CoordinateSystem.Origin;

            Pipe mainPipe = null;
            LocationCurve locaitonCuve = mainPipe.Location as LocationCurve;
            Line lineMainPipe = locaitonCuve.Curve as Line;
            XYZ directionMainPipe = lineMainPipe.Direction.Normalize();
            XYZ sMainPoint = lineMainPipe.GetEndPoint(0);
            XYZ eMainPoint = lineMainPipe.GetEndPoint(1);
            XYZ directionUpToDown = null;
            if (sMainPoint.Z > eMainPoint.Z) directionUpToDown = directionMainPipe;
            else directionUpToDown = -directionMainPipe;
            XYZ vectorMainExceputZ = sMainPoint.Subtract(new XYZ(eMainPoint.X, eMainPoint.Y, sMainPoint.Z)).Normalize();
            XYZ vectorRotate = null;
            if (vectorMainExceputZ.IsAlmostEqualTo(XYZ.BasisX) || vectorMainExceputZ.IsAlmostEqualTo(-XYZ.BasisX))
            {
                vectorRotate = XYZ.BasisY;
            }
            else 
            {
                vectorRotate = XYZ.BasisX;
            }
            //xoay theo do doc cua main


            XYZ interseciton = null;
            XYZ upToDown = null;
            Transform transfomr1 = Transform.CreateTranslation(upToDown * 1000 / 304.8);
            XYZ point1000 = transfomr1.OfPoint(interseciton);

            // var point10002 = interseciton + upToDown * 1000 / 304.8;

            //Transform transfomrRotation1= Transform.CreateRotation(,)
            double tanApha = 0.01;
            double angle = Math.Atan(tanApha);
            Transform transformRot1 = null;
            Transform transformRot2 = null;

            //XYZ vectorAfterRot1= transfomr1.OfVector()

            //Plane plane= Plane.CreateByNormalAndOrigin()

            XYZ p1 = null;
            XYZ p2 = null;

            XYZ p1RoP2 = p2 - p1;

            XYZ pointOuter = null;
            bool isTrueP1 = false;
            if(p1.Z < pointOuter.Z && p2.Z > pointOuter.Z)
            {
                isTrueP1 = true;
            }
            else if(p1.Z > pointOuter.Z && p2.Z < pointOuter.Z)
            {
                isTrueP1 = false;
            }
            else
            {
                double d1= pointOuter.DistanceTo(p1);
                double d2= pointOuter.DistanceTo(p2);
                if(d1< d2)
                {
                    isTrueP1 = true;
                }
                else
                {
                    isTrueP1 = false;
                }
            }




            FamilyInstance teee = null;
            teee.LookupParameter("Angle").AsDouble();
            string familyName = "M_Tee - Generic";

            Family familyTee = new FilteredElementCollector(doc).OfClass(typeof(Family)).Cast<Family>().
                Where(x => x.FamilyCategory.Id.Value == (long)BuiltInCategory.OST_PipeFitting).
                First(x => x.Name == familyName);

            FamilySymbol typeTee = doc.GetElement(familyTee.GetFamilySymbolIds().First()) as FamilySymbol;
            FamilyInstance teeInstance = null;
            XYZ point = null;
            using(Transaction t= new Transaction(doc, "PutFamily"))
            {
                t.Start();
                if (typeTee.IsActive==false)
                {
                    typeTee.Activate();
                }
                teeInstance = doc.Create.NewFamilyInstance(point, typeTee, Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
                t.Commit();
            }

            //doc.Create.NewFamilyInstance()

            List<FamilyInstance> listAirTermial = new List<FamilyInstance>();
            Duct mainDuct = null;

            List<Connector> listConnectorTerminal = new List<Connector>();
            foreach(FamilyInstance termial in listAirTermial)
            {
                MEPModel mepModelTerminal = termial.MEPModel;
                if (mepModelTerminal != null)
                {
                    ConnectorManager connectorManagerAT = mepModelTerminal.ConnectorManager;
                    Connector connectorAT = connectorManagerAT.Lookup(0);
                    listConnectorTerminal.Add(connectorAT);
                }

            }

            LocationCurve locationMainDuct = mainDuct.Location as LocationCurve;
            Line lineMainDuct = locationMainDuct.Curve as Line;
            XYZ directionMainDuct = lineMainDuct.Direction.Normalize();


            ElementId mainDuctTypeId = mainDuct.GetTypeId();
            ElementId mainDuctLevel = mainDuct.LevelId;
            ElementId mainDuctSystemTypeId = mainDuct.get_Parameter(BuiltInParameter.RBS_DUCT_SYSTEM_TYPE_PARAM).AsElementId();

            foreach(Connector connectorAT in listConnectorTerminal)
            {
                XYZ pointConnector = connectorAT.Origin;
                Plane planeConnectorAT = Plane.CreateByNormalAndOrigin(directionMainDuct, pointConnector);
                XYZ pointIntersect = XYZCalculator.IntersectionPlaneByVector(planeConnectorAT, directionMainDuct, lineMainDuct.GetEndPoint(0));

                XYZ directionIntersectToConnectorAT = new XYZ(pointConnector.X, pointConnector.Y, pointIntersect.Z).Subtract(pointIntersect).Normalize();

                Transform transform200 = Transform.CreateTranslation(directionIntersectToConnectorAT * 200 / 304.8);
                XYZ point200 = transform200.OfPoint(pointIntersect);
                XYZ point400 = transform200.OfPoint(point200);

                Duct ductSub = null;
                using(Transaction t= new Transaction(doc, "CreateSub"))
                {
                    t.Start();
                    ductSub = Duct.Create(doc, mainDuctSystemTypeId, mainDuctTypeId, mainDuctLevel, point200, point400);
                    t.Commit();
                }

                Connector connecor200 = ductSub.ConnectorManager.Lookup(0);
                Connector connecor400 = ductSub.ConnectorManager.Lookup(1);

                FamilyInstance takeOff = null;
                using (Transaction t = new Transaction(doc, "CreateSub"))
                {
                    t.Start();
                    doc.Create.NewTakeoffFitting(connecor200, mainDuct);
                    t.Commit();
                }

                Family familyDA = new FilteredElementCollector(doc).OfClass(typeof(Family)).Cast<Family>()
                    .First(x => x.Name == "M_Fire Damper - Rectangular - Simple");
                ElementId idSyl = familyDA.GetFamilySymbolIds().First();
                FamilySymbol fammilySymbol = doc.GetElement(idSyl) as FamilySymbol;

                FamilyInstance ductAccessory = null;
                using (Transaction t = new Transaction(doc, "CreateSub"))
                {
                    t.Start();
                    if (!fammilySymbol.IsActive) fammilySymbol.Activate();
                    ductAccessory = doc.Create.NewFamilyInstance(point400, fammilySymbol, Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
                    t.Commit();
                }

                MEPModel mepModelAccessory = ductAccessory.MEPModel ;
                Connector connecorAC1 = mepModelAccessory.ConnectorManager.Lookup(0);
                XYZ directionAC1 = connecorAC1.CoordinateSystem.BasisZ.Normalize();
                XYZ directionSub = point400.Subtract(point200).Normalize();

                double angleRotation = FindAngleRotaion(directionAC1, directionSub, XYZ.BasisZ);

                if( Math.Abs(angleRotation)> 0.0001)
                {
                    using (Transaction t = new Transaction(doc, "CreateSub"))
                    {
                        t.Start();
                        Line lineAxis = Line.CreateUnbound(point400, XYZ.BasisZ);
                        ElementTransformUtils.RotateElement(doc, ductAccessory.Id, lineAxis, angleRotation);
                        t.Commit();
                    }
                }

                //
                //doc.Create.NewFlexDuct()


                //Autodesk.Revit.DB.Connector connecor1 = null;
                //connecor1.ConnectTo()
                ViewFamilyType typeOfSection = new FilteredElementCollector(doc).OfClass(typeof(ViewFamilyType)).Cast<ViewFamilyType>().First();
                BoundingBoxXYZ boundaingBox = new BoundingBoxXYZ();
                Transform transformSection = Transform.Identity;
                transformSection.Origin = null;
                transformSection.BasisX = null;// truc cua ong
                transformSection.BasisY = XYZ.BasisZ;
                transformSection.BasisZ = transformSection.BasisX.CrossProduct(transformSection.BasisY);

                boundaingBox.Transform = transformSection;
                double length = 1000; // chieu dai cua ong
                double radius = 100;// ban kinh cua ong
                XYZ min = new XYZ(-length / 2, 0, -radius);
                XYZ max = new XYZ(length / 2, -radius, radius);
                boundaingBox.Min = min;
                boundaingBox.Max = max;


                ViewSection.CreateSection(doc, typeOfSection.Id, boundaingBox);

            }


            #endregion
            return Result.Succeeded;

        }

        public static double FindAngleRotaion(XYZ originDirection, XYZ targetDirection, XYZ vectorAxis)
        {
            double angleResult = 0;
            double angle = targetDirection.AngleTo(originDirection);
            targetDirection = targetDirection.Normalize();
            XYZ viewDirection = vectorAxis.Normalize();
            Transform transform1 = Transform.CreateRotation(viewDirection, angle);
            XYZ vectorNew1 = transform1.OfVector(originDirection).Normalize();
            if (vectorNew1.IsAlmostEqualTo(targetDirection, 0.0001))
            {
                angleResult = angle;
            }
            else if (vectorNew1.IsAlmostEqualTo(-targetDirection, 0.0001))
            {
                angleResult = angle + Math.PI;
            }
            else
            {
                angleResult = -angle;
                Transform transform2 = Transform.CreateRotation(viewDirection, -angle);
                XYZ vectorNew2 = transform2.OfVector(originDirection).Normalize();
                if (vectorNew2.IsAlmostEqualTo(targetDirection, 0.0001))
                {
                    angleResult = -angle;
                }
                else
                {
                    angleResult = -angle + Math.PI;
                }
            }
            return angleResult;
        }
    }

    public class ConnectData
    {
        public List<Connector> Connectors { set; get; }

        public XYZ PointConnect { set; get; }
    }
}