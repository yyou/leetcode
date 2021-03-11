using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution617Recursion {
        public TreeNode MergeTrees(TreeNode root1, TreeNode root2) {
            if (root1 == null) {
                return root2;
            }

            if (root2 == null) {
                return root1;
            }

            var newNode = new TreeNode(root1.val + root2.val);
            newNode.left = MergeTrees(root1.left, root2.left);
            newNode.right = MergeTrees(root1.right, root2.right);
            return newNode;
        }
    }

    public class Solution617Iteration {
        public TreeNode MergeTrees(TreeNode root1, TreeNode root2) {
            if (root1 == null) {
                return root2;
            }
            if (root2 == null) {
                return root1;
            }

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root1);
            queue.Enqueue(root2);

            while (queue.Any()) {
                var node1 = queue.Dequeue();
                var node2 = queue.Dequeue();
                node1.val += node2.val;
                if (node1.left != null && node2.left != null) {
                    queue.Enqueue(node1.left);
                    queue.Enqueue(node2.left);
                }
                if (node1.right != null && node2.right != null) {
                    queue.Enqueue(node1.right);
                    queue.Enqueue(node2.right);
                }
                if (node1.left == null && node2.left != null) {
                    node1.left = node2.left;
                }
                if (node1.right == null && node2.right != null) {
                    node1.right = node2.right;
                }
            }

            return root1;
        }
    }
}