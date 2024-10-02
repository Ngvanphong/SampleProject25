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

namespace TemplateRevit2025.View.ChairFamily
{
    /// <summary>
    /// Interaction logic for ChairFamilyView.xaml
    /// </summary>
    public partial class ChairFamilyView : Window
    {
        public ExternalEvent GetTypeEvent { set; get; }
        public ChairFamilyView()
        {
            InitializeComponent();
        }

        private void btnOk(object sender, RoutedEventArgs e)
        {

        }

        private void comboboxFamilyChanged(object sender, SelectionChangedEventArgs e)
        {

            GetTypeEvent.Raise();
        }

        private void UpdateComboxboxType()
        {
            
        }
    }
}
