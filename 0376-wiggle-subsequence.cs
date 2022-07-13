// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution376 {
        public int WiggleMaxLength(int[] nums) {
            if (nums.Length <= 1) {
                return nums.Length;
            }

            var preDiff = 0;
            var result = 1;
            for (var i = 0; i < nums.Length - 1; ++i) {
                var currDiff = nums[i + 1] - nums[i];
                if ((currDiff > 0 && preDiff <= 0) || (currDiff < 0 && preDiff >= 0)) {
                    result++;
                    preDiff = currDiff;
                }
            }

            return result;
        }
    }
}
