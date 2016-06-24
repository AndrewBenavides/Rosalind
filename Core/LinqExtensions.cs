using System;
using System.Collections.Generic;
using System.Linq;
using Rosalind.Core.Utilities;

namespace Rosalind.Core {
    public static class LinqExtensions {
        //http://stackoverflow.com/a/5215506
        public static IEnumerable<List<T>> Partition<T>(this IEnumerable<T> sequence, int size) {
            List<T> partition = new List<T>(size);
            foreach (var item in sequence) {
                partition.Add(item);
                if (partition.Count == size) {
                    yield return partition;
                    partition = new List<T>(size);
                }
            }
            if (partition.Count > 0) yield return partition;
        }

        //public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> sequence, int size) {
        //    return sequence
        //        .Select((e, i) => new { Index = i / 3, Element = e })
        //        .GroupBy(o => o.Index, o => o.Element);
        //}

        public static IEnumerable<T> WhereMax<T>(this IEnumerable<T> source)
            where T : IEnumerable<object> {
            return source.WhereMax(x => x.Count());
        }

        public static IEnumerable<T> WhereMax<T>(this IEnumerable<T> source, Func<T, int> selector) {
            int max = 0;
            var matches = new List<T>();
            foreach (var item in source) {
                var count = selector(item);
                if (count > max) {
                    max = count;
                    matches = new List<T>();
                }
                if (count == max) matches.Add(item);
            }
            return matches;
        }

        //public static bool ContainsSequence<T>(this IEnumerable<T> source, IEnumerable<T> subsequence) {
        //    var main = source as IList<T> ?? source.ToList();
        //    var sub = subsequence as IList<T> ?? subsequence.ToList();
        //    return main.ContainsSequence(sub);
        //}

        public static bool ContainsSequence<T>(this IList<T> source, IList<T> subsequence) {
            if (subsequence.Count > source.Count) return false;
            var first = subsequence[0];
            for (int i = 0; i < source.Count; i++) {
                if (source[i].Equals(first)) {
                    for (int j = 0, k = i; j < subsequence.Count && k < source.Count && source[k].Equals(subsequence[j]); j++, k++) {
                        if (j == subsequence.Count - 1) return true;
                    }
                }
            }
            return false;
        }

        public static bool ContainsSequence<T>(this IEnumerable<T> source, IEnumerable<T> subsequence) {
            var count = subsequence.Count();
            var xEnumerator = source.GetEnumerator().AsReversible(count);
            var yEnumerator = subsequence.GetEnumerator().AsReversible(count);
            yEnumerator.MoveNext();
            var windback = 0;
            while (xEnumerator.MoveNext()) {
                while (xEnumerator.Current.Equals(yEnumerator.Current)) {
                    if (!yEnumerator.MoveNext()) return true;
                    if (!xEnumerator.MoveNext()) return false;
                    windback++;
                }
                if (windback > 0) {
                    xEnumerator.MovePrevious(windback);
                    yEnumerator.MovePrevious(windback);
                    windback = 0;
                }
            }
            return false;
        }

        public static IReversibleEnumerator<T> AsReversible<T>(this IEnumerator<T> enumerator) {
            return new ReversibleEnumerator<T>(enumerator);
        }

        public static IReversibleEnumerator<T> AsReversible<T>(this IEnumerator<T> enumerator, int bufferCapacity) {
            return new ReversibleEnumerator<T>(enumerator, bufferCapacity);
        }
    }
}
