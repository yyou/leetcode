// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace leetcode {
    public class Solution122 {
        public int MaxProfit_DP(int[] prices) {
            var size = prices.Length;
            if (size == 0) {
                return 0;
            }

            //[i,0] represents the max value from holding the share on the ith day
            //[i,1] represents the max value from not holding the share on the ith day
            var dp = new int[size, 2];
            dp[0, 0] = -prices[0];
            dp[0, 1] = 0;

            for (var i = 1; i < size; ++i) {
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] - prices[i]);
                dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] + prices[i]);
            }

            return Math.Max(dp[size - 1, 0], dp[size - 1, 1]);
        }

        public int MaxProfit_DP_with_least_space(int[] prices) {
            var size = prices.Length;
            if (size == 0) {
                return 0;
            }

            //[0] represents the max value from holding the share on the current day
            //[1] represents the max value from not holding the share on the current day
            var dp = new int[2];

            dp[0] = -prices[0];
            dp[1] = 0;

            for (var i = 1; i < prices.Length; ++i) {
                dp[0] = Math.Max(dp[0], dp[1] - prices[i]);
                dp[1] = Math.Max(dp[1], dp[0] + prices[i]);
            }

            return Math.Max(dp[0], dp[1]);
        }

        public int MaxProfit_GreedyAlgorithm(int[] prices) {
            var result = 0;
            for (var i = 1; i < prices.Length; ++i) {
                result += Math.Max(prices[i] - prices[i - 1], 0);
            }
            return result;
        }
    }
}
