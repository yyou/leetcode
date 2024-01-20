using System;
using System.Collections.Generic;

namespace leetcode {
    public class PriorityQueue<T> {
        private T[] _items;
        private int _capacity;
        private int _count;
        private readonly IComparer<T> _comparer;

        public PriorityQueue(int capacity, IComparer<T> comparer) {
            if (capacity <= 0) {
                throw new ArgumentException(String.Format("Invalid capacity - {0}", capacity));
            }
            _items = new T[capacity + 1];
            _comparer = comparer;
            _count = 0;
            _capacity = capacity;
        }

        public void Push(T item) {
            if (Count == _capacity) {
                _capacity *= 2;
                var items = new T[_capacity + 1];
                Array.Copy(_items, items, _count + 1);
                _items = items;
            }

            _count++;
            _items[_count] = item;
            var i = _count;
            var p = i / 2;
            while (i > 1 && _comparer.Compare(_items[p], _items[i]) > 0) {
                var tmp = _items[i];
                _items[i] = _items[p];
                _items[p] = tmp;
                i = p;
                p = i / 2;
            }
        }

        public T Pop() {
            if (_count <= 0) {
                throw new Exception("Pop failed - queue empty");
            }

            var val = _items[1];
            _items[1] = _items[_count];
            _count--;
            var idx = 1;
            while (idx < _count) {
                var childIndex = idx * 2;

                if (childIndex > _count) {
                    break;
                }

                // Choose the smaller of children
                if (childIndex + 1 <= _count && _comparer.Compare(_items[childIndex + 1], _items[childIndex]) < 0) {
                    childIndex++;
                }

                if (_comparer.Compare(_items[childIndex], _items[idx]) > 0) {
                    break;
                }

                var tmp = _items[idx];
                _items[idx] = _items[childIndex];
                _items[childIndex] = tmp;

                idx = childIndex;
            }

            return val;
        }

        public int Count {
            get {
                return _count;
            }
        }
    }
}