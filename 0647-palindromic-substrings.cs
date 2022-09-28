// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution647 {
        public int CountSubstrings(string s) {
            var size = s.Length;
            var result = 0;

            // dp[i,j] - the number of palindromic substrings between substring [i,j]
            var dp = new bool[size, size];
            for (var i = size - 1; i >= 0; i--) {
                for (var j = i; j < size; ++j) {
                    if (s[i] == s[j]) {
                        if (j - i <= 1) {
                            result++;
                            dp[i, j] = true;
                        } else if (dp[i + 1, j - 1]) {
                            result++;
                            dp[i, j] = true;
                        }
                    }
                }
            }

            return result;
        }
    }
}
