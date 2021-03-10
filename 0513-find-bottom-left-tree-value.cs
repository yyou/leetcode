using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution513LayerTraversal {
        public int FindBottomLeftValue(TreeNode root) {
            var result = 0;
            var queue = new Queue<TreeNode>();
            if (root != null) {
                queue.Enqueue(root);
            }
            while (queue.Any()) {
                var size = queue.Count;
                for (var i = 0; i < size; ++i) {
                    var node = queue.Dequeue();
                    if (i == 0) {
                        result = node.val;
                    }
                    if (node.left != null) {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null) {
                        queue.Enqueue(node.right);
                    }
                }
            }
            return result;
        }
    }

    public class Solution513Recursion {
        private int maxDepth = Int32.MinValue;
        private int result = 0;

        public int FindBottomLeftValue(TreeNode root) {
            FindBottomLeftValue(root, 0);
            return result;
        }

        public void FindBottomLeftValue(TreeNode node, int currentDepth) {
            if (node.left == null && node.right == null) {
                if (currentDepth > maxDepth) {
                    maxDepth = currentDepth;
                    result = node.val;
                }
                return;
            }

            if (node.left != null) {
                currentDepth++;
                FindBottomLeftValue(node.left, currentDepth);
                currentDepth--;
            }

            if (node.right != null) {
                currentDepth++;
                FindBottomLeftValue(node.right, currentDepth);
                currentDepth--;
            }
        }
    }
}