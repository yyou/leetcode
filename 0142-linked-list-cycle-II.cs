// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution142 {
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
