// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
using System;

namespace leetcode {
    public class Solution1143 {
        public int LongestCommonSubsequence(string text1, string text2) {
            var size1 = text1.Length;
            var size2 = text2.Length;
            if (size1 == 0 || size2 == 0) {
                return 0;
            }

            // dp[i,j] - the longest common subsequcen between text1 [0, i-1] and text2 [0, j-1]
            var dp = new int[size1 + 1, size2 + 2];
            for (var i = 1; i <= size1; ++i) {
                for (var j = 1; j <= size2; ++j) {
                    if (text1[i - 1] == text2[j - 1]) {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    } else {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            return dp[size1, size2];
        }
    }
}
