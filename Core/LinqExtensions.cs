using System.Collections.Generic;
using System.Linq;

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
    }
}
