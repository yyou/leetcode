// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace leetcode {
    public class Solution198 {
        public int Rob(int[] nums) {
            if (nums.Length == 0) {
                return 0;
            }
            if (nums.Length == 1) {
                return nums[0];
            }
            var dp = new int[nums.Length];
            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);
            for (var i = 2; i < nums.Length; ++i) {
                dp[i] = Math.Max(dp[i - 2] + nums[i], dp[i - 1]);
            }
            return dp[nums.Length - 1];
        }
    }
}
