using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution235Recursion {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
            if (root == null) {
                return null;
            }

            if (root.val > p.val && root.val > q.val) {
                var left = LowestCommonAncestor(root.left, p, q);
                if (left != null) {
                    return left;
                }
            }

            if (root.val < p.val && root.val < q.val) {
                var right = LowestCommonAncestor(root.right, p, q);
                if (right != null) {
                    return right;
                }
            }

            return root;
        }
    }

    public class Solution235Iteration {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
            while (root != null) {
                if (root.val > p.val && root.val > q.val) {
                    root = root.left;
                } else if (root.val < p.val && root.val < q.val) {
                    root = root.right;
                } else {
                    return root;
                }
            }
            return null;
        }
    }
}