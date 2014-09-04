using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Core {
    public class SequenceEqualityComparer<T> : IEqualityComparer<IEnumerable<T>> {
        public bool Equals(IEnumerable<T> x, IEnumerable<T> y) {
            return x.SequenceEqual(y);
        }

        public int GetHashCode(IEnumerable<T> obj) {
            unchecked {
                int hash = 19;
                foreach (var item in obj) hash = hash * 31 + item.GetHashCode();
                return hash;
            }
        }
    }
}
