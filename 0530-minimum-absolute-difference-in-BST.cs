using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution530Iteration {
        public int GetMinimumDifference(TreeNode root) {
            var list = new List<int>();
            var stack = new Stack<TreeNode>();
            if (root != null) {
                stack.Push(root);
            }
            while (stack.Any()) {
                var node = stack.Pop();
                if (node != null) {
                    if (node.right != null) {
                        stack.Push(node.right);
                    }
                    stack.Push(node);
                    stack.Push(null);
                    if (node.left != null) {
                        stack.Push(node.left);
                    }
                } else {
                    node = stack.Pop();
                    list.Add(node.val);
                }
            }

            var min = Int32.MaxValue;
            for (var i = 0; i < list.Count - 1; i++) {
                if (list[i + 1] - list[i] < min) {
                    min = list[i + 1] - list[i];
                }
            }

            return min;
        }
    }

    public class Solution530Recursion {
        private Int32 _min = Int32.MaxValue;
        private TreeNode _prev = null;

        public int GetMinimumDifference(TreeNode root) {
            if (root == null) {
                return _min;
            }

            GetMinimumDifference(root.left);

            if (_prev != null && root.val - _prev.val < _min) {
                _min = root.val - _prev.val;
            }

            _prev = root;

            GetMinimumDifference(root.right);

            return _min;
        }
    }
}