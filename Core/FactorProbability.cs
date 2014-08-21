using System;
using System.Collections.Generic;
using System.Linq;
using Rosalind.Core.Math;

namespace Rosalind.Core {
    public static class FactorProbability {
        public static Dictionary<Zygosity, double> Calculate(IEnumerable<Factor> set) {
            var groups = set
                .GroupBy(f => f.Zygosity)
                .ToDictionary(g => g.Key, g => g.Count());

            double k = groups[Zygosity.HomozygousDominant];
            double m = groups[Zygosity.Heterozygous];
            double n = groups[Zygosity.HomozygousRecessive];
            double total = k + m + n;
            double divisor = (4 * total * (total - 1));

            //For detailed information use Freeplane to read /Documentation/IPRB_FactorProbability.mm
            var dom = ((4 * k * (k - 1)) + (4 * k * m) + (m * (m - 1))) / divisor;
            var het = ((4 * k * m) + (8 * k * n) + (2 * m * (m - 1)) + (4 * m * n)) / divisor;
            var rec = ((m * (m - 1)) + (4 * m * n) + (4 * n * (n - 1))) / divisor;

            var dict = new Dictionary<Zygosity, double>() {
                { Zygosity.HomozygousDominant, dom },
                { Zygosity.Heterozygous, het },
                { Zygosity.HomozygousRecessive, rec }
            };
            return dict;
        }
        
        public static double GetByEnumeration(IEnumerable<Factor> set, Func<Factor, bool> predicate) {
            var punnettSquares = Combinations.ListFor(set, 2)
                .Select(c => Factor.Cross(c[0], c[1]))
                .ToList();
            var matching = punnettSquares
                .SelectMany(e => e.Outcomes)
                .Count(predicate);
            var p = (double)matching / punnettSquares.Sum(s => s.Outcomes.Count);
            return p;
        }
    }
}
