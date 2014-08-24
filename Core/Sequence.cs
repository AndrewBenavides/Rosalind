using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosalind.Core {
    public class Sequence : List<Nucleotide> {
        public double GcContent {
            get { return Sequence.GetGcContent(this); }
        }
        
        public Dictionary<Nucleotide, int> NucleotideCounts {
            get { return Sequence.GetNucleotideCounts(this); }
        }

        public Sequence ReverseComplement {
            get { return Sequence.GetReverseComplement(this); }
        }

        private Sequence(IEnumerable<Nucleotide> nucleotides)
            : base(nucleotides) { }

        public static int CalculateHammingDistance(Sequence a, Sequence b) {
            if (a.Count != b.Count) throw new NotSupportedException("Sequences must be of equal length.");
            int distance = 0;
            for (int i = 0; i < a.Count; i++) {
                if (a[i] != b[i]) distance++;
            }
            return distance;
        }

        public int CalculateHammingDistance(Sequence other) {
            return Sequence.CalculateHammingDistance(this, other);
        }

        public static Sequence Create(IEnumerable<Nucleotide> sequence) {
            return new Sequence(sequence);
        }

        public static List<int> FindMotif(Sequence source, Sequence search) {
            var locations = new List<int>();
            var start = search.Count - 1;
            var frame = new LinkedList<Nucleotide>(source.Take(start));
            for (int i = start; i < source.Count; i++) {
                frame.AddLast(source[i]);
                if (search.SequenceEqual(frame)) locations.Add((i - start) + 1); //One-based index.
                frame.RemoveFirst();
            }
            return locations;
        }

        public string FindMotif(Sequence search) {
            var locations = Sequence.FindMotif(this, search);
            return string.Join(" ", locations);
        }

        public static double GetGcContent(Sequence sequence) {
            var count = sequence
                .Count(n => n == Nucleotide.Cytosine || n == Nucleotide.Guanine);
            return ((double)count / sequence.Count) * 100D;
        }

        public static Dictionary<Nucleotide, int> GetNucleotideCounts(Sequence sequence) {
            return sequence
                .GroupBy(n => n.Symbol)
                .OrderBy(g => g.Key)
                .ToDictionary(g => Nucleotide.Nucleotides[g.Key], g => g.Count());
        }

        public static Sequence GetReverseComplement(Sequence sequence) {
            return new Sequence(sequence
                .Select(n => n.Complement)
                .Reverse());
        }
        
        public static Sequence Parse(string sequence) {
            return new Sequence(sequence
                .Select(c => Nucleotide.Nucleotides[c]));
        }

        public string PrintNucleotideCountsSummary() {
            return this.NucleotideCounts
                .OrderBy(d => d.Key.Symbol)
                .Select(d => d.Value)
                .Concatenate(" ");
        }

        public override string ToString() {
            return this.Select(n => n.Symbol).Concatenate();
        }
    }
}
