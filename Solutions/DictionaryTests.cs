using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Rosalind.Solutions {
    public class DictionaryTests {
        [Fact]
        public void InsertSpeed() {
            var standardTime = Test(new Dictionary<int, int>());
            var sortedTime = Test(new SortedDictionary<int, int>());
            var reverseTime = Test(new SortedDictionary<int, int>(new ReverseSorter()));
        }

        private long Test(IDictionary<int, int> dict) {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 10000000; i > 0; i--) {
                dict.Add(i, i);
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        private class ReverseSorter : IComparer<int> {
            public int Compare(int x, int y) {
                return x == y ? 0 : x < y ? 1 : -1;
            }
        }
    }
}
