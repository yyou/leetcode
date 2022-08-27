// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution63 {
        public int UniquePathsWithObstacles(int[][] obstacleGrid) {
            var m = obstacleGrid.Length;
            var n = obstacleGrid[0].Length;

            int[,] dp = new int[m, n];

            for (var i = 0; i < m && obstacleGrid[i][0] == 0; ++i) {
                dp[i, 0] = 1;
            }

            for (var j = 0; j < n && obstacleGrid[0][j] == 0; ++j) {
                dp[0, j] = 1;
            }

            for (var i = 1; i < m; ++i) {
                for (var j = 1; j < n; ++j) {
                    if (obstacleGrid[i][j] == 1) {
                        continue;
                    }
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }

            return dp[m - 1, n - 1];
        }
    }
}
