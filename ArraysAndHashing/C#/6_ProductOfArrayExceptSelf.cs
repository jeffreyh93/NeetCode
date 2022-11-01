/**
https://leetcode.com/problems/product-of-array-except-self/

Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].

The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.

You must write an algorithm that runs in O(n) time and without using the division operation.
*/

public int[] ProductExceptSelf(int[] nums) {
    int[] lArr = new int[nums.Length];
    int[] rArr = new int[nums.Length];

    lArr[0] = 1;
    for (int i = 1; i < lArr.Length; i++) {
        lArr[i] = lArr[i - 1] * nums[i - 1];
    }
    
    rArr[nums.Length - 1] = 1;
    for (int j = nums.Length - 2; j >= 0; j--) {
        rArr[j] = rArr[j + 1] * nums[j + 1];
    }
    int[] ret = new int[nums.Length];
    for (int k = 0; k < nums.Length; k++) {
        ret[k] = lArr[k] * rArr[k];
    }
    return ret;
}

/**
Algorithm:
Calculate the value of each index in the left direction, then in the right direction. At the end multiply each index together

Space: O(n), every element is stored in the array
Time: O(n), every element is visited
*/