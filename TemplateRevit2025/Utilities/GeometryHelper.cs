using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateRevit2025.Utilities
{
    public class GeometryHelper
    {
        public static void GetGeometryAll(Element element, Options option,ref List<Solid> listSolidResult)
        {
            GeometryElement geoElement = element.get_Geometry(option);
            foreach(GeometryObject geoObj in geoElement)
            {
                Solid solid = geoObj as Solid;
                if (solid != null && solid.Volume > 0.000001) listSolidResult.Add(solid);
                else
                {
                    var geomInst = geoObj as GeometryInstance;
                    if(geomInst != null)
                    {
                        GetInstanceGeo(geomInst, ref listSolidResult);
                    }
                }
            }
        }

        private static void GetInstanceGeo(GeometryInstance geoInst, ref List<Solid> listSolidResult)
        {
            foreach(GeometryObject geoObj in geoInst.GetInstanceGeometry())
            {
                if (geoObj is Solid solid && solid.Volume > 0.000001) listSolidResult.Add(solid);
                else
                {
                    if (geoObj is GeometryInstance subGeonInst) GetInstanceGeo(subGeonInst, ref listSolidResult);
                }
            }
        }


    }
}
