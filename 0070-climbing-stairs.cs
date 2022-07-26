// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution70 {
        public int ClimbStairs(int n) {
            if (n <= 1) {
                return 1;
            }

            var dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;
            int result = 0;
            for (var i = 2; i <= n; ++i) {
                dp[i] = dp[i - 1] + dp[i - 2];
                result = dp[i];
            }

            return result;
        }
    }
}
