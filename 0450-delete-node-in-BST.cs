using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution {

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
                    var cur = root.right;
                    while (cur.left != null) {
                        cur = cur.left;
                    }
                    cur.left = root.left;
                    root = root.right;
                    return root;
                }
            }

            return root;
        }
    }
}