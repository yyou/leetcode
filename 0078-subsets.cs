using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution78 {
        private IList<IList<int>> _result = new List<IList<int>>();
        private IList<int> _path = new List<int>();

        public IList<IList<int>> Subsets(int[] nums) {
            Subsets(nums, 0);
            return _result;
        }

        private void Subsets(int[] nums, int startIndex) {
            AddToResult(_path);

            for (var i = startIndex; i < nums.Length; ++i) {
                _path.Add(nums[i]);
                Subsets(nums, i + 1);
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