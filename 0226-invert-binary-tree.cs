using System;
using System.Collections.Generic;

namespace leetcode {
    public class Solution226Recursion {
        public TreeNode InvertTree(TreeNode root) {
            if (root == null) {
                return null;
            }

            var leftNode = InvertTree(root.left);
            var rightNode = InvertTree(root.right);
            return new TreeNode(root.val, rightNode, leftNode);
        }
    }

    public class Solution226Iteration {
        public TreeNode InvertTree(TreeNode root) {
            var stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0) {
                var node = stack.Pop();
                if (node == null) {
                    continue;
                }
                var tmp = node.left;
                node.left = node.right;
                node.right = tmp;

                stack.Push(node.right);
                stack.Push(node.left);
            }

            return root;
        }
    }
}
