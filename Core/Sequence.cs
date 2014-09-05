using System;
using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Core {
    public class Sequence : List<Nucleotide>, IEqualityComparer<Sequence> {
        private int hashcode = 19;

        public double GcContent {
            get { return Sequence.GetGcContent(this); }
        }

        public Dictionary<Nucleotide, int> NucleotideCounts {
            get { return Sequence.GetNucleotideCounts(this); }
        }

        public Sequence ReverseComplement {
            get { return Sequence.GetReverseComplement(this); }
        }

        private Sequence(IEnumerable<Nucleotide> nucleotides) {
            this.Capacity = nucleotides.Count();
            using (var e = nucleotides.GetEnumerator()) {
                for (int i = 0; i < this.Capacity; i++) {
                    e.MoveNext();
                    var nucleotide = e.Current;
                    this.hashcode = this.hashcode * 31 + nucleotide.ID;
                    Insert(i, nucleotide);
                }
            }
        }

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

        public override bool Equals(object obj) {
            var other = obj as Sequence;
            if (other != null) return this.SequenceEqual(other);
            return false;
        }

        public bool Equals(Sequence x, Sequence y) {
            return x.SequenceEqual(y);
        }

        public static List<int> FindMotif(Sequence source, Sequence search) {
            return MotifFinder.FindMotifIndexes(source, search);
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

        public override int GetHashCode() {
            return this.hashcode;
        }

        public int GetHashCode(Sequence obj) {
            return obj.GetHashCode();
        }

        public static Dictionary<Nucleotide, int> GetNucleotideCounts(Sequence sequence) {
            return sequence
                .GroupBy(n => n.Symbol)
                .OrderBy(g => g.Key)
                .ToDictionary(g => Nucleotide.Registry[g.Key], g => g.Count());
        }

        public static Sequence GetReverseComplement(Sequence sequence) {
            return new Sequence(sequence
                .Select(n => n.Complement)
                .Reverse());
        }

        public static Sequence Parse(string sequence) {
            return new Sequence(sequence
                .Select(c => Nucleotide.Registry[c]));
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
