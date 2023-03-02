using System.Threading;

namespace Igorary.Utils.Timer
{
    public interface ITimerFactory
    {
        ITimer CreateTimer(TimerCallback callback, int interval);
    }
}
