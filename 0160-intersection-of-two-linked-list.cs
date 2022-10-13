// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace leetcode {
    public class Solution160 {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
            // Get list A length
            var sizeA = 0;
            var node = headA;
            while (node != null) {
                node = node.next;
                sizeA++;
            }

            // Get list B length
            var sizeB = 0;
            node = headB;
            while (node != null) {
                node = node.next;
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
            var nodeA = headA;
            var nodeB = headB;
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
