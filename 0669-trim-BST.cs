using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution669BasedOnBSTDeletion { //complex
        public TreeNode TrimBST(TreeNode root, int low, int high) {
            if (root == null) {
                return null;
            }

            root.left = TrimBST(root.left, low, high);
            root.right = TrimBST(root.right, low, high);

            if (root.val < low || root.val > high) {
                return DeleteNode(root, root.val);
            }

            return root;
        }

        public TreeNode DeleteNode(TreeNode root, int key) {
            if (root == null) {
                return root;
            }

            if (root.val > key) {
                root.left = DeleteNode(root.left, key);
            } else if (root.val < key) {
                root.right = DeleteNode(root.right, key);
            } else {
                if (root.left == null && root.right == null) {
                    return null;
                } else if (root.left == null) {
                    return root.right;
                } else if (root.right == null) {
                    return root.left;
                } else {
                    // Find the most right node of current node's left child
                    // and replace the current node with that node
                    var node = root.left;
                    while (node.right != null) {
                        node = node.right;
                    }
                    var val = node.val;
                    root.left = DeleteNode(root.left, val);
                    root.val = val;
                    return root;
                }
            }

            return root;
        }
    }

    public class Solution669Another { // better to understand but still contains unnecessary trim operation
        public TreeNode TrimBST(TreeNode root, int low, int high) {
            if (root == null) {
                return null;
            }

            // These 2 lines contains unnecessary trim operations
            // We don't need to check every node in BST
            root.left = TrimBST(root.left, low, high);
            root.right = TrimBST(root.right, low, high);

            if (root.val >= low && root.val <= high) {
                return root;
            }

            if (root.left == null && root.right == null) {
                return null;
            }

            if (root.left == null) {
                return root.right;
            }

            if (root.right == null) {
                return root.left;
            }

            var cur = root.right;
            while (cur.left != null) {
                cur = cur.left;
            }

            cur.left = root.left;
            return root.right;
        }
    }

    public class Solution669Simple { // removed unnecessary trim operations
        public TreeNode TrimBST(TreeNode root, int low, int high) {
            if (root == null) {
                return null;
            }

            // This step will avoid trimming root.left
            if (root.val < low) {
                return TrimBST(root.right, low, high);
            }

            // This step will avoid trimming root.right
            if (root.val > high) {
                return TrimBST(root.left, low, high);
            }

            root.left = TrimBST(root.left, low, high);
            root.right = TrimBST(root.right, low, high);

            return root;
        }
    }
}