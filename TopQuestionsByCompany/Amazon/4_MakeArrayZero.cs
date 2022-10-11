/**
https://leetcode.com/problems/make-array-zero-by-subtracting-equal-amounts/

You are given a non-negative integer array nums. In one operation, you must:

    Choose a positive integer x such that x is less than or equal to the smallest non-zero element in nums.
    Subtract x from every positive element in nums.

Return the minimum number of operations to make every element in nums equal to 0.
*/

public class Solution {
    public int MinimumOperations(int[] nums) {
        HashSet<int> track = new HashSet<int>();
        foreach (int n in nums) {
            if (n != 0 && !track.Contains(n)) track.Add(n);
        }
        return track.Count;
    }
}

/**
Algorithm: the number of steps required is just the number of unique non-zero numbers in the array

Space: O(n), elements stored in a hashset
Time: O(n), every element is iterated through
*/