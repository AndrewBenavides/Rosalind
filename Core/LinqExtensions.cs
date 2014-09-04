using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Rosalind.Core {
    public static class LinqExtensions {
        //http://stackoverflow.com/a/5215506
        public static IEnumerable<List<T>> Partition<T>(this IEnumerable<T> sequence, int size) {
            List<T> partition = new List<T>(size);
            foreach (var item in sequence) {
                partition.Add(item);
                if(partition.Count == size) {
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
    }
}
