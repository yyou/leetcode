using System;

namespace leetcode
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public override string ToString()
        {         
            return String.Format(
                "({0}, {1}, {2})", 
                this.val, 
                this.left == null? "null" : this.left.ToString(),
                this.right == null? "null" : this.right.ToString());
        }
    }
}
