using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosalind.Core {
    public class ProteinString : GeneticString {
        public ProteinString(Sequence sequence)
            : base(sequence) { }

        public ProteinString(string label, Sequence sequence)
            : base(label, sequence) { }

        public static ProteinString Create(Sequence sequence) {
            return new ProteinString(sequence);
        }

        public static ProteinString Create(string label, Sequence sequence) {
            return new ProteinString(label, sequence);
        }

        public static ProteinString Parse(string sequenceString) {
            var sequence = Sequence.Parse(sequenceString);
            return new ProteinString(sequence);
        }

        public string ToEncodedString() {
            var encoded = this.Sequence
                .Partition(3)
                .Select(part => AminoAcid.Lookup(part).Symbol)
                .Concatenate();
            return encoded.Trim();
        }

        protected override void VerifySequence() {
            VerifyStartCodon();
            VerifyStopCodon();
        }

        private void VerifyStartCodon() {
            if (this.Sequence.Take(3).Concatenate() != "AUG") {
                var message = "Sequence is not valid for a protein string: Sequence does not begin with the starting codon (\"AUG\").";
                throw new InvalidOperationException(message);
            }
        }

        private void VerifyStopCodon() {
            var stopCodons = AminoAcid.Registry
                .Where(a => a.Value.Type == AminoAcid.Types.Stop)
                .Select(a => a.Key);
            var last = this.Sequence
                .Skip(this.Sequence.Count - 3)
                .Concatenate();
            if (!stopCodons.Contains(last)) {
                var message = "Sequence is not valid for a protein string: Sequence does not end with a stop codon (\"UAA\", \"UGA\", \"UAG\").";
                throw new InvalidOperationException(message);
            }
        }
    }
}
