using System.Linq;
using Rosalind.Core;
using Rosalind.Core.Graphing;
using Rosalind.Core.Math;
using Xunit;

namespace Rosalind.Solutions {
    public class Solutions {
        private bool QuickEquivalent(double a, double b) {
            return QuickEquivalent(a, b, 0.001);
        }

        private bool QuickEquivalent(double a, double b, double maxRelativeError) {
            double fst, snd;
            if (a > b) {
                fst = a;
                snd = b;
            } else {
                fst = b;
                snd = a;
            }
            var error = (System.Math.Abs(fst - snd) / fst);
            return error <= maxRelativeError;
        }
        
        [Fact]
        public void DNA() {
            DataService.SolveUsing(DNA_Solve);
        }

        private void DNA_Solve(DataEntry entry) {
            var dnaString = DnaString.Parse(entry.ReadDataset());
            var result = dnaString.Sequence.PrintNucleotideCountsSummary();
            var expected = entry.ReadOrWriteOutput(result);
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void RNA() {
            DataService.SolveUsing(RNA_Solve);
        }

        private void RNA_Solve(DataEntry entry) {
            var dnaString = DnaString.Parse(entry.ReadDataset());
            var result = dnaString.ToRnaString().Sequence.ToString();
            var expected = entry.ReadOrWriteOutput(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void REVC() {
            DataService.SolveUsing(REVC_Solve);
        }

        private void REVC_Solve(DataEntry entry) {
            var dnaString = DnaString.Parse(entry.ReadDataset());
            var result = dnaString.Sequence.ReverseComplement.ToString();
            var expected = entry.ReadOrWriteOutput(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FIB() {
            DataService.SolveUsing(FIB_Solve);
        }

        private void FIB_Solve(DataEntry entry) {
            var input = entry.ReadDataset().ToList<int>(' ');
            var n = input[0];
            var k = input[1];
            var result = Fibonacci.Solve(n, k, 1);
            var expected = entry.ReadOrWriteOutput(result);
            Assert.Equal(expected, result.ToString());
        }

        [Fact]
        public void GC() {
            DataService.SolveUsing(GC_Solve);
        }

        private void GC_Solve(DataEntry entry) {
            var database = Database.Parse(entry.ReadDataset());
            var highest = database.Values
                .OrderByDescending(n => n.Sequence.GcContent)
                .First();
            var result = string.Format("{0}\r\n{1:N6}", highest.Label, highest.Sequence.GcContent);
            var expected = entry.ReadOrWriteOutput(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void HAMM() {
            DataService.SolveUsing(HAMM_Solve);
        }

        private void HAMM_Solve(DataEntry entry) {
            var input = entry.ReadDataset().ToLines();

            var dnaStringA = DnaString.Parse(input[0]);
            var dnaStringB = DnaString.Parse(input[1]);
            var distance = dnaStringA.Sequence.CalculateHammingDistance(dnaStringB.Sequence).ToString();
            var expected = entry.ReadOrWriteOutput(distance);
            Assert.Equal(expected, distance);
        }

        [Fact]
        public void IPRB() {
            DataService.SolveUsing(IPRB_Solve);
        }

        private void IPRB_Solve(DataEntry entry) {
            var input = entry.ReadDataset();

            var factors = FactorGenerator.Population(input);
            var probability = FactorProbability.GetByEnumeration(factors, 
                f => f.Zygosity == Zygosity.HomozygousDominant || f.Zygosity == Zygosity.Heterozygous);
            var result = string.Format("{0:N5}", probability);

            var expected = entry.ReadOrWriteOutput(result);
            Assert.Equal(expected, result);
            IPRB_Solve2(input, expected);
        }

        private void IPRB_Solve2(string input, string expected) {
            var factors = FactorGenerator.Population(input);
            var p = FactorProbability.Calculate(factors);
            var probability = p[Zygosity.HomozygousDominant] + p[Zygosity.Heterozygous];
            var result = string.Format("{0:N5}", probability);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void PROT() {
            DataService.SolveUsing(PROT_Solve);
        }

        private void PROT_Solve(DataEntry entry) {
            var protein = ProteinString.Parse(entry.ReadDataset());
            var encoded = protein.ToEncodedString();
            var expected = entry.ReadOrWriteOutput(encoded);
            Assert.Equal(expected, encoded);
        }

        [Fact]
        public void SUBS() {
            DataService.SolveUsing(SUBS_Solve);
        }

        private void SUBS_Solve(DataEntry entry) {
            var input = entry.ReadDataset().ToLines();
            var source = Sequence.Parse(input[0]);
            var search = Sequence.Parse(input[1]);
            var result = source.FindMotif(search);
            var expected = entry.ReadOrWriteOutput(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CONS() {
            DataService.SolveUsing(CONS_Solve);
        }

        private void CONS_Solve(DataEntry entry) {
            var database = Database.Parse(entry.ReadDataset());
            var consenus = database.GetConsensus();
            var result = consenus.PrintConsensus();
            var expected = entry.ReadOrWriteOutput(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FIBD() {
            DataService.SolveUsing(FIBD_Solve);
        }

        private void FIBD_Solve(DataEntry entry) {
            var input = entry.ReadDataset().ToList<int>(' ');
            var result = Fibonacci.SolveDecay(input[0], input[1]).ToString();
            var expected = entry.ReadOrWriteOutput(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GRPH() {
            DataService.SolveUsing(GRPH_Solve);
        }

        private void GRPH_Solve(DataEntry entry) {
            var database = Database.Parse(entry.ReadDataset());
            var graph = OverlapGraph.For(database, 3);
            var result = graph.ToString();
            var expected = entry.ReadOrWriteOutput(result);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void IEV() {
            DataService.SolveUsing(IEV_Solve);
        }

        public void IEV_Solve(DataEntry entry) {
            var inputs = entry.ReadDataset().ToList<int>(' ');
            var result = FactorProbability.CalculateExpectedOffspring(inputs, 2).ToString("F1");
            var expected = entry.ReadOrWriteOutput(result);
            Assert.Equal(expected, result);
        }
    }
}
