using System;
using System.Text;

namespace leetcode {
    public static class TreeNodeExtensions {
        public static String Serialize(this TreeNode node) {
            if (node == null) {
                return "#";
            }
            return String.Format(
                "({0}, {1}, {2})",
                node.val,
                node.left.Serialize(),
                node.right.Serialize());
        }
    }
}