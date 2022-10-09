/**
https://leetcode.com/problems/evaluate-reverse-polish-notation/

Evaluate the value of an arithmetic expression in Reverse Polish Notation.

Valid operators are +, -, *, and /. Each operand may be an integer or another expression.

Note that division between two integers should truncate toward zero.

It is guaranteed that the given RPN expression is always valid. That means the expression would always evaluate to a result, and there will not be any division by zero operation.
*/

public class Solution {
    public int EvalRPN(string[] tokens) {
        Stack<int> track = new Stack<int>();

        foreach (string tok in tokens) {
            if (tok.Equals("+") || tok.Equals("*") || tok.Equals("-") || tok.Equals("/")) {
                int op2 = track.Pop();
                int op1 = track.Pop();

                int res;
                if (tok.Equals("+")) res = op1 + op2;
                else if (tok.Equals("*")) res = op1 * op2;
                else if (tok.Equals("-")) res = op1 - op2;
                else res = op1 / op2;

                track.Push(res);
            } else {
                track.Push(Int32.Parse(tok));
            }
        }
        return track.Peek();
    }
}

/**
Algorithm:
If the token is a number then add that to the stack otherwise perform the operation on the top 2 operands

Space: O(n), uses a stack to keep track of the operands
Time: O(n), each token is iterated through
*/