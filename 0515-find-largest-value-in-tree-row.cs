// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace leetcode {
    public class Solution515 {
        public IList<int> LargestValues(TreeNode root) {
            var queue = new Queue<TreeNode>();
            if (root != null) {
                queue.Enqueue(root);
            }

            var result = new List<int>();
            while (queue.Count > 0) {
                var size = queue.Count;
                var max = Int32.MinValue;
                for (var i = 0; i < size; ++i) {
                    var node = queue.Dequeue();
                    max = Math.Max(max, node.val);
                    if (node.left != null) {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null) {
                        queue.Enqueue(node.right);
                    }
                }
                result.Add(max);
            }

            return result;
        }
    }
}
