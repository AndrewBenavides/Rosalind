using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Core {
    public class DnaString {
        public string Sequence { get; private set; }
        
        public DnaString(string sequence) {
            this.Sequence = sequence;
        }

        private static List<int> GetNucleotideCounts(string sequence) {
            return sequence
                .OrderBy(n => n)
                .GroupBy<char, char>(n => n)
                .Select(g => g.Count())
                .ToList();
        }

        public string GetNucleotideCounts() {
            return string.Join(" ", GetNucleotideCounts(this.Sequence));
        }
    }
}
