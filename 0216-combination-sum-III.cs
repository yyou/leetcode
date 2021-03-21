using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution216 {
        private List<int> _path = new List<int>();
        private IList<IList<int>> _result = new List<IList<int>>();

        public IList<IList<int>> CombinationSum3(int k, int n) {
            BackTracking(k, n, 1);
            return _result;
        }

        private void BackTracking(int k, int n, int startIndex) {
            if (_path.Count == k && _path.Sum() == n) {
                var clonedPath = new List<int>();
                foreach (var p in _path) {
                    clonedPath.Add(p);
                }
                _result.Add(clonedPath);
                return;
            }

            if (_path.Count == k) {
                return;
            }

            for (var i = startIndex; i <= 9; ++i) {
                _path.Add(i);
                BackTracking(k, n, i + 1);
                _path.RemoveAt(_path.Count - 1);
            }
        }
    }
}