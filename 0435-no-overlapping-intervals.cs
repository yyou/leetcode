// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace leetcode {
    public class Solution435 {
        public int EraseOverlapIntervals(int[][] intervals) {
            if (intervals.Length == 0) {
                return 0;
            }

            Array.Sort(intervals, new Solution435Comparer());

            var count = 1;
            var currentRightBorder = intervals[0][1];
            for (var i = 1; i < intervals.Length; ++i) {
                if (currentRightBorder <= intervals[i][0]) {
                    count++;
                    currentRightBorder = intervals[i][1];
                }
            }

            return intervals.Length - count;
        }
    }

    public class Solution435Comparer : IComparer<int[]> {
        public int Compare(int[] a, int[] b) {
            if (a[1] > b[1]) {
                return 1;
            } else if (a[1] < b[1]) {
                return -1;
            } else {
                return 0;
            }
        }
    }
}
