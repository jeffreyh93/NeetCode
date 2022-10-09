/**
https://leetcode.com/problems/two-sum/

Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

You can return the answer in any order.
*/

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var track = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++) {
            if (track.ContainsKey(target - nums[i])) return new int[2] {i, track[target - nums[i]]};

            if (!track.ContainsKey(nums[i])) track.Add(nums[i], i);
        }
        return null;
    }
}

/**
Algorithm: use a dictionary to keep track of each element and its index. for every index, check whether target - element was already checked.
If it was then return the current index and that element's index

Space: O(n), every element stored in the dictionary
Time: O(n), every element is iterated through
*/