using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class MyQueue {
        private Stack<int> _stack1;
        private Stack<int> _stack2;

        /** Initialize your data structure here. */
        public MyQueue() {
            _stack1 = new Stack<int>();
            _stack2 = new Stack<int>();
        }

        /** Push element x to the back of queue. */
        public void Push(int x) {
            _stack1.Push(x);
        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop() {
            while (_stack1.Count > 1) {
                _stack2.Push(_stack1.Pop());
            }
            var num = _stack1.Pop();
            while (_stack2.Count > 0) {
                _stack1.Push(_stack2.Pop());
            }
            return num;
        }

        /** Get the front element. */
        public int Peek() {
            while (_stack1.Count > 1) {
                _stack2.Push(_stack1.Pop());
            }
            var num = _stack1.Peek();
            while (_stack2.Count > 0) {
                _stack1.Push(_stack2.Pop());
            }
            return num;
        }

        /** Returns whether the queue is empty. */
        public bool Empty() {
            return _stack1.Count() == 0;
        }
    }

    /**
     * Your MyQueue object will be instantiated and called as such:
     * MyQueue obj = new MyQueue();
     * obj.Push(x);
     * int param_2 = obj.Pop();
     * int param_3 = obj.Peek();
     * bool param_4 = obj.Empty();
     */
}