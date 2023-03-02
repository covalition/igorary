using System;

namespace Igorary.Utils.CurrentTime
{
    public class CurrentTimeService : ICurrentTimeService
    {
        public DateTime Now => DateTime.Now;
    }
}
