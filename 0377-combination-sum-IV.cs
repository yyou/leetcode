// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution377 {
        public int CombinationSum4(int[] nums, int target) {
            var dp = new int[target + 1];
            dp[0] = 1;
            for (var j = 1; j <= target; ++j) {
                for (var i = 0; i < nums.Length; ++i) {
                    if (j >= nums[i]) {
                        dp[j] += dp[j - nums[i]];
                    }
                }
            }
            return dp[target];
        }
    }
}
