﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace Rosalind.Core {
    public sealed class Nucleotide : IComparable<Nucleotide> {
        #region Type-safe enumeration values
        public static readonly Nucleotide Adenine = Nucleotide.Create(0, 'A', "Adenine", 'T', new char[] { 'A' });
        public static readonly Nucleotide Cytosine = Nucleotide.Create(1, 'C', "Cytosine", 'G', new char[] { 'C' });
        public static readonly Nucleotide Guanine = Nucleotide.Create(2, 'G', "Gaunine", 'C', new char[] { 'G' });
        public static readonly Nucleotide Thymine = Nucleotide.Create(3, 'T', "Thymine", 'A', new char[] { 'T' });
        public static readonly Nucleotide Uracil = Nucleotide.Create(4, 'U', "Uracil", 'A', new char[] { 'U' });
        public static readonly Nucleotide Weak = Nucleotide.Create(5, 'W', "Weak Interaction", 'S', new char[] { 'A', 'T', 'U' });
        public static readonly Nucleotide Strong = Nucleotide.Create(6, 'S', "Strong Interaction", 'W', new char[] { 'C', 'G' });
        public static readonly Nucleotide Amino = Nucleotide.Create(7, 'M', "Amino", 'K', new char[] { 'A', 'C' });
        public static readonly Nucleotide Keto = Nucleotide.Create(8, 'K', "Ketones", 'M', new char[] { 'G', 'T', 'U' });
        public static readonly Nucleotide Purine = Nucleotide.Create(9, 'R', "Purine", 'Y', new char[] { 'A', 'G' });
        public static readonly Nucleotide Pyrimidine = Nucleotide.Create(10, 'Y', "Pyrimidine", 'R', new char[] { 'C', 'T', 'U' });
        public static readonly Nucleotide NotA = Nucleotide.Create(11, 'B', "Not A", 'V', new char[] { 'C', 'G', 'T', 'U' });
        public static readonly Nucleotide NotC = Nucleotide.Create(12, 'D', "Not C", 'H', new char[] { 'A', 'G', 'T', 'U' });
        public static readonly Nucleotide NotG = Nucleotide.Create(13, 'H', "Not G", 'D', new char[] { 'A', 'C', 'T', 'U' });
        public static readonly Nucleotide NotT = Nucleotide.Create(14, 'V', "Not T", 'B', new char[] { 'A', 'C', 'G' });
        public static readonly Nucleotide Nucleic = Nucleotide.Create(15, 'N', "Nucleic Acid", 'N', new char[] { 'A', 'C', 'G', 'T', 'U' });
        #endregion

        private static readonly ReadOnlyDictionary<char, Nucleotide> _registry;
        private static readonly ReadOnlyDictionary<IEnumerable<Nucleotide>, Nucleotide> _encodingRegistry;

        public static ReadOnlyDictionary<char, Nucleotide> Registry { get { return _registry; } }

        static Nucleotide() {
            _registry = GetRegistry();
            _encodingRegistry = GetEncodingRegistry();
            foreach (var n in _registry.Values) {
                n.Complement = _registry[n.complement];
                n.Bases = new ReadOnlyCollection<Nucleotide>(n.bases
                    .Select(b => _registry[b])
                    .ToList());
            }
        }

        private static ReadOnlyDictionary<char, Nucleotide> GetRegistry() {
            var dict = typeof(Nucleotide)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(f => f.FieldType == typeof(Nucleotide))
                .Select(f => (Nucleotide)f.GetValue(null))
                .ToDictionary(n => n.Symbol, n => n);
            return new ReadOnlyDictionary<char, Nucleotide>(dict);
        }

        private static ReadOnlyDictionary<IEnumerable<Nucleotide>, Nucleotide> GetEncodingRegistry() {
            var dict = _registry.Values.ToDictionary(
                keySelector: n => new SortedSet<Nucleotide>(n.bases.Select(b => _registry[b])),
                elementSelector: n => n,
                comparer: new NucleotideBasesEncodingComparer());
            return new ReadOnlyDictionary<IEnumerable<Nucleotide>, Nucleotide>(dict);
        }
        
        private readonly IEnumerable<char> bases;
        private readonly char complement;
        private readonly int id;
        private readonly string name;
        private readonly char symbol;
        
        public ReadOnlyCollection<Nucleotide> Bases { get; private set; }
        public Nucleotide Complement { get; private set; }
        public int ID { get { return this.id; } }
        public string Name { get { return this.name; } }
        public char Symbol { get { return this.symbol; } }

        private Nucleotide(int id, char symbol, string name, char complement, IEnumerable<char> bases) {
            this.complement = complement;
            this.id = id;
            this.name = name;
            this.symbol = symbol;
            this.bases = bases;
        }
        
        private static Nucleotide Create(int id, char symbol, string name, char complement, IEnumerable<char> bases) {
            return new Nucleotide(id, symbol, name, complement, bases);
        }

        public static Nucleotide EncodeBases(IEnumerable<Nucleotide> consensus) {
            var set = new SortedSet<Nucleotide>(consensus);
            return _encodingRegistry[set];
        }

        public override int GetHashCode() {
            return this.id;
        }
        
        public override string ToString() {
            return this.Symbol.ToString();
        }

        #region IComparable<T> Implementation
        public int CompareTo(Nucleotide other) {
            return this.Symbol.CompareTo(other.symbol);
        }
        #endregion
    }
}
