using Rosalind.Core;
using Xunit;

namespace Rosalind.Solutions {
    public class FibonacciTests {
        [Fact]
        public void ValidateSimple() {
            TestSimple(0, 0);
            TestSimple(1, 1);
            TestSimple(2, 1);
            TestSimple(3, 2);
            TestSimple(4, 3);
            TestSimple(5, 5);
            TestSimple(6, 8);
            TestSimple(7, 13);
            TestSimple(8, 21);
        }

        private void TestSimple(int n, int expected) {
            Assert.Equal(expected, Fibonacci.Solve(n));
        }

        [Fact]
        public void ValidateMultiplicative() {
            TestMultiplicative(0, 1, 1, 0);
            TestMultiplicative(1, 1, 1, 1);
            TestMultiplicative(2, 1, 1, 1);
            TestMultiplicative(3, 1, 1, 2);
            TestMultiplicative(4, 1, 1, 3);
            TestMultiplicative(5, 1, 1, 5);
            TestMultiplicative(6, 1, 1, 8);
            TestMultiplicative(7, 1, 1, 13);
            TestMultiplicative(5, 3, 1, 19);
            TestMultiplicative(32, 3, 1, 108412748857);
            TestMultiplicative(34, 4, 1, 18788331166609);
            TestMultiplicative(33, 5, 1, 112316396483406);
        }

        private void TestMultiplicative(int n, int k, int start, long expected) {
            Assert.Equal(expected, Fibonacci.Solve(n, k, start));
        }
    }
}
