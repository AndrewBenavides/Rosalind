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

        private static List<int> GetNucleotideCounts(string sequence) {
            return sequence
                .OrderBy(n => n)
                .GroupBy<char, char>(n => n)
                .Select(g => g.Count())
                .ToList();
        }

        public string GetNucleotideCounts() {
            var sequence = new string(this.Sequence
                .Select(n => n.Symbol)
                .ToArray());
            return string.Join(" ", GetNucleotideCounts(sequence));
        }

        public string TranscribeToRna() {
            return new string(this.Sequence
                .Select(n => {
                    if (n == Nucleotide.Thymine) return Nucleotide.Uracil.Symbol;
                    return n.Symbol;
                })
                .ToArray());
        }
    }
}
