using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution {
        public ListNode DetectCycle(ListNode head) {
            var slow = head;
            var fast = head;

            while (fast != null && fast.next != null) {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast) {
                    var node1 = head;
                    var node2 = fast;

                    while (node1 != node2) {
                        node1 = node1.next;
                        node2 = node2.next;
                    }

                    return node1;
                }
            }

            return null;
        }
    }
}