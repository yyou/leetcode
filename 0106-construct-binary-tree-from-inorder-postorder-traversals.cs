using System;

namespace leetcode {
    public class Solution106 {
        public TreeNode BuildTree(int[] inorder, int[] postorder) {
            return Build(
                inorder, 0, inorder.Length - 1,
                postorder, 0, postorder.Length - 1);
        }

        private TreeNode Build(
            int[] inorder, int inorderStart, int inorderEnd,
            int[] postorder, int postorderStart, int postorderEnd) {

            if (inorderStart > inorderEnd || postorderStart > postorderEnd) {
                return null;
            }

            var rootValue = postorder[postorderEnd];

            var index = -1;
            for (var i = inorderStart; i <= inorderEnd; ++i) {
                if (inorder[i] == rootValue) {
                    index = i;
                    break;
                }
            }

            var leftSize = index - inorderStart;
            var node = new TreeNode(rootValue);
            node.left = Build(
                inorder, inorderStart, index - 1,
                postorder, postorderStart, postorderStart + leftSize - 1);
            node.right = Build(
                inorder, index + 1, inorderEnd,
                postorder, postorderStart + leftSize, postorderEnd - 1);
            return node;
        }
    }
}