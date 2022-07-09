using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution90 {
        private readonly IList<IList<int>> _result = new List<IList<int>>();
        private readonly IList<int> _path = new List<int>();

        public IList<IList<int>> SubsetsWithDup(int[] nums) {
            Array.Sort(nums);
            var used = new bool[nums.Length];
            Backtracking(nums, 0, used);
            return _result;
        }

        private void Backtracking(int[] nums, int startIndex, bool[] used) {
            _result.Add(new List<int>(_path));

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
    }
}