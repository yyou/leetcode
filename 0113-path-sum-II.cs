using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution113 {
        private List<IList<int>> result;
        public IList<IList<int>> PathSum(TreeNode root, int targetSum) {
            result = new List<IList<int>>();
            if (root == null) {
                return result;
            }
            var nums = new List<int>();
            PathSum(root, targetSum, 0, nums);
            return result;
        }

        private void PathSum(TreeNode node, int targetSum, int currentSum, List<int> currentNumbers) {
            currentNumbers.Add(node.val);
            if (node.left == null && node.right == null) {
                if (currentSum + node.val == targetSum) {
                    var newNumbers = new List<int>();
                    for (var i = 0; i < currentNumbers.Count; ++i) {
                        newNumbers.Add(currentNumbers[i]);
                    }
                    result.Add(newNumbers);
                }
            }

            if (node.left != null) {
                PathSum(node.left, targetSum, currentSum + node.val, currentNumbers);
            }

            if (node.right != null) {
                PathSum(node.right, targetSum, currentSum + node.val, currentNumbers);
            }

            currentNumbers.RemoveAt(currentNumbers.Count - 1);
        }
    }
}