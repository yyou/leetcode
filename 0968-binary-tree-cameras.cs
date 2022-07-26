// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution968 {
        // Assume there are 3 node status:
        // 0 - not covered by a camera
        // 1 - has camera
        // 2 - covered by a camera

        private int _result = 0;

        public int MinCameraCover(TreeNode root) {
            if (Traverse(root) == 0) {
                _result++;
            }
            return _result;
        }

        private int Traverse(TreeNode root) {
            if (root == null) {
                return 2;
            }

            var left = Traverse(root.left);
            var right = Traverse(root.right);

            if (left == 0 || right == 0) {
                _result++;
                return 1;
            } else if (left == 1 || right == 1) {
                return 2;
            } else {
                return 0;
            }
        }
    }
}
