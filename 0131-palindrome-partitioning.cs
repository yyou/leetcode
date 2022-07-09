using System.Collections.Generic;

namespace leetcode {
    public class Solution131 {
        private readonly IList<IList<string>> _result = new List<IList<string>>();
        private readonly IList<string> _path = new List<string>();

        public IList<IList<string>> Partition(string s) {
            Partition(s, 0);
            return _result;
        }

        private void Partition(string s, int start) {
            if (start >= s.Length) {
                _result.Add(new List<string>(_path));
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

        private static bool IsPalindrome(string s, int start, int end) {
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