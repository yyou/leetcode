using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution77 {
        private IList<IList<int>> _result = new List<IList<int>>();
        private List<int> _path = new List<int>();

        public IList<IList<int>> Combine(int n, int k) {
            BackTracking(n, k, 1);
            return _result;
        }

        private void BackTracking(int n, int k, int startIndex) {
            if (_path.Count == k) {
                var clonedPath = new List<int>();
                foreach (var num in _path) {
                    clonedPath.Add(num);
                }
                _result.Add(clonedPath);
                return;
            }

            for (var i = startIndex; i <= n; ++i) {
                _path.Add(i);
                BackTracking(n, k, i + 1);
                _path.RemoveAt(_path.Count - 1);
            }
        }
    }
}
