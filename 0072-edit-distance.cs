// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace leetcode {
    public class Solution72 {
        public int MinDistance(string word1, string word2) {
            var size1 = word1.Length;
            var size2 = word2.Length;

            // dp[i,j] - the min edit distance between word1's substring [0,i-1] and word2's substring[0,j-1]
            var dp = new int[size1 + 1, size2 + 1];
            for (var i = 0; i <= size1; ++i) {
                dp[i, 0] = i;
            }
            for (var j = 1; j <= size2; ++j) {
                dp[0, j] = j;
            }

            for (var i = 1; i <= size1; ++i) {
                for (var j = 1; j <= size2; ++j) {
                    if (word1[i - 1] == word2[j - 1]) {
                        dp[i, j] = dp[i - 1, j - 1];
                    } else {
                        dp[i, j] = Math.Min(dp[i - 1, j - 1], Math.Min(dp[i - 1, j], dp[i, j - 1])) + 1;
                    }
                }
            }

            return dp[size1, size2];
        }
    }
}
