// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace leetcode {
    public class Solution406 {
        public int[][] ReconstructQueue(int[][] people) {
            Array.Sort(people, new QueueContructionComparer());

            var result = new List<int[]>();

            for (var i = 0; i < people.Length; ++i) {
                var location = people[i][1];
                if (location >= result.Count) {
                    result.Add(people[i]);
                } else {
                    result.Insert(location, people[i]);
                }
            }

            return result.ToArray();
        }


    }

    public class QueueContructionComparer : IComparer<int[]> {
        public int Compare(int[] a, int[] b) {
            if (a[0] == b[0]) {
                return a[1] - b[1];
            } else {
                return b[0] - a[0];
            }
        }
    }
}
