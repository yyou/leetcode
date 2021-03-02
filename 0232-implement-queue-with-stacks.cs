using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class MyQueue {

        private Stack<int> _stackIn;
        private Stack<int> _stackOut;

        /** Initialize your data structure here. */
        public MyQueue() {
            _stackIn = new Stack<int>();
            _stackOut = new Stack<int>();
        }

        /** Push element x to the back of queue. */
        public void Push(int x) {
            _stackIn.Push(x);
        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop() {
            if (_stackOut.Count == 0) {
                while (_stackIn.Count > 0) {
                    _stackOut.Push(_stackIn.Pop());
                }
            }
            return _stackOut.Pop();
        }

        /** Get the front element. */
        public int Peek() {
            var num = Pop();
            _stackOut.Push(num);
            return num;

        }

        /** Returns whether the queue is empty. */
        public bool Empty() {
            return _stackIn.Count() == 0 && _stackOut.Count() == 0;
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