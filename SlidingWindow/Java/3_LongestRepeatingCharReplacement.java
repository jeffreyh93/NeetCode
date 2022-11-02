/**
https://leetcode.com/problems/longest-repeating-character-replacement/

You are given a string s and an integer k. You can choose any character of the string and change it to any other uppercase English character. You can perform this operation at most k times.

Return the length of the longest substring containing the same letter you can get after performing the above operations.
*/

class Solution {
    public int characterReplacement(String s, int k) {
        int maxLen = 0, left = 0, mostFreq = 0;
        int[] counts = new int[26];
        for (int right = 0; right < s.length(); right++) {
            counts[s.charAt(right) - 'A']++;
            mostFreq = Math.max(mostFreq, counts[s.charAt(right) - 'A']);

            int lettersToReplace = (right - left + 1) - mostFreq;
            if (lettersToReplace > k) {
                count[s.charAt(left) - 'A']--;
                left++;
            }
            maxLen = Math.max(maxLen, right - left + 1);
        }
        return maxLen;
    }
}

/**
Algorithm: maintain a left, right pointer and expand the window on iteration. Then keep track of the most frequent characters within that sliding window using a constant char array then if window size - freq count > k then we need to shift the left pointer to reduce that window size.

Space: O(1), constant char array used, O(26) == O(1)
Time: O(n), one pass through the array
*/