/**
https://leetcode.com/problems/two-sum/

Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

You can return the answer in any order.
*/

class Solution {
    public int[] twoSum(int[] nums, int target) {
        HashMap<int, int> track = new HashMap();
        for (int i = 0; i < nums.length; i++) {
            if (track.containsKey(target - nums[i])) return new int[] {i, track.get(target - nums[i])};
            track.put(nums[i], i);
        }       
        return null;
    }
}

/**
Algorithm: Maintain a hashset that keeps track of all the elements and their index. Then when visiting each number, check if the target - curr element is in the dict. If it is then we found the pair of elements that add to target

Space: O(n), all numbers and their indeces stored in the hashmap
Time: O(n), every num in the array visited
*/