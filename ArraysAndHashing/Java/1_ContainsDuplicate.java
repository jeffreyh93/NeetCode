/**
https://leetcode.com/problems/contains-duplicate/

Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.
*/

class Solution {
    public boolean containsDuplicate(int[] nums) {
        HashSet<Integer> track = new HashSet();
        for (int n : nums) {
            if (track.contains(n)) return true;
            track.add(n);
        }
        return false;
    }
}

/**
Algorithm: store the visited numbers in a hashset, return false if the set already contains that number

Space: O(n), all elements stored in the hashset
Time: O(n), all elements in the num array iterated through
*/