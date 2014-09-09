using System;
using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Core {
    public class Sequence : List<Nucleotide>, IEqualityComparer<Sequence>, IComparer<Sequence>, IComparer<List<Nucleotide>>, IComparable<Sequence> {
        private Lazy<int> hashcode;

        public double GcContent {
            get { return Sequence.GetGcContent(this); }
        }

        public Dictionary<Nucleotide, int> NucleotideCounts {
            get { return Sequence.GetNucleotideCounts(this); }
        }

        public Sequence ReverseComplement {
            get { return Sequence.GetReverseComplement(this); }
        }

        private Sequence(IEnumerable<Nucleotide> nucleotides) : base(nucleotides) {
            this.hashcode = new Lazy<int>(() => GenerateHashCode());
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
            return this.hashcode.Value;
        }

        private int GenerateHashCode() {
            int hash = 19;
            for (int i = 0; i < this.Count; i++) hash = hash * 31 + this[i].GetHashCode();
            return hash;
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

        #region IComparable<T> Implementation
        public int CompareTo(Sequence other) {
            return Compare(this, other);
        }
        #endregion
        
        #region IComparer<T> Implementation
        public int Compare(Sequence x, Sequence y) {
            var a = x as List<Nucleotide>;
            var b = y as List<Nucleotide>;
            return Compare(a, b);
        }

        public int Compare(List<Nucleotide> x, List<Nucleotide> y) {
            for (int i = 0, j = 0; i < x.Count && j < y.Count; i++, j++) {
                if (x[i].Symbol != y[j].Symbol) {
                    return x[i].Symbol > y[j].Symbol ? 1 : -1;
                }
            }
            if (x.Count == y.Count) return 0;
            return x.Count > y.Count ? 1 : -1;
        }
        #endregion

        #region IEqualityComparer<T> Implementation
        public bool Equals(Sequence x, Sequence y) {
            return x.SequenceEqual(y);
        }
        
        public int GetHashCode(Sequence obj) {
            return obj.GetHashCode();
        }
        #endregion
    }
}
