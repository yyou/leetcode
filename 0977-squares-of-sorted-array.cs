// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution977 {
        // implemented the O(n) time complexity solution
        public int[] SortedSquares(int[] nums) {

            var result = new int[nums.Length];
            var idx = nums.Length - 1;
            for (int i = 0, j = nums.Length - 1; i <= j;) {
                if (nums[i] * nums[i] < nums[j] * nums[j]) {
                    result[idx--] = nums[j] * nums[j];
                    j--;
                } else {
                    result[idx--] = nums[i] * nums[i];
                    i++;
                }
            }

            return result;
        }
    }
}
