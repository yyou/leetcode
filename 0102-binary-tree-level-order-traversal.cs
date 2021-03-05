using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    /**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
    public class Solution102 {
        public IList<IList<int>> LevelOrder(TreeNode root) {
            var queue = new Queue<TreeNode>();
            if (root != null) {
                queue.Enqueue(root);
            }

            var result = new List<IList<int>>();
            while (queue.Count > 0) {
                var size = queue.Count;
                var values = new List<int>();
                for (var i = 0; i < size; ++i) {
                    var node = queue.Dequeue();
                    values.Add(node.val);
                    if (node.left != null) {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null) {
                        queue.Enqueue(node.right);
                    }
                }
                result.Add(values);
            }
            return result;
        }
    }
}