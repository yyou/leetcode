// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution35 {

        // O(logn) solution
        public int SearchInsert1(int[] nums, int target) {
            var left = 0;
            var right = nums.Length - 1;
            while (left <= right) {
                var middle = left + (right - left) / 2;
                if (nums[middle] == target) {
                    return middle;
                } else if (nums[middle] < target) {
                    left = middle + 1;
                } else {
                    right = middle - 1;
                }
            }

            return left;
        }

        // O(n) solution
        public int SearchInsert2(int[] nums, int target) {
            for (var i = 0; i < nums.Length; ++i) {
                if (nums[i] >= target) {
                    return i;
                }
            }

            return nums.Length;
        }
    }
}
