using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution216 {
        private readonly List<int> _path = new();
        private readonly IList<IList<int>> _result = new List<IList<int>>();

        public IList<IList<int>> CombinationSum3(int k, int n) {
            BackTracking(k, n, 0, 1);
            return _result;
        }

        private void BackTracking(int k, int targetSum, int currentSum, int startIndex) {
            if (_path.Count == k) {
                if (currentSum == targetSum) {
                    var clonedPath = new List<int>();
                    foreach (var p in _path) {
                        clonedPath.Add(p);
                    }
                    _result.Add(clonedPath);
                }
                return;
            }

            for (var i = startIndex; i <= 9; ++i) {
                if (currentSum + i > targetSum) {
                    break;
                }

                _path.Add(i);
                currentSum += i;

                BackTracking(k, targetSum, currentSum, i + 1);

                currentSum -= i;
                _path.RemoveAt(_path.Count - 1);
            }
        }
    }
}