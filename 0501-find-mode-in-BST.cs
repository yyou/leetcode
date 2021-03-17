using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution501Recursion {
        private TreeNode _prev = null;
        private int _count = 0;
        private int _maxCount = 0;
        private List<int> _result = new List<int>();

        public int[] FindMode(TreeNode root) {
            Traversal(root);
            return _result.ToArray();
        }

        private void Traversal(TreeNode node) {
            if (node == null) {
                return;
            }

            Traversal(node.left);

            if (_prev == null) {
                _count = 1;
            } else if (_prev.val == node.val) {
                _count++;
            } else { // do not equal to the previous one
                _count = 1;
            }

            _prev = node;

            if (_count == _maxCount) {
                _result.Add(node.val);
            } else if (_count > _maxCount) {
                _result.Clear();
                _result.Add(node.val);
                _maxCount = _count;
            }

            Traversal(node.right);
        }
    }
}