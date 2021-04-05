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
            if (start >= s.Length) {
                var clonedPath = new List<string>();
                foreach (var p in _path) {
                    clonedPath.Add(p);
                }
                _result.Add(clonedPath);
                return;
            }

            for (var i = start; i < s.Length; ++i) {
                if (IsPalindrome(s, start, i)) {
                    _path.Add(s.Substring(start, i - start + 1));
                    Partition(s, i + 1);
                    _path.RemoveAt(_path.Count - 1);
                }
            }
        }

        private bool IsPalindrome(string s, int start, int end) {
            while (start < end) {
                if (s[start] != s[end]) {
                    return false;
                }
                start++;
                end--;
            }
            return true;
        }
    }
}