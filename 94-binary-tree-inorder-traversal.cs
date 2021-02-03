using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution94 {
        public IList<int> InorderTraversal(TreeNode root) {
            IList<int> result = new List<int>();
            InorderTraversal(root, result);
            return result;
        }

        private void InorderTraversal(TreeNode node, IList<int> result) {
            if (node == null) {
                return;
            }

            InorderTraversal(node.left, result);
            result.Add(node.val);
            InorderTraversal(node.right, result);
        }
    }
}