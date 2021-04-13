using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution491 {
        private IList<IList<int>> _result = new List<IList<int>>();
        private IList<int> _path = new List<int>();

        public IList<IList<int>> FindSubsequences(int[] nums) {
            Backtracking(nums, 0);
            return _result;
        }

        private void Backtracking(int[] nums, int startIndex) {
            if (_path.Count > 1) {
                AddToResult(_path);
            }

            var usedNums = new List<int>();

            for (var i = startIndex; i < nums.Length; ++i) {
                if ((_path.Any() && nums[i] < _path.Last()) || usedNums.IndexOf(nums[i]) != -1) {
                    continue;
                }

                usedNums.Add(nums[i]);

                _path.Add(nums[i]);
                Backtracking(nums, i + 1);
                _path.RemoveAt(_path.Count - 1);
            }
        }

        private void AddToResult(IList<int> path) {
            var clonedPath = new List<int>();
            foreach (var num in path) {
                clonedPath.Add(num);
            }
            _result.Add(clonedPath);
            return;
        }
    }
}