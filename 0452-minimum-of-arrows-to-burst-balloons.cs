// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace leetcode {
    public class Solution452 {
        public int FindMinArrowShots(int[][] points) {
            Array.Sort(points, new Solution452Comparer());

            var result = 1;

            for (var i = 1; i < points.Length; ++i) {
                if (points[i][0] > points[i - 1][1]) { // not overlap
                    result++;
                } else {
                    points[i][1] = Math.Min(points[i][1], points[i - 1][1]);
                }
            }

            return result;
        }
    }

    public class Solution452Comparer : IComparer<int[]> {
        public int Compare(int[] a, int[] b) {
            if (a[0] < b[0]) {
                return -1;
            } else if (a[0] > b[0]) {
                return 1;
            } else {
                return 0;
            }
        }
    }
}
