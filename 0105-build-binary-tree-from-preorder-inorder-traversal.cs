namespace leetcode {
    public class Solution105 {
        public TreeNode BuildTree(int[] preorder, int[] inorder) {
            return Build(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
        }

        private TreeNode Build(
            int[] preorder, int preorderStart, int preorderEnd,
            int[] inorder, int inorderStart, int inorderEnd
        ) {
            if (preorderStart > preorderEnd || inorderStart > inorderEnd) {
                return null;
            }
            var rootValue = preorder[preorderStart];
            var index = -1;
            for (var i = inorderStart; i <= inorderEnd; ++i) {
                if (inorder[i] == rootValue) {
                    index = i;
                    break;
                }
            }

            var leftSize = index - inorderStart;
            //var rightSize = inorderEnd - index;
            var root = new TreeNode(rootValue);
            root.left = Build(
                preorder, preorderStart + 1, preorderStart + leftSize,
                inorder, inorderStart, index - 1);
            root.right = Build(
                preorder, preorderStart + leftSize + 1, preorderEnd,
                inorder, index + 1, inorderEnd);
            return root;
        }
    }
}