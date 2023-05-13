using System;

namespace Igorary.Utils.CurrentTime
{
    /// <summary>
    /// Provides current time.
    /// </summary>
    public class CurrentTimeService : ICurrentTimeService
    {
        public DateTime Now => DateTime.Now;
    }
}
