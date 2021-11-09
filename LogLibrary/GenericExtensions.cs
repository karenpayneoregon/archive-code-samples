using System;
using System.Collections.Generic;
using System.Linq;

namespace LogLibrary
{
    public static class GenericExtensions
    {
        /// <summary>
        /// Take last N items from source
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="source">Instance of type</param>
        /// <param name="subtractCount">Amount to keep from source</param>
        /// <returns></returns>
        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int subtractCount) => 
            source.Skip(Math.Max(0, source.Count() - subtractCount));
    }
}
