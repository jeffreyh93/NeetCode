/**
https://leetcode.com/problems/longest-palindromic-substring/

Given a string s, return the longest palindromic substring in s.

A string is called a palindrome string if the reverse of that string is the same as the original string.
*/

public class Solution {
    public string LongestPalindrome(string s) {
        if (s == null || s.Length < 2) return s;
        int maxLen = 0, startIdx = 0;

        for (int i = 0; i < s.Length; i++) {
            int lenOdd = ExpandCenter(s, i, i);
            int lenEven = ExpandCenter(s, i, i + 1);

            if (maxLen < Math.Max(lenOdd, lenEven)) {
                maxLen = Math.Max(lenOdd, lenEven);
                startIdx = lenOdd > lenEven ? i - lenOdd / 2 : i - lenEven / 2 + 1;
            }
        }        
        return s.Substring(startIdx, maxLen);
    }

    public int ExpandCenter(string s, int left, int right) {
        while (left >= 0 && right <= s.Length - 1 && s[left] == s[right]) {
            left--;
            right++;
        }
        left++;
        right--;

        return right - left + 1;
    }
}

/**
Algorithm:
For every char in the string, expand around that index in the odd and even directions. Compare those lengths to the max then track the max len and start idx

Space: O(1), no extra space used
Time: O(n^2), for every index (n), compare against all elements in the string (n)
*/
