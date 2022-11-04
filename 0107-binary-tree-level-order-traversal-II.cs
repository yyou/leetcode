// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution107 {
        public IList<IList<int>> LevelOrderBottom(TreeNode root) {
            var result = new List<IList<int>>();
            var queue = new Queue<TreeNode>();
            if (root != null) {
                queue.Enqueue(root);
            }

            while (queue.Any()) {
                var size = queue.Count();
                var values = new List<int>();
                for (var i = 0; i < size; ++i) {
                    var node = queue.Dequeue();
                    values.Add(node.val);

                    if (node.left != null) {
                        queue.Enqueue(node.left);
                    }

                    if (node.right != null) {
                        queue.Enqueue(node.right);
                    }
                }

                result.Add(values);
            }

            result.Reverse();

            return result;
        }
    }
}
