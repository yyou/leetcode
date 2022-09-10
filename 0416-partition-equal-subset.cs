// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
using System;

public class Solution416 {
    public bool CanPartition(int[] nums) {
        int sum = 0;
        for (var i = 0; i < nums.Length; ++i) {
            sum += nums[i];
        }

        if (sum % 2 != 0) {
            return false;
        }

        var target = sum / 2;
        var dp = new int[100 * 200 / 2 + 1];
        for (var i = 0; i < nums.Length; ++i) {
            for (var j = target; j >= nums[i]; j--) {
                dp[j] = Math.Max(dp[j], dp[j - nums[i]] + nums[i]);
            }
        }

        return dp[target] == target;
    }
}
