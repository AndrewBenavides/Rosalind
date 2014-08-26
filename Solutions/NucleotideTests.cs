using Rosalind.Core;
using Xunit;

namespace Rosalind.Solutions {
    public class NucleotideTests {
        [Fact]
        public void DictionaryContainsValues() {
            Assert.NotEmpty(Nucleotide.Registry);
            Assert.Contains<Nucleotide>(Nucleotide.Adenine, Nucleotide.Registry.Values);
            Assert.Contains<Nucleotide>(Nucleotide.Cytosine, Nucleotide.Registry.Values);
            Assert.Contains<Nucleotide>(Nucleotide.Guanine, Nucleotide.Registry.Values);
            Assert.Contains<Nucleotide>(Nucleotide.Thymine, Nucleotide.Registry.Values);
            Assert.Contains<Nucleotide>(Nucleotide.Uracil, Nucleotide.Registry.Values);
            Assert.Equal(16, Nucleotide.Registry.Count);
        }

        [Fact]
        public void Complements() {
            Assert.Equal(Nucleotide.Adenine.Complement, Nucleotide.Thymine);
            Assert.Equal(Nucleotide.Cytosine.Complement, Nucleotide.Guanine);
            Assert.Equal(Nucleotide.Guanine.Complement, Nucleotide.Cytosine);
            Assert.Equal(Nucleotide.Thymine.Complement, Nucleotide.Adenine);
            Assert.Equal(Nucleotide.Uracil.Complement, Nucleotide.Adenine);
        }
    }
}
