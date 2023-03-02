// ITimer.cs
// Copyright (c) 2023 Covalition. All rights reserved.

using System;

namespace Igorary.Utils.Timer
{
    public interface ITimer : IDisposable
    {
        bool IsStarted { get; }

        void SetStarted(bool started);
    }
}
