/**
https://leetcode.com/problems/binary-tree-level-order-traversal/

Given the root of a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level).
*/

public class Solution {
    public IList<IList<int>> LevelOrderIterative(TreeNode root) {
        List<IList<int>> ret = new List<IList<int>>();
        if (root == null) return ret;

        Queue<TreeNode> track = new Queue<TreeNode>();
        track.Enqueue(root);

        while (track.Count != 0) {
            List<int> currLevel = new List<int>();
            int numNodes = track.Count;
            for (int i = 0; i < numNodes; i++) {
                TreeNode tmp = track.Dequeue();
                currLevel.Add(tmp.val);

                if (tmp.left != null) track.Enqueue(tmp.left);
                if (tmp.right != null) track.Enqueue(tmp.right);                
            }
            ret.Add(currLevel);            
        }
        return ret;
    }

    public IList<IList<int>> LevelOrderRecursive(TreeNode root) {
        List<IList<int>> ret = new List<IList<int>>();
        TraverseTree(ret, root, 0);
        return ret;
    }
    public void TraverseTree(List<IList<int>> ret, TreeNode root, int level) {
        if (root == null) return;

        if (ret.Count == level) ret.Add(new List<int>());
        ret[level].Add(root.val);

        TraverseTree(ret.left, root, level + 1);
        TraverseTree(ret.right, root, level + 1);
    }
}

/**
Algorithm: Trees
Iterative - BFS, Use a queue to keep track of the current level of the tree. Every iteration create a new list and add the nodes' values to that list. Then for every node add the non-null left and right children, then add the full list back to the return list.

Space: O(n), at worst case there are n/2 leaf nodes in the tree and n/2 nodes in the queue at the last level
Time: O(n), all nodes are iterated through

Recursive - DFS, Use a recursive function to add non-null node values to the return list. Pass in the level to the recursive function to know which index to add the node to.

Space: O(n), at worst case the tree is completely unbalanced, all nodes are on the left side of the tree, eg. so n calls on the stack
Time: O(n), all nodes are iterated through
*/