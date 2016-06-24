using System.Collections;
using System.Collections.Generic;

namespace Rosalind.Core.Utilities {
    public interface IReversibleEnumerator<out T> : IEnumerator<T> {
        int Index { get; }
        bool MovePrevious();
        bool MovePrevious(int steps);
    }

    public class ReversibleEnumerator<T> : IReversibleEnumerator<T> {
        private Dictionary<int, T> buffer;
        private int bufferCapacity = 0;
        private IEnumerator<T> enumerator;
        private bool useCapacity = false;

        public T Current { get; private set; }
        public int BufferEnd { get; private set; }
        public int BufferStart { get; private set; }
        public int Index { get; private set; }

        public ReversibleEnumerator(IEnumerator<T> enumerator) {
            this.enumerator = enumerator;
            this.Index = -1;
            this.BufferStart = 0;
            this.BufferEnd = -1;
            this.buffer = new Dictionary<int, T>();
        }

        public ReversibleEnumerator(IEnumerator<T> enumerator, int bufferCapacity)
            : this(enumerator) {
            this.buffer = new Dictionary<int, T>(bufferCapacity);
            this.bufferCapacity = bufferCapacity;
            this.useCapacity = true;
        }

        private void AdvanceBuffer() {
            if (this.Index > this.BufferEnd) {
                if (this.useCapacity && this.buffer.Count >= this.bufferCapacity) {
                    this.buffer.Remove(this.Index - this.bufferCapacity);
                    this.BufferStart++;
                }
                this.buffer.Add(this.Index, this.enumerator.Current);
                this.BufferEnd++;
            }
        }

        public void Dispose() {
            this.enumerator.Dispose();
            this.buffer.Clear();
            this.Index = -1;
        }

        public bool MoveNext() {
            this.Index++;
            if (this.Index > this.BufferEnd) {
                var success = this.enumerator.MoveNext();
                if (success) {
                    AdvanceBuffer();
                    this.Current = this.enumerator.Current;
                } else {
                    this.Current = default(T);
                }
                return success;
            } else {
                this.Current = this.buffer[this.Index];
                return true;
            }
        }

        public bool MovePrevious() {
            if (this.Index - 1 < this.BufferStart) return false;
            this.Index--;
            this.Current = this.buffer[this.Index];
            return true;
        }

        public bool MovePrevious(int steps) {
            if (this.Index - steps < this.BufferStart) return false;
            this.Index -= steps;
            this.Current = this.buffer[this.Index];
            return true;
        }

        public void Reset() {
            this.enumerator.Reset();
            this.buffer.Clear();
            this.Index = -1;
        }

        #region Explicit IEnumerator Implementation
        object IEnumerator.Current {
            get {
                return this.Current;
            }
        }
        #endregion
    }
}
