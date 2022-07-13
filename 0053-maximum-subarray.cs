// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace leetcode {
    public class Solution53 {
        public int MaxSubArray_WithDP(int[] nums) {
            var res = Int32.MinValue;
            if (nums.Length == 0) {
                return 0;
            }

            var dp_0 = nums[0];
            res = Math.Max(res, dp_0);
            for (var i = 1; i < nums.Length; ++i) {
                dp_0 = Math.Max(nums[i], nums[i] + dp_0);

                res = Math.Max(res, dp_0);
            }

            return res;
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
