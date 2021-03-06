using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
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