// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution24Recusive {
        public ListNode SwapPairs(ListNode head) {
            if (head == null) {
                return null;
            }

            if (head.next == null) {
                return head;
            }

            var third = head.next.next;
            var next = head.next;
            next.next = head;
            head.next = SwapPairs(third);

            return next;
        }
    }
}
