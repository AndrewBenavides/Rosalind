namespace Rosalind.Core {
    public class Allele {
        public bool IsDominant { get; set; }
        public char Symbol { get; set; }

        public Allele(char symbol) {
            this.Symbol = symbol;
            if (symbol.ToString().ToUpper() == symbol.ToString()) {
                this.IsDominant = true;
            } else {
                this.IsDominant = false;
            }
        }

        public override string ToString() {
            return this.Symbol.ToString();
        }
    }
}
