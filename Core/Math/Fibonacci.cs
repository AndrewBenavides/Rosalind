using System.Collections.Generic;

namespace Rosalind.Core.Math {
    public class Fibonacci {
        private Dictionary<int, long> results = new Dictionary<int, long>();

        private Fibonacci() { }

        public static long Solve(int n) {
            return Solve(n, 1, 1);
        }

        public static long Solve(int n, int k) {
            return Solve(n, k, 1);
        }
        
        public static long Solve(int n, int k, int start) {
            var fib = new Fibonacci();
            var result = fib.SolveWithCache(n, k, start);
            fib = null;
            return result;
        }

        private long SolveWithCache(int n, int k, int start) {
            if (!this.results.ContainsKey(n)){
                long result;
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
