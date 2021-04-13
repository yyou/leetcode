using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution90 {
        private IList<IList<int>> _result = new List<IList<int>>();
        private IList<int> _path = new List<int>();

        public IList<IList<int>> SubsetsWithDup(int[] nums) {
            Array.Sort(nums);
            var used = new bool[nums.Length];
            Backtracking(nums, 0, used);
            return _result;
        }

        private void Backtracking(int[] nums, int startIndex, bool[] used) {
            AddToResult(_path);

            for (var i = startIndex; i < nums.Length; ++i) {
                if (i > 0 && nums[i] == nums[i - 1] && used[i - 1] == false) {
                    continue;
                }
                _path.Add(nums[i]);
                used[i] = true;
                Backtracking(nums, i + 1, used);
                used[i] = false;
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