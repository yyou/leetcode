using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution199 {
        public IList<int> RightSideView(TreeNode root) {
            var queue = new Queue<TreeNode>();
            if (root != null) {
                queue.Enqueue(root);
            }

            var result = new List<int>();
            while (queue.Count > 0) {
                var size = queue.Count;
                var values = new List<int>();
                for (var i = 0; i < size; ++i) {
                    var node = queue.Dequeue();
                    if (i == size - 1) {
                        result.Add(node.val);
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