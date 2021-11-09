using System;
using System.Collections.Generic;
using System.Linq;

namespace LogLibrary
{
    public static class GenericExtensions
    {
        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int subtractCount) => 
            source.Skip(Math.Max(0, source.Count() - subtractCount));
    }
}
