using System;
using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Core {
    public static class FactorGenerator {
        public static Factor Single(Zygosity zygosity) {
            var dominant = new Allele('A');
            var recessive = new Allele('a');
            switch (zygosity) {
                case Zygosity.Heterozygous:
                    return new Factor(dominant, recessive);
                case Zygosity.HomozygousDominant:
                    return new Factor(dominant, dominant);
                case Zygosity.HomozygousRecessive:
                    return new Factor(recessive, recessive);
                default:
                    throw new NotImplementedException();
            }
        }

        public static IList<Factor> Population(string input) {
            var inputException = new NotSupportedException("The input was not recognized.");
            try {
                var amounts = input.Split(' ')
                    .Select(i => int.Parse(i))
                    .ToList();
                if (amounts.Count != 3) throw inputException;
                var list = new List<Factor>();
                AddGeneratedFactors(list, Zygosity.HomozygousDominant, amounts[0]);
                AddGeneratedFactors(list, Zygosity.Heterozygous, amounts[1]);
                AddGeneratedFactors(list, Zygosity.HomozygousRecessive, amounts[2]);
                return list;
            } catch {
                throw inputException;
            }
        }

        private static void AddGeneratedFactors(List<Factor> list, Zygosity zygosity, int count) {
            for (int i = 0; i < count; i++) list.Add(Single(zygosity));
        }
    }
}
