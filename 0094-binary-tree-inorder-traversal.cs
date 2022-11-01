// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

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

    public class Solution94IterationUnified {
        public IList<int> InorderTraversal(TreeNode root) {
            var result = new List<int>();
            var st = new Stack<TreeNode>();

            if (root != null) {
                st.Push(root);
            }

            while (st.Any()) {
                var node = st.Peek();
                if (node != null) {
                    node = st.Pop();

                    if (node.right != null) {
                        st.Push(node.right);
                    }

                    st.Push(node);
                    st.Push(null);

                    if (node.left != null) {
                        st.Push(node.left);
                    }
                } else {
                    st.Pop();
                    node = st.Pop();
                    result.Add(node.val);
                }
            }

            return result;
        }
    }
}
