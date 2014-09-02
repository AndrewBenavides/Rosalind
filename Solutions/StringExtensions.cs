using System;
using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Solutions {
    public static partial class StringExtenstions {
        public static List<string> ToLines(this string input) {
            return input.ToList('\r', '\n');
        }

        public static List<string> ToList(this string input, params char[] splittingChars) {
            return input
                .Split(splittingChars, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
        }

        public static List<T> ToList<T>(this string input, params char[] splittingChars) {
            return input
                .Split(splittingChars, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => (T)Convert.ChangeType(s, typeof(T)))
                .ToList();
        }
    }
}
