using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Rosalind.Core.Utilities;

namespace Rosalind.Core {
    public sealed class AminoAcid {
        public enum Types {
            Start,
            Standard,
            Stop
        }

        private const string _aminoAcidsPath = "AminoAcids.json";
        private static ReadOnlyDictionary<string, AminoAcid> _lookupDictionary = LoadAminoAcids();

        private readonly string abbreviation;
        private readonly ReadOnlyCollection<string> codons;
        private readonly string name;
        private readonly char symbol;
        private readonly Types type;

        public string Abbreviation { get { return this.abbreviation; } }
        public ReadOnlyCollection<string> Codons { get { return this.codons; } }
        public string Name { get { return this.name; } }
        public static ReadOnlyDictionary<string, AminoAcid> Registry { get { return _lookupDictionary; } }
        public char Symbol { get { return this.symbol; } }
        public Types Type { get { return this.type; } }

        public AminoAcid(string name, string abbreviation, char symbol, IList<string> codons) {
            this.abbreviation = abbreviation;
            this.codons = new ReadOnlyCollection<string>(codons);
            this.name = name;
            this.symbol = symbol;
            this.type = AminoAcid.ResolveType(symbol);
        }

        private static ReadOnlyDictionary<string, AminoAcid> LoadAminoAcids() {
            var dict = JsonLoader.LoadList<AminoAcid>(_aminoAcidsPath)
                .SelectMany(a => a.Codons
                    .Select(c => new { Codon = c, AminoAcid = a }))
                .ToDictionary(o => o.Codon, o => o.AminoAcid);
            return new ReadOnlyDictionary<string, AminoAcid>(dict);
        }

        public static AminoAcid Lookup(string codon) {
            return _lookupDictionary[codon];
        }

        public static AminoAcid Lookup(IEnumerable<Nucleotide> subsequence) {
            var codon = subsequence
                .Select(n => n.Symbol)
                .Concatenate();
            return AminoAcid.Lookup(codon);
        }

        private static Types ResolveType(char symbol) {
            switch (symbol) {
                case 'M':
                    return Types.Start;
                case ' ':
                    return Types.Stop;
                default:
                    return Types.Standard;
            }
        }

        public override string ToString() {
            return string.Format("{0}: {1}: {2}", this.symbol, this.abbreviation, this.name);
        }
    }
}
