namespace Rosalind.Core.Graphing {
    public class Edge<T> {
        public T Head { get; set; }
        public T Tail { get; set; }

        public Edge(T tail, T head) {
            this.Head = head;
            this.Tail = tail;
        }

        public override string ToString() {
            return string.Format("{0} {1}", this.Tail.ToString(), this.Head.ToString());
        }
    }
}
