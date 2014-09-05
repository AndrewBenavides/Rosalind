using System.Linq;
using Rosalind.Core;
using Xunit;

namespace Rosalind.Solutions {
    public class LinqExtensionsTests {

        [Fact]
        public void ContainsSequence_List() {
            var a = Sequence.Parse("TACAGAGCTAGCTGTCCGCGTAGTAATGGTAGCGCATCAAGTGAGAGTGTGATTCGGAAGTTGCGATGCGACCCGACGGACGTAACAGTTCACGGGTAAGAAAAAAACGCCGCTGCCGCATATATTTTGTTCCAGGACCAGGTCCGGCTGGAGACTAGATCCTGATTTTTTTTCCCCGACGTGGTACCGTTGGGGACAATCACCTTATTACAAGTTCTTTAACCGTCCCACAAATCACAT");
            var b = Sequence.Parse("TACA");
            var c = Sequence.Parse("TAG");
            var d = Sequence.Parse("CCCACAAA");
            var e = Sequence.Parse("CACAT");
            var f = Sequence.Parse("CACATA");
            var g = Sequence.Parse("G");
            var h = Sequence.Parse("N");

            Assert.True(a.ContainsSequence(b));
            Assert.True(a.ContainsSequence(c));
            Assert.True(a.ContainsSequence(d));
            Assert.True(a.ContainsSequence(e));
            Assert.False(a.ContainsSequence(f));
            Assert.True(a.ContainsSequence(g));
            Assert.False(a.ContainsSequence(h));
        }

        [Fact]
        public void ContainsSequence_Enumerable() {
            var a = Enumerable.Range(0, 9);
            var b = new int[] { 4, 5, 6 };
            var c = new int[] { 4, 5, 7 };
            var d = new int[] { 0 };
            var e = new int[] { 11 };
            Assert.True(a.ContainsSequence(a));
            Assert.True(a.ContainsSequence(b));
            Assert.False(a.ContainsSequence(c));
            Assert.True(a.ContainsSequence(d));
            Assert.False(a.ContainsSequence(e));
        }
    }
}
