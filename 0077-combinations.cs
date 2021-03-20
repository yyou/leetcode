using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution77 {
        private IList<IList<int>> _result = new List<IList<int>>();

        public IList<IList<int>> Combine(int n, int k) {
            var selectedList = new List<int>();
            for (var i = 1; i <= n; ++i) {
                selectedList.Add(i);
            }

            var path = new List<int>();

            BackTracking(path, selectedList, 0, k);

            return _result;
        }

        private void BackTracking(List<int> path, List<int> selectedList, int currentIndex, int k) {
            if (path.Count == k) {
                var clonedPath = new List<int>();
                foreach (var num in path) {
                    clonedPath.Add(num);
                }
                _result.Add(clonedPath);
                return;
            }

            for (var i = currentIndex; i < selectedList.Count; ++i) {
                if (path.IndexOf(selectedList[i]) != -1) {
                    continue;
                }

                path.Add(selectedList[i]);
                BackTracking(path, selectedList, i + 1, k);
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
