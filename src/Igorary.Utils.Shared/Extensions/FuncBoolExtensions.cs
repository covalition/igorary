// FuncBoolExtensions.cs
// Copyright (c) 2023 Covalition. All rights reserved.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Igorary.Utils.Extensions
{
    public static class FuncBoolExtensions
    {
        /// <summary>
        /// Waits for the condition to be true.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="milisecondsFrequency"></param>
        /// <param name="milisecondsTimeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="TimeoutException"></exception>
        public static async Task WaitForIt(this Func<bool> condition, int milisecondsFrequency = 25, int milisecondsTimeout = -1, CancellationToken cancellationToken = new CancellationToken())
        {
            Task waitTask = Task.Run(async () =>
            {
                while (!condition())
                    await Task.Delay(milisecondsFrequency, cancellationToken);
            }, cancellationToken);

            if (waitTask != await Task.WhenAny(waitTask, Task.Delay(milisecondsTimeout, cancellationToken)))
                throw new TimeoutException();
        }
    }
}
