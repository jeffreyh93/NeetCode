/**
https://leetcode.com/problems/product-of-array-except-self/

Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].

The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.

You must write an algorithm that runs in O(n) time and without using the division operation.
*/

class Solution {
    public int[] productExceptSelf(int[] nums) {
        int n = nums.length;
        int[] left = new int[n];
        int[] right = new int[n];
        left[0] = 1;
        right[n - 1] = 1;
        for (int i = 1; i < n; i++) {
            left[i] = left[i - 1] * nums[i - 1];
            right[n - i - 2] = right[n - i - 1] * nums[n - i - 1];
        }           
        int[] ret = new int[n];
        for (int i = 0; i < n; i++) {
            ret[i] = left[i] * right[i];
        }
        return ret;
    }
}

/**
Algorithm: Maintain two separate arrays, one in the right direction and another in the left direction. Set the left / right most index with a value of 1 then every iteration until the index, multiply the nums value at that index * the left index. ie, left[i] = nums[i - 1] * left[i - 1], right[i] = nums[i  + 1] * right[i + 1]. Then when creating the return array, just multiply the left index by the right index, ie. ret[i] = left[i] * right[i]

Space: O(n), using a left and right array to keep track
Time: O(n), one pass through the array
*/