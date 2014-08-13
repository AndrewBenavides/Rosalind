using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosalind.Core {
    public abstract class GeneticString {
        public string Label { get; protected set; }
        public Sequence Sequence { get; protected set; }

        public GeneticString(Sequence sequence) {
            this.Sequence = sequence;
            VerifySequence();
        }

        public GeneticString(string label, Sequence sequence)
            : this(sequence) {
            this.Label = label;
        }

        protected abstract void VerifySequence();

        public override string ToString() {
            if (!string.IsNullOrWhiteSpace(this.Label)) {
                return this.Label;
            }
            return this.Sequence.ToString();
        }
    }
}
