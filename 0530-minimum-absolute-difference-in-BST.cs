// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution530IterationAndArray {
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

    public class Solution530Iteration {
        private TreeNode pre = null;
        private int min = int.MaxValue;

        public int GetMinimumDifference(TreeNode root) {
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
                    if (pre != null && node.val - pre.val < min) {
                        min = node.val - pre.val;
                    }
                    pre = node;
                }
            }

            return min;
        }
    }

    public class Solution530Recursion {
        private int _min = int.MaxValue;
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

    public class Solution530RecursionAndArray {
        private readonly List<int> _list = new List<int>();

        public int GetMinimumDifference(TreeNode root) {
            Traversal(root);
            var min = int.MaxValue;
            for (var i = 0; i < _list.Count - 1; ++i) {
                if (min > _list[i + 1] - _list[i]) {
                    min = _list[i + 1] - _list[i];
                }
            }
            return min;
        }

        private void Traversal(TreeNode node) {
            if (node == null) {
                return;
            }

            Traversal(node.left);
            _list.Add(node.val);
            Traversal(node.right);
        }
    }
}
