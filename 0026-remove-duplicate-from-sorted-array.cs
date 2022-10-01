// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution26 {
        public int RemoveDuplicates(int[] nums) {
            var slowIndex = 0;
            for (var fastIndex = 0; fastIndex < nums.Length - 1; ++fastIndex) {
                if (nums[fastIndex] != nums[fastIndex + 1]) {
                    nums[slowIndex] = nums[fastIndex];
                    slowIndex++;
                }
            }

            nums[slowIndex] = nums[nums.Length - 1];
            slowIndex++;
            return slowIndex;
        }
    }
}
