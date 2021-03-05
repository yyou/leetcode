using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution144Recursion {
        public IList<int> PreorderTraversal(TreeNode root) {
            IList<int> result = new List<int>();
            PreorderTraversal(root, result);
            return result;
        }

        private void PreorderTraversal(TreeNode node, IList<int> result) {
            if (node == null) {
                return;
            }
            result.Add(node.val);
            PreorderTraversal(node.left, result);
            PreorderTraversal(node.right, result);
        }
    }

    public class Solution144Iteration {
        public IList<int> PreorderTraversal(TreeNode root) {
            IList<int> result = new List<int>();
            var stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0) {
                var node = stack.Pop();
                if (node == null) {
                    continue;
                }
                result.Add(node.val);
                stack.Push(node.right);
                stack.Push(node.left);
            }
            return result;
        }
    }
}