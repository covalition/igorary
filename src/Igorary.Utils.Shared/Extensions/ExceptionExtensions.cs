// ExceptionExtensions.cs
// Copyright (c) 2023 Covalition. All rights reserved.

using System;

namespace Igorary.Utils.Extensions
{
    public static class ExceptionExtensions
    {
        public static T GetInner<T>(this Exception ex) where T : Exception
        {
            Exception inner = ex;
            while (inner != null && !(inner is T))
                inner = inner.InnerException;
            return inner as T;
        }
    }
}
