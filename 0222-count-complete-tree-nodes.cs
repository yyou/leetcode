using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution222Recursion {
        public int CountNodes(TreeNode root) {
            TreeNode leftNode = root;
            TreeNode rightNode = root;

            var hl = 0;
            var hr = 0;

            while (leftNode != null) {
                leftNode = leftNode.left;
                hl++;
            }

            while (rightNode != null) {
                rightNode = rightNode.right;
                hr++;
            }

            if (hl == hr) {
                return (int)Math.Pow(2, hl) - 1;
            } else {
                return 1 + CountNodes(root.left) + CountNodes(root.right);
            }
        }
    }

    public class Solution222Iteration {
        public int CountNodes(TreeNode root) {
            if (root == null) {
                return 0;
            }

            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            var count = 0;

            while (q.Count() != 0) {
                var size = q.Count();
                count += size;
                for (var i = 0; i < size; i++) {
                    var node = q.Dequeue();
                    if (node.left != null) {
                        q.Enqueue(node.left);
                    }
                    if (node.right != null) {
                        q.Enqueue(node.right);
                    }
                }
            }

            return count;
        }
    }
}