using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution617 {
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
}