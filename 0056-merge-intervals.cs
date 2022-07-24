// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace leetcode {
    public class Solution56 {
        public int[][] Merge(int[][] intervals) {
            if (intervals.Length <= 1) {
                return intervals;
            }

            Array.Sort(intervals, new Solution56Comparer());

            var result = new List<int[]>();
            var pre = intervals[0];
            for (var i = 1; i < intervals.Length; ++i) {
                var curr = intervals[i];
                if (curr[0] > pre[1]) {
                    result.Add(pre);
                    pre = curr;
                } else {
                    pre[0] = Math.Min(pre[0], curr[0]);
                    pre[1] = Math.Max(pre[1], curr[1]);
                }
            }
            result.Add(pre);

            return result.ToArray();
        }
    }

    public class Solution56Comparer : IComparer<int[]> {
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
