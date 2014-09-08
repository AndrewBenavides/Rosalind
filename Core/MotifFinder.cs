using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Core {
    public static class MotifFinder {
        #region SuffixArray
        public static List<string> GenerateSuffixArray(Sequence sequence) {
            var seq = sequence.ToString();
            var suffix = new SortedSet<string>(GetSuffixes(seq));
            return suffix.ToList();
        }

        private static IEnumerable<string> GetSuffixes(string value) {
            var len = value.Length;
            for (int i = 0; i < len; i++) {
                yield return value.Substring(i, len - i);
            }
        }

        private static IEnumerable<string> ExplodeString(string value) {
            var len = value.Length;
            for (int i = len; i >= 2; i--) {
                for (int j = 0; j <= len - i; j++) {
                    yield return value.Substring(j, i);
                }
            }
        }

        //http://rosalind.info/problems/lcsm/solutions/#comment-259
        public static List<Sequence> FindMotifs(IEnumerable<Sequence> sequences) {
            var remaining = sequences.Skip(1)
                .Select(s => GenerateSuffixArray(s))
                .ToList();
            var combos = ExplodeString(sequences.First().ToString()).ToList();
            var common = combos
                .Distinct()
                .Where(sub => remaining.All(s => Contains(s, sub)))
                .Select(s => Sequence.Parse(s))
                .ToList();
            return common; ;
        }
        #endregion

        #region Reduce
        private static bool Contains(List<string> suffix, string value) {
            var result = suffix.BinarySearch(value);
            if (result >= 0) return true;
            if (~result >= suffix.Count) return false;
            return suffix[~result].Contains(value);
        }

        private static IEnumerable<string> CommonSubStr(IList<string> strings, int frameLength) {
            var first = strings[0];
            var range = first.Length - frameLength + 1;
            for (int i = 0; i < range; i++) {
                var part = first.Substring(i, frameLength);
                if (strings.Skip(1).All(s => s.Contains(part))) yield return part;
            }
        }

        //http://rosalind.info/problems/lcsm/solutions/#comment-192
        public static IList<string> FindLongestCommonSubstrings(IEnumerable<string> strings) {
            var sorted = strings.OrderByDescending(s => s.Length).ToList();
            var min = 0;
            var max = sorted[0].Length;
            var mid = max;
            do {
                if (CommonSubStr(sorted, mid).Any()) {
                    min = mid;
                } else {
                    max = mid;
                }
                mid = (min + max) / 2;
            } while (min + 1 < max);
            return CommonSubStr(sorted, mid).ToList();
        }
        #endregion

        #region Brute Force
        private static IEnumerable<Sequence> ExplodeSequence(Sequence sequence) {
            for (int i = sequence.Count; i >= 2; i--) {
                for (int j = 0; j <= sequence.Count - i; j++) {
                    yield return Sequence.Create(sequence.Skip(j).Take(i));
                }
            }
        }

        private static List<Sequence> FindCommonSubsequences(IEnumerable<Sequence> sequences) {
            var remaining = sequences.Skip(1).ToList();
            var common = ExplodeSequence(sequences.First())
                .AsParallel()
                .Where(sub => remaining.All(s => s.ContainsSequence(sub)))
                .Distinct()
                .ToList();
            return common;
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
        #endregion
    }
}
