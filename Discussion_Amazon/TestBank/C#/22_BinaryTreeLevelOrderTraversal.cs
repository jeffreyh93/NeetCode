/**
https://leetcode.com/problems/binary-tree-level-order-traversal/

Given the root of a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level).
*/

public class Solution {
    public IList<IList<int>> LevelOrder(TreeNode root) {
        List<IList<int>> ret = new List<IList<int>>();
        if (root == null) return ret;

        Queue<TreeNode> track = new Queue<TreeNode>();
        track.Enqueue(root);
        while (track.Count != 0) {
            int numNodes = track.Count;
            List<int> tmp = new List<int>();
            for (int i = 0; i < numNodes; i++) {
                TreeNode curr = track.Dequeue();
                tmp.Add(curr.val);

                if (curr.left != null) track.Enqueue(curr.left);
                if (curr.right != null) track.Enqueue(curr.right);
            }
            ret.Add(tmp);
        }
        return ret;
    }
}

/**
Algorithm: Queue/Stack
Maintain a queue that keeps track of the nodes at the given level. Iterate through the nodes in the queue and add the non-null left and right nodes
back into the queue. When processing the queue add the int to a temp list that gets added back to the return list once the level is processed

Space: O(n), at the bottom level there are n/2 leaf nodes in the queue
Time: O(n), all nodes are processed
*/