// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
using System;

public class Solution1049 {
    public int LastStoneWeightII(int[] stones) {
        var sum = 0;
        for (var i = 0; i < stones.Length; ++i) {
            sum += stones[i];
        }

        var target = sum / 2;
        var dp = new int[30 * 1000 + 1];

        for (var i = 0; i < stones.Length; ++i) {
            for (var j = target; j >= stones[i]; --j) {
                dp[j] = Math.Max(dp[j], dp[j - stones[i]] + stones[i]);
            }
        }

        return sum - dp[target] - dp[target];
    }
}
