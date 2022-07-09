using System.Collections.Generic;

namespace leetcode {
    public class Solution77 {
        private readonly IList<IList<int>> _result = new List<IList<int>>();
        private readonly List<int> _path = new();

        public IList<IList<int>> Combine(int n, int k) {
            BackTracking(n, k, 1);
            return _result;
        }

        private void BackTracking(int n, int k, int startIndex) {
            if (_path.Count == k) {
                _result.Add(new List<int>(_path));
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
