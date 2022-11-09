// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;

namespace leetcode {
    public class Solution0257Recursion {
        private List<string> _result;

        public IList<string> BinaryTreePaths(TreeNode root) {
            _result = new List<string>();
            var nums = new List<int>();

            if (root != null) {
                BinaryTreePaths(root, nums);
            }

            return _result;

        }

        private void BinaryTreePaths(TreeNode node, List<int> nums) {
            nums.Add(node.val);

            if (node.left == null && node.right == null) {
                _result.Add(string.Join("->", nums.ToArray()));
            }

            if (node.left != null) {
                BinaryTreePaths(node.left, nums);
            }

            if (node.right != null) {
                BinaryTreePaths(node.right, nums);
            }

            nums.RemoveAt(nums.Count - 1);
        }
    }
}
