// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace leetcode {
    public class Solution213 {
        public int Rob(int[] nums) {
            if (nums.Length == 0) {
                return 0;
            }

            if (nums.Length == 1) {
                return nums[0];
            }

            if (nums.Length == 2) {
                return Math.Max(nums[0], nums[1]);
            }

            var result1 = RobRange(nums, 1, nums.Length - 1);
            var result2 = RobRange(nums, 0, nums.Length - 2);

            return Math.Max(result1, result2);
        }

        private int RobRange(int[] nums, int start, int end) {
            if (start == end) {
                return nums[start];
            }
            if (start + 1 == end) {
                return Math.Max(nums[start], nums[end]);
            }

            var dp = new int[nums.Length];
            dp[start] = nums[start];
            dp[start + 1] = Math.Max(nums[start], nums[start + 1]);
            for (var i = start + 2; i <= end; ++i) {
                dp[i] = Math.Max(dp[i - 2] + nums[i], dp[i - 1]);
            }

            return dp[end];
        }
    }
}
