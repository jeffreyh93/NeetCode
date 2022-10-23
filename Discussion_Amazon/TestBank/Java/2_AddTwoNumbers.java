/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode() {}
 *     ListNode(int val) { this.val = val; }
 *     ListNode(int val, ListNode next) { this.val = val; this.next = next; }
 * }
 */
class Solution {
    public ListNode addTwoNumbers(ListNode l1, ListNode l2) {
        ListNode ret = new ListNode();
        ListNode curr = ret, ptr1 = l1, ptr2 = l2;
        int carry = 0;
        while (ptr1 != null || ptr2 != null || carry != 0) {
            int val1 = ptr1 != null ? ptr1.val : 0;
            int val2 = ptr2 != null ? ptr2.val : 0;
            int sum = val1 + val2 + carry;

            curr.next = new ListNode(sum % 10);
            curr = curr.next;
            carry = sum / 10;

            if (ptr1 != null) ptr1 = ptr1.next;
            if (ptr2 != null) ptr2 = ptr2.next;
        }
        return ret.next;
    }
}