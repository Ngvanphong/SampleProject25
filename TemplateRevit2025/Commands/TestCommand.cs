using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
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
            if (family != null)
            {
                Location locationFa = family.Location;
                LocationPoint locationPoint = locationFa as LocationPoint;
                XYZ pointLo = locationPoint.Point;



                Transform transformNew = Transform.Identity;
                transformNew.Origin = pointLo;
                transformNew.BasisX = new XYZ(0, 1, 0);
                transformNew.BasisY = new XYZ(-1, 0, 0);
                transformNew.BasisZ = transformNew.BasisX.CrossProduct(transformNew.BasisY).Normalize();

                using (Transaction t = new Transaction(doc, "Rotaion"))
                {
                    t.Start();
                    Line lineAxis = Line.CreateUnbound(pointLo, XYZ.BasisZ);
                    ElementTransformUtils.RotateElement(doc, family.Id, lineAxis, Math.PI / 2);
                    XYZ vector = new XYZ(500 / 304.8, 0, 0);
                    ElementTransformUtils.MoveElement(doc, family.Id, vector);

                    Plane plane = Plane.CreateByNormalAndOrigin(XYZ.BasisX, pointLo);
                    ElementTransformUtils.MirrorElements(doc, new List<ElementId> { family.Id }, plane, false);
                    //ElementTransformUtils.MirrorElement(doc,  family.Id , plane);
                    //doc.Delete(family.Id);


                    t.Commit();
                }
                //Transform transformRo = family.GetTransform();
            }






            Pipe pipe = doc.GetElement(id) as Pipe;

            LocationCurve locationPipe = pipe.Location as LocationCurve;
            Line linePipe = locationPipe.Curve as Line;

            double startPa = linePipe.GetEndParameter(0);
            double endPara = linePipe.GetEndParameter(1);
            double midPara = (startPa + endPara) / 2;
            XYZ centerPoint = linePipe.Evaluate(midPara, false);


            Transform transformRota = Transform.CreateRotationAtPoint(XYZ.BasisZ, Math.PI / 4, centerPoint);
            Line rotationLine = linePipe.CreateTransformed(transformRota) as Line;
            double startParaRo = rotationLine.GetEndParameter(0);
            double endParaRo = rotationLine.GetEndParameter(1);

            XYZ moveVector = new XYZ(100/304.8, 0, 0);
            Transform traslate = Transform.CreateTranslation(moveVector);
            Line lineMove = rotationLine.CreateTransformed(traslate) as Line;

            //Transform reflectionTransform= Transform.CreateReflection()

            Transform transformRo2 = Transform.CreateRotation(XYZ.BasisZ, Math.PI);

            double extend = 500 / 304.8;
            double startParaExtend = startParaRo - extend / rotationLine.Length * (endParaRo - startParaRo);
            double endParaExtend = endParaRo + extend / rotationLine.Length * (endParaRo - startParaRo);
            rotationLine.MakeBound(startParaExtend, endParaExtend);

            using(Transaction t= new Transaction(doc, "ModifyPipe"))
            {
                t.Start();
                locationPipe.Curve = rotationLine;
                t.Commit();
            }


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
