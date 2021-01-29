using System;
using System.Collections;
using System.Collections.Generic;

namespace leetcode {
    public class Solution1 {
        public int[] TwoSum(int[] nums, int target) {
            var dict = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; ++i) {
                var n = target - nums[i];
                if (dict.ContainsKey(n)) {
                    return new int[] { dict[n], i };
                } else {
                    dict[nums[i]] = i;
                }
            }
            return new int[0];
        }
    }
}
