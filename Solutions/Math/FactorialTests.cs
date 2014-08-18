using System.Numerics;
using Rosalind.Core.Math;
using Xunit;

namespace Rosalind.Solutions.Math {
    public class FactorialTests {
        [Fact]
        public void Simple() {
            Assert.Equal(1, Factorial.For(1));
            Assert.Equal(2, Factorial.For(2));
            Assert.Equal(120, Factorial.For(5));
            Assert.Equal(2432902008176640000, Factorial.For(20));
        }

        [Fact]
        public void Large() {
            Assert.Equal(BigInteger.Parse("15511210043330985984000000"), Factorial.For(25));
            Assert.Equal(BigInteger.Parse("30414093201713378043612608166064768844377641568960512000000000000"), Factorial.For(50));
            Assert.Equal(BigInteger.Parse("93326215443944152681699238856266700490715968264381621468592963895217599993229915608941463976156518286253697920827223758251185210916864000000000000000000000000"), Factorial.For(100));
        }

        [Fact]
        public void ExceedsLongMaxValue() {
            Assert.True(Factorial.For(21) > long.MaxValue);
        }
    }
}
