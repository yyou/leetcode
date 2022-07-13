// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace leetcode {
    public class Solution455 {
        public int FindContentChildren(int[] g, int[] s) {
            //solution 1: the largest cookie should be assigned to the one with largest greed factor 
            // Array.Sort(g);
            // Array.Sort(s);
            // int count = 0;
            // var index = s.Length - 1;
            // for (var i = g.Length - 1; i >= 0; i--) {
            //     if (index >= 0 && s[index] >= g[i]) {
            //         count++;
            //         index--;
            //     }
            // }
            // return count;

            //Solution 2: the smallest cookie should be assigned to the one with smallest greed factor
            Array.Sort(g);
            Array.Sort(s);

            int count = 0;
            var childIndex = 0;
            for (var cookieIndex = 0; cookieIndex < s.Length; ++cookieIndex) {
                if (childIndex < g.Length && s[cookieIndex] >= g[childIndex]) {
                    count++;
                    childIndex++;
                }
            }

            return count;
        }
    }
}
