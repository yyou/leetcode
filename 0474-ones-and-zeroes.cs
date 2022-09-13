// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

public class Solution474 {
    public int FindMaxForm(string[] strs, int m, int n) {
        var dp = new int[m + 1, n + 1];
        foreach (var str in strs) {
            var ones = 0;
            var zeroes = 0;
            for (var k = 0; k < str.Length; ++k) {
                if (str[k] == '0') {
                    zeroes++;
                } else {
                    ones++;
                }
            }

            for (var i = m; i >= zeroes; i--) {
                for (var j = n; j >= ones; j--) {
                    dp[i, j] = Math.Max(dp[i, j], dp[i - zeroes, j - ones] + 1);
                }
            }
        }

        return dp[m, n];
    }
}
