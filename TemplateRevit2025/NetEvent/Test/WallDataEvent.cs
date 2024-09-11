using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateRevit2025.Utilities.Events.DataToView
{
   public class WallDataEvent
    {
        public event EventHandler<WallDataReachedEventArgs> EventWallDataReached;
        public virtual void Raise(WallDataReachedEventArgs e)
        {
            EventWallDataReached?.Invoke(this, e);
        }
    }
}
