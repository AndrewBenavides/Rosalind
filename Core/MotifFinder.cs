using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Core {
    public static class MotifFinder {
        private static IEnumerable<Sequence> ExplodeSequence(Sequence sequence) {
            for (int i = sequence.Count; i >= 2; i--) {
                for (int j = 0; j <= sequence.Count - i; j++) {
                    yield return Sequence.Create(sequence.Skip(j).Take(i));
                }
            }
        }

        private static List<Sequence> FindCommonSubsequences(IEnumerable<Sequence> sequences) {
            var first = new HashSet<Sequence>(ExplodeSequence(sequences.First()));
            foreach (var sequence in sequences.Skip(1)) {
                var next = ExplodeSequence(sequence);
                first.IntersectWith(next);
            }
            return first.ToList();
        }

        public static List<Sequence> FindLongestCommonSubsequences(IEnumerable<Sequence> sequences) {
            return MotifFinder.FindCommonSubsequences(sequences)
                .WhereMax()
                .ToList();
        }

        public static List<int> FindMotifIndexes(Sequence sequence, Sequence search) {
            var locations = new List<int>();
            var start = search.Count - 1;
            var frame = new LinkedList<Nucleotide>(sequence.Take(start));
            for (int i = start; i < sequence.Count; i++) {
                frame.AddLast(sequence[i]);
                if (search.SequenceEqual(frame)) locations.Add((i - start) + 1); //One-based index.
                frame.RemoveFirst();
            }
            return locations;
        }
    }
}
