// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;

namespace leetcode {
    public class NaryTreeNode {
        public int val;
        public IList<NaryTreeNode> children;

        public NaryTreeNode() { }

        public NaryTreeNode(int _val) {
            val = _val;
        }

        public NaryTreeNode(int _val, IList<NaryTreeNode> _children) {
            val = _val;
            children = _children;
        }
    }
}
