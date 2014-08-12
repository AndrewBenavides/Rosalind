using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Core {
    public class DnaString {
        public List<Nucleotide> Sequence { get; private set; }
        
        public DnaString(string sequenceString) {
            this.Sequence = GetSequence(sequenceString);
        }

        private static List<Nucleotide> GetSequence(string sequence) {
            return sequence
                .Select(c => Nucleotide.Nucleotides[c])
                .ToList();
        }

        private static List<int> GetNucleotideCounts(IEnumerable<Nucleotide> sequence) {
            return sequence
                .GroupBy(s => s.Symbol)
                .OrderBy(g => g.Key)
                .Select(g => g.Count())
                .ToList();
        }

        public string GetNucleotideCounts() {
            return string.Join(" ", GetNucleotideCounts(this.Sequence));
        }

        private static List<Nucleotide> TranscribeToRna(IEnumerable<Nucleotide> sequence) {
            return sequence
                .Select(n => n == Nucleotide.Thymine ? Nucleotide.Uracil : n)
                .ToList();
        }

        public string TranscribeToRna() {
            return string.Join("", TranscribeToRna(this.Sequence).Select(n => n.Symbol));
        }

        public string GetReverseComplement() {
            return string.Join("", this.Sequence
                .Select(n => n.Complement.Symbol)
                .Reverse());
        }
    }
}
