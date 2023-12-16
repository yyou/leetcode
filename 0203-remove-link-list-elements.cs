using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Solution203 {
        public ListNode RemoveElements(ListNode head, int val) {
            var dummyHead = new ListNode(1, head);
            var pre = dummyHead;
            var cur = head;
            while (cur != null) {
                if (cur.val == val) {
                    pre.next = cur.next;
                } else {
                    pre = cur;
                }
                cur = cur.next;
            }
            return dummyHead.next;
        }
    }
}