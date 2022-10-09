/**
https://leetcode.com/problems/add-two-numbers/

You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.
*/

public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode head = new ListNode();
        ListNode curr = head, ptr1 = l1, ptr2 = l2;
        int carry = 0;

        while (ptr1 != null || ptr2 != null) {
            int val1 = ptr1 == null ? 0 : ptr1.val;
            int val2 = ptr2 == null ? 0 : ptr2.val;

            int sum = val1 + val2 + carry;

            curr.next = new ListNode(sum % 10);
            carry = sum / 10;
            curr = curr.next;

            if (ptr1 != null) ptr1 = ptr1.next;
            if (ptr2 != null) ptr2 = ptr2.next;
        }

        if (carry != 0) curr.next = new ListNode(carry);

        return head.next;
    }
}

/**
Algorithm:
Use two list node ptr to iterate through both. Only terminate the loop once both lists are found to be null, otherwise iterate the non-null pointers.
Every iteration get the sum between curr ptrs and the carry. When we leave the loop add an extra node if carry != 0

Space: O(1), no extra space used aside from the return list
Time: O(max(n1, n2)) loop through both lists, time depends on the longer one
*/