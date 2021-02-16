using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution203 {
        public ListNode RemoveElements(ListNode head, int val) {
            var dummyHead = new ListNode(1, head);
            var pre = dummyHead;
            var cur = head;
            ListNode next = null;
            while (cur != null) {
                next = cur.next;
                if (cur.val == val) {
                    pre.next = next;
                } else {
                    pre = cur;

                }
                cur = next;
            }
            return dummyHead.next;
        }
    }
}