// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

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

    public class Solution144IterationUnified {
        public IList<int> PreorderTraversal(TreeNode root) {
            var stack = new Stack<TreeNode>();
            var result = new List<int>();

            if (root != null) {
                stack.Push(root);
            }

            while (stack.Any()) {
                var top = stack.Peek();
                if (top != null) {
                    stack.Pop();

                    if (top.right != null) {
                        stack.Push(top.right);
                    }

                    if (top.left != null) {
                        stack.Push(top.left);
                    }

                    stack.Push(top);
                    stack.Push(null);
                } else {
                    stack.Pop();
                    var node = stack.Pop();
                    result.Add(node.val);
                }
            }

            return result;
        }
    }
}
