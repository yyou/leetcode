// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace leetcode {
    public class Solution337 {
        public int Rob(TreeNode root) {
            var vals = RobHouse(root);

            return Math.Max(vals[0], vals[1]);
        }

        // in the return array, the first number is the max value which the node is not stealed.
        // the second number is the max value which the node is stealed
        private int[] RobHouse(TreeNode root) {
            if (root == null) {
                return new int[] { 0, 0 };
            }

            var left = RobHouse(root.left);
            var right = RobHouse(root.right);

            // not steal the current node but steal the left node and right node
            var val1 = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);

            //steal the current node
            var val2 = root.val + left[0] + right[0];

            return new int[] { val1, val2 };
        }
    }
}
