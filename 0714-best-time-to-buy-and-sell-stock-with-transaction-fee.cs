// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace leetcode {
    public class Solution714 {
        public int MaxProfit(int[] prices, int fee) {
            var size = prices.Length;
            if (size == 0) {
                return 0;
            }

            // 2 statuses:
            // status 0: holding the share
            // status 1: not holding the share
            var dp = new int[size, 2];
            dp[0, 0] = -prices[0];
            dp[0, 1] = 0;

            for (var i = 1; i < size; ++i) {
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] - prices[i]);
                dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] + prices[i] - fee);
            }

            return dp[size - 1, 1];
        }
    }
}
