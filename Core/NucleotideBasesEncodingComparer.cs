using System;
using System.Collections.Generic;

namespace Rosalind.Core {
    public class NucleotideBasesEncodingComparer : IEqualityComparer<IEnumerable<Nucleotide>> {
        public bool Equals(IEnumerable<Nucleotide> x, IEnumerable<Nucleotide> y) {
            var a = new SortedSet<Nucleotide>(x);
            var b = new SortedSet<Nucleotide>(y);
            if (b.Contains(Nucleotide.Thymine) && !b.Contains(Nucleotide.Uracil) && a.Contains(Nucleotide.Uracil)) {
                a.Remove(Nucleotide.Uracil);
            }
            if (b.Contains(Nucleotide.Uracil) && !b.Contains(Nucleotide.Thymine) && a.Contains(Nucleotide.Thymine)) {
                a.Remove(Nucleotide.Thymine);
            }
            return a.SetEquals(b);
        }

        public int GetHashCode(IEnumerable<Nucleotide> obj) {
            int hash = 0;
            foreach (var nucleotide in obj) hash = hash | GetValue(nucleotide);
            return hash;
        }

        private static int GetValue(Nucleotide nucleotide) {
            switch (nucleotide.Symbol) {
                case 'A': return 1 << 3;
                case 'C': return 1 << 2;
                case 'G': return 1 << 1;
                case 'T': return 1 << 0;
                case 'U': return 1 << 0;
                default: throw new NotImplementedException();
            }
        }
    }
}
