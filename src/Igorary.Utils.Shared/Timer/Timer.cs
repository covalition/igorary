using System;
using System.Threading;

namespace Igorary.Utils.Timer
{
    public class Timer : ITimer, IDisposable
    {
        readonly System.Threading.Timer _timer;
        bool _disposedValue;
        readonly int _interval;

        public bool IsStarted { get; set; }

        public Timer(TimerCallback callback, int interval)
        {
            _timer = new System.Threading.Timer(callback, null, Timeout.Infinite, 0);
            _interval = interval;
        }

        public void SetStarted(bool started)
        {
            _timer.Change(started ? 0 : Timeout.Infinite, _interval);
            IsStarted = started;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _timer.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Timer()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
