// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution112Recursion {
        public bool HasPathSum(TreeNode root, int targetSum) {
            if (root == null) {
                return false;
            }

            if (root.left == null && root.right == null) {
                return root.val == targetSum;
            } else if (root.right == null) {
                return HasPathSum(root.left, targetSum - root.val);
            } else if (root.left == null) {
                return HasPathSum(root.right, targetSum - root.val);
            } else {
                var leftPathResult = HasPathSum(root.left, targetSum - root.val);
                if (leftPathResult) {
                    return true;
                }

                var rightPathResult = HasPathSum(root.right, targetSum - root.val);
                return rightPathResult;
            }
        }
    }

    public class Solution112Iteration {
        public bool HasPathSum(TreeNode root, int targetSum) {
            if (root == null) {
                return targetSum == 0;
            }

            var stack = new Stack<Tuple<TreeNode, int>>();
            stack.Push(new Tuple<TreeNode, int>(root, root.val));

            while (stack.Any()) {
                var tuple = stack.Pop();
                if (tuple.Item1.left == null && tuple.Item1.right == null && tuple.Item2 == targetSum) {
                    return true;
                }

                var rightChild = tuple.Item1.right;
                if (rightChild != null) {
                    stack.Push(new Tuple<TreeNode, int>(rightChild, tuple.Item2 + rightChild.val));
                }

                var leftChild = tuple.Item1.left;
                if (leftChild != null) {
                    stack.Push(new Tuple<TreeNode, int>(leftChild, tuple.Item2 + leftChild.val));
                }
            }

            return false;
        }
    }
}
