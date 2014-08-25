using System;
using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Core {
    public class DatabaseConsensus {
        private Dictionary<int, List<List<Nucleotide>>> consensusCache = new Dictionary<int, List<List<Nucleotide>>>();
        private Dictionary<int, List<string>> consensusCache2 = new Dictionary<int, List<string>>();

        public Database Database { get; private set; }
        public List<IGeneticString> ConsensusStrings { get; private set; }
        public Dictionary<Nucleotide, NucleotideFrequencyProfile> NucleotideProfiles { get; private set; }

        private DatabaseConsensus(Database database) {
            this.Database = database;
            var length = database.Max(s => s.Value.Sequence.Count);
            this.NucleotideProfiles = Nucleotide.Nucleotides.Values
                .ToDictionary(n => n, n => new NucleotideFrequencyProfile(n, length));
            foreach (var s in this.Database.Values) AddString(s);
            //CalculateConsensusStrings(length);
            CalculateConsensusStrings2(length);
            //CalculateConsensusStringSimple(length);
        }

        public void AddString(IGeneticString geneticString) {
            var sequence = geneticString.Sequence;
            for (int i = 0; i < sequence.Count; i++) {
                this.NucleotideProfiles[sequence[i]].PositionalFrequency[i]++;
            }
        }

        private List<List<Nucleotide>> BuildConsensusStrings(List<List<Nucleotide>> source, int index) {
            var collected = new List<List<Nucleotide>>();
            if (index >= source.Count) return collected;
            foreach (var n in source[index]) {
                var current = new List<Nucleotide>(1) { n };
                var next = GetNext(source, index + 1);
                if (next.Count > 0) {
                    foreach (var result in next) {
                        collected.Add(current.Concat(result).ToList());
                    }
                } else {
                    collected.Add(current);
                }
            }
            return collected;
        }

        private List<List<Nucleotide>> GetNext(List<List<Nucleotide>> source, int index) {
            if (!consensusCache.ContainsKey(index)) {
                var next = BuildConsensusStrings(source, index);
                consensusCache.Add(index, next);
            }
            return consensusCache[index];
        }

        private IEnumerable<string> BuildConsensusStrings2(List<string> source, int index) {
            if (index < source.Count) {
                foreach (var c in source[index]) {
                    var next = GetNext2(source, index + 1);
                    if (next.Any()) {
                        foreach(var array in next){
                            var a = array.ToArray();
                            a[index] = c;
                            var s = new string(a);
                            yield return s;
                        }
                    } else {
                        var current = new char[source.Count];
                        current[index] = c;
                        var s = new string(current);
                        yield return s;
                    }
                }
            }
        }

        private List<string> GetNext2(List<string> source, int index) {
            if (!consensusCache2.ContainsKey(index)) {
                var next = BuildConsensusStrings2(source, index);
                consensusCache2.Add(index, next.ToList());
            }
            return consensusCache2[index];
        }

        private void CalculateConsensusStrings(int geneticStringLength) {
            var mostFrequentNucleotides = Enumerable
                .Repeat<List<Nucleotide>>(new List<Nucleotide>(), geneticStringLength)
                .ToList();

            for (int i = 0; i < geneticStringLength; i++) {
                var highestFrequency = this.NucleotideProfiles.Values
                    .Max(n => n.PositionalFrequency[i]);
                mostFrequentNucleotides[i] = this.NucleotideProfiles.Values
                    .Where(n => n.PositionalFrequency[i] == highestFrequency)
                    .Select(n => n.Nucleotide)
                    .ToList();
            }
            var strings = BuildConsensusStrings(mostFrequentNucleotides, 0)
                .Select(c => DnaString.Create(Sequence.Create(c)))
                .ToList<IGeneticString>();
            this.ConsensusStrings = strings;
        }

        private void CalculateConsensusStrings2(int geneticStringLength) {
            List<string> mostFrequentNucleotides = Enumerable
                .Repeat(string.Empty, geneticStringLength)
                .ToList();

            for (int i = 0; i < geneticStringLength; i++) {
                var highestFrequency = this.NucleotideProfiles.Values
                    .Max(n => n.PositionalFrequency[i]);
                mostFrequentNucleotides[i] = this.NucleotideProfiles.Values
                    .Where(n => n.PositionalFrequency[i] == highestFrequency)
                    .Select(n => n.Nucleotide.Symbol)
                    .Concatenate();
            }
            var strings = BuildConsensusStrings2(mostFrequentNucleotides, 0)
                .Select(c => DnaString.Parse(c))
                .ToList<IGeneticString>();
            this.ConsensusStrings = strings;
        }
        
        private void CalculateConsensusStringSimple(int geneticStringLength) {
            var mostFrequentNucleotides = new List<Nucleotide>();
            for (int i = 0; i < geneticStringLength; i++) {
                var highestFrequency = this.NucleotideProfiles.Values
                    .Max(n => n.PositionalFrequency[i]);
                var mostFrequentNucleotide = this.NucleotideProfiles.Values
                    .First(n => n.PositionalFrequency[i] == highestFrequency)
                    .Nucleotide;
                mostFrequentNucleotides.Add(mostFrequentNucleotide);
            }
            var consensus = DnaString.Create(Sequence.Create(mostFrequentNucleotides));
            this.ConsensusStrings = new List<IGeneticString>() { consensus };
        }

        public static DatabaseConsensus For(Database database) {
            return new DatabaseConsensus(database);
        }

        public string PrintConsensus() {
            var lines = new List<string>();
            foreach (var consensus in this.ConsensusStrings) {
                lines.Add(consensus.Sequence.Concatenate());
            }
            foreach (var consensus in this.NucleotideProfiles.Values) {
                if (consensus.PositionalFrequency.Any(c => c > 0)) lines.Add(consensus.PrintConsensus());
            }
            return string.Join("\r\n", lines);
        }
    }
}
