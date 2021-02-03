using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution112 {
        public bool HasPathSum(TreeNode root, int targetSum) {
            if (root == null) {
                return targetSum == 0;
            }

            if (root.left != null && root.right != null) {
                var leftPathResult = HasPathSum(root.left, targetSum - root.val);
                var rightPathResult = HasPathSum(root.right, targetSum - root.val);
                return leftPathResult || rightPathResult;
            } else if (root.right == null) {
                return HasPathSum(root.left, targetSum - root.val);
            } else if (root.left == null) {
                return HasPathSum(root.right, targetSum - root.val);
            } else {
                return root.val == targetSum;
            }
        }
    }
}