using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateRevit2025.Utilities;

namespace TemplateRevit2025.ViewModel.CreateBeam
{
    class MainVM : ViewModelBase
    {
        private  SubLeftVM _leftView;
        public SubLeftVM LeftView
        {
            get { return _leftView;}
            set { _leftView = value; OnPropertyChanged(); }
        }

        private SubRightVM _rightView;
        public SubRightVM RightView
        {
            get { return _rightView; }
            set { _rightView = value;OnPropertyChanged(); }
        }
    }
}
