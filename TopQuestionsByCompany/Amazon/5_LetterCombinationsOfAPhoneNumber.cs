/**
https://leetcode.com/problems/letter-combinations-of-a-phone-number/

Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. Return the answer in any order.

A mapping of digits to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.
*/

public class Solution {
    Dictionary<char, string> map = new Dictionary<char, string>() {
        {'2', "abc"},
        {'3', "def"},
        {'4', "ghi"},
        {'5', "jkl"},
        {'6', "mno"},
        {'7', "pqrs"},
        {'8', "tuv"},
        {'9', "wxyz"}
    };
    public IList<string> LetterCombinations(string digits) {
        List<string> ret = new List<string>();
        foreach (char c in digits) {
            string toAdd = map[c];
            if (ret.Count = 0) {
                foreach (char letter in toAdd) {
                    ret.Add(letter);
                }
            } else {
                for (int i = 0; i < ret.Count; i++) {
                    string base = ret[i];
                    for (int j = 0; j < toAdd.Length; j++) {
                        if (j == 0) {
                            ret[i] += toAdd[j];
                        } else {
                            ret.Add(base + toAdd[j]);
                        }
                    }
                }
            }
        }
        return ret;
    }
}