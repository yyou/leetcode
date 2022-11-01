// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    /**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
    public class Solution145Recursive {
        public IList<int> PostorderTraversal(TreeNode root) {
            IList<int> result = new List<int>();
            PostorderTraversal(root, result);
            return result;
        }

        private void PostorderTraversal(TreeNode node, IList<int> result) {
            if (node == null) {
                return;
            }

            PostorderTraversal(node.left, result);
            PostorderTraversal(node.right, result);
            result.Add(node.val);
        }
    }

    public class Solution145Iteration {
        public IList<int> PostorderTraversal(TreeNode root) {
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
            result = result.Reverse().ToList();
            return result;
        }
    }

    public class Solution145IterationUnified {
        public IList<int> PostorderTraversal(TreeNode root) {
            var result = new List<int>();
            var st = new Stack<TreeNode>();
            if (root != null) {
                st.Push(root);
            }

            while (st.Any()) {
                var node = st.Peek();
                if (node != null) {
                    st.Push(null);

                    if (node.right != null) {
                        st.Push(node.right);
                    }

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
