using System;

namespace leetcode {
    public class Solution123 {
        public int MaxProfit(int[] prices) {
            var dp_10 = 0;
            var dp_11 = Int32.MinValue;
            var dp_20 = 0;
            var dp_21 = Int32.MinValue;

            for (var i = 0; i < prices.Length; i++) {
                dp_20 = Math.Max(dp_20, dp_21 + prices[i]);
                dp_21 = Math.Max(dp_21, dp_10 - prices[i]);
                dp_10 = Math.Max(dp_10, dp_11 + prices[i]);
                dp_11 = Math.Max(dp_11, -prices[i]);
            }

            return dp_20;
        }
    }
}