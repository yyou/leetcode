using System;

namespace leetcode
{
    public class Solution226
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            var leftNode = InvertTree(root.left);
            var rightNode = InvertTree(root.right);
            return new TreeNode(root.val, rightNode, leftNode);
        }
    }
}
