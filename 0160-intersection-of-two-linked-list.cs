// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution160 {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
            // Get list A length
            var sizeA = 0;
            var nodeA = headA;
            while (nodeA != null) {
                nodeA = nodeA.next;
                sizeA++;
            }

            // Get list B length
            var sizeB = 0;
            var nodeB = headB;
            while (nodeB != null) {
                nodeB = nodeB.next;
                sizeB++;
            }

            // always regard list A is longer or equal to list B
            // exchange if list A is shorter than list B
            if (sizeB > sizeA) {
                var tmp = headA;
                headA = headB;
                headB = tmp;

                var tmpSize = sizeA;
                sizeA = sizeB;
                sizeB = tmpSize;
            }

            // Make list A & B aligned at the end
            nodeA = headA;
            nodeB = headB;
            var diff = sizeA - sizeB;
            while (diff > 0) {
                nodeA = nodeA.next;
                diff--;
            }

            // Compare the node pair one by one
            while (nodeA != null && nodeB != null) {
                if (nodeA == nodeB) {
                    return nodeA;
                }
                nodeA = nodeA.next;
                nodeB = nodeB.next;
            }

            return null;
        }
    }
}
