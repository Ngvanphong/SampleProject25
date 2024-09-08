using Autodesk.Revit.UI;
using AdWindow = Autodesk.Windows;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace TemplateRevit2025.Utilities
{
    public static class RibbonExternsion
    {
        public static RibbonPanel CreatePanel(this UIControlledApplication application, string panelName)
        {
            RibbonPanel ribbonPanel = null;
            foreach (var panel in application.GetRibbonPanels(Tab.AddIns))
            {
                if (panel.Name.Equals(panelName))
                {
                    ribbonPanel = panel;
                    break;
                }
            }

            return ribbonPanel ?? application.CreateRibbonPanel(panelName);
        }

        public static RibbonPanel CreatePanel(this UIControlledApplication application, string panelName, string tabName)
        {
            AdWindow.RibbonTab ribbonTab = null;
            foreach (var tab in AdWindow.ComponentManager.Ribbon.Tabs)
            {
                if (tab.Id.Equals(tabName))
                {
                    ribbonTab = tab;
                    break;
                }
            }

            if (ribbonTab is null)
            {
                application.CreateRibbonTab(tabName);
                return application.CreateRibbonPanel(tabName, panelName);
            }

            RibbonPanel ribbonPanel = null;
            foreach (var panel in application.GetRibbonPanels(tabName))
            {
                if (panel.Name.Equals(panelName))
                {
                    ribbonPanel = panel;
                    break;
                }
            }

            return ribbonPanel ?? application.CreateRibbonPanel(tabName, panelName);
        }

        public static PushButton AddPushButton(this RibbonPanel panel, Type command, string buttonText)
        {
            var pushButtonData = new PushButtonData(command.FullName, buttonText, Assembly.GetAssembly(command)!.Location, command.FullName);
            return (PushButton)panel.AddItem(pushButtonData);
        }

        public static PushButton AddPushButton<TCommand>(this RibbonPanel panel, string buttonText) where TCommand : IExternalCommand, new()
        {
            var command = typeof(TCommand);
            var pushButtonData = new PushButtonData(command.FullName, buttonText, Assembly.GetAssembly(command)!.Location, command.FullName);
            return (PushButton)panel.AddItem(pushButtonData);
        }

        public static PulldownButton AddPullDownButton(this RibbonPanel panel, string internalName, string buttonText)
        {
            var pushButtonData = new PulldownButtonData(internalName, buttonText);
            return (PulldownButton)panel.AddItem(pushButtonData);
        }

        public static SplitButton AddSplitButton(this RibbonPanel panel, string internalName, string buttonText)
        {
            var pushButtonData = new SplitButtonData(internalName, buttonText);
            return (SplitButton)panel.AddItem(pushButtonData);
        }

        public static RadioButtonGroup AddRadioButtonGroup(this RibbonPanel panel, string internalName)
        {
            var pushButtonData = new RadioButtonGroupData(internalName);
            return (RadioButtonGroup)panel.AddItem(pushButtonData);
        }


        public static  Autodesk.Revit.UI.ComboBox AddComboBox(this RibbonPanel panel, string internalName)
        {
            var pushButtonData = new ComboBoxData(internalName);
            return (Autodesk.Revit.UI.ComboBox)panel.AddItem(pushButtonData);
        }

        public static Autodesk.Revit.UI.TextBox AddTextBox(this RibbonPanel panel, string internalName)
        {
            var pushButtonData = new TextBoxData(internalName);
            return (Autodesk.Revit.UI.TextBox)panel.AddItem(pushButtonData);
        }

        public static PushButton AddPushButton(this PulldownButton pullDownButton, Type command, string buttonText)
        {
            var pushButtonData = new PushButtonData(command.FullName, buttonText, Assembly.GetAssembly(command)!.Location, command.FullName);
            return pullDownButton.AddPushButton(pushButtonData);
        }

        public static PushButton AddPushButton<TCommand>(this PulldownButton pullDownButton, string buttonText) where TCommand : IExternalCommand, new()
        {
            var command = typeof(TCommand);
            var pushButtonData = new PushButtonData(command.FullName, buttonText, Assembly.GetAssembly(command)!.Location, command.FullName);
            return pullDownButton.AddPushButton(pushButtonData);
        }

        public static RibbonButton SetImage(this RibbonButton button, string uri)
        {
            button.Image = new BitmapImage(new Uri(uri, UriKind.RelativeOrAbsolute));
            return button;
        }

        public static RibbonButton SetLargeImage(this RibbonButton button, string uri)
        {
            button.LargeImage = new BitmapImage(new Uri(uri, UriKind.RelativeOrAbsolute));
            return button;
        }

        public static RibbonButton SetAvailabilityController<T>(this PushButton button) where T : IExternalCommandAvailability, new()
        {
            button.AvailabilityClassName = typeof(T).FullName;
            return button;
        }


    }
}
