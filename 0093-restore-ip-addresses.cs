using System.Collections.Generic;

namespace leetcode {
    public class Solution93 {
        private readonly IList<string> _result = new List<string>();
        private readonly IList<int> _path = new List<int>();

        public IList<string> RestoreIpAddresses(string s) {
            RestoreIpAddresses(s, 0);
            return _result;
        }

        private void RestoreIpAddresses(string s, int startIndex) {
            if (_path.Count >= 5) {
                return;
            }

            if (startIndex >= s.Length) {
                if (_path.Count == 4) {
                    var ip = string.Join(".", _path);
                    _result.Add(ip);

                }
                return;
            }

            for (var i = startIndex + 1; i <= s.Length && i - startIndex <= 3; ++i) {
                var sub = s.Substring(startIndex, i - startIndex);
                if (sub.Length > 1 && sub[0] == '0') {
                    continue;
                }

                var num = int.Parse(sub);
                if (num < 0 || num > 255) {
                    continue;
                }

                _path.Add(num);
                RestoreIpAddresses(s, i);
                _path.RemoveAt(_path.Count - 1);
            }
        }
    }
}