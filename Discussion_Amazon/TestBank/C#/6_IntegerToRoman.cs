/**
https://leetcode.com/problems/integer-to-roman/

Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

Symbol       Value
I             1
V             5
X             10
L             50
C             100
D             500
M             1000

For example, 2 is written as II in Roman numeral, just two one's added together. 12 is written as XII, which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.

Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:

    I can be placed before V (5) and X (10) to make 4 and 9. 
    X can be placed before L (50) and C (100) to make 40 and 90. 
    C can be placed before D (500) and M (1000) to make 400 and 900.

Given an integer, convert it to a roman numeral.
*/

public class Solution {
    public string IntToRoman(int num) {
        int[] values = new int[13] {1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1};
        string[] symbols = new string[] {13} {"M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"};

        StringBuilder ret = new StringBuilder();

        for (int i = 0; i < values.Length; i++) {
            while (values[i] <= num) {
                ret.Append(symbols[i]);
                num -= values[i];
            }
        }
        return ret.ToString();
    }
}

/**
Algorithm: Greedy / Arrays
Use greedy algorithm to sort the possible values from the largest to smallest. For every index check if that element <= num, if it is then append the 
return string by that symbol then decrease num by that amount. 

Space: O(1), no extra space used
Time: O(1), constant time complexity because there is a fixed upper limit, not dependent on input
*/