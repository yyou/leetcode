// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace leetcode {
    public class Solution0055 {
        public bool CanJump(int[] nums) {
            var cover = 0;
            for (var i = 0; i <= cover; i++) {
                cover = Math.Max(nums[i] + i, cover);
                if (cover >= nums.Length - 1) {
                    return true;
                }
            }

            return false;
        }
    }
}
