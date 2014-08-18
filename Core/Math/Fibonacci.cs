using System.Collections.Generic;
using System.Numerics;

namespace Rosalind.Core.Math {
    public class Fibonacci {
        private Dictionary<int, BigInteger> results = new Dictionary<int, BigInteger>();

        private Fibonacci() { }

        public static BigInteger Solve(int n) {
            return Solve(n, 1, 1);
        }

        public static BigInteger Solve(int n, int k) {
            return Solve(n, k, 1);
        }
        
        public static BigInteger Solve(int n, int k, int start) {
            var fib = new Fibonacci();
            var result = fib.SolveWithCache(n, k, start);
            fib = null;
            return result;
        }

        private BigInteger SolveWithCache(int n, int k, int start) {
            if (!this.results.ContainsKey(n)){
                BigInteger result;
                if (n == 0) {
                    result = 0;
                } else if (n <= 2) {
                    result = start;
                } else {
                    result = SolveWithCache(n - 1, k, start) + (k * SolveWithCache(n - 2, k, start));
                }
                this.results.Add(n, result);
            }
            return this.results[n];
        }
    }
}
