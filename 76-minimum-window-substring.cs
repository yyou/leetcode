using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution76 {
        public string MinWindow(string s, string t) {
            var need = new Dictionary<Char, Int32>();
            for (var i = 0; i < t.Length; ++i) {
                if (need.ContainsKey(t[i])) {
                    need[t[i]]++;
                } else {
                    need[t[i]] = 1;
                }
            }

            var window = new Dictionary<Char, Int32>();
            var valid = 0;

            var left = 0;
            var right = 0;

            var minimumLength = Int32.MaxValue;
            var start = 0;
            var len = 0;

            while (right < s.Length) {
                // Expand window
                var c = s[right];
                right++;

                if (need.ContainsKey(c)) {
                    if (window.ContainsKey(c)) {
                        window[c]++;
                    } else {
                        window[c] = 1;
                    }

                    if (window[c] == need[c]) {
                        valid++;
                    }
                }

                // Need to shrink window
                while (valid == need.Count()) {
                    if (right - left < minimumLength) {
                        start = left;
                        len = right - left;
                        minimumLength = len;
                    }

                    var d = s[left];
                    left++;

                    if (need.ContainsKey(d)) {
                        if (window[d] == need[d]) {
                            valid--;
                        }
                        window[d]--;
                    }
                }
            }

            if (minimumLength == Int32.MaxValue) {
                return "";
            } else {
                return s.Substring(start, len);
            }
        }
    }
}
