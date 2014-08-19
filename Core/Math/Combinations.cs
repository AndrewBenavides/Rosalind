using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Core.Math {
    public static class Combinations {
        public static IEnumerable<IEnumerable<T>> For<T>(IEnumerable<T> set, int size) {
            var list = set as IList<T>;
            if (list != null) {
                return SolveList(list, size);
            } else {
                return Solve(set, size);
            }
        }

        public static IList<IList<T>> ListFor<T>(IEnumerable<T> set, int size) {
            var list = set as IList<T>;
            if (list != null) {
                return SolveList(list, size);
            } else {
                return Solve(set, size)
                    .Select(c => (IList<T>)c.ToList())
                    .ToList();
            }
        }

        private static IEnumerable<IEnumerable<T>> Solve<T>(IEnumerable<T> set, int size) {
            int index = 0;
            foreach (var item in set) {
                var a = new List<T>(1) { item };
                if (size - 1 == 0) {
                    yield return a;
                } else {
                    index++;
                    foreach (var next in Solve(set.Skip(index), size - 1)) {
                        yield return a.Concat(next);
                    }
                }
            }
        }

        private static IList<IList<T>> SolveList<T>(IList<T> set, int size) {
            var amount = Combinations.AmountFor(set.Count, size);
            var lists = new T[amount][];
            for (int i = 0; i < amount; i++) lists[i] = new T[size];
            SolveList(set, size, 0, lists, 0, 0);
            return lists;
        }

        private static int SolveList<T>(IList<T> set, int size, int start, IList<IList<T>> appendees, int list, int depth) {
            int added = 0;
            for (int i = start; i <= set.Count - size; i++) {
                if (size - 1 > 0) {
                    var appended = SolveList(set, size - 1, i + 1, appendees, list, depth + 1);
                    for (int k = 0; k < appended; k++) {
                        appendees[list + k][depth] = (set[i]);
                        added++;
                    }
                    list += appended;
                } else {
                    appendees[list + added++][depth] = set[i];
                }
            }
            return added;
        }

        public static long AmountFor<T>(IEnumerable<T> set, int take) {
            return Combinations.AmountFor(set.Count(), take);
        }

        public static long AmountFor(int count, int take) {
            var n = Factorial.For(count);
            var r = Factorial.For(take);
            var d = Factorial.For(count - take);
            return checked((long)(n / (r * d)));
        }
    }
}
