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

            var previousNode = head;
            var node = previousNode.next;
            previousNode.next = null;
            while (node != null) {
                var nextNode = node.next;
                node.next = previousNode;
                previousNode = node;
                node = nextNode;
            }
            return previousNode;
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