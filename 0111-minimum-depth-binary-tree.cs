// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution111Iteration {
        public int MinDepth(TreeNode root) {
            if (root == null) {
                return 0;
            }

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            var steps = 0;

            while (q.Count() != 0) {
                var count = q.Count();
                steps++;
                for (var i = 0; i < count; i++) {
                    var currentNode = q.Dequeue();

                    if (currentNode.left == null && currentNode.right == null) {
                        return steps;
                    }

                    if (currentNode.left != null) {
                        q.Enqueue(currentNode.left);
                    }

                    if (currentNode.right != null) {
                        q.Enqueue(currentNode.right);
                    }
                }
            }

            return steps;
        }
    }

    public class Solution111Recursion {
        public int MinDepth(TreeNode root) {
            if (root == null) {
                return 0;
            }

            var leftDepth = MinDepth(root.left);
            var rightDepth = MinDepth(root.right);

            if (root.left == null) {
                return rightDepth + 1;
            }

            if (root.right == null) {
                return leftDepth + 1;
            }

            return Math.Min(leftDepth, rightDepth) + 1;
        }
    }
}
