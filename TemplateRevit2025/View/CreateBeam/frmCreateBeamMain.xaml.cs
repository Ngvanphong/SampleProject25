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
using TemplateRevit2025.ViewModel.CreateBeam;

namespace TemplateRevit2025.View.CreateBeam
{
    /// <summary>
    /// Interaction logic for frmCreateBeamMain.xaml
    /// </summary>
    public partial class frmCreateBeamMain : Window
    {
        public ExternalEvent _createBeamEvent { get; set; }
        public frmCreateBeamMain()
        {
            InitializeComponent();
        }

        private void btnClick(object sender, RoutedEventArgs e)
        {
            _createBeamEvent.Raise();
        }
    }
}
