using System.Collections.Generic;

namespace leetcode {
    public class Solution78 {
        private readonly IList<IList<int>> _result = new List<IList<int>>();
        private readonly IList<int> _path = new List<int>();

        public IList<IList<int>> Subsets(int[] nums) {
            Subsets(nums, 0);
            return _result;
        }

        private void Subsets(int[] nums, int startIndex) {
            _result.Add(new List<int>(_path));

            for (var i = startIndex; i < nums.Length; ++i) {
                _path.Add(nums[i]);
                Subsets(nums, i + 1);
                _path.RemoveAt(_path.Count - 1);
            }
        }
    }
}