// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace leetcode {
    public class Solution309 {
        public int MaxProfit(int[] prices) {
            var size = prices.Length;
            if (size == 0) {
                return 0;
            }

            // 4 different statuses:
            // status 0: buy stock today
            // status 1: not holding any stock tody
            // status 2: sell stock today
            // status 3: in cooling period
            var dp = new int[size, 4];
            dp[0, 0] = -prices[0];
            dp[0, 1] = 0;
            dp[0, 2] = 0;
            dp[0, 3] = 0;

            for (var i = 1; i < size; ++i) {
                dp[i, 0] = Math.Max(dp[i - 1, 0], Math.Max(dp[i - 1, 1], dp[i - 1, 3]) - prices[i]);
                dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 3]);
                dp[i, 2] = dp[i - 1, 0] + prices[i];
                dp[i, 3] = dp[i - 1, 2];
            }

            return Math.Max(dp[size - 1, 1], Math.Max(dp[size - 1, 2], dp[size - 1, 3]));
        }
    }
}
