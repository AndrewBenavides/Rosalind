using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Core {
    public class EnumerableEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>, IEqualityComparer<IList<T>> {
        public static EnumerableEqualityComparer<T> Default = new EnumerableEqualityComparer<T>();
        
        public bool Equals(IEnumerable<T> x, IEnumerable<T> y) {
            return x.SequenceEqual(y);
        }

        public bool Equals(IList<T> x, IList<T> y) {
            return x.SequenceEqual(y);
        }

        public int GetHashCode(IEnumerable<T> obj) {
            unchecked {
                int hash = 19;
                foreach (var item in obj) hash = hash * 31 + item.GetHashCode();
                return hash;
            }
        }

        public int GetHashCode(IList<T> obj) {
            unchecked {
                var count = obj.Count;
                int hash = 19;
                for (int i = 0; i < count; i++) hash = hash * 31 + obj[i].GetHashCode();
                return hash;
            }
        }
    }
}
