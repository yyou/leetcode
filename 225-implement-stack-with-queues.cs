using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class MyStack {
        private Queue<int> _queue1;
        private Queue<int> _queue2;

        /** Initialize your data structure here. */
        public MyStack() {
            _queue1 = new Queue<int>();
            _queue2 = new Queue<int>();
        }

        /** Push element x onto stack. */
        public void Push(int x) {
            _queue1.Enqueue(x);
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop() {
            while (_queue1.Count > 1) {
                _queue2.Enqueue(_queue1.Dequeue());
            }

            var num = _queue1.Dequeue();

            while (_queue2.Count > 0) {
                _queue1.Enqueue(_queue2.Dequeue());
            }

            return num;
        }

        /** Get the top element. */
        public int Top() {
            while (_queue1.Count > 1) {
                _queue2.Enqueue(_queue1.Dequeue());
            }

            var num = _queue1.Dequeue();

            while (_queue2.Count > 0) {
                _queue1.Enqueue(_queue2.Dequeue());
            }

            _queue1.Enqueue(num);

            return num;
        }

        /** Returns whether the stack is empty. */
        public bool Empty() {
            return _queue1.Count == 0;
        }
    }

    /**
     * Your MyStack object will be instantiated and called as such:
     * MyStack obj = new MyStack();
     * obj.Push(x);
     * int param_2 = obj.Pop();
     * int param_3 = obj.Top();
     * bool param_4 = obj.Empty();
     */
}