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
Algorithm:
Use a dictionary to track if the target - nums[i] element was alreadt found in the array. If it was then return that element's index and the current
Otherwise just add the current index to the dictionary if not already found

Space: O(n), potentially all elements are stored in the dictionary
Time: O(n), all elements are iterated through
*/