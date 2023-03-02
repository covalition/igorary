using System;

namespace Igorary.Utils.CurrentTime
{
    public interface ICurrentTimeService
    {
        DateTime Now { get; }
    }
}
