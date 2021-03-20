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
}