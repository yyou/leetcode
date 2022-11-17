// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution60 {
        public int UniquePaths(int m, int n) {
            int[,] a = new int[m, n];

            for (var i = 0; i < n; ++i) {
                a[0, i] = 1;
            }

            for (var i = 0; i < m; ++i) {
                a[i, 0] = 1;
            }

            for (var i = 1; i < m; ++i) {
                for (var j = 1; j < n; ++j) {
                    a[i, j] = a[i - 1, j] + a[i, j - 1];
                }
            }

            return a[m - 1, n - 1];
        }
    }

    public class Solution60WithSpaceOpportimised {
        public int UniquePaths(int m, int n) {
            var a = new int[n];

            for (var i = 0; i < n; ++i) {
                a[i] = 1;
            }

            for (var j = 1; j < m; ++j) {
                for (var i = 1; i < n; ++i) {
                    a[i] += a[i - 1];
                }
            }

            return a[n - 1];
        }
    }
}

