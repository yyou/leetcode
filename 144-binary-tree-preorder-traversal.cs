using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution144 {
        public IList<int> PreorderTraversal(TreeNode root) {
            IList<int> result = new List<int>();
            PreorderTraversal(root, result);
            return result;
        }

        private void PreorderTraversal(TreeNode node, IList<int> result) {
            if (node == null) {
                return;
            }
            result.Add(node.val);
            PreorderTraversal(node.left, result);
            PreorderTraversal(node.right, result);
        }
    }
}