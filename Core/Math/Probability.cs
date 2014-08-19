using System;
using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Core.Math {
    public class Probability {
        public static double ForSet(IEnumerable<Factor> set, Func<Factor, bool> predicate) {
            var squares = Combinations.ListFor(set, 2)
                .Select(c => Factor.Cross(c[0], c[1]))
                .ToList();
            var matching = squares
                .SelectMany(e => e.Outcomes)
                .Count(predicate);
            var p = (double)matching / squares.Sum(s => s.Outcomes.Count);
            return p;
        }
    }
}
