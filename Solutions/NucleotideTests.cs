using Rosalind.Core;
using Xunit;

namespace Rosalind.Solutions {
    public class NucleotideTests {
        [Fact]
        public void DictionaryContainsValues() {
            Assert.NotEmpty(Nucleotide.Nucleotides);
            Assert.Contains<Nucleotide>(Nucleotide.Adenine, Nucleotide.Nucleotides.Values);
            Assert.Contains<Nucleotide>(Nucleotide.Cytosine, Nucleotide.Nucleotides.Values);
            Assert.Contains<Nucleotide>(Nucleotide.Guanine, Nucleotide.Nucleotides.Values);
            Assert.Contains<Nucleotide>(Nucleotide.Thymine, Nucleotide.Nucleotides.Values);
            Assert.Contains<Nucleotide>(Nucleotide.Uracil, Nucleotide.Nucleotides.Values);
            Assert.Equal(5, Nucleotide.Nucleotides.Count);
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
