// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace leetcode {
    public class Solution343 {
        public int IntegerBreak(int n) {
            var dp = new int[n + 1];
            dp[2] = 1;

            for (var i = 3; i <= n; ++i) {
                for (var j = 1; j < i - 1; j++) {
                    dp[i] = Math.Max(dp[i], Math.Max(j * dp[i - j], j * (i - j)));
                }
            }

            return dp[n];
        }
    }
}
