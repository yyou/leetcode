// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace leetcode {
    public class Solution122 {
        public int MaxProfit_DP(int[] prices) {
            var dp_i_0 = 0;
            var dp_i_1 = Int32.MinValue;
            for (var i = 0; i < prices.Length; ++i) {
                var tmp = dp_i_0;
                dp_i_0 = Math.Max(dp_i_0, dp_i_1 + prices[i]);
                dp_i_1 = Math.Max(dp_i_1, tmp - prices[i]);
            }
            return dp_i_0;
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
