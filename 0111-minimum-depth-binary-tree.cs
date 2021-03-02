using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution111 {
        public int MinDepth(TreeNode root) {
            if (root == null) {
                return 0;
            }

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            var steps = 1;

            while (q.Count() != 0) {
                var count = q.Count();
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
                steps++;
            }

            return steps;
        }
    }
}
