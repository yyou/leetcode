// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution115 {
        public int NumDistinct(string s, string t) {
            var size1 = s.Length;
            var size2 = t.Length;

            // dp[i,j] - the number of distinct subsequences betwwen s [0, i-1] and t [0, j-1]
            var dp = new int[size1 + 1, size2 + 1];
            for (var i = 0; i <= size1; ++i) {
                dp[i, 0] = 1;
            }
            for (var j = 1; j <= size2; ++j) {
                dp[0, j] = 0;
            }

            for (var i = 1; i <= size1; ++i) {
                for (var j = 1; j <= size2; ++j) {
                    if (s[i - 1] == t[j - 1]) {
                        dp[i, j] = dp[i - 1, j - 1] + dp[i - 1, j];
                    } else {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }

            return dp[size1, size2];
        }
    }
}
