using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateRevit2025.Interfaces
{
    public class PointDirection
    {
        public XYZ Point { set; get; }
        public XYZ Vector { set; get; }
    }
    interface IPutFamilyByLineService
    {
        IEnumerable<Family> GetFamilyFurniture(Document doc);

        XYZ GetPointByDistance(Curve curve, double distance);

        XYZ GetDirectionAtPoint(Document doc,Curve curve, XYZ point);

        List<PointDirection> GetPointDirectionByLine(Document doc,List<ModelCurve> listModelCurve,
            double divide);
    }
}
