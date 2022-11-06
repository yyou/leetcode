// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution572 {
        public bool IsSubtree(TreeNode root, TreeNode subRoot) {
            if (IsSame(root, subRoot)) {
                return true;
            }

            if (root != null && IsSubtree(root.left, subRoot)) {
                return true;
            }

            if (root != null && IsSubtree(root.right, subRoot)) {
                return true;
            }

            return false;
        }

        private bool IsSame(TreeNode node1, TreeNode node2) {
            if (node1 == null && node2 == null) {
                return true;
            }

            if (node1 == null || node2 == null || node1.val != node2.val) {
                return false;
            }

            return IsSame(node1.left, node2.left) && IsSame(node1.right, node2.right);
        }
    }
}
