using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution700 {
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
}