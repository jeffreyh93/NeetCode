/**
https://leetcode.com/problems/sort-colors/

Given an array nums with n objects colored red, white, or blue, sort them in-place so that objects of the same color are adjacent, with the colors in the order red, white, and blue.

We will use the integers 0, 1, and 2 to represent the color red, white, and blue, respectively.

You must solve this problem without using the library's sort function.
*/

public class Solution {
    public void SortColors(int[] nums) {
        int p0 = 0, curr = 0, p2 = nums.Length - 1;
        int tmp;

        while (curr <= p2) {
            if (nums[curr] == 0) {
                tmp = nums[curr];
                nums[curr++] = nums[p0];
                nums[p0++] = tmp;
            }
            else if (nums[curr] == 2) {
                tmp = nums[curr];
                nums[curr] = nums[p2];
                nums[p2--] = curr;
            }
            else {
                curr++;
            }
        }
    }
}

/**
Algorithm: Arrays and hashing
Keep track of the 0s and 2s pointer, every iteration if it is a 0 or 2 then swap with that pointer. Increment curr only if the element is a 0 or 1.
Everytime we swap then increment the 0s or decrement the 2s pointer

Space: O(1), no extra space used
Time: O(n), one pass through the array
*/