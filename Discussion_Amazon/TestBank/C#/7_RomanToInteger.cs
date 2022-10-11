/**
https://leetcode.com/problems/roman-to-integer/

Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

Symbol       Value
I             1
V             5
X             10
L             50
C             100
D             500
M             1000

For example, 2 is written as II in Roman numeral, just two ones added together. 12 is written as XII, which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.

Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:

    I can be placed before V (5) and X (10) to make 4 and 9. 
    X can be placed before L (50) and C (100) to make 40 and 90. 
    C can be placed before D (500) and M (1000) to make 400 and 900.

Given a roman numeral, convert it to an integer.
*/

public class Solution {
    public int RomanToInt(string s) {
        Dictionary<char, int> values = new Dictionary<char, int>() {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        int ret = 0;
        for (int i = 0; i < s.Length; i++) {
            int currVal = values[s[i]];
            if (i == s.Length - 1) ret += currVal;
            else {
                int nextVal = values[s[i + 1]];
                if (currVal < nextVal) {
                    ret += nextVal - currVal;
                    i++;
                } else {
                    ret += currVal;
                }
            }
        }
        return ret;
    }
}

/**
Algorithm: Arrays and Hashing
one pass through the string, for every index check its value and the next value. If the next value is greater than current then add the result of subtracting
next and current, then skip the next symbol. Otherwise just add the current value and go to the next.

Space: O(1), no extra space used, linear
Time: O(n), every element of the string is evaluated
*/