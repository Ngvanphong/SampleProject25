using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateRevit2025.Utilities;

namespace TemplateRevit2025.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class SaveData : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;

            Pipe mainPipe = null;
            Reference mainRef = uiDoc.Selection.PickObject(ObjectType.Element, "Pick main pipe");
            mainPipe = doc.GetElement(mainRef) as Pipe;

            Pipe subPipe = null;
            Reference subRefRef = uiDoc.Selection.PickObject(ObjectType.Element, "Pick sub pipe");
            subPipe = doc.GetElement(subRefRef) as Pipe;

            double angle = 10 * Math.PI / 180;

            LocationCurve locationCurve = mainPipe.Location as LocationCurve;
            Line lineMain = locationCurve.Curve as Line;
            XYZ start = locationCurve.Curve.GetEndPoint(0);
            XYZ end = locationCurve.Curve.GetEndPoint(1);

            XYZ pMainBot = null;
            XYZ pMainTop = null;
            if (start.Z < end.Z)
            {
                pMainBot = start;
                pMainTop = end;
            }
            else
            {
                pMainBot = end;
                pMainTop = start;
            }

            XYZ directionMain = pMainBot.Subtract(pMainTop).Normalize();

            XYZ vectorZMain = directionMain.CrossProduct(XYZ.BasisZ).Normalize();

            LocationCurve subLocation = subPipe.Location as LocationCurve;
            Line subLine = subLocation.Curve as Line;
            XYZ diretionSubLine = subLine.Direction.Normalize();

            XYZ centerCheck = subLine.GetEndPoint(0).Add(subLine.GetEndPoint(1)).Divide(2);
            XYZ vectorCheck = centerCheck.Subtract(pMainBot).Normalize();

            double dotZVectorCheck = vectorCheck.DotProduct(vectorZMain);
            XYZ vectorZMainTrue = null;
            XYZ axisRotae15 = null;
            if (dotZVectorCheck > 0.0001)
            {
                vectorZMainTrue = vectorZMain;
                axisRotae15 = directionMain;
            }
            else
            {
                vectorZMainTrue = -vectorZMain;
                axisRotae15 = -directionMain;
            }

            Transform transformRotateTru15 = Transform.CreateRotation(axisRotae15, -angle);
            XYZ vectorRotate15 = transformRotateTru15.OfVector(vectorZMainTrue);



            XYZ normalPlane = directionMain.CrossProduct(vectorRotate15).Normalize();

            Plane planeRote15 = Plane.CreateByNormalAndOrigin(normalPlane, pMainBot);


            XYZ startSub = subLine.GetEndPoint(0);
            XYZ intersectPoint = XYZCalculator.IntersectionPlaneByVector(planeRote15, diretionSubLine, startSub);

            XYZ axisPlane = normalPlane;
            Transform transformTru45 = Transform.CreateRotation(axisPlane, -Math.PI / 4);
            XYZ vectorRote45 = transformTru45.OfVector(directionMain).Normalize();

            double extend = 300000 / 304.8;
            XYZ p1 = intersectPoint - vectorRote45 * extend;
            XYZ p2 = intersectPoint + vectorRote45 * extend;
            Line lineInterct = Line.CreateBound(p1, p2);

            var intersectResult = lineMain.Intersect(lineInterct, out IntersectionResultArray resultInter);

            return Result.Succeeded;
        }
    }

   
}
