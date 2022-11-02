/**
https://leetcode.com/problems/valid-anagram/

Given two strings s and t, return true if t is an anagram of s, and false otherwise.

An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
*/

class Solution {
    public boolean isAnagram(String s, String t) {
        if (s.length() != t.length()) return false;
        int[] letterCount = new int[26];
        for (int i = 0; i < s.length(); i++) {
            letterCount[s.charAt(i) - 'a']++;
            letterCount[t.charAt(i) - 'a']--;
        }

        for (int i = 0; i < 26; i++) {
            if (letterCount[i] != 0) return false;
        }
        return true;
    }
}

/**
Algorithm: Loop through both strings, maintain the char counts in a constant size array, then do one pass through that array. If any index is not 0 then there is a mismatch

Space: O(1), using a count array but it is constant space, always size 26. IF we allow unicode then this would be O(n) because we'd use a dictionary instead to keep track of char counts 
Time: O(n), all chars in both strings visited
*/