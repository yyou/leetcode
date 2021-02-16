using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution209 {
        public int MinSubArrayLen(int target, int[] nums) {
            var left = 0;
            var right = 0;

            int sub = 0;
            int minLength = Int32.MaxValue;
            while (right < nums.Length) {
                var num = nums[right];
                right++;
                sub += num;
                if (sub >= target) {
                    var len = right - left;
                    minLength = Math.Min(minLength, len);
                }

                while (sub >= target) {
                    var num2 = nums[left];
                    left++;
                    sub -= num2;
                    if (sub >= target) {
                        var len = right - left;
                        minLength = Math.Min(minLength, len);
                    }
                }
            }

            return (minLength == Int32.MaxValue) ? 0 : minLength;
        }
    }
}