/**
https://leetcode.com/problems/min-stack/

Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

Implement the MinStack class:

    MinStack() initializes the stack object.
    void push(int val) pushes the element val onto the stack.
    void pop() removes the element on the top of the stack.
    int top() gets the top element of the stack.
    int getMin() retrieves the minimum element in the stack.

You must implement a solution with O(1) time complexity for each function.
*/

public class MinStack {
    Stack<int> track;
    Stack<int> min;
    public MinStack() {
        track = new Stack<int>();
        min = new Stack<int>();
    }
    public void Push(int val) {
        track.Push(val);
        if (min.Count == 0 || min.Peek() >= val) min.Push(val);
    }
    public void Pop() {
        int val = track.Pop();
        if (min.Peek() == val) min.Pop();
    }
    public int Top() {
        return track.Peek();
    }
    public int GetMin() {
        return min.Peek();
    }
}

/**
Algorithm:
Maintain two stacks to keep track of the elements as well as the minimum at any given time. The min stack will keep track of min elements as we're pushing new ones
When popping then check whether the popped value is equal to the top of the min stack. If it is then pop from there too

Space: O(n), two stacks are used to store the elements
Time: O(1), constant time to retrieve the elements as well as popping
*/