/**
https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/

Given the root of a binary tree, return the zigzag level order traversal of its nodes' values. (i.e., from left to right, then right to left for the next level and alternate between).
*/

public class Solution {
    public IList<IList<int>> ZigzagLevelOrderIterative(TreeNode root) {
        List<IList<int>> ret = new List<IList<int>>();
        if (root == null) return ret;

        Queue<TreeNode> track = new Queue<TreeNode>();
        track.Enqueue(root);
        bool leftToRight = true;
        while (track.Count != 0) {
            int numNodes = track.Count;
            List<int> currLevel = new List<int>();
            for (int i = 0; i < numNodes; i++) {
                TreeNode node = track.Dequeue();
                if (leftToRight) currLevel.Add(node.val);
                else currLevel.Insert(0, node.val);

                if (node.left != null) track.Enqueue(node.left);
                if (node.right != null) track.Enqueue(node.right);
            }
            leftToRight = !leftToRight;
            ret.Add(currLevel);
        }
        return ret;
    }

    public List<IList<int>> ZigzagLevelOrderRecursive(TreeNode root) {
        List<IList<int>> ret = new List<IList<int>>();
        if (root == null) return ret;

        DFS(root, ret, 0);
        return ret;
    }

    public void DFS(TreeNode root, List<IList<int>> ret, int level) {
        if (root == null) return;
        if (ret.Count == level) ret.Add(new List<int>());

        if (level % 2 == 0) ret[level].Add(root.val);
        else ret[level].Insert(0, root.val);

        DFS(root.left, ret, level + 1);
        DFS(root.right, ret, level + 1);
    }
}

/**
Algorithm: Trees
Iterative - BFS, Add the nodes to the queue in the left to right direction. Then at the current level if it is an even level, add in left to right direction (list.Add(val)) otherwise add in the reverse direction (list.Insert(0, val)). After, add the non-null left then right nodes and flip the bool to make it the other direction

Space: O(n), at worst case there are n/2 leaf nodes which get added to the queue for that level
Time: O(n), all nodes are visited

Recursive - DFS, recursively call the DFS function which takes in the node and the level. Depending on whether the level is even or odd, add in the normal (even) or reverse (odd) direction.

Space: O(n), at worst case the tree is completely unbalanced so there are n recursive calls
Time: O(n), all nodes are visited
*/