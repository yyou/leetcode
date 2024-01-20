// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;

namespace leetcode {
    public class Solution98 {
        public bool IsValidBST(TreeNode root) {
            if (root == null) {
                return true;
            }

            if (root.left != null && root.left.val >= root.val) {
                return false;
            }

            if (root.right != null && root.right.val <= root.val) {
                return false;
            }

            var leftMax = GetLeftMax(root);
            if (leftMax != null && leftMax.val >= root.val) {
                return false;
            }

            var rightMin = GetRightMin(root);
            if (rightMin != null && rightMin.val <= root.val) {
                return false;
            }

            if (!IsValidBST(root.left)) {
                return false;
            }

            if (!IsValidBST(root.right)) {
                return false;
            }

            return true;
        }

        private TreeNode GetLeftMax(TreeNode node) {
            if (node.left == null) {
                return null;
            }

            node = node.left;
            while (node.right != null) {
                node = node.right;
            }

            return node;
        }

        private TreeNode GetRightMin(TreeNode node) {
            if (node.right == null) {
                return null;
            }

            var preNode = node.right;
            var curNode = preNode.left;
            while (curNode != null) {
                preNode = curNode;
                curNode = curNode.left;
            }

            return preNode;
        }
    }

    public class Solution98RecursivelyByPreNode {
        private TreeNode pre;
        public bool IsValidBST(TreeNode root) {
            if (root == null) {
                return true;
            }

            if (IsValidBST(root.left) == false) {
                return false;
            }

            if (pre != null && pre.val >= root.val) {
                return false;
            }

            pre = root;

            if (IsValidBST(root.right) == false) {
                return false;
            }

            return true;
        }
    }

    public class Solution98ByMinMaxNodes {
        public bool IsValidBST(TreeNode root) {
            return IsValidBST(root, null, null);
        }

        private bool IsValidBST(TreeNode root, TreeNode min, TreeNode max) {
            if (root == null) {
                return true;
            }

            if (min != null && root.val <= min.val) {
                return false;
            }

            if (max != null && root.val >= max.val) {
                return false;
            }

            return IsValidBST(root.left, min, root) && IsValidBST(root.right, root, max);
        }
    }

    public class Solution98ByMinMaxValues {
        public bool IsValidBST(TreeNode root) {
            return IsValidBST(root, long.MinValue, long.MaxValue);
        }

        // as the node value is in range between Int32.MinValue and Int32.MaxValue,
        // need to use long as the type of 'min' and 'max'.
        private bool IsValidBST(TreeNode root, long min, long max) {
            if (root == null) {
                return true;
            }

            if (root.val <= min || root.val >= max) {
                return false;
            }

            return IsValidBST(root.left, min, root.val) &&
                IsValidBST(root.right, root.val, max);
        }
    }

    // BST values should be in order. So we convert it to a list and then compare the numbers.
    public class Solution98ByArray {
        public bool IsValidBST(TreeNode root) {
            var nums = new List<int>();
            GetNumbers(root, nums);

            for (var i = 0; i < nums.Count - 1; ++i) {
                if (nums[i] >= nums[i + 1]) {
                    return false;
                }
            }

            return true;
        }

        private void GetNumbers(TreeNode root, List<int> numbers) {
            if (root == null) {
                return;
            }

            if (root.left != null) {
                GetNumbers(root.left, numbers);
            }

            numbers.Add(root.val);

            if (root.right != null) {
                GetNumbers(root.right, numbers);
            }
        }
    }
}
