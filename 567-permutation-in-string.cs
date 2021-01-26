using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution567 {
        public bool CheckInclusion(string s1, string s2) {
            var need = new Dictionary<char, int>();
            var window = new Dictionary<char, int>();
            for (var i = 0; i < s1.Length; ++i) {
                if (need.ContainsKey(s1[i])) {
                    need[s1[i]]++;
                } else {
                    need[s1[i]] = 1;
                }
            }

            int left = 0, right = 0;
            int valid = 0;

            while (right < s2.Length) {
                char c = s2[right];
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

                while (right - left >= s1.Length) {
                    char d = s2[left];
                    left++;

                    if (valid == need.Count()) {
                        return true;
                    }

                    if (need.ContainsKey(d)) {
                        if (window[d] == need[d]) {
                            valid--;
                        }
                        window[d]--;
                    }
                }
            }

            return false;
        }
    }
}
