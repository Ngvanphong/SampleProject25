using TemplateRevit2025.Model.Test;

namespace TemplateRevit2025.NetEvent.Test
{
    public class WallDataReachedEventArgs : EventArgs
    {
        public InstanceCus WallData { set; get; }

    }
}
