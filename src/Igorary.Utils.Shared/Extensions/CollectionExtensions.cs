using System;
using System.Collections.Generic;
using System.Text;

namespace Igorary.Utils.Extensions
{
    public static class CollectionExtensions
    {
        public static T Register<T>(this ICollection<T> collection, T obj) {
            collection.Add(obj);
            return obj;
        }
    }
}
