using System.Collections.Generic;
using System.Linq;

namespace Rosalind.Core {
    public class RnaString : GeneticString {
        public RnaString(Sequence sequence)
            : base(sequence) { }

        public RnaString(string label, Sequence sequence)
            : base(label, sequence) { }

        public static RnaString Create(Sequence sequence) {
            return new RnaString(sequence);
        }

        public static RnaString Create(string label, Sequence sequence) {
            return new RnaString(label, sequence);
        }

        public static RnaString Parse(string sequenceString) {
            var sequence = Sequence.Parse(sequenceString);
            return new RnaString(sequence);
        }

        public DnaString ToDnaString() {
            var sequence = Sequence.Create(this.Sequence
                .Select(n => n == Nucleotide.Uracil ? Nucleotide.Thymine : n));
            return new DnaString(sequence);
        }

        protected override void VerifySequence() {
            if (this.Sequence.Any(n => n == Nucleotide.Thymine)) {
                var message = "RnaStrings do not utilize the Thymine Nucleotide, check the input string for compliance.";
                throw new System.InvalidOperationException(message);
            }
        }
    }
}
