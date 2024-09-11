using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateRevit2025.Model.Test;

namespace TemplateRevit2025.Utilities.Events.DataToView
{
    public class WallDataReachedEventArgs : EventArgs
    {
        public InstanceCus WallData { set; get; }

    }
}
