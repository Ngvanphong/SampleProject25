using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateRevit2025.NetEvent.Test;

namespace TemplateRevit2025.NetEvent.ChairFamily
{
    public class FamilyDataEvent
    {
        public event EventHandler<FamilyVmEventArgs> FamilyComboboxChangeEvent;
        public virtual void Raise(FamilyVmEventArgs sendData)
        {
            FamilyComboboxChangeEvent?.Invoke(this, sendData);
        }
    }
}
