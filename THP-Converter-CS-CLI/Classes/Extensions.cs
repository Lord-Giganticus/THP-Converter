﻿using System.Collections.Generic;

namespace THP_Converter_CS_CLI.Classes
{
    static class Extensions
    {
        internal static string ReplaceSpacesWithUnderscore(this string str) => str.Replace(' ', '_');

        internal static List<T> ToList<T>(this T[] arr)
        {
            var l = new List<T>();
            foreach (var a in arr)
                l.Add(a);
            return l;
        }
    }
}
