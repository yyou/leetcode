// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace leetcode {
    public class Solution300 {
        public int LengthOfLIS(int[] nums) {
            var size = nums.Length;
            if (size == 0) {
                return 0;
            }

            // [i] the longest increasing subsequence that include element [i]
            var dp = new int[size];
            for (var i = 0; i < size; ++i) {
                dp[i] = 1;
            }

            int result = 1;
            for (var i = 1; i < size; ++i) {
                for (var j = 0; j < i; ++j) {
                    if (nums[i] > nums[j]) {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }

                if (dp[i] > result) {
                    result = dp[i];
                }
            }

            return result;
        }
    }
}
