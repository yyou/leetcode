// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
using System;

namespace leetcode {
    public class Solution977 {
        // implemented the O(n) time complexity solution
        public int[] SortedSquares(int[] nums) {

            var result = new int[nums.Length];
            var idx = nums.Length - 1;

            var left = 0;
            var right = nums.Length - 1;
            while (left <= right) {
                if (Math.Abs(nums[left]) < Math.Abs(nums[right])) {
                    result[idx] = nums[right];
                    idx--;
                    right--;
                } else if (Math.Abs(nums[left]) > Math.Abs(nums[right])) {
                    result[idx] = nums[left];
                    idx--;
                    left++;
                } else {
                    result[idx] = nums[right];
                    idx--;
                    if (left != right) {
                        result[idx] = nums[left];
                        idx--;
                        left++;
                    }
                    right--;
                }
            }

            for (var i = 0; i < result.Length; ++i) {
                result[i] = result[i] * result[i];
            }

            return result;
        }
    }
}
