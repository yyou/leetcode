using System;
using System.Collections.Generic;

namespace leetcode {
    public class Solution652 {
        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root) {
            var dict = new Dictionary<int, Boolean>();
            var result = new List<TreeNode>();
            FindDuplicateSubtrees(root, dict, result);
            return result;
        }

        private int FindDuplicateSubtrees(
            TreeNode node, Dictionary<int, Boolean> dict, List<TreeNode> result) {
            if (node == null) {
                return 0;
            }

            var s = String.Format(
                "{0} {1} {2}",
                node.val,
                FindDuplicateSubtrees(node.left, dict, result),
                FindDuplicateSubtrees(node.right, dict, result));
            var code = s.GetHashCode();
            if (dict.ContainsKey(code)) {
                if (dict[code] == false) {
                    result.Add(node);
                    dict[code] = true;
                }
            } else {
                dict[code] = false;
            }

            return code;
        }
    }
}