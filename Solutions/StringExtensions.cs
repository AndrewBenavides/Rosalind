using System;
using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Solutions {
    public static partial class StringExtenstions {
        public static List<string> ToLines(this string input) {
            return input
                .Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
        }
    }
}
