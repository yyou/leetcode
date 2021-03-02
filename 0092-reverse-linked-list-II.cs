using System;

namespace leetcode {
    public class Solution92 {
        public ListNode ReverseBetween(ListNode head, int m, int n) {
            if (m == 1) {
                return ReverseN(head, n);
            }

            head.next = ReverseBetween(head.next, m - 1, n - 1);
            return head;

        }

        private ListNode successorNode = null;

        private ListNode ReverseN(ListNode head, int n) {
            if (n == 1) {
                successorNode = head.next;
                return head;
            }

            var lastNode = ReverseN(head.next, n - 1);
            head.next.next = head;
            head.next = successorNode;
            return lastNode;
        }
    }
}