using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateRevit2025.Utilities
{
    public static class XYZCalculator
    {
        public static XYZ IntersectionPlaneByVector(Plane plane, XYZ followVector, XYZ point)
        {
            XYZ originPlane = plane.Origin;
            XYZ normalPlane = plane.Normal;

            double dotPlaneWithFolowVector = normalPlane.Normalize().DotProduct(followVector);
            if (Math.Abs(dotPlaneWithFolowVector) < 0.000000000001)
            {
                return null;
            }
            double lineParameter = (normalPlane.DotProduct(originPlane)
                - normalPlane.DotProduct(point))
            / normalPlane.DotProduct(followVector);

            return point + lineParameter * followVector;
        }

    }
}
