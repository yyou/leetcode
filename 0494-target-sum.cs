// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

public class Solution {
    public int FindTargetSumWays(int[] nums, int target) {
        var sum = 0;
        for (var i = 0; i < nums.Length; ++i) {
            sum += nums[i];
        }

        if ((sum + target) % 2 == 1) {
            return 0;
        }

        if (Math.Abs(target) > sum) {
            return 0;
        }

        var bagSize = (sum + target) / 2;
        var dp = new int[bagSize + 1];
        dp[0] = 1;

        for (var i = 0; i < nums.Length; ++i) {
            for (var j = bagSize; j >= nums[i]; j--) {
                dp[j] += dp[j - nums[i]];
            }
        }

        return dp[bagSize];
    }
}
