// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace leetcode {
    public class Solution1005 {
        public int LargestSumAfterKNegations(int[] nums, int k) {
            Array.Sort<int>(nums, new AbsoluteValueComparer());

            for (var i = 0; i < nums.Length; ++i) {
                if (nums[i] < 0 && k > 0) {
                    nums[i] *= -1;
                    k--;
                }
            }

            if ((k % 2) == 1) {
                nums[nums.Length - 1] *= -1;
            }

            var result = 0;
            for (var i = 0; i < nums.Length; ++i) {
                result += nums[i];
            }

            return result;

        }

        private class AbsoluteValueComparer : IComparer<int> {
            public int Compare(int v1, int v2) {
                return Math.Abs(v2) - Math.Abs(v1);
            }
        }
    }
}
