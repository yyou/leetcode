using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution25 {
        public ListNode ReverseKGroup(ListNode head, int k) {
            ListNode a, b;
            a = head;
            b = head;
            for (var i = 0; i < k; ++i) {
                if (b == null) {
                    return head;
                }
                b = b.next;
            }


            var newHead = Reverse(a, b);
            a.next = ReverseKGroup(b, k);
            return newHead;
        }

        private ListNode Reverse(ListNode a, ListNode b) {
            ListNode pre, curr, next;
            pre = null;
            curr = a;
            next = a;

            while (curr != b) {
                next = curr.next;
                curr.next = pre;
                pre = curr;
                curr = next;
            }

            return pre;
        }
    }
}