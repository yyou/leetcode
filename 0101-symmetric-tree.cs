using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution101LevelTraversal {
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

    public class Solution101PostorderTraversal {
        public bool IsSymmetric(TreeNode root) {
            if (root == null) {
                return true;
            }

            return IsSymmetric(root.left, root.right);
        }

        private bool IsSymmetric(TreeNode leftNode, TreeNode rightNode) {
            if (leftNode == null && rightNode == null) {
                return true;
            }

            if (leftNode == null || rightNode == null) {
                return false;
            }

            if (leftNode.val != rightNode.val) {
                return false;
            }

            return IsSymmetric(leftNode.left, rightNode.right) &&
                IsSymmetric(leftNode.right, rightNode.left);
        }
    }

    public class Solution101Iteration {
        public bool IsSymmetric(TreeNode root) {
            if (root == null) {
                return true;
            }

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root.left);
            queue.Enqueue(root.right);

            while (queue.Count > 0) {
                var leftNode = queue.Dequeue();
                var rightNode = queue.Dequeue();

                if (leftNode == null && rightNode == null) {
                    continue;
                }

                if (leftNode == null || rightNode == null) {
                    return false;
                }

                if (leftNode.val != rightNode.val) {
                    return false;
                }

                queue.Enqueue(leftNode.left);
                queue.Enqueue(rightNode.right);
                queue.Enqueue(leftNode.right);
                queue.Enqueue(rightNode.left);
            }

            return true;
        }
    }
}
