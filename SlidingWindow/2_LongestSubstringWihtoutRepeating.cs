/**
https://leetcode.com/problems/longest-substring-without-repeating-characters/

Given a string s, find the length of the longest substring without repeating characters.
*/

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var track = new Dictionary<char, int>();
        int ret = 0;

        for (int i = 0, left = 0; i < s.Length; i++) {
            if (track.ContainsKey(s[i])) {
                left = Math.Max(track[s[i]], left);
            } else {
                track.Add(s[i], 0);
            }
            ret = Math.Max(ret, i - left + 1);
            track[s[i]] = i + 1;
        }
        return ret;
    }
}

/**
Algorithm: 
Use a dictionary to keep track of all chars and what their index is in the string. Everytime we find a char array in the dictionary, move the left pointer
to the max between where it is currently, and where the char was found. Then return the difference between current index and the left pointer. Update the 
index of the current char

Space: O(min(m, n)), all chars are stored in the dictionary. m is used for each unique char in the dictionary
Time: O(n), one pass through each char
*/