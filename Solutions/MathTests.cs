using System.Collections.Generic;
using System.Linq;
using Rosalind.Core.Math;
using Xunit;

namespace Rosalind.Solutions {
    public class MathTests {
        [Fact]
        public void FactorialValidation() {
            Assert.Equal(1, Factorial.For(1));
            Assert.Equal(2, Factorial.For(2));
            Assert.Equal(120, Factorial.For(5));
            Assert.Equal(2432902008176640000, Factorial.For(20));
            Assert.True(Factorial.For(100) > long.MaxValue);
        }

        [Fact]
        public void CombinationsValidation() {
            var set = GetSet(25);
            var take = 7;
            var combinations = Combinations.For(set, take);
            Assert.NotEmpty(combinations);
            foreach (var c in combinations) Assert.Equal(take, c.Count());
        }

        [Fact]
        public void CombinationsListValidation() {
            var set = GetSet(25).ToList().AsEnumerable();
            var take = 7;
            var combinations = Combinations.For(set, take);
            Assert.NotEmpty(combinations);
            foreach (var c in combinations) Assert.Equal(take, c.Count());
        }

        private IEnumerable<int> GetSet(int size) {
            for (int i = 1; i <= size; i++) {
                yield return i;
            }
        }
    }
}
