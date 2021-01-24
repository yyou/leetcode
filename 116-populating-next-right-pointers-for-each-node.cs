using System;

namespace leetcode
{
    public class Solution116
    {
        public Node Connect(Node root)
        {
            if (root == null)
            {
                return null;
            }
            Connect(root.left, root.right);
            return root;
        }

        private void Connect(Node node1, Node node2)
        {
            if (node1 == null || node2 == null)
            {
                return;
            }

            node1.next = node2;

            Connect(node1.left, node1.right);
            Connect(node2.left, node2.right);
            Connect(node1.right, node2.left);
            return;
        }
    }
}