using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution98 {
        public bool IsValidBST(TreeNode root) {
            if (root == null) {
                return true;
            }

            if (root.left != null && root.left.val >= root.val) {
                return false;
            }

            if (root.right != null && root.right.val <= root.val) {
                return false;
            }

            var leftMax = GetLeftMax(root);
            if (leftMax != null && leftMax.val >= root.val) {
                return false;
            }

            var rightMin = GetRightMin(root);
            if (rightMin != null && rightMin.val <= root.val) {
                return false;
            }

            if (!IsValidBST(root.left)) {
                return false;
            }

            if (!IsValidBST(root.right)) {
                return false;
            }

            return true;
        }

        private TreeNode GetLeftMax(TreeNode node) {
            if (node.left == null) {
                return null;
            }

            var preNode = node.left;
            var curNode = preNode.right;
            while (curNode != null) {
                preNode = curNode;
                curNode = curNode.right;
            }

            return preNode;
        }

        private TreeNode GetRightMin(TreeNode node) {
            if (node.right == null) {
                return null;
            }

            var preNode = node.right;
            var curNode = preNode.left;
            while (curNode != null) {
                preNode = curNode;
                curNode = curNode.left;
            }

            return preNode;
        }
    }
}