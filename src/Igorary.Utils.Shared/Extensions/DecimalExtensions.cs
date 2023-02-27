// DecimalExtensions.cs
// Copyright (c) 2023 Covalition. All rights reserved.

using System;

namespace Igorary.Utils.Extensions
{
    public static class DecimalExtensions
    {
        /// <summary>
        /// Zaokrągla decimal do 2 miejsc po przecinku.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static decimal Round2(this decimal d)
        {
            return Math.Round(d, 2, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Zaokrągla decimal do 4 miejsc po przecinku.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static decimal Round4(this decimal d)
        {
            return Math.Round(d, 4, MidpointRounding.AwayFromZero);
        }
    }
}
