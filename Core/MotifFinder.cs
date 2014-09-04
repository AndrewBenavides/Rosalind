using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Core {
    public static class MotifFinder {
        private static SequenceEqualityComparer<Nucleotide> _comparer = new SequenceEqualityComparer<Nucleotide>();

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

        public static List<Sequence> FindLongestCommonSubsequences(IEnumerable<Sequence> sequences) {
            var subsequences = ExplodeSequences(sequences);
            var common = IsolateCommonSubsequences(subsequences).ToList();
            return common;
        }

        private static List<HashSet<List<Nucleotide>>> ExplodeSequences(IEnumerable<Sequence> sequences) {
            var sets = new List<HashSet<List<Nucleotide>>>();
            foreach (var sequence in sequences) {
                var subsequences = new HashSet<List<Nucleotide>>(_comparer);
                for (int i = sequence.Count; i >= 2; i--) {
                    for (int j = 0; j <= sequence.Count - i; j++) {
                        var sub = sequence.GetRange(j, i);
                        if (!subsequences.Contains(sub)) subsequences.Add(sub);
                    }
                }
                sets.Add(subsequences);
            }
            return sets;
        }

        private static IEnumerable<Sequence> IsolateCommonSubsequences(IEnumerable<IEnumerable<IEnumerable<Nucleotide>>> sequences) {
            //IEnumerable<IEnumerable<IEnumerable<Nucleotide>>>
            //List<HashSet<List<Nucleotide>>>
            //List<HashSet<Sequence>>
            var common = sequences
                .Aggregate((acc, next) => acc = acc.Intersect(next, _comparer))
                .Select(s => Sequence.Create(s));
            return common;
        }

        //private static IEnumerable<Sequence> IsolateCommonSubsequences(List<HashSet<List<Nucleotide>>> sequences) {
        //    var copy = sequences.ToList();
        //    var first = copy[0];
        //    foreach (var sequence in copy.Skip(1)) first.IntersectWith(sequence);
        //    var common = first
        //        .Select(s => Sequence.Create(s));
        //    return common;
        //}
    }
}
