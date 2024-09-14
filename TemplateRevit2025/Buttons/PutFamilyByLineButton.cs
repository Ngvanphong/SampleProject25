using Autodesk.Revit.UI;
using TemplateRevit2025.Commands;
using TemplateRevit2025.Utilities;

namespace TemplateRevit2025.Buttons;

public class PutFamilyByLineButton
{
    public void Create(UIControlledApplication application)
    {
        RibbonPanel ribbonPanel= application.CreatePanel(AppConstant.PanelAr, AppConstant.TabName);
        PushButton pushButton = ribbonPanel.AddPushButton(typeof(PutFamilyByLineCommand), "Put \n Family");
        pushButton.SetImage("/TemplateRevit2025;component/Resources/Images/icons8-crop-24 (3).png");
        pushButton.SetLargeImage("/TemplateRevit2025;component/Resources/Images/icons8-crop-24 (3).png");
    }
}