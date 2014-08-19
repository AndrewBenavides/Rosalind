using System.Collections.Generic;

namespace Rosalind.Core {
    public class PunnettSquare {
        private Factor[,] matrix;
        private List<Factor> outcomes;

        public Factor Maternal { get; private set; }
        public Factor[,] Matrix { get { return this.matrix; } }
        public List<Factor> Outcomes { get { return this.outcomes; } }
        public Factor Paternal { get; private set; }
                
        public PunnettSquare(Factor paternal, Factor maternal) {
            this.Paternal = paternal;
            this.Maternal = maternal;
            this.matrix = PunnettSquare.CalculateOutcomes(paternal, maternal);
            this.outcomes = PunnettSquare.ListOutcomes(this.matrix);
        }

        public static Factor[,] CalculateOutcomes(Factor p, Factor m) {
            var offspring = new Factor[2, 2];
            for (int i = 0; i <= 1; i++) {
                for (int j = 0; j <= 1; j++) {
                    offspring[i, j] = new Factor(p.Alleles[j], m.Alleles[i]);
                }
            }
            return offspring;
        }

        public static List<Factor> ListOutcomes(Factor[,] factors) {
            var list = new List<Factor>();
            for (int i = 0; i < factors.Rank; i++) {
                for (int j = factors.GetLowerBound(i); j <= factors.GetUpperBound(i); j++) {
                    list.Add(factors[i, j]);
                }
            }
            return list;
        }
    }
}
