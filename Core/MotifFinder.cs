using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Core {
    public static class MotifFinder {
        #region Suffix Array
        //http://rosalind.info/problems/lcsm/solutions/#comment-259
        private static bool Contains(List<List<Nucleotide>> suffixes, List<Nucleotide> value) {
            var result = suffixes.BinarySearch(value, SequenceComparer.Default);
            if (result >= 0) return true;
            if (~result >= suffixes.Count) return false;
            return suffixes[~result].ContainsSequence(value);
        }

        private static IEnumerable<List<Nucleotide>> ExplodeSequence(Sequence sequence) {
            var count = sequence.Count;
            for (int i = 2; i <= count; i++) {
                for (int j = 0; j <= count - i; j++) {
                    yield return sequence.GetRange(j, i);
                }
            }
        }

        public static List<Sequence> FindLongestCommonSubsequences(IEnumerable<Sequence> sequences, bool returnAll) {
            var remaining = sequences.Skip(1)
                .Select(s => GenerateSuffixLists(s))
                .ToList();
            IEnumerable<List<Nucleotide>> combos = returnAll ?
               ExplodeSequence(sequences.First()) :
               ExplodeSequence(sequences.First())
                   .GroupBy(s => s.Count)
                   .TakeWhile(group => group
                       .Any(sub => remaining.All(r => Contains(r, sub))))
                   .Last();
            var common = combos
                .AsParallel()
                .Where(sub => remaining.All(r => Contains(r, sub)))
                .Select(sub => Sequence.Create(sub))
                .ToList();
            return common;
        }

        private static List<List<Nucleotide>> GenerateSuffixLists(Sequence sequence) {
            var length = sequence.Count;
            return Enumerable.Range(0, length)
                .Select(i => sequence.GetRange(i, length - i))
                .OrderBy(s => s, SequenceComparer.Default)
                .ToList();
        }
        #endregion

        #region Reduce
        //http://rosalind.info/problems/lcsm/solutions/#comment-192
        private static IEnumerable<List<Nucleotide>> FindCommonSubsequences(IList<Sequence> sequences, int frameLength) {
            var first = sequences[0];
            var range = first.Count - frameLength + 1;
            for (int i = 0; i < range; i++) {
                var sub = first.GetRange(i, frameLength);
                if (sequences.Skip(1).All(s => s.ContainsSequence(sub))) yield return sub;
            }
        }

        /* Starts by first checking if the entire string is a match, then starts looking for substrings
         * with a length of half of the original string (e.g. 500 out of 1000).
         * When a match is found, the substring search length increases until a match is not found.
         * When a match is not found, the substring search length decreases until a match is found.
         * This cycle repeats until min and max converge.
         * 
         * This searches only for the longest common substring by realizing that all combinations
         * of the longest sub string will be found at lower lengths and increasing the search length
         * until nothing is found will return the longest substring. 
         */
        public static List<Sequence> FindLongestCommonSubsequences(IEnumerable<Sequence> sequences) {
            var sorted = sequences.OrderByDescending(s => s.Count).ToList();
            var min = 0;
            var max = sorted[0].Count;
            var mid = max;
            do {
                if (FindCommonSubsequences(sorted, mid).Any()) {
                    min = mid;
                } else {
                    max = mid;
                }
                mid = (min + max) / 2;
            } while (min + 1 < max);
            return FindCommonSubsequences(sorted, mid)
                .Select(s => Sequence.Create(s))
                .ToList();
        }
        #endregion

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
