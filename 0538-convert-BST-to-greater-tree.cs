using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    // This solution is based on the fact that BST is sorted
    // and convert BST to an list and calculate the node value 
    // inside list firstly.
    public class Solution538UsingList {
        private List<TreeNode> _list = new List<TreeNode>();
        private int _index = 0;

        public TreeNode ConvertBST(TreeNode root) {
            CreateList(root);
            for (var i = _list.Count - 2; i >= 0; i--) {
                _list[i].val = _list[i + 1].val + _list[i].val;
            }
            UpdateNodeValue(root);
            return root;
        }

        private void CreateList(TreeNode root) {
            if (root == null) {
                return;
            }
            CreateList(root.left);
            _list.Add(root);
            CreateList(root.right);
        }

        private void UpdateNodeValue(TreeNode root) {
            if (root == null) {
                return;
            }
            UpdateNodeValue(root.left);
            root.val = _list[_index].val;
            _index++;
            UpdateNodeValue(root.right);
        }
    }

    // A simple solution without 
    public class Solution538 {
        private int _prev = 0;
        public TreeNode ConvertBST(TreeNode root) {
            if (root == null) {
                return null;
            }

            ConvertBST(root.right);
            root.val += _prev;
            _prev = root.val;
            ConvertBST(root.left);
            return root;
        }
    }
}