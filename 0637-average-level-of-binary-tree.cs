using System;
using System.Collections.Generic;

namespace leetcode {
    public class Solution637 {
        public IList<double> AverageOfLevels(TreeNode root) {
            var queue = new Queue<TreeNode>();
            if (root != null) {
                queue.Enqueue(root);
            }

            var result = new List<double>();
            while (queue.Count > 0) {
                var size = queue.Count;
                var values = new List<int>();
                var sum = 0.0d;
                for (var i = 0; i < size; ++i) {
                    var node = queue.Dequeue();
                    sum += node.val;
                    if (node.left != null) {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null) {
                        queue.Enqueue(node.right);
                    }
                }
                result.Add(sum / size);
            }
            return result;
        }
    }
}