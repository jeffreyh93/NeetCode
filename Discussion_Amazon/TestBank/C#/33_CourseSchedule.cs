/**
https://leetcode.com/problems/course-schedule/

There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.

For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
Return true if you can finish all courses. Otherwise, return false.
*/

public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        int[] inDeg = new int[numCourses];

        foreach (int[] relationship in prerequisites) {
            int prev = relationship[1];
            int next = relationship[0];

            if (!graph.ContainsKey(prev)) graph.Add(prev, new List<int>());
            graph[prev].Add(next);
            inDeg[next]++;
        }

        Queue<int> toComplete = new Queue<int>();
        for (int i = 0; i < numCourses; i++) {
            if (inDeg[i] == 0) toComplete.Enqueue(i);
        }

        int count = 0;
        while (toComplete.Count != 0) {
            int node = toComplete.Dequeue();
            count++;

            if (graph.ContainsKey(node)) {
                List<int> nextCourses = graph[node];
                foreach (int next in nextCourses) {
                    inDeg[next]--;
                    if (inDeg[next] == 0) {
                        toComplete.Enqueue(next);
                    }
                }
            }
        }
        return count == numCourses;
    }
}

/**
Algorithm: Graphs
Create a dictionary of each course and the courses that depend on that course. Also create an indegree array that stores the count of prerequisites that each course has. If any course has 0 prerequisites then we can complete those first, so add those to the queue. Then as we iterate through the queue check each of the node's edges and decrement each of those nodes' indegrees. Add the 0 indegree nodes back to the queue. If anytime the queue is empty then break out then track the number of popped nodes (completed courses) and compare that against num courses.

Space: O(E + V), the graph data structure contains all edges and vectors in the graph
Time: O(E + V), each vector is visited as well as their edges
*/