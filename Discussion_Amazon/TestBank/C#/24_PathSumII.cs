/**
https://leetcode.com/problems/path-sum-ii/

Given the root of a binary tree and an integer targetSum, return all root-to-leaf paths where the sum of the node values in the path equals targetSum. Each path should be returned as a list of the node values, not node references.

A root-to-leaf path is a path starting from the root and ending at any leaf node. A leaf is a node with no children.
*/

public class Solution {
    public IList<IList<int>> PathSum(TreeNode root, int targetSum) {
        List<IList<int>> ret = new List<IList<int>>();
        DFS(root, targetSum, new List<int>(), ret);
        return ret;
    }

    public void DFS(TreeNode node, int sum, List<int> path, List<IList<int>> ret) {
        if (node == null) return;

        path.Add(node.val);
        if (node.val == sum && node.left == null && node.right == null) {
            ret.Add(new List<int>(path));
        } else {
            DFS(node.left, sum - node.val, path, ret);
            DFS(node.right, sum - node.val, path, ret);
        }
        path.RemoveAt(path.Count - 1);
    }
}

/**
Algorithm: Backtracking
Recursively visit the tree, if node is null then just exit. The satisfy condition is if the remaining sum = the current node value and the node's left and 
right nodes are both null, meaning we are at the leaf node. Otherwise, traverse through the left and right nodes. Remove the last added value at the end of the
recursion.

Space: O(N), path list to keep track of the current path
Time: O(N^2), Potentially all leaf nodes satisfy the condition, that would mean for all n/2 leaves we need to traverse through N nodes. 
*/