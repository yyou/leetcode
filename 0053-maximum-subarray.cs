// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace leetcode {
    public class Solution53 {
        public int MaxSubArray_WithDP(int[] nums) {
            var size = nums.Length;
            if (size == 0) {
                return 0;
            }

            // dp[i] - the maximum-subarray which includes nums[i-1];
            var dp = new int[size];
            dp[0] = nums[0];
            var result = dp[0];
            for (var i = 1; i < size; ++i) {
                dp[i] = Math.Max(dp[i - 1] + nums[i], nums[i]);
                if (dp[i] > result) {
                    result = dp[i];
                }
            }

            return result;
        }

        public int MaxSubArray_WithGreedy(int[] nums) {
            var result = Int32.MinValue;
            var count = 0;

            for (var i = 0; i < nums.Length; ++i) {
                count += nums[i];
                result = Math.Max(result, count);

                if (count < 0) {
                    count = 0;
                }
            }

            return result;
        }
    }
}
