using System;
using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Core {
    public enum Zygosity {
        Heterozygous,
        HomozygousDominant,
        HomozygousRecessive
    }
    
    public class Factor {
        public Allele A { get; set; }
        public Allele B { get; set; }
        public Allele[] Alleles { get; set; }
        public Zygosity Zygosity { get; set; }

        public Factor(Allele a, Allele b) {
            this.A = a;
            this.B = b;
            this.Alleles = new Allele[2] { this.A, this.B };
            this.Zygosity = Factor.DetermineZygosity(this);
        }

        public static Factor Generate(Zygosity zygosity) {
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

        public static IList<Factor> GeneratePopulation(string input) {
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
            for (int i = 0; i < count; i++) list.Add(Generate(zygosity));
        }

        public static Zygosity DetermineZygosity(Factor factor) {
            if (factor.A.IsDominant && factor.B.IsDominant) return Zygosity.HomozygousDominant;
            if (!factor.A.IsDominant && !factor.B.IsDominant) return Zygosity.HomozygousRecessive;
            return Zygosity.Heterozygous;
        }

        public static PunnettSquare Cross(Factor p, Factor m) {
            return new PunnettSquare(p, m);
        }

        public PunnettSquare Cross(Factor maternalOther) {
            return Factor.Cross(this, maternalOther);
        }

        public override string ToString() {
            return this.Alleles
                .OrderBy(a => a)
                .Select(a => a.Symbol).Concatenate();
        }
    }
}
