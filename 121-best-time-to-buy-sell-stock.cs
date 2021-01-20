using System;

namespace leetcode
{
    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            var dp_i_0 = 0;
            var dp_i_1 = Int32.MinValue;
            for (var i = 0; i < prices.Length; ++i)
            {
                dp_i_0 = Math.Max(dp_i_0, dp_i_1 + prices[i]);
                dp_i_1 = Math.Max(dp_i_1, -prices[i]);
            }
            return dp_i_0;
        }
    }
}
