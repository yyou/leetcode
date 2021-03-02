using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution101 {
        public bool IsSymmetric(TreeNode root) {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count() > 0) {
                var size = queue.Count();
                var list = new List<int?>();
                for (var n = 0; n < size; ++n) {
                    var node = queue.Dequeue();
                    if (node == null) {
                        list.Add(null);
                    } else {
                        list.Add(node.val);
                    }

                    if (node != null) {
                        queue.Enqueue(node.left);
                        queue.Enqueue(node.right);
                    }
                }

                var i = 0;
                var j = list.Count() - 1;
                while (i < j) {
                    if (list[i] != list[j]) {
                        return false;
                    }
                    i++;
                    j--;
                }
            }

            return true;
        }
    }
}
