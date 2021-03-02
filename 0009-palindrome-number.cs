using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution9 {
        public bool IsPalindrome(int x) {
            var s = x.ToString();
            int l = 0;
            int r = s.Length - 1;
            while (l <= r) {
                if (s[l] != s[r]) {
                    return false;
                }
                l++;
                r--;
            }

            return true;
        }
    }
}