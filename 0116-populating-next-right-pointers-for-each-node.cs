// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution116Recursion {
        public Node Connect(Node root) {
            if (root == null) {
                return null;
            }
            Connect(root.left, root.right);
            return root;
        }

        private void Connect(Node node1, Node node2) {
            if (node1 == null || node2 == null) {
                return;
            }

            node1.next = node2;

            Connect(node1.left, node1.right);
            Connect(node2.left, node2.right);
            Connect(node1.right, node2.left);
            return;
        }
    }

    public class Solution116Iteration {
        public Node Connect(Node root) {
            var queue = new Queue<Node>();
            if (root != null) {
                queue.Enqueue(root);
            }

            while (queue.Any()) {
                var size = queue.Count;
                for (var i = 0; i < size; ++i) {
                    var node = queue.Dequeue();
                    if (i < size - 1) {
                        node.next = queue.Peek();
                    }

                    if (node.left != null) {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null) {
                        queue.Enqueue(node.right);
                    }
                }
            }

            return root;
        }
    }
}
