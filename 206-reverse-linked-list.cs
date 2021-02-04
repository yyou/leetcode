using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution206Iteration {
        public ListNode ReverseList(ListNode head) {
            if (head == null) {
                return null;
            }

            if (head.next == null) {
                return head;
            }

            var currentNode = new ListNode(head.val, null);
            head = head.next;
            while (head != null) {
                var node = new ListNode(head.val, currentNode);
                currentNode = node;
                head = head.next;
            }
            return currentNode;
        }
    }

    public class Solution206Recursive {
        public ListNode ReverseList(ListNode head) {
            if (head == null) {
                return null;
            }

            if (head.next == null) {
                return head;
            }

            ListNode last = ReverseList(head.next);
            head.next.next = head;
            head.next = null;
            return last;
        }
    }
}