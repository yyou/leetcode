using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution108 {
        public TreeNode SortedArrayToBST(int[] nums) {
            if (nums == null) {
                return null;
            }

            return SortedArrayToBST(nums, 0, nums.Length - 1);
        }

        private TreeNode SortedArrayToBST(int[] nums, int start, int end) {
            if (start > end) {
                return null;
            }

            if (start == end) {
                return new TreeNode(nums[start]);
            }

            var middle = start + (end - start) / 2;
            var node = new TreeNode(nums[middle]);
            node.left = SortedArrayToBST(nums, start, middle - 1);
            node.right = SortedArrayToBST(nums, middle + 1, end);

            return node;
        }
    }
}