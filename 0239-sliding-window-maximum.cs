using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode
{
    public class Solution239 {
        public int[] MaxSlidingWindow(int[] nums, int k) {
            var queue = new MyQueue();
            for(var i = 0; i < k; ++i) {
                queue.Enqueue(nums[i]);
            }
            
            var result = new List<int>();
            result.Add(queue.Top());
            
            for(var i = k; i < nums.Length; ++i) {
                queue.Dequeue(nums[i-k]);
                queue.Enqueue(nums[i]);
                result.Add(queue.Top());
            }
            
            return result.ToArray();
        }
    }

    public class MyQueue {
        private LinkedList<int> _list;
        
        public MyQueue() {
            _list = new LinkedList<int>();
        }
        
        public void Enqueue(int val) {
            while (_list.Count > 0 && _list.Last.Value < val) {
                _list.RemoveLast();
            }
            _list.AddLast(val);
        }
        
        public void Dequeue(int val) {
            if (_list.Count > 0 && _list.First.Value == val) {
                _list.RemoveFirst();
            }
        }
        
        public int Top() {
            return _list.First.Value;
        }
    }
}