using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution404Recursion {
        public int SumOfLeftLeaves(TreeNode root) {
            if (root == null) {
                return 0;
            }

            var sum = 0;
            if (root.left != null && root.left.left == null && root.left.right == null) {
                sum += root.left.val;
            }

            sum += SumOfLeftLeaves(root.left);
            sum += SumOfLeftLeaves(root.right);

            return sum;
        }
    }

    public class Solution404Iteration {
        public int SumOfLeftLeaves(TreeNode root) {
            var st = new Stack<TreeNode>();
            var sum = 0;
            if (root != null) {
                st.Push(root);
            }
            while (st.Any()) {
                var node = st.Pop();
                if (node != null) {
                    if (node.right != null) {
                        st.Push(node.right);
                    }

                    if (node.left != null) {
                        st.Push(node.left);
                    }

                    st.Push(node);
                    st.Push(null);
                } else {
                    var node2 = st.Pop();
                    if (node2.left != null && node2.left.left == null && node2.left.right == null) {
                        sum += node2.left.val;
                    }
                }
            }
            return sum;
        }
    }
}