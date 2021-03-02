using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution349 {
        public int[] Intersection(int[] nums1, int[] nums2) {
            var list1 = new List<int>(nums1);
            var list2 = new List<int>(nums2);
            return list1.Intersect(list2).ToArray();
        }
    }
}