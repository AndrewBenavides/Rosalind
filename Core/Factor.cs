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

        public static PunnettSquare Cross(Factor p, Factor m) {
            return new PunnettSquare(p, m);
        }

        public PunnettSquare Cross(Factor maternalOther) {
            return Factor.Cross(this, maternalOther);
        }

        public static Zygosity DetermineZygosity(Factor factor) {
            if (factor.A.IsDominant && factor.B.IsDominant) return Zygosity.HomozygousDominant;
            if (!factor.A.IsDominant && !factor.B.IsDominant) return Zygosity.HomozygousRecessive;
            return Zygosity.Heterozygous;
        }

        public override string ToString() {
            return this.Alleles
                .OrderBy(a => a.Symbol)
                .Select(a => a.Symbol).Concatenate();
        }
    }
}
