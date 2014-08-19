using System;
using System.Collections.Generic;
using System.Linq;
using Rosalind.Core.Math;
using Xunit;

namespace Rosalind.Solutions.Math {
    public class CombinationsTests {
        private static IEnumerable<int> GenerateDataset(int size) {
            for (int i = 1; i <= size; i++) {
                yield return i;
            }
        }

        [Fact]
        public void UsingEnumerable() {
            var set = GenerateDataset(25);
            var take = 7;
            var combinations = Combinations.For(set, take);
            Assert.NotEmpty(combinations);
            Assert.IsAssignableFrom<IEnumerable<IEnumerable<int>>>(combinations);
            Assert.Throws<Xunit.Sdk.IsAssignableFromException>(() => 
                Assert.IsAssignableFrom<IList<IList<int>>>(combinations)
            );
            foreach (var c in combinations) Assert.Equal(take, c.Count());
        }

        [Fact]
        public void UsingList() {
            var set = GenerateDataset(25).ToList().AsEnumerable();
            var take = 7;
            var combinations = Combinations.For(set, take);
            Assert.NotEmpty(combinations);
            Assert.IsAssignableFrom<IList<IList<int>>>(combinations);
            foreach (var c in combinations) Assert.Equal(take, c.Count());
        }

        [Fact]
        public void UsingEnumerableToList() {
            var set = GenerateDataset(5);
            var combinations = Combinations.ListFor(set, 2);
            Assert.IsAssignableFrom<IList<IList<int>>>(combinations);
        }

        [Fact]
        public void UsingListToList() {
            var set = GenerateDataset(5);
            var combinations = Combinations.ListFor(set, 2);
            Assert.IsAssignableFrom<IList<IList<int>>>(combinations);
        }
    }
}
