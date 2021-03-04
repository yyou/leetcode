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
    public class Solution145 {
        public IList<int> PostorderTraversal(TreeNode root) {
            IList<int> result = new List<int>();
            PostorderTraversal(root, result);
            return result;
        }

        private void PostorderTraversal(TreeNode node, IList<int> result) {
            if (node == null) {
                return;
            }

            PostorderTraversal(node.left, result);
            PostorderTraversal(node.right, result);
            result.Add(node.val);
        }
    }
}