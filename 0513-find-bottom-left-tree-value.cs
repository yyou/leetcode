using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution513Recursion {
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
}