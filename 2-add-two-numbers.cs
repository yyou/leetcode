using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode {
    public class Solution2 {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
            var node1 = l1;
            var node2 = l2;
            int curryForward = 0;
            var head = new ListNode(0);
            var currentNode = head;
            while (node1 != null || node2 != null) {
                var d1 = node1 != null ? node1.val : 0;
                var d2 = node2 != null ? node2.val : 0;
                var sum = d1 + d2 + curryForward;
                if (sum > 9) {
                    curryForward = sum / 10;
                    sum = sum % 10;
                } else {
                    curryForward = 0;
                }
                var newNode = new ListNode(sum);
                currentNode.next = newNode;
                currentNode = newNode;

                if (node1 != null) {
                    node1 = node1.next;
                }

                if (node2 != null) {
                    node2 = node2.next;
                }
            }

            if (curryForward > 0) {
                currentNode.next = new ListNode(curryForward);
            }

            return head.next;
        }
    }
}
