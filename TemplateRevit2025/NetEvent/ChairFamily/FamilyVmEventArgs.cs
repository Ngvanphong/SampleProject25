using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateRevit2025.ViewModel.ChairFamily;

namespace TemplateRevit2025.NetEvent.ChairFamily
{
    public class FamilyVmEventArgs: EventArgs
    {
        public FamillyVm DataSend { set; get; }

        public List<TypeVm> ListTypeVm { set; get; }


    }
}
