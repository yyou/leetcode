using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution117 {
        public Node Connect(Node root) {
            var queue = new Queue<Node>();
            if (root != null) {
                queue.Enqueue(root);
            }
            while (queue.Count() > 0) {
                var size = queue.Count();
                var list = new List<Node>();

                for (var i = 0; i < size; ++i) {
                    var node = queue.Dequeue();
                    list.Add(node);
                    if (node.left != null) {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null) {
                        queue.Enqueue(node.right);
                    }
                }

                for (var i = 0; i < list.Count() - 1; ++i) {
                    list[i].next = list[i + 1];
                }
            }

            return root;
        }
    }
}