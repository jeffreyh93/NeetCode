/**
https://leetcode.com/problems/valid-palindrome/

A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.

Given a string s, return true if it is a palindrome, or false otherwise.
*/

public class Solution {
    public bool IsPalindrome(string s) {
        int start = 0, end = s.Length - 1;

        while (start < end) {
            if (!Char.IsLetterOrDigit(s[start])) start++;
            else if (!Char.IsLetterOrDigit(s[end])) end--;
            else {
                if (Char.ToLower(s[start]) != Char.ToLower(s[end])) return false;
                start++;
                end--;
            }
        }
        return true;
    }
}

/**
Algorithm:
Use two pointers, one at the end and the other at the beginning. Compare the lower case chars one by one only if they're a letter or digit. Otherwise skip that iteration

Space: O(1), no extra space used
Time: O(n), all chars of the string compared
*/