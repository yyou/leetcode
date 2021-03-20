using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution450Recursion {

        public TreeNode DeleteNode(TreeNode root, int key) {
            if (root == null) {
                return root;
            }

            if (root.val == key) {
                if (root.left == null && root.right == null) {
                    return null;
                } else if (root.left == null) {
                    return root.right;
                } else if (root.right == null) {
                    return root.left;
                } else {
                    // If the left and right children are not empty, 
                    // the left subtree head node (left child) of the deleted copy
                    // is placed on the left child of the leftmost node of the right 
                    // subtree of the deleted copy, and the right child of the delete
                    // list is returned as the new root
                    var cur = root.right;
                    while (cur.left != null) {
                        cur = cur.left;
                    }
                    cur.left = root.left;
                    root = root.right;
                    return root;
                }
            }

            if (root.val > key) {
                root.left = DeleteNode(root.left, key);
            } else if (root.val < key) {
                root.right = DeleteNode(root.right, key);
            }

            return root;
        }
    }

    public class Solution450AnotherRecursion {
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