/**
https://leetcode.com/problems/two-sum/

Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

You can return the answer in any order.
*/

public int[] TwoSum(int[] nums, int target) {
    Dictionary<int, int> track = new Dictionary<int, int>();
    for (int i = 0; i < nums.Length; i++) {
        if (track.ContainsKey(target - nums[i])) {
            return new int[2] {i, track[target - nums[i]]};
        }
        if (!track.ContainsKey(nums[i])) {
            track.Add(nums[i], i);
        }
    }
    return null;
}

/**
Algorithm:
Store each element in the dictionary. Check if target - element is already in the dictionary. If it is then we found our pair and return those indeces

Space: O(n), each element is stored in the dictionary
Time: O(n), at worst every element is visited
*/