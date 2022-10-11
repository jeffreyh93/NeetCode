/**
https://leetcode.com/problems/rotate-list/

Given the head of a linked list, rotate the list to the right by k places.
*/

public class Solution {
    public ListNode RotateRight(ListNode head, int k) {
        if (head == null || head.next == null) return head;

        ListNode oldTail = head;
        int n;
        for (n = 1; oldTail.next != null; n++) 
            oldTail = oldTail.next;
        oldTail.next = head;

        ListNode newTail = head;
        for (int i = 0; i < n - (k % n) - 1; i++) 
            newTail = newTail.next;
        ListNode ret = newTail.next;
        newTail.next = null;

        return ret;
    }
}

/**
Algorithm: LinkedLists
turn the initial linked list into a cycle where the tail.next wraps around to the head. Then, for k rotations we know that the tail can be found at n - (k % n) 
- 1 where n = number of nodes in the list. Assign the return node to be the next node in the new found tail then assign the new tail.next to be null

Space: O(1), no extra space used
Time: O(n), one pass through the linked list
*/