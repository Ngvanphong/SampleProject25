namespace TemplateRevit2025.NetEvent.Test
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
