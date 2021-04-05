using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution131 {
        private IList<IList<string>> _result = new List<IList<string>>();
        private IList<string> _path = new List<string>();

        public IList<IList<string>> Partition(string s) {
            Partition(s, 0);
            return _result;
        }

        private void Partition(string s, int start) {
            if (start == s.Length) {
                var clonedPath = new List<string>();
                foreach (var p in _path) {
                    clonedPath.Add(p);
                }
                _result.Add(clonedPath);
                return;
            }

            for (var i = start + 1; i <= s.Length; ++i) {
                var sub = s.Substring(start, i - start);
                if (IsPalindrome(sub)) {
                    _path.Add(sub);
                    Partition(s, i);
                    _path.RemoveAt(_path.Count - 1);
                }
            }
        }

        private bool IsPalindrome(string s) {
            var i = 0;
            var j = s.Length - 1;
            while (i < j) {
                if (s[i] != s[j]) {
                    return false;
                }
                i++;
                j--;
            }
            return true;
        }
    }
}