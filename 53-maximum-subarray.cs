using System;

namespace leetcode {
    public class Solution53 {
        public int MaxSubArray(int[] nums) {
            var res = Int32.MinValue;
            if (nums.Length == 0) {
                return 0;
            }

            var dp_0 = nums[0];
            res = Math.Max(res, dp_0);
            for (var i = 1; i < nums.Length; ++i) {
                dp_0 = Math.Max(nums[i], nums[i] + dp_0);

                res = Math.Max(res, dp_0);
            }

            return res;
        }
    }
}