using System;

namespace leetcode {
    public class Solution230 {
        public int KthSmallest(TreeNode root, int k) {
            var result = 0;
            var currentRank = 0;
            KthSmallest(root, ref currentRank, k, ref result);
            return result;
        }

        private bool KthSmallest(
            TreeNode root, ref int currentRank, int searchedRank, ref int result) {

            if (root == null) {
                return false;
            }

            var found = KthSmallest(root.left, ref currentRank, searchedRank, ref result);
            if (found) {
                return true;
            }

            currentRank++;
            if (currentRank == searchedRank) {
                result = root.val;
                return true;
            }

            found = KthSmallest(root.right, ref currentRank, searchedRank, ref result);
            return found;
        }
    }
}