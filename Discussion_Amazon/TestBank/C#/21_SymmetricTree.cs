/**
https://leetcode.com/problems/symmetric-tree/

Given the root of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center).
*/

public class Solution {
    public bool IsSymmetric(TreeNode root) {
        if (root == null) return true;
        return Validate(root.left, root.right);
    }

    public bool Validate(TreeNode ptr1, TreeNode ptr2) {
        if (ptr1 == null && ptr2 == null) return true;
        else if (ptr1 == null || ptr2 == null) return false;
        else if (ptr1.val != ptr2.val) return false;

        return Validate(ptr1.left, ptr2.right) && Validate(ptr1.right, ptr2.left);
    }
}

/**
Algorithm: Trees
Visit every node in both halves of the tree, as we iterate compare the left node of left half, and right node of right half as well as right node of left half against left node of right half. 

Space: O(n), recursive stack in the case where the trees are linear
Time: O(n), all nodes are visited in the tree
*/