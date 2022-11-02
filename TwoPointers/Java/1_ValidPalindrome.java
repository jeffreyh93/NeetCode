/**
https://leetcode.com/problems/valid-palindrome/

A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.

Given a string s, return true if it is a palindrome, or false otherwise.
*/

class Solution {
    public boolean isPalindrome(String s) {
        int left = 0, right = s.length() - 1;
        while (left < right) {
            if (!Character.isLetterOrDigit(s.charAt(left))) left++;
            else if (!Character.isLetterOrDigit(s.charAt(right))) right--;
            else {
                if (Character.toLowerCase(s.charAt(left)) != Character.toLowerCase(s.charAt(right))) return false;
                left++;
                right--;
            }
        }
        return true;
    }
}

/**
Algorithm: Use two pointers to traverse the left and right directions simultaneously. If the char is not alpha-numeric then go to the next index in that direction. Otherwise convert the char to lower then do a comparison. Stop when the left pointer value exceeds the right pointer value

Space: O(1), no extra space used
Time: O(n), one pass through the string, two pointers both going towards the center
*/