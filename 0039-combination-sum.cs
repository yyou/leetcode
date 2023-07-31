using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution39 {
        public IList<IList<int>> CombinationSum(int[] candidates, int target) {
            _result.Clear();
            _path.Clear();
            Array.Sort(candidates);
            BackTracking(candidates, target, 0, 0);
            return _result;
        }

        private void BackTracking(int[] candidates, int target, int currentSum, int startIndex) {
            if (currentSum > target) {
                return;
            }

            if (currentSum == target) {
                _result.Add(new List<int>(_path));
                return;
            }

            for (var i = startIndex; i < candidates.Length; ++i) {
                _path.Add(candidates[i]);
                currentSum += candidates[i];
                BackTracking(candidates, target, currentSum, i);
                currentSum -= candidates[i];
                _path.RemoveAt(_path.Count - 1);
            }
        }

        private readonly IList<IList<int>> _result = new List<IList<int>>();
        private readonly IList<int> _path = new List<int>();
    }

    public class Solution39AfterCuttingBranches {
        private readonly IList<IList<int>> _result = new List<IList<int>>();
        private readonly IList<int> _path = new List<int>();

        public IList<IList<int>> CombinationSum(int[] candidates, int target) {
            Array.Sort(candidates);
            Backtrack(candidates, target, 0, 0);
            return _result;
        }

        private void Backtrack(int[] candidates, int target, int sum, int startIndex) {
            if (sum == target) {
                _result.Add(new List<int>(_path));
                return;
            }

            for (var i = startIndex; i < candidates.Length && sum + candidates[i] <= target; ++i) {
                _path.Add(candidates[i]);
                sum += candidates[i];

                Backtrack(candidates, target, sum, i);
                _path.RemoveAt(_path.Count - 1);
                sum -= candidates[i];
            }
        }
    }
}