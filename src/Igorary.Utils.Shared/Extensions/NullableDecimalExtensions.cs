// NullableDecimalExtensions.cs
// Copyright (c) 2023 Covalition. All rights reserved.

namespace Igorary.Utils.Extensions
{
    public static class NullableDecimalExtensions
    {
        public static string ToString(this decimal? d, string format)
        {
            if (d != null)
                return d.Value.ToString(format);
            else
                return null;
        }
    }
}
