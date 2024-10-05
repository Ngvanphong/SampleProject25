using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateRevit2025.Interfaces;

namespace TemplateRevit2025.Services
{
    public class PutFamilyByLineService : IPutFamilyByLineService
    {
        public XYZ GetDirectionAtPoint(Document doc, Curve curve, XYZ point)
        {
            if(curve is Line)
            {
                XYZ directionLine = (curve as Line).Direction.Normalize();
                XYZ viewDirection = doc.ActiveView.ViewDirection.Normalize();
                XYZ resultDirection = -directionLine.CrossProduct(viewDirection).Normalize();
                return resultDirection;
            }
            return null;
        }

        public IEnumerable<Family> GetFamilyFurniture(Document doc)
        {
            return new FilteredElementCollector(doc).OfClass(typeof(Family)).Cast<Family>()
                .Where(x => x.FamilyCategory.Id.Value == (long)BuiltInCategory.OST_Furniture);
        }

        public XYZ GetPointByDistance(Curve curve, double distance, out double para)
        {
            double length = curve.Length;
            double startPara = curve.GetEndParameter(0);
            double endPara = curve.GetEndParameter(1);
            double rate = distance / length;
            double dividePara = startPara + rate * (endPara - startPara);
            para = dividePara;

            //Curve newCurve= curve.Clone();
            //newCurve.MakeBound(startPara, dividePara);
            //return newCurve.GetEndPoint(1);

            XYZ pointResult = curve.Evaluate(dividePara, false);
            return pointResult;


        }

        

        public List<PointDirection> GetPointDirectionByLine(Document doc, List<ModelCurve> listModelCurve, double divide)
        {
            List<PointDirection> listResult = new List<PointDirection>();
            foreach (ModelCurve modelCurve in listModelCurve)
            {
                Curve curve = modelCurve.GeometryCurve;
                int countDivide = (int)Math.Ceiling(curve.Length / divide);
                double divideAfter = curve.Length / countDivide;
                double totalDivide = 0;
                for(int i = 0; i< countDivide-1; i++)
                {
                    totalDivide += divideAfter;
                    XYZ pointDivide= GetPointByDistance(curve, totalDivide, out double para);
                    if(curve is Line)
                    {
                        Line line = curve as Line;
                        XYZ directionLine = line.Direction.Normalize();
                        XYZ viewDirection = doc.ActiveView.ViewDirection.Normalize();
                        XYZ normalLine = directionLine.CrossProduct(viewDirection).Normalize();
                        PointDirection pointDir = new PointDirection();
                        pointDir.Point = pointDivide;
                        pointDir.Vector = normalLine;
                        listResult.Add(pointDir);
                    }
                    else
                    {
                        Transform transofom = curve.ComputeDerivatives(para, false);
                        XYZ vectorY = transofom.BasisY.Normalize();
                        PointDirection pointDir = new PointDirection();
                        pointDir.Point = pointDivide;
                        pointDir.Vector = vectorY;
                        listResult.Add(pointDir);
                    }
                }
                
            }
            return listResult;
        }

        public void RotaionElementToVector(Document doc,FamilyInstance familyInstance, PointDirection pointDirection)
        {
            XYZ originDirection = XYZ.BasisY;
            XYZ targetDirection = pointDirection.Vector;

            double angle = targetDirection.AngleTo(originDirection);

            XYZ axis = doc.ActiveView.ViewDirection.Normalize();
            Transform transform1 = Transform.CreateRotationAtPoint(axis, angle, pointDirection.Point);
            XYZ target1 = transform1.OfVector(originDirection).Normalize();
            double resultAngle = angle;
            if (target1.IsAlmostEqualTo(targetDirection,0.000001))
            {
                resultAngle = angle;
            }
            else if (target1.IsAlmostEqualTo(-targetDirection, 0.00001))
            {
                resultAngle = angle + Math.PI;
            }
            else 
            {
                resultAngle = -angle;
                Transform transform2 = Transform.CreateRotationAtPoint(axis, -angle, pointDirection.Point);
                XYZ target2 = transform2.OfVector(originDirection).Normalize();
                if (target2.IsAlmostEqualTo(targetDirection, 0.000001))
                {
                    resultAngle = -angle;
                }
            }

            Line lineAxis = Line.CreateUnbound(pointDirection.Point, axis);
            ElementTransformUtils.RotateElement(doc, familyInstance.Id, lineAxis, resultAngle);
            
        }
    }
}
