using System;

namespace leetcode
{
    public class Solution
    {
        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            return Build(nums, 0, nums.Length - 1);
        }

        private TreeNode Build(int[] nums, int lo, int hi) {
            if (lo > hi) {
                return null;
            }

            var max = Int32.MinValue;
            var index = -1;
            for(var i = lo; i <= hi; ++i) {
                if (nums[i] > max) {
                    max = nums[i];
                    index = i;
                }
            }

            var left = Build(nums, lo, index - 1);
            var right = Build(nums, index + 1, hi);
            return new TreeNode(nums[index], left, right);
        }
    }
}