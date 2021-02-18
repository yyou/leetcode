using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class MyLinkedList {
        private ListNode dummy;
        private int size;

        /** Initialize your data structure here. */
        public MyLinkedList() {
            dummy = new ListNode(0);
            size = 0;
        }

        /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
        public int Get(int index) {
            if (index > size - 1 || index < 0) {
                return -1;
            }

            var cur = dummy.next;

            while (index > 0) {
                cur = cur.next;
                index--;
            }

            return cur.val;
        }

        /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
        public void AddAtHead(int val) {
            var newNode = new ListNode(val, dummy.next);
            dummy.next = newNode;
            size++;
        }

        /** Append a node of value val to the last element of the linked list. */
        public void AddAtTail(int val) {
            var cur = dummy;
            while (cur.next != null) {
                cur = cur.next;
            }

            cur.next = new ListNode(val);
            size++;
        }

        /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
        public void AddAtIndex(int index, int val) {
            if (index > size || index < 0) {
                return;
            }

            var pre = dummy;
            var cur = dummy.next;

            while (index > 0) {
                pre = cur;
                cur = cur.next;
                index--;
            }

            if (cur == null) { // index points to the one after last element
                pre.next = new ListNode(val);
            } else {
                var newNode = new ListNode(val, cur);
                pre.next = newNode;
            }

            size++;
        }

        /** Delete the index-th node in the linked list, if the index is valid. */
        public void DeleteAtIndex(int index) {
            if (index > size - 1 || index < 0) {
                return;
            }

            var pre = dummy;
            var cur = dummy.next;

            while (index > 0) {
                pre = cur;
                cur = cur.next;
                index--;
            }

            pre.next = cur.next;
            size--;
        }
    }
}