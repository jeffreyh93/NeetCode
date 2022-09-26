/**
https://leetcode.com/problems/contains-duplicate/

Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.
*/

public bool ContainsDuplciate(int[] nums) {
    HashSet<int> track = new HashSet<int>();
    foreach (int n in nums) {
        if (track.Contains(n)) return true;
        track.Add(n);
    }
    return false;
}

/**
Algorithm:
Use a hashset to keep track of the numbers already visited, for each number in the nums array, check if the hashset already contains that number.

Space: O(n), all elements stored in a hashset
Time: O(n), full nums array is iterated through
*/