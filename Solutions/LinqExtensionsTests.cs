using Rosalind.Core;
using Xunit;

namespace Rosalind.Solutions {
    public class LinqExtensionsTests {

        [Fact]
        public void ContainsSequence() {
            var a = Sequence.Parse("TACAGAGCTAGCTGTCCGCGTAGTAATGGTAGCGCATCAAGTGAGAGTGTGATTCGGAAGTTGCGATGCGACCCGACGGACGTAACAGTTCACGGGTAAGAAAAAAACGCCGCTGCCGCATATATTTTGTTCCAGGACCAGGTCCGGCTGGAGACTAGATCCTGATTTTTTTTCCCCGACGTGGTACCGTTGGGGACAATCACCTTATTACAAGTTCTTTAACCGTCCCACAAATCACAT");
            var b = Sequence.Parse("TACA");
            var c = Sequence.Parse("TAG");
            var d = Sequence.Parse("CCCACAAA");
            var e = Sequence.Parse("CACAT");
            var f = Sequence.Parse("CACATA");
            Assert.True(a.ContainsSequence(b));
            Assert.True(a.ContainsSequence(c));
            Assert.True(a.ContainsSequence(d));
            Assert.True(a.ContainsSequence(e));
            Assert.False(a.ContainsSequence(f));

            var g = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            var h = new int[] { 4, 5, 6 };
            var i = new int[] { 4, 5, 7 };
            Assert.True(g.ContainsSequence(h));
            Assert.False(g.ContainsSequence(i));
        }
    }
}
