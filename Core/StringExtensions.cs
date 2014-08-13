using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosalind.Core {
    public static class StringExtensions {
        public static string Concatenate<T>(this IEnumerable<T> objects) {
            return string.Join("", objects);
        }

        public static string Concatenate<T>(this IEnumerable<T> objects, string separator) {
            return string.Join(separator, objects);
        }
    }
}
