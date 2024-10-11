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
using TemplateRevit2025.NetEvent.ChairFamily;
using TemplateRevit2025.NetEvent.Test;
using TemplateRevit2025.ViewModel.ChairFamily;

namespace TemplateRevit2025.View.ChairFamily
{
    /// <summary>
    /// Interaction logic for ChairFamilyView.xaml
    /// </summary>
    public partial class ChairFamilyView : Window
    {
        public ExternalEvent GetTypeEvent { set; get; }

        public FamilyDataEvent _familySendEvent { set; get; }


        public void SetListTypeVm(object sender, FamilyVmEventArgs sendData)
        {
            var dataContext = this.DataContext as ChairFamilyVM;
            dataContext.Types = sendData.ListTypeVm;
        }
        public ChairFamilyView()
        {
            InitializeComponent();
            _familySendEvent = new FamilyDataEvent();
            
        }

        private void btnOk(object sender, RoutedEventArgs e)
        {

        }

        private void comboboxFamilyChanged(object sender, SelectionChangedEventArgs e)
        {
           
            FamilyVmEventArgs args = new FamilyVmEventArgs();
            args.DataSend = (sender as System.Windows.Controls.ComboBox).SelectedItem as FamillyVm;

            _familySendEvent.Raise(args); // noi phat su kien;

            GetTypeEvent.Raise(); // de truy cap xuong revit get type va gian source combobox;


        }

        private void UpdateComboxboxType()
        {
            
        }
    }
}
