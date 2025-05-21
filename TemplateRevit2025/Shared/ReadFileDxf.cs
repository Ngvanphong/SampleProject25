using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using netDxf;
using netDxf.Blocks;
using netDxf.Entities;
using revit = Autodesk.Revit.DB;

namespace TemplateRevit2025.Shared
{
    public class ReadFileDxf
    {
        public static HashSet<string> GetLayerName(revit.Document doc ,revit.ImportInstance cadImport)
        {
            HashSet<string> hashSetString = new HashSet<string>();
            var options = new revit.Options();
            options.IncludeNonVisibleObjects = false;
            options.ComputeReferences = true;
            options.View = doc.ActiveView;
            revit.GeometryElement geoEle = cadImport.get_Geometry(options);
            foreach (revit.GeometryObject geoOjb in geoEle)
            {
                if ( geoOjb  is revit.GeometryInstance)
                {
                    revit.GeometryInstance geoInst = geoOjb as revit.GeometryInstance;
                    foreach(revit.GeometryObject geoObj2 in geoInst.GetInstanceGeometry())
                    {
                        if(geoObj2 is revit.Line)
                        {
                            revit.Line line = geoObj2 as revit.Line;
                            revit.GraphicsStyle graphicStyle = doc.GetElement(line.GraphicsStyleId) as revit.GraphicsStyle;
                            hashSetString.Add(graphicStyle.GraphicsStyleCategory.Name);
                        }
                        else if(geoObj2 is revit.Arc) 
                        { 
                        }
                    }
                }
            }
            return hashSetString;

        }
        public static List<revit.Line> GetAllLineDxf(string fullPath, revit.Transform transformRevit)
        {
            List<revit.Line> lines = new List<revit.Line>();
            var docDxf= DxfDocument.Load(fullPath);
            foreach(Block block in docDxf.Blocks)
            {
                foreach(var entity in block.Entities)
                {
                    if(entity is netDxf.Entities.Line)
                    {
                        Line lineItem= entity as Line;
                        if(lineItem.Layer!=null && lineItem.Layer.Name == "S-GRID")
                        {
                            revit.XYZ st = new revit.XYZ(lineItem.StartPoint.X/304.8, lineItem.StartPoint.Y / 304.8, lineItem.StartPoint.Z / 304.8);
                            revit.XYZ end = new revit.XYZ(lineItem.EndPoint.X / 304.8, lineItem.EndPoint.Y / 304.8, lineItem.EndPoint.Z / 304.8);
                            revit.Line lineRevit = revit.Line.CreateBound(st, end);
                            revit.Line lineRevitNew = lineRevit.CreateTransformed(transformRevit) as revit.Line;
                            lines.Add(lineRevitNew);
                        }
                    }
                    else if(entity is netDxf.Entities.Polyline2D)
                    {

                    }
                    else if(entity is netDxf.Entities.Text)
                    {

                    }
                    else if (entity is netDxf.Entities.MText)
                    {

                    }
                }
            }
            return lines;
        }
    }
}
