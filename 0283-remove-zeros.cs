// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution283 {
        public void MoveZeroes(int[] nums) {
            var slowIndex = 0;
            for (var fastIndex = 0; fastIndex < nums.Length; ++fastIndex) {
                if (nums[fastIndex] != 0) {
                    nums[slowIndex] = nums[fastIndex];
                    slowIndex++;
                }
            }

            for (var i = slowIndex; i < nums.Length; ++i) {
                nums[i] = 0;
            }
        }
    }
}
