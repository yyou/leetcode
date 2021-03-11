using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution700Recursion {
        public TreeNode SearchBST(TreeNode root, int val) {
            if (root == null) {
                return null;
            }

            if (root.val == val) {
                return root;
            }

            if (root.val > val) {
                return SearchBST(root.left, val);
            } else {
                return SearchBST(root.right, val);
            }
        }
    }

    public class Solution700Iteration {
        public TreeNode SearchBST(TreeNode root, int val) {
            if (root == null) {
                return null;
            }

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Any()) {
                var node = queue.Dequeue();
                if (node == null) {
                    return null;
                }

                if (node.val == val) {
                    return node;
                }

                if (node.val > val) {
                    queue.Enqueue(node.left);
                }

                if (node.val < val) {
                    queue.Enqueue(node.right);
                }
            }
            return null;
        }
    }
}