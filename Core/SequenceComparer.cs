using System.Collections.Generic;

namespace Rosalind.Core {
    public class SequenceComparer : IComparer<Sequence>, IComparer<IList<Nucleotide>> {
        public static SequenceComparer Default = new SequenceComparer();
        
        public int Compare(Sequence x, Sequence y) {
            return CompareSequences(x, y);
        }

        public int Compare(IList<Nucleotide> x, IList<Nucleotide> y) {
            return CompareSequences(x, y);
        }

        private int CompareSequences(IList<Nucleotide> x, IList<Nucleotide> y) {
            for (int i = 0, j = 0; i < x.Count && j < y.Count; i++, j++) {
                if (x[i].Symbol != y[j].Symbol) {
                    return x[i].Symbol > y[j].Symbol ? 1 : -1;
                }
            }
            if (x.Count == y.Count) return 0;
            return x.Count > y.Count ? 1 : -1;
        }
    }
}
