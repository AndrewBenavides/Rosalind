using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Rosalind.Core {
    public sealed class Nucleotide {
        public static readonly Nucleotide Adenine = Nucleotide.Create('A', "Adenine", 'T');
        public static readonly Nucleotide Cytosine = Nucleotide.Create('C', "Cytosine", 'G');
        public static readonly Nucleotide Guanine = Nucleotide.Create('G', "Gaunine", 'C');
        public static readonly Nucleotide Thymine = Nucleotide.Create('T', "Thymine", 'A');
        public static readonly Nucleotide Uracil = Nucleotide.Create('U', "Uracil", 'A');
        private static readonly Dictionary<char, Nucleotide> _nucleotides = GetNucleotides();

        private readonly char complement;
        private readonly string name;
        private readonly char symbol;

        public Nucleotide Complement { get { return Nucleotide.Nucleotides[this.complement]; } }
        public string Name { get { return this.name; } }
        public static Dictionary<char, Nucleotide> Nucleotides { get { return _nucleotides; } }
        public char Symbol { get { return this.symbol; } }

        private Nucleotide(char symbol, string name, char complement) {
            this.complement = complement;
            this.name = name;
            this.symbol = symbol;
        }

        private static Nucleotide Create(char symbol, string name, char complement) {
            return new Nucleotide(symbol, name, complement);
        }

        private static Dictionary<char, Nucleotide> GetNucleotides() {
            return typeof(Nucleotide)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(f => f.FieldType == typeof(Nucleotide))
                .Select(f => (Nucleotide)f.GetValue(null))
                .ToDictionary(n => n.Symbol, n => n);
        }

        public override string ToString() {
            return this.Symbol.ToString();
        }
    }
}
