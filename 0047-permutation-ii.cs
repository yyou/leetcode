using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution0047WithoutSorting {
        private readonly IList<IList<int>> _result = new List<IList<int>>();

        public IList<IList<int>> PermuteUnique(int[] nums) {
            var path = new List<int>();
            var used = new bool[21];
            // Note we didn't sort the original array here
            PermuteUnique(nums, path, used);
            return _result;
        }

        // Use 2 supporting arrays - used and repeated
        private void PermuteUnique(int[] nums, List<int> path, bool[] used) {
            if (nums.Length == path.Count) {
                _result.Add(new List<int>(path));
                return;
            }

            var repeated = new bool[21];
            for (var i = 0; i < nums.Length; ++i) {
                if (used[i] == true) {
                    continue;
                }

                if (repeated[nums[i] + 10] == true) {
                    continue;
                }

                repeated[nums[i] + 10] = true;

                used[i] = true;
                path.Add(nums[i]);
                PermuteUnique(nums, path, used);
                path.RemoveAt(path.Count - 1);
                used[i] = false;
            }
        }
    }

    public class Solution47WithSorting {
        private readonly IList<IList<int>> _result = new List<IList<int>>();

        public IList<IList<int>> PermuteUnique(int[] nums) {
            var path = new List<int>();
            Array.Sort(nums);
            var used = new bool[nums.Length];
            PermuteUnique(nums, path, used);
            return _result;
        }

        private void PermuteUnique(int[] nums, List<int> path, bool[] used) {
            if (nums.Length == path.Count) {
                _result.Add(new List<int>(path));
                return;
            }

            for (var i = 0; i < nums.Length; ++i) {

                if (i > 0 && nums[i] == nums[i - 1] && used[i - 1] == false) {
                    continue;
                }

                if (used[i] == false) {
                    used[i] = true;
                    path.Add(nums[i]);
                    PermuteUnique(nums, path, used);
                    path.RemoveAt(path.Count - 1);
                    used[i] = false;
                }
            }
        }
    }
}