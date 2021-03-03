using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution347 {
        public int[] TopKFrequent(int[] nums, int k) {
            var dict = new ItemCountDictionary<int>();
            foreach (var num in nums) {
                dict[num]++;
            }

            var queue = new MyPriorityQueue();
            foreach (var node in dict) {
                queue.Push(new Tuple<int, int>(node.Key, node.Value));
                if (queue.Count > k) {
                    queue.Pop();
                }
            }

            var result = new int[k];
            var index = 0;
            while (queue.Count > 0) {
                var node = queue.Pop();
                result[index++] = node.Item1;
            }

            return result;
        }
    }

    public class MyPriorityQueue {
        private List<Tuple<int, int>> _list;

        public MyPriorityQueue() {
            _list = new List<Tuple<int, int>>();
        }

        public void Push(Tuple<int, int> item) {
            int index = _list.Count() - 1;
            while (index >= 0 && _list[index].Item2 > item.Item2) {
                index--;
            }
            _list.Insert(index + 1, item);
        }

        public Tuple<int, int> Pop() {
            var node = _list.First();
            _list.RemoveAt(0);
            return node;
        }

        public int Count {
            get {
                return _list.Count();
            }
        }
    }
}