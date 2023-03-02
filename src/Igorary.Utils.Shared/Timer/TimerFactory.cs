using System;
using System.Threading;

namespace Igorary.Utils.Timer
{
    public class TimerFactory : ITimerFactory
    {
        public ITimer CreateTimer(TimerCallback callback, int interval)
        {
            return new Timer(callback, interval);
        }
    }
}
