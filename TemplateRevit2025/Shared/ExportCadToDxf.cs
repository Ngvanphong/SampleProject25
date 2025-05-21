using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace TemplateRevit2025.Shared
{
    public class ExportCadToDxf
    {
        public static string ExportToDxf(Document doc, ImportInstance cadImport)
        {
            string tempFolder = Path.GetTempPath();
            string nameFile = "CadExport" + Guid.NewGuid().ToString() + ".dxf";
            using(Transaction t= new Transaction(doc, "Export"))
            {
                t.Start();

                var allElementIdInView= new FilteredElementCollector(doc,doc.ActiveView.Id)
                    .WhereElementIsNotElementType().Where(x=>x.CanBeHidden(doc.ActiveView))
                    .Select(el=>el.Id).ToList();
                allElementIdInView.Remove(cadImport.Id);
                doc.ActiveView.HideElements(allElementIdInView);

                doc.Regenerate();

                ICollection<ElementId> viewSets= new HashSet<ElementId>();
                viewSets.Add(doc.ActiveView.Id);

                DXFExportOptions dxfExportOption= new DXFExportOptions();
                dxfExportOption.FileVersion = ACADVersion.R2013;
                doc.Export(tempFolder, nameFile, viewSets,dxfExportOption);

                t.Commit();
            }
            return Path.Combine(tempFolder, nameFile);
        }
    }
}
