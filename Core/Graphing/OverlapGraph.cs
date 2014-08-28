using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Core.Graphing {
    public class OverlapGraph {
        public List<Edge<IGeneticString>> AdjacencyList { get; private set; }

        private OverlapGraph(Database database, int length) {
            this.AdjacencyList = Match(database, length);
        }

        public static OverlapGraph For(Database database, int length) {
            return new OverlapGraph(database, length);
        }

        public static List<Edge<IGeneticString>> Match(Database database, int length) {
            IEnumerable<Edge<IGeneticString>> matches = new List<Edge<IGeneticString>>();
            foreach (var tail in database.Values) {
                var suffix = tail.Sequence.Skip(tail.Sequence.Count - length);
                matches = matches.Union(database.Values
                    .Where(head =>
                        suffix.SequenceEqual(head.Sequence.Take(length))
                        && !tail.Sequence.SequenceEqual(head.Sequence))
                    .Select(head => new Edge<IGeneticString>(tail, head)));
            }
            return matches.ToList();
        }

        public override string ToString() {
            return this.AdjacencyList.Concatenate("\r\n");
        }
    }

}
