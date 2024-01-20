namespace leetcode {
    public class Solution206Iteration {
        public ListNode ReverseList(ListNode head) {
            ListNode pre = null;
            ListNode cur = head;
            while (cur != null) {
                ListNode next = cur.next;
                cur.next = pre;
                pre = cur;
                cur = next;
            }
            return pre;
        }
    }

    public class Solution206Recursive {
        public ListNode ReverseList(ListNode head) {
            if (head == null) {
                return null;
            }

            if (head.next == null) {
                return head;
            }

            ListNode last = ReverseList(head.next);
            head.next.next = head;
            head.next = null;
            return last;
        }
    }
}