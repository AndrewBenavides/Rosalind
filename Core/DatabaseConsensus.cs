using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Core {
    public class DatabaseConsensus {
        public Database Database { get; private set; }
        public IGeneticString ConsensusString { get; private set; }
        public NucleotideFrequencyMatrix FrequencyMatrix { get; private set; }

        private DatabaseConsensus(Database database) {
            this.Database = database;
            this.FrequencyMatrix = NucleotideFrequencyMatrix.For(database);
            this.ConsensusString = GetFirstConsensusString();
        }

        private IGeneticString GetEncodedConsensusString() {
            var nucleotides = GetMostFrequentNucleotides();
            var consensus = nucleotides
                .Select(set => Nucleotide.EncodeBases(set));
            var geneticString = DnaString.Create(Sequence.Create(consensus));
            return geneticString;
        }

        private IGeneticString GetFirstConsensusString() {
            var nucleotides = GetMostFrequentNucleotides();
            var consensus = nucleotides.Select(n => n.First());
            var geneticString = DnaString.Create(Sequence.Create(consensus));
            return geneticString;
        }

        private List<List<Nucleotide>> GetMostFrequentNucleotides() {
            var nucleotides = this.FrequencyMatrix.MaxFrequencies
                .Select((max, i) => this.FrequencyMatrix.Matrix
                    .Where(kvp => kvp.Value[i] == max)
                    .Select(kvp => kvp.Key)
                    .ToList())
                .ToList();
            return nucleotides;
        }

        public static DatabaseConsensus For(Database database) {
            return new DatabaseConsensus(database);
        }

        public string PrintConsensus() {
            return string.Format("{0}\r\n{1}", this.ConsensusString, this.FrequencyMatrix.PrintMatrix());
        }
    }
}
