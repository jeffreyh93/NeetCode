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
Algorithm: Queues/Stacks
Use two stacks to keep track of the stack as well as the minimum value. As we are pushing, push to the track normally and only push to the min stack if it is empty or the value is greater than or equal to the top of the min stack. When popping, pop from the track normally and only pop from the min stack if the value from the stack is equal to the top of the min stack.

Space: O(n), used to keep track of the stack
Time: O(1), constant time complexity
*/