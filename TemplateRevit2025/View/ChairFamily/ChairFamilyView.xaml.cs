using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TemplateRevit2025.NetEvent.Test;

namespace TemplateRevit2025.View.ChairFamily
{
    /// <summary>
    /// Interaction logic for ChairFamilyView.xaml
    /// </summary>
    public partial class ChairFamilyView : Window
    {
        public ExternalEvent GetTypeEvent { set; get; }
        public WallDataEvent sendEventToRevitHanler;
        public ChairFamilyView()
        {
            InitializeComponent();
            sendEventToRevitHanler = new WallDataEvent();  

        }

        private void btnOk(object sender, RoutedEventArgs e)
        {

        }

        private void comboboxFamilyChanged(object sender, SelectionChangedEventArgs e)
        {
            WallDataReachedEventArgs argss=new WallDataReachedEventArgs();
            argss.WallData = new Model.Test.InstanceCus() {Name= "10" };
            sendEventToRevitHanler.Raise(argss);
            GetTypeEvent.Raise();
        }

        private void UpdateComboxboxType()
        {
            
        }
    }
}
