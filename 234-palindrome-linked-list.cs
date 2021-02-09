using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution234 {
        private ListNode left;

        public bool IsPalindrome(ListNode head) {
            left = head;
            return traverse(head);
        }

        private bool traverse(ListNode right) {
            if (right == null) {
                return true;
            }

            var result = traverse(right.next);
            result = result && (right.val == left.val);
            left = left.next;
            return result;
        }
    }
}