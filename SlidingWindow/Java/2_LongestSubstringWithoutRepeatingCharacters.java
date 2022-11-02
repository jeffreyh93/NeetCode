/**
https://leetcode.com/problems/longest-substring-without-repeating-characters/

Given a string s, find the length of the longest substring without repeating characters.
*/

class Solution {
    public int lengthOfLongestSubstring(String s) {
        HashMap<Character, Integer> trackChar = new HashMap();
        int maxLen = 0, startIdx = 0;
        for (int i = 0; i < s.length(); i++) {
            char c = s.charAt(i);
            if (trackChar.containsKey(c)) {
                startIdx = Math.max(startIdx, trackChar.get(c) + 1);
            }
            maxLen = Math.max(maxLen, i - startIdx + 1);
            trackChar.put(c, i);
        }
        return maxLen;
    }
}

/**
Algorithm: keep track of a start idx and only update that when we visit a char that is already in the dictionary. In that case, assign start idx to be the max between itself and the result of getting that index value from the dictionary + 1. Then every iteration, assign the max length index to be the max between itself and the diff between curr index and start idx + 1, then update the dictionary value for the current char

Space: O(n), uses a hashmap to track all chars and their index
Time: O(n), one pass through the elements in the string
*/