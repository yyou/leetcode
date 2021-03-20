using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution701Recursion {
        public TreeNode InsertIntoBST(TreeNode root, int val) {
            return InsertValue(root, val);
        }

        private TreeNode InsertValue(TreeNode node, int val) {
            if (node == null) {
                return new TreeNode(val);
            }
            if (node.val > val) {
                node.left = InsertValue(node.left, val);
            } else {
                node.right = InsertValue(node.right, val);
            }
            return node;
        }
    }

    public class Solution701Iteration {
        public TreeNode InsertIntoBST(TreeNode root, int val) {
            if (root == null) {
                return new TreeNode(val);
            }

            var node = root;
            while (node != null) {
                if (node.val > val) {
                    if (node.left == null) {
                        node.left = new TreeNode(val);
                        return root;
                    } else {
                        node = node.left;
                    }
                } else {
                    if (node.right == null) {
                        node.right = new TreeNode(val);
                        return root;
                    } else {
                        node = node.right;
                    }
                }
            }
            return root;
        }
    }
}