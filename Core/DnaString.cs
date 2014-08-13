using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Core {
    public class DnaString : GeneticString {
        public DnaString(Sequence sequence)
            : base(sequence) { }

        public DnaString(string label, Sequence sequence)
            : base(label, sequence) { }

        public static DnaString Create(Sequence sequence) {
            return new DnaString(sequence);
        }

        public static DnaString Create(string label, Sequence sequence) {
            return new DnaString(label, sequence);
        }

        public static DnaString Parse(string sequenceString) {
            var sequence = Sequence.Parse(sequenceString);
            return new DnaString(sequence);
        }

        public RnaString ToRnaString() {
            var sequence = Sequence.Create(this.Sequence
                .Select(n => n == Nucleotide.Thymine ? Nucleotide.Uracil : n));
            return new RnaString(sequence);
        }

        protected override void VerifySequence() {
            if (this.Sequence.Any(n => n == Nucleotide.Uracil)) {
                var message = "DnaStrings do not utilize the Uracil Nucleotide, check the input string for compliance.";
                throw new System.InvalidOperationException(message);
            }
        }
    }
}
