// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution637 {
        public IList<double> AverageOfLevels(TreeNode root) {
            var queue = new Queue<TreeNode>();
            if (root != null) {
                queue.Enqueue(root);
            }

            var result = new List<double>();
            while (queue.Any()) {
                var size = queue.Count;
                var sum = 0.0d;
                for (var i = 0; i < size; ++i) {
                    var node = queue.Dequeue();
                    sum += node.val;
                    if (node.left != null) {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null) {
                        queue.Enqueue(node.right);
                    }
                }
                result.Add(sum / size);
            }
            return result;
        }
    }
}
