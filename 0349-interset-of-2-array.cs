// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution349 {
        public int[] Intersection(int[] nums1, int[] nums2) {
            var a1 = new int[1001];
            foreach (var i in nums1) {
                a1[i]++;
            }

            var a2 = new int[1001];
            foreach (var i in nums2) {
                a2[i]++;
            }

            var intersect = new List<int>();
            for (var i = 0; i <= 1000; i++) {
                if (a1[i] > 0 && a2[i] > 0) {
                    intersect.Add(i);
                }
            }

            return intersect.ToArray();
        }

        // If the number's range is too big, then it's a waste to use array as hashtable.
        public int[] Intersection2(int[] nums1, int[] nums2) {
            var set = new HashSet<int>();
            foreach (var i in nums1) {
                set.Add(i);
            }

            var result = new HashSet<int>();
            foreach (var i in nums2) {
                if (set.Contains(i)) {
                    result.Add(i);
                }
            }

            return result.ToArray();
        }
    }
}
