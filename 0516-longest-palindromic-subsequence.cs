// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace leetcode {
    public class Solution516 {
        public int LongestPalindromeSubseq(string s) {
            var size = s.Length;

            // dp[i,j] - the length of longest palindrome substring between substring [i,j]
            var dp = new int[size, size];
            for (var i = 0; i < size; ++i) {
                dp[i, i] = 1;
            }

            for (var i = size - 1; i >= 0; --i) {
                for (var j = i + 1; j < size; ++j) {
                    if (s[i] == s[j]) {
                        dp[i, j] = dp[i + 1, j - 1] + 2;
                    } else {
                        dp[i, j] = Math.Max(dp[i, j - 1], dp[i + 1, j]);
                    }
                }
            }

            return dp[0, size - 1];
        }
    }
}
