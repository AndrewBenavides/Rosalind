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

        public static Sequence Create(IEnumerable<Nucleotide> sequence) {
            return new Sequence(sequence);
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
