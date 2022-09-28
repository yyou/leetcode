// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution718 {
        public int FindLength(int[] nums1, int[] nums2) {
            var size1 = nums1.Length;
            var size2 = nums2.Length;
            if (size1 == 0 || size2 == 0) {
                return 0;
            }

            var result = 0;

            // dp[i,j] - the max length of repeated subarray between nums1[i] and nums2[j]
            var dp = new int[size1, size2];
            for (var i = 0; i < size1; ++i) {
                for (var j = 0; j < size2; ++j) {
                    if (nums1[i] == nums2[j]) {
                        if (i == 0 || j == 0) {
                            dp[i, j] = 1;
                        } else {
                            dp[i, j] = dp[i - 1, j - 1] + 1;
                        }
                    }

                    if (dp[i, j] > result) {
                        result = dp[i, j];
                    }
                }
            }

            return result;
        }
    }
}
