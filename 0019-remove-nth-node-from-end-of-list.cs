// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution19 {
        public ListNode RemoveNthFromEnd(ListNode head, int n) {
            var dummy = new ListNode(0, head);
            var fast = dummy;

            // fast pointer needs to walk n+1 steps.
            // So that the slow pointer will point to the previous node of the removed node
            // when fast pointer points to null
            while (n >= 0) {
                fast = fast.next;
                n--;
            }

            var slow = dummy;

            while (fast != null) {
                fast = fast.next;
                slow = slow.next;
            }

            slow.next = slow.next.next;

            return dummy.next;
        }
    }
}
