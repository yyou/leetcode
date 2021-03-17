using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution501Recursion {
        private TreeNode _prev = null;
        private int _count = 0;
        private int _maxCount = 0;
        private List<int> _result = new List<int>();

        public int[] FindMode(TreeNode root) {
            Traversal(root);
            return _result.ToArray();
        }

        private void Traversal(TreeNode node) {
            if (node == null) {
                return;
            }

            Traversal(node.left);

            if (_prev == null) {
                _count = 1;
            } else if (_prev.val == node.val) {
                _count++;
            } else { // do not equal to the previous one
                _count = 1;
            }

            _prev = node;

            if (_count == _maxCount) {
                _result.Add(node.val);
            } else if (_count > _maxCount) {
                _result.Clear();
                _result.Add(node.val);
                _maxCount = _count;
            }

            Traversal(node.right);
        }
    }

    public class Solution501Iteration {
        public int[] FindMode(TreeNode root) {
            var count = 0;
            var maxCount = 0;
            TreeNode prev = null;
            var result = new List<int>();
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
                    if (prev == null) {
                        count = 1;
                    } else if (prev.val == node.val) {
                        count++;
                    } else {
                        count = 1;
                    }

                    if (count == maxCount) {
                        result.Add(node.val);
                    } else if (count > maxCount) {
                        result.Clear();
                        result.Add(node.val);
                        maxCount = count;
                    }

                    prev = node;
                }
            }

            return result.ToArray();
        }
    }
}