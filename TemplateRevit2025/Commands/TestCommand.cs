using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Numerics;
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

            var ids= uiDoc.Selection.GetElementIds();
            ElementId id = ids.First();

            FamilyInstance family = doc.GetElement(id) as FamilyInstance;

            
     

            Location locationFa= family.Location;
            LocationPoint locationPoint = locationFa as LocationPoint;
            XYZ pointLo = locationPoint.Point;



            Transform transformNew = Transform.Identity;
            transformNew.Origin = pointLo;
            transformNew.BasisX = new XYZ(0, 1, 0);
            transformNew.BasisY = new XYZ(-1, 0, 0);
            transformNew.BasisZ = transformNew.BasisX.CrossProduct(transformNew.BasisY).Normalize();

            using (Transaction t= new Transaction(doc, "Rotaion"))
            {
                t.Start();
                Line lineAxis = Line.CreateUnbound(pointLo, XYZ.BasisZ);
                ElementTransformUtils.RotateElement(doc, family.Id, lineAxis, Math.PI / 2);
                t.Commit();
            }

            Transform transformRo = family.GetTransform();



            return Result.Succeeded;
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
