using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution236 {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
            var path1 = new Stack<TreeNode>();
            IsAncestor(root, p, path1);

            var path2 = new Stack<TreeNode>();
            IsAncestor(root, q, path2);

            TreeNode lowestAncestor = root;
            while (path1.Any() && path2.Any()) {
                var node1 = path1.Pop();
                var node2 = path2.Pop();
                if (node1.val != node2.val) {
                    break;
                }
                lowestAncestor = node1;
            }

            return lowestAncestor;
        }

        private bool IsAncestor(TreeNode upperNode, TreeNode lowerNode, Stack<TreeNode> path) {
            if (upperNode == null) {
                return false;
            }

            if (upperNode.val == lowerNode.val) {
                path.Push(upperNode);
                return true;
            }

            if (upperNode.left != null && IsAncestor(upperNode.left, lowerNode, path)) {
                path.Push(upperNode);
                return true;
            }

            if (upperNode.right != null && IsAncestor(upperNode.right, lowerNode, path)) {
                path.Push(upperNode);
                return true;
            }

            return false;
        }
    }
}
