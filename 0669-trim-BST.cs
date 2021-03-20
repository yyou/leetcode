using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution669BasedOnBSTDeletion {
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
}