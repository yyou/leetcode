// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution701Recursion {
        public TreeNode InsertIntoBST(TreeNode root, int val) {
            if (root == null) {
                return new TreeNode(val);
            }
            if (root.val > val) {
                root.left = InsertIntoBST(root.left, val);
            } else {
                root.right = InsertIntoBST(root.right, val);
            }
            return root;
        }
    }

    public class Solution701Recursion2 {
        private TreeNode _parent;

        public TreeNode InsertIntoBST(TreeNode root, int val) {
            if (root == null) {
                return new TreeNode(val);
            }

            Traversal(root, val);

            return root;
        }

        private void Traversal(TreeNode node, int val) {
            if (node == null) {
                if (_parent.val > val) {
                    _parent.left = new TreeNode(val);
                } else {
                    _parent.right = new TreeNode(val);
                }

                return;
            }

            _parent = node;

            if (node.val > val) {
                Traversal(node.left, val);
            } else {
                Traversal(node.right, val);
            }
        }
    }

    public class Solution701Iteration {
        public TreeNode InsertIntoBST(TreeNode root, int val) {
            if (root == null) {
                return new TreeNode(val);
            }

            var node = root;
            while (node != null) {
                if (node.val > val) {
                    if (node.left == null) {
                        node.left = new TreeNode(val);
                        return root;
                    } else {
                        node = node.left;
                    }
                } else {
                    if (node.right == null) {
                        node.right = new TreeNode(val);
                        return root;
                    } else {
                        node = node.right;
                    }
                }
            }
            return root;
        }
    }
}
