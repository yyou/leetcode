using System;
using System.Linq;
using System.Collections.Generic;

namespace leetcode {
    public class Solution {
        public int RemoveElement(int[] nums, int val) {
            var slowPointer = 0;
            for (var fastPointer = 0; fastPointer < nums.Length; ++fastPointer) {
                if (nums[fastPointer] != val) {
                    nums[slowPointer++] = nums[fastPointer];
                }
            }
            return slowPointer;
        }
    }
}