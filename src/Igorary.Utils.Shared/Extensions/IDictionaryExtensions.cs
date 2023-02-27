// IDictionaryExtensions.cs
// Copyright (c) 2023 Covalition. All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Igorary.Utils.Extensions
{
    public static class IDictionaryExtensions
    {
        /// <summary>
        /// Returns the value or null, if the key wasn't found.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The (reference) type of values in the dictionary.</typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key">The key of the element to get.</param>
        /// <returns>The element with the specified key or null.</returns>
        public static TValue Find<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) where TValue : class
        {
            if (dictionary.TryGetValue(key, out TValue value))
                return value;
            return null;
        }
    }
}
