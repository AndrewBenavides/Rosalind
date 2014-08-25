using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Core {
    public class NucleotideFrequencyProfile {
        public Nucleotide Nucleotide { get; set; }
        public List<int> PositionalFrequency { get; set; }

        public NucleotideFrequencyProfile(Nucleotide nucleotide, int length) {
            this.Nucleotide = nucleotide;
            this.PositionalFrequency = new List<int>(Enumerable.Repeat<int>(0, length));
        }

        public string PrintConsensus() {
            var counts = string.Join(" ", this.PositionalFrequency);
            return string.Format("{0}: {1}", this.Nucleotide.Symbol, counts);
        }
    }
}
