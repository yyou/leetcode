// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution96 {
        public int NumTrees(int n) {
            var dp = new int[n + 1];
            dp[0] = 1;

            for (var i = 1; i <= n; ++i) {
                for (var j = 1; j <= i; ++j) {
                    dp[i] += dp[j - 1] * dp[i - j];
                }
            }

            return dp[n];
        }
    }
}
