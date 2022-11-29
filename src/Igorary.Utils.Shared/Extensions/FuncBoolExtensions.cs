using System;
using System.Threading;
using System.Threading.Tasks;

namespace Igorary.Utils.Extensions
{
    public static class FuncBoolExtensions
    {
        public static async Task WaitForIt(this Func<bool> condition, int frequency = 25, int milisecondsTimeout = -1, CancellationToken cancellationToken = new CancellationToken())
        {
            var waitTask = Task.Run(async () =>
            {
                while (!condition())
                    await Task.Delay(frequency, cancellationToken);
            }, cancellationToken);

            if (waitTask != await Task.WhenAny(waitTask, Task.Delay(milisecondsTimeout, cancellationToken)))
                throw new TimeoutException();
        }
    }
}
