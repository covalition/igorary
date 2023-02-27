// CollectionExtensions.cs
// Copyright (c) 2023 Covalition. All rights reserved.

using System.Collections.Generic;

namespace Igorary.Utils.Extensions
{
    public static class CollectionExtensions
    {
        public static T Register<T>(this ICollection<T> collection, T obj)
        {
            collection.Add(obj);
            return obj;
        }
    }
}
