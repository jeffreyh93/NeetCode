/**
https://leetcode.com/problems/string-to-integer-atoi/

Implement the myAtoi(string s) function, which converts a string to a 32-bit signed integer (similar to C/C++'s atoi function).

The algorithm for myAtoi(string s) is as follows:

    Read in and ignore any leading whitespace.
    Check if the next character (if not already at the end of the string) is '-' or '+'. Read this character in if it is either. This determines if the final result is negative or positive respectively. Assume the result is positive if neither is present.
    Read in next the characters until the next non-digit character or the end of the input is reached. The rest of the string is ignored.
    Convert these digits into an integer (i.e. "123" -> 123, "0032" -> 32). If no digits were read, then the integer is 0. Change the sign as necessary (from step 2).
    If the integer is out of the 32-bit signed integer range [-231, 231 - 1], then clamp the integer so that it remains in the range. Specifically, integers less than -231 should be clamped to -231, and integers greater than 231 - 1 should be clamped to 231 - 1.
    Return the integer as the final result.

*/

public class Solution {
    public int MyAtoi(string s) {
        bool positive = true;
        int idx = 0, ret = 0;

        while (idx < s.Length && s[idx] == ' ') idx++;
        if (idx == s.Length) return 0;

        if (s[idx] == '-') {
            positive = false;
            idx++;
        } else if (s[idx] == '+') {
            idx++;
        }

        while (idx < s.Length && Char.IsDigit(s[idx])) {
            int digit = s[idx] - '0';
            if (ret > Int32.MaxValue / 10 || (ret == Int32.MaxValue / 10 && digit > Int32.MaxValue % 10)) {
                return positive ? int32.MaxValue : Int32.MinValue;
            }
            ret = ret * 10 + digit;
            idx++;
        }
        return positive ? ret : -ret;
    }
}

/**
Algorithm:
Account for multiple edge cases;
    continue iterating through the string until no longer white space. if we reached the end of the string then just return 0
    if the next char is '-' then the result is negative otherwise it is assumed to be positive
    continue iterating through the next chars until non-digit is found. add the result to the return value
    if the return value would ever exceed int32.maxvalue or int32.minvalue then return that capped value, otherwise return the pos or neg value

Space: O(1), no extra space used
Time: O(n), every char in the string is iterated through
*/