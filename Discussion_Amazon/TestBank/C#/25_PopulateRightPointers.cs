/**
https://leetcode.com/problems/populating-next-right-pointers-in-each-node/

You are given a perfect binary tree where all leaves are on the same level, and every parent has two children. The binary tree has the following definition:

struct Node {
  int val;
  Node *left;
  Node *right;
  Node *next;
}

Populate each next pointer to point to its next right node. If there is no next right node, the next pointer should be set to NULL.

Initially, all next pointers are set to NULL.
*/

public class Solution {
    public Node Connect(Node root) {
        if (root == null) return root;
        Queue<int> track = new Queue<int>();
        track.Enqueue(root);

        while (track.Count != 0) {
            int numNodes = track.Count;
            for (int i = 0; i < numNodes; i++) {
                Node tmp = track.Dequeue();
                if (i < numNodes - 1) {
                    tmp.next = track.Peek();
                }
                if (tmp.left != null) track.Enqueue(tmp.left);
                if (tmp.right != null) track.Enqueue(tmp.right);
            }
        }        
        return root;
    }
}

/**
Algorithm: Queue/Stack
Maintain a queue to traverse the tree by its level. While iterating through the stack at any given time, assign the next node of the currently visited node
to be the peeked value of the queue. then add the left and right nodes of the curr node if not null

Space: O(n), queue used to store the level, at most it is n/2 leaf nodes
Time: O(n), all nodes visited
*/