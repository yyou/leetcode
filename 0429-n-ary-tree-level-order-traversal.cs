// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution429 {
        public IList<IList<int>> LevelOrder(NaryTreeNode root) {
            var result = new List<IList<int>>();
            var queue = new Queue<NaryTreeNode>();
            if (root != null) {
                queue.Enqueue(root);
            }

            while (queue.Any()) {
                var size = queue.Count();
                var values = new List<int>();
                for (var i = 0; i < size; ++i) {
                    var node = queue.Dequeue();
                    values.Add(node.val);
                    if (node.children != null) {
                        for (var j = 0; j < node.children.Count(); ++j) {
                            queue.Enqueue(node.children[j]);
                        }
                    }
                }
                result.Add(values);
            }

            return result;
        }
    }
}
