// ObjectExtensions.cs
// Copyright (c) 2023 Covalition. All rights reserved.

namespace Igorary.Utils.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Returns the value of the <paramref name="propName"/> property.
        /// </summary>
        /// <param name="source">The source object</param>
        /// <param name="propName">Property name</param>
        /// <returns></returns>
        public static object GetPropValue(this object source, string propName)
        {
            return source.GetType().GetProperty(propName).GetValue(source, null);
        }
    }
}
