using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Windows;
using Microsoft.Extensions.Logging;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;
using TemplateRevit2025.Interfaces;
using TemplateRevit2025.Model.Test;
using TemplateRevit2025.RevitHandler.Test;
using TemplateRevit2025.Utilities;
using TemplateRevit2025.View.Test;
using TemplateRevit2025.ViewModel.Test;

namespace TemplateRevit2025.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class TestCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc= uiDoc.Document;

            FamilyInstance fcu = null;
            try
            {
                var refFCU = uiDoc.Selection.PickObject(ObjectType.Element, new FamilyInstanceFilter(), "Pick FCU");
                fcu = doc.GetElement(refFCU) as FamilyInstance;
            }
            catch
            {
                return Result.Succeeded;
            }

            Duct duct = null;
            try
            {
                var refDuct = uiDoc.Selection.PickObject(ObjectType.Element, new DuctFitler(), "Pick Duct");
                duct = doc.GetElement(refDuct) as Duct;
            }
            catch
            {
                return Result.Succeeded;
            }

            XYZ connectorLocation = null;
            try
            {
                connectorLocation = uiDoc.Selection.PickPoint("Pick connector");
            }
            catch
            {
                return Result.Succeeded;
            }

            
            MEPModel mepModel = fcu.MEPModel;
            ConnectorManager connectorManager = mepModel.ConnectorManager;
            double disntaceMin = 100000000;
            Connector connectorTarget = null;
            ConnectorSet connectorSet = connectorManager.Connectors;

            foreach (Connector connector in connectorSet)
            {
                XYZ locationItem = connector.Origin;
                if (locationItem != null)
                {
                    double d = locationItem.DistanceTo(connectorLocation);
                    if (d < disntaceMin)
                    {
                        disntaceMin = d;
                        connectorTarget = connector;
                    }
                }

            }
            Connector ductConnect = null;
            ConnectorManager ductConnectorManager = duct.ConnectorManager;
            double distMin2 = 10000000;
            ConnectorSet connectSetDuct = ductConnectorManager.Connectors;
            foreach (Connector item in connectSetDuct)
            {
                XYZ locationItem = item.Origin;
                if (locationItem != null)
                {
                    double d = locationItem.DistanceTo(connectorTarget.Origin);
                    if (d < distMin2)
                    {
                        distMin2 = d;
                        ductConnect = item;
                    }
                }
            }

            //Duct newDuct = null;
            
            ElementId idLevel = duct.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM).AsElementId();
            Level level = doc.GetElement(idLevel) as Level;
            double length = 600 / 304.8;
            XYZ directionTargetConnect = connectorTarget.CoordinateSystem.BasisZ.Normalize();
            XYZ point600 = connectorTarget.Origin + directionTargetConnect * length;

            //using (Transaction t1 = new Transaction(doc, "CreateDuct"))
            //{
            //    t1.Start();

            //    var type = duct.DuctType;
            //    newDuct = Duct.Create(doc, type.Id, idLevel, connectorTarget, point600);
            //    t1.Commit();
            //}
            // connect two 
            //var interator = newDuct.ConnectorManager.Connectors.GetEnumerator();
            //interator.Reset();
            //interator.MoveNext();
            //interator.MoveNext();
            //Connector endConnectNewDuct = interator.Current as Connector;
            using (Transaction t1 = new Transaction(doc, "CreateDuct2"))
            {
                t1.Start();
                doc.Create.NewTransitionFitting(ductConnect, connectorTarget);
                
                t1.Commit();
            }

            ConnectorSet connectorset = duct.ConnectorManager.Connectors;
            
            //using (Transaction t1 = new Transaction(doc, "Trasitrion"))
            //{
            //    t1.Start();
            //    ductConnect.ConnectTo(connectorTarget);
            //    t1.Commit();
            //}


            return Result.Succeeded;
        }
    }

    class DuctFitler : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem.Category != null && elem.Category.Id.Value == (long)BuiltInCategory.OST_DuctCurves)
            {
                return true;
            }
            return false;
                
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return true;
        }
    }

    class FamilyInstanceFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if(elem is FamilyInstance)
            {
                return true;
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return true;
        }
    }

    class FurnitureFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if(elem.Category !=null && elem.Category.Id.Value == (long)BuiltInCategory.OST_Furniture)
            {
                return true;
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return true;
        }
    }
}
