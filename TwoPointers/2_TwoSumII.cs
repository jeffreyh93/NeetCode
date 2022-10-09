/**
https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/

Given a 1-indexed array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number. Let these two numbers be numbers[index1] and numbers[index2] where 1 <= index1 < index2 <= numbers.length.

Return the indices of the two numbers, index1 and index2, added by one as an integer array [index1, index2] of length 2.

The tests are generated such that there is exactly one solution. You may not use the same element twice.

Your solution must use only constant extra space.
*/

public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int start = 0, end = numbers.Length - 1;

        while (start < end) {
            int sum = numbers[start] + numbers[end];

            if (sum == target) return new int[2] {start + 1, end + 1};
            else if (sum < target) start++;
            else end--;
        }
        return null;
    }
}

/**
Algorithm:
Use two pointers on either ends of the array, if the sum == target then just return pointer locations, if the sum of pointers < target then increment left pointer otherwise increment right pointer

Space: O(logn), complexity used to sort the array
Time: O(nlogn), all elements compared and the output array is sorted
*/