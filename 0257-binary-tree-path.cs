using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution0257 {
        private List<String> _result;

        public IList<string> BinaryTreePaths(TreeNode root) {
            _result = new List<String>();
            var nums = new List<int>();

            if (root != null) {
                BinaryTreePaths(root, nums);
            }

            return _result;

        }

        private void BinaryTreePaths(TreeNode node, List<int> nums) {
            nums.Add(node.val);

            if (node.left == null && node.right == null) {
                _result.Add(String.Join("->", nums.ToArray()));
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