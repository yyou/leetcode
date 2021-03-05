using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution94Recursion {
        public IList<int> InorderTraversal(TreeNode root) {
            IList<int> result = new List<int>();
            InorderTraversal(root, result);
            return result;
        }

        private void InorderTraversal(TreeNode node, IList<int> result) {
            if (node == null) {
                return;
            }

            InorderTraversal(node.left, result);
            result.Add(node.val);
            InorderTraversal(node.right, result);
        }
    }

    public class Solution94Iteration {
        public IList<int> InorderTraversal(TreeNode root) {
            IList<int> result = new List<int>();
            var stack = new Stack<TreeNode>();
            var cur = root;
            while (cur != null || stack.Count > 0) {
                if (cur != null) {
                    stack.Push(cur);
                    cur = cur.left;
                } else {
                    cur = stack.Pop();
                    result.Add(cur.val);
                    cur = cur.right;
                }
            }

            return result;
        }
    }
}