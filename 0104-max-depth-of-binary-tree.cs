// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace leetcode {

    // the depth of a tree node is the path from the root node to that node.
    // the height of a tree node is the longest path from that node to a leaf node.
    // the depth of the whole tree is the height of root node.

    // to get the depth by the height of root node.
    public class Solution104Recursion {
        public int MaxDepth(TreeNode root) {
            if (root == null) {
                return 0;
            }

            if (root.left == null && root.right == null) {
                return 1;
            }

            return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }
    }

    // get the max depth
    public class Solution104Recursion2 {
        private int _result = 0;

        public int MaxDepth(TreeNode root) {
            if (root == null) {
                return 0;
            }

            GetDepth(root, 1);

            return _result;
        }

        private void GetDepth(TreeNode root, int depth) {
            _result = Math.Max(_result, depth);

            if (root.left != null) {
                GetDepth(root.left, depth + 1);
            }

            if (root.right != null) {
                GetDepth(root.right, depth + 1);
            }
        }
    }

    public class Solution104Iteration {
        public int MaxDepth(TreeNode root) {
            if (root == null) {
                return 0;
            }

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            var maxDepth = 0;
            while (queue.Count > 0) {
                var size = queue.Count;
                for (var i = 0; i < size; ++i) {
                    var node = queue.Dequeue();
                    if (node.left != null) {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null) {
                        queue.Enqueue(node.right);
                    }
                }
                maxDepth++;
            }
            return maxDepth;
        }
    }
}
