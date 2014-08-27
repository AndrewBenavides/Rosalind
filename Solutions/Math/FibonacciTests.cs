using System.Numerics;
using Rosalind.Core.Math;
using Xunit;

namespace Rosalind.Solutions.Math {
    public class FibonacciTests {
        [Fact]
        public void Simple() {
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
        public void Multiplicative() {
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

        [Fact]
        public void Large() {
            TestLarge(100, "354224848179261915075");
            TestLarge(200, "280571172992510140037611932413038677189525");
        }

        private void TestLarge(int n, string expected) {
            Assert.Equal(BigInteger.Parse(expected), Fibonacci.Solve(n));
        }

        [Fact]
        public void Decay() {
            TestDecay(5, 3, "3");
            TestDecay(5, 4, "4");
            TestDecay(5, 5, "5");
            TestDecay(6, 3, "4");
            TestDecay(6, 4, "6");
            TestDecay(6, 5, "7");
            TestDecay(7, 3, "5");
            TestDecay(7, 4, "9");
            TestDecay(7, 5, "11");
            TestDecay(10, 3, "12");
            TestDecay(10, 4, "28");
            TestDecay(10, 5, "40");
            TestDecay(11, 3, "16");
        }

        private void TestDecay(int n, int m, string expected) {
            Assert.Equal(BigInteger.Parse(expected), Fibonacci.SolveDecay(n, m));
        }
    }
}
