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

        public static double CalculateExpectedOffspringWithDominantTrait(IList<int> genotypePairings, int offspring) {
            var pairs = GetGenotypePairings(genotypePairings);
            var AAAA = pairs["AAAA"] * ((4 / 4D) + (0 / 4D)) * offspring;
            var AAAa = pairs["AAAa"] * ((2 / 4D) + (2 / 4D)) * offspring;
            var AAaa = pairs["AAaa"] * ((0 / 4D) + (4 / 4D)) * offspring;
            var AaAa = pairs["AaAa"] * ((1 / 4D) + (2 / 4D)) * offspring;
            var Aaaa = pairs["Aaaa"] * ((0 / 4D) + (2 / 4D)) * offspring;
            var aaaa = pairs["aaaa"] * ((0 / 4D) + (0 / 4D)) * offspring;
            var result = AAAA + AAAa + AAaa + AaAa + Aaaa + aaaa;
            return result;
        }

        public static Dictionary<Zygosity, double> CalculateExpectedOffsrping(IList<int> genotypePairings, int offspring) {
            var pairs = GetGenotypePairings(genotypePairings);
            var dominant = ((pairs["AAAA"] * 1.00) + (pairs["AAAa"] * 0.50) + (pairs["AaAa"] * 0.25)) * offspring;
            var hetero = ((pairs["AAAa"] * 0.50) + (pairs["AAaa"] * 1.00) + (pairs["AaAa"] * 0.50) + (pairs["Aaaa"] * 0.50)) * offspring;
            var recessive = ((pairs["AaAa"] * 0.25) + (pairs["Aaaa"] * 0.50) + (pairs["aaaa"] * 1.00)) * offspring;

            var dict = new Dictionary<Zygosity, double>() {
                { Zygosity.HomozygousDominant, dominant },
                { Zygosity.Heterozygous, hetero },
                { Zygosity.HomozygousRecessive, recessive }
            };
            return dict;
        }

        private static Dictionary<string, int> GetGenotypePairings(IList<int> genotypePairings) {
            return new Dictionary<string, int>(){
                { "AAAA", genotypePairings[0] },
                { "AAAa", genotypePairings[1] },
                { "AAaa", genotypePairings[2] },
                { "AaAa", genotypePairings[3] },
                { "Aaaa", genotypePairings[4] },
                { "aaaa", genotypePairings[5] }
            };
        }
    }
}
