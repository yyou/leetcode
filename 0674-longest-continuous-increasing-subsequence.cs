// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution674 {
        public int FindLengthOfLCIS(int[] nums) {
            var size = nums.Length;
            if (size == 0) {
                return 0;
            }

            // dp[i]: the longest continous increasing subsequence which ends with nums[i]
            var dp = new int[size];
            for (var i = 0; i < size; ++i) {
                dp[i] = 1;
            }

            var result = 1;
            for (var i = 0; i < size - 1; ++i) {
                if (nums[i + 1] > nums[i]) {
                    dp[i + 1] = dp[i] + 1;
                }

                if (dp[i + 1] > result) {
                    result = dp[i + 1];
                }
            }

            return result;
        }
    }
}
