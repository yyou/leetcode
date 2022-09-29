// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution5 {
        public string LongestPalindrome(string s) {
            var size = s.Length;

            string result = "";

            // dp[i,j] - if the substring [i,j] is palindromic substring
            var dp = new bool[size, size];
            for (var i = size - 1; i >= 0; --i) {
                for (var j = i; j < size; ++j) {
                    if (s[i] == s[j] && (j - i <= 1 || dp[i + 1, j - 1])) {
                        dp[i, j] = true;
                        if (j - i + 1 > result.Length) {
                            result = s.Substring(i, j - i + 1);
                        }
                    }
                }
            }

            return result;
        }
    }
}
