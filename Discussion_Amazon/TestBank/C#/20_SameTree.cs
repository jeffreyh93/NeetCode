/**
https://leetcode.com/problems/same-tree/

Given the roots of two binary trees p and q, write a function to check if they are the same or not.

Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.
*/

public class Solution {
    public bool IsSameTree(TreeNode p, TreeNode q) {
        if (p == null && q == null) return true;
        else if (p == null || q == null) return false;
        else if (p.val != q.val) return false;

        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);       
    }
}

/**
Algorithm: Tree
For each node check the conditions if they're both null return true, if one is null and the other is not return false and finally if their values do not match return false. Then check each node's left and right nodes.

Space: O(n), recursion stack for nodes in the tree
Time: O(n), all nodes are visited in both trees
*/