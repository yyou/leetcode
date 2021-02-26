using System;
using System.Linq;

namespace leetcode {
    public class Solution541 {
        public string ReverseStr(string s, int k) {
            var c = s.ToCharArray();
            var sections = c.Count() / (2 * k);
            for (var i = 0; i < sections; ++i) {
                var start = i * 2 * k;
                ReverseStr(c, start, k);
            }

            if (c.Count() % (2 * k) > 0) {
                var start = sections * 2 * k;
                var len = c.Count() - start;
                if (len < k) {
                    ReverseStr(c, start, len);
                } else {
                    ReverseStr(c, start, k);
                }
            }
            return new String(c);
        }

        private void ReverseStr(char[] c, int start, int len) {
            var i = start;
            var j = start + len - 1;
            while (i < j) {
                var tmp = c[i];
                c[i] = c[j];
                c[j] = tmp;
                i++;
                j--;
            }
        }
    }
}
