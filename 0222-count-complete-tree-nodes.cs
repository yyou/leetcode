using System;

namespace leetcode {
    public class Solution222 {
        public int CountNodes(TreeNode root) {
            TreeNode leftNode = root;
            TreeNode rightNode = root;

            var hl = 0;
            var hr = 0;

            while (leftNode != null) {
                leftNode = leftNode.left;
                hl++;
            }

            while (rightNode != null) {
                rightNode = rightNode.right;
                hr++;
            }

            if (hl == hr) {
                return (int)Math.Pow(2, hl) - 1;
            } else {
                return 1 + CountNodes(root.left) + CountNodes(root.right);
            }
        }
    }
}