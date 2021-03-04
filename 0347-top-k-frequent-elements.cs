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

            var queue = new PriorityQueue<KeyValuePair<int, int>>(200, new ItemFrequencyComparer());
            foreach (var kvPair in dict) {
                queue.Push(kvPair);
                if (queue.Count > k) {
                    queue.Pop();
                }
            }

            var result = new int[k];
            var index = 0;
            while (queue.Count > 0) {
                var node = queue.Pop();
                result[index++] = node.Key;
            }

            return result;
        }
    }

    public class ItemFrequencyComparer : IComparer<KeyValuePair<int, int>> {
        public int Compare(KeyValuePair<int, int> p1, KeyValuePair<int, int> p2) {
            if (p1.Value > p2.Value) {
                return 1;
            } else if (p1.Value < p2.Value) {
                return -1;
            } else {
                return 0;
            }
        }
    }    
}