/**
https://leetcode.com/problems/valid-parentheses/

Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:

    Open brackets must be closed by the same type of brackets.
    Open brackets must be closed in the correct order.
    Every close bracket has a corresponding open bracket of the same type.

*/

public class Solution {
    public bool IsValid(string s) {
        var track = new Stack<char>();

        foreach (char c in s) {
            if (c == '(' || c == '[' || c == '{') track.Push(c);
            else {
                if (track.Count == 0) return false;

                char top = track.Pop();
                if (c == ')' && top != '(') return false;
                else if (c == ']' && top != '[') return false;
                else if (c == '}' && top != '{') return false;
            }
        }
        return track.Count == 0;
    }
}

/**
Algorithm:
Use a stack to keep track of the last inserted bracket. In the case when we want to add an open brack just add that to the stack. 
If we want to add a close bracket then check the top of the stack, if it is matching then continue otherwise return false
At the end of the string if there are any chars still in the stack then return false

Space: O(n), potentially all chars are stored in the stack
Time: O(n), all chars are iterated through
*/