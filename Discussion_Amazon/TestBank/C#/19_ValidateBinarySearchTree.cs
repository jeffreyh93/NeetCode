/**
https://leetcode.com/problems/validate-binary-search-tree/

Given the root of a binary tree, determine if it is a valid binary search tree (BST).

A valid BST is defined as follows:

The left subtree of a node contains only nodes with keys less than the node's key.
The right subtree of a node contains only nodes with keys greater than the node's key.
Both the left and right subtrees must also be binary search trees.
*/

public class Solution {
    public bool IsValidBST(TreeNode root) {
        return Validate(root, null, null);
    }

    public bool Validate(TreeNode curr, int? max, int? min) {
        if (curr == null) return true;
        else if ((max != null && curr > max) || (min != null && curr < min)) return false;

        return Validate(curr.left, curr.val, min) && Validate(curr.right, max, curr.val);
    }
}

/**
Algorithm: Trees
Traverse the tree and keep track of the max and min bounds of any given node. Whenever we traverse left, update the max to be the current node value
If traverse right, update the min to be current node

Space: O(n), n calls recursively on the stack
Time: O(n), all nodes of the tree are iterated through
*/