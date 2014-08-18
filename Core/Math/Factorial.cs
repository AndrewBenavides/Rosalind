using System.Collections.Generic;
using System.Numerics;

namespace Rosalind.Core.Math {
    public static class Factorial {
        private static Dictionary<int, BigInteger> _cache = new Dictionary<int, BigInteger>();

        public static BigInteger For(int n) {
            BigInteger result;
            if (!_cache.TryGetValue(n, out result)) {
                result = Solve(n);
                _cache.Add(n, result);
            }
            return result;
        }

        private static BigInteger Solve(int n) {
            return n > 1 ? n * Solve(n - 1) : BigInteger.One;
        }
    }
}
