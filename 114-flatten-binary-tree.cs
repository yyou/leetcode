using System;

namespace leetcode {
    public class Solution114 {
        public void Flatten(TreeNode root) {
            if (root == null) {
                return;
            }

            Flatten(root.left);
            Flatten(root.right);

            if (root.left != null) {
                var p = root.left;
                while (p.right != null) {
                    p = p.right;
                }

                p.right = root.right;
                root.right = root.left;
                root.left = null;
            }
        }
    }
}