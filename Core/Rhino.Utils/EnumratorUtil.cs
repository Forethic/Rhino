using System;
using System.Collections.Generic;

namespace Rhino.Utils
{
    public static class EnumratorUtil
    {
        public static void Foreach<T>(this IEnumerable<T> enumrator, Action<T> action)
        {
            foreach (var item in enumrator)
            {
                action(item);
            }
        }
    }
}