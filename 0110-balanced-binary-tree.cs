// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace leetcode {
    public class Solution110Recursion {
        public bool IsBalanced(TreeNode root) {
            return GetHeight(root) != -1;
        }

        private int GetHeight(TreeNode node) {
            if (node == null) {
                return 0;
            }

            var leftHeight = GetHeight(node.left);
            if (leftHeight == -1) {
                return -1;
            }

            var rightHeight = GetHeight(node.right);
            if (rightHeight == -1) {
                return -1;
            }

            if (Math.Abs(leftHeight - rightHeight) > 1) {
                return -1;
            }

            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }
}
