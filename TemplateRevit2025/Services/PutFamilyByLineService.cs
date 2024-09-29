using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
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

        public XYZ GetPointByDistance(Curve curve, double distance)
        {
            double length = curve.Length;
            double startPara= curve.GetEndParameter(0);
            double endPara = curve.GetEndParameter(1);
            double rate = distance / length;
            double dividePara= startPara + rate *(endPara-startPara);
            Curve newCurve= curve.Clone();
            newCurve.MakeBound(startPara, dividePara);
            return newCurve.GetEndPoint(1);
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
                    XYZ pointDivide= GetPointByDistance(curve, totalDivide);


                }



            }
            return null;
        }
    }
}
