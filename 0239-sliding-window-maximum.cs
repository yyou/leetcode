// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;

namespace leetcode {
    public class Solution239 {
        public int[] MaxSlidingWindow(int[] nums, int k) {
            var queue = new ForwardQueue();
            for (var i = 0; i < k; ++i) {
                queue.Push(nums[i]);
            }

            var result = new List<int>();
            result.Add(queue.Top());

            for (var i = k; i < nums.Length; ++i) {
                queue.Pop(nums[i - k]);
                queue.Push(nums[i]);
                result.Add(queue.Top());
            }

            return result.ToArray();
        }
    }

    public class ForwardQueue {
        private readonly LinkedList<int> _list;

        public ForwardQueue() {
            _list = new LinkedList<int>();
        }

        public void Push(int val) {
            while (_list.Count > 0 && _list.Last.Value < val) {
                _list.RemoveLast();
            }
            _list.AddLast(val);
        }

        public void Pop(int val) {
            if (_list.Count > 0 && _list.First.Value == val) {
                _list.RemoveFirst();
            }
        }

        public int Top() {
            return _list.First.Value;
        }
    }
}
