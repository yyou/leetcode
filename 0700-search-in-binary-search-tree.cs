using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution700Recursion {
        public TreeNode SearchBST(TreeNode root, int val) {
            if (root == null) {
                return null;
            }

            if (root.val == val) {
                return root;
            }

            if (root.val > val) {
                return SearchBST(root.left, val);
            } else {
                return SearchBST(root.right, val);
            }
        }
    }

    public class Solution700Iteration {
        public TreeNode SearchBST(TreeNode root, int val) {
            while (root != null) {
                if (root.val > val) {
                    root = root.left;
                } else if (root.val < val) {
                    root = root.right;
                } else {
                    return root;
                }
            }
            return null;
        }
    }
}