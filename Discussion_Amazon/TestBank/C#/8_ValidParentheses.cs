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
        Stack<char> track = new Stack<char>();
        foreach (char c in track) {
            if (c == '(' || c == '[' || c == '{') track.Push(c);
            else {
                if (track.Count == 0) return false;
                char top = track.Pop();

                if (c == ')' && top != '(') return false;
                else if (c == '}' && top != '{') return false;
                else if (c == ']' && top != '[') return false;
            }
        }
        return track.Count == 0;
    }
}

/**
Algorithm: Stacks
iterate through the string for each char and match the close bracket against the top of the stack. If they don't match or stack is empty then return false
If the char is an open bracket then just add that to the stack

Space: O(n), each char stored in the stack
Time: O(n), all elements of the string iterated through
*/