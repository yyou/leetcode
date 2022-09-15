// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution518 {
        public int Change(int amount, int[] coins) {
            var dp = new int[amount + 1];
            dp[0] = 1;
            for (var i = 0; i < coins.Length; ++i) {
                for (var j = coins[i]; j <= amount; ++j) {
                    dp[j] += dp[j - coins[i]];
                }
            }

            return dp[amount];
        }
    }
}
