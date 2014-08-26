using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Core {
    public class NucleotideFrequencyMatrix : Dictionary<Nucleotide, List<int>> {
        public Dictionary<Nucleotide, List<int>> Matrix { get; private set; }
        public List<int> MaxFrequencies { get; private set; }

        private NucleotideFrequencyMatrix(int length) {
            this.MaxFrequencies = Enumerable.Repeat(0, length).ToList();
            this.Matrix = Nucleotide.Registry.Values
                .Where(n => n.Bases.Count == 1)
                .ToDictionary(n => n, n => Enumerable.Repeat(0, length).ToList());
        }

        private void AddString(IGeneticString geneticString) {
            var sequence = geneticString.Sequence;
            for (int i = 0; i < sequence.Count; i++) {
                var value = ++this.Matrix[sequence[i]][i];
                if (value > this.MaxFrequencies[i]) this.MaxFrequencies[i] = value;
            }
        }

        public static NucleotideFrequencyMatrix For(Database database) {
            var length = database.Max(s => s.Value.Sequence.Count);
            var frequencyMatrix = new NucleotideFrequencyMatrix(length);
            foreach (IGeneticString geneticString in database.Values) {
                frequencyMatrix.AddString(geneticString);
            }
            return frequencyMatrix;
        }

        public string PrintMatrix() {
            return this.Matrix
                .Where(kvp => kvp.Value.Any(c => c > 0))
                .Select(kvp => string.Format("{0}: {1}", kvp.Key.Symbol, kvp.Value.Concatenate(" ")))
                .Concatenate("\r\n");
        }
    }
}
