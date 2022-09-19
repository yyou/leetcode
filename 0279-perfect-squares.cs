// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace leetcode {
    public class Solution0279 {
        public int NumSquares(int n) {
            var dp = new int[n + 1];
            dp[0] = 0;
            for (var i = 1; i <= n; ++i) {
                dp[i] = int.MaxValue;
            }

            for (var i = 1; i <= n; ++i) {
                for (var j = 1; j * j <= i; ++j) {
                    dp[i] = Math.Min(dp[i], dp[i - j * j] + 1);
                }
            }

            return dp[n];
        }
    }
}
