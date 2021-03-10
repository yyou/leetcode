using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution404 {
        public int SumOfLeftLeaves(TreeNode root) {
            if (root == null) {
                return 0;
            }

            var sum = 0;
            if (root.left != null && root.left.left == null && root.left.right == null) {
                sum += root.left.val;
            }

            sum += SumOfLeftLeaves(root.left);
            sum += SumOfLeftLeaves(root.right);

            return sum;
        }
    }
}