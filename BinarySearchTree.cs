using System;

namespace leetcode {
    public class BinarySearchTree {

        // Check if a BST is valid or not
        public static bool IsValid(TreeNode root) {
            return IsValid(root, null, null);
        }

        private static bool IsValid(TreeNode node, TreeNode min, TreeNode max) {
            if (node == null) {
                return false;
            }

            if (min != null && node.val < min.val) {
                return false;
            }

            if (max != null && node.val > max.val) {
                return false;
            }

            return IsValid(node.left, min, node) &&
                IsValid(node.right, node, max);
        }

        // Check if a value is in the BST
        public static bool In(TreeNode root, int val) {
            if (root == null) {
                return false;
            }

            if (root.val == val) {
                return true;
            }

            if (root.val < val) {
                return In(root.right, val);
            } else {
                return In(root.left, val);
            }
        }

        // Insert a value into BST
        public static TreeNode Insert(TreeNode root, int val) {
            if (root == null) {
                return new TreeNode(val);
            }

            if (root.val < val) {
                root.right = Insert(root.right, val);
            } else if (root.val < val) {
                root.left = Insert(root.left, val);
            }

            return root;
        }

        // Delete a value
        public static TreeNode Delete(TreeNode root, int val) {
            if (root == null) {
                return null;
            }

            if (root.val == val) {
                if (root.left == null) {
                    return root.right;
                } else if (root.right == null) {
                    return root.left;
                } else {
                    var minNode = GetMin(root.right);
                    root.val = minNode.val;
                    root.right = Delete(root.right, minNode.val);
                }
            } else if (root.val < val) {
                root.left = Delete(root.left, val);
            } else if (root.val > val) {
                root.right = Delete(root.right, val);
            }

            return root;
        }

        private static TreeNode GetMin(TreeNode node) {
            while (node != null && node.left != null) {
                node = node.left;
            }

            return node;
        }
    }
}