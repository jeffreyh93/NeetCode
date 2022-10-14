/**
https://leetcode.com/problems/course-schedule-ii/

There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.

For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
Return the ordering of courses you should take to finish all courses. If there are many valid answers, return any of them. If it is impossible to finish all courses, return an empty array.
*/

public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        if (prerequisites.Length == 0) {
            int[] noPreReq = new int[numCourses];
            for (int i = 0; i < numCourses; i++) {
                noPreReq[i] = i;
            }
            return noPreReq;
        }

        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        int[] inDeg = new int[numCourses];

        foreach (int[] relationships in prerequisites) {
            int[] prev = relationships[1], next = relationships[0];
            if (!graph.ContainsKey(prev)) graph.Add(prev, new List<int>());
            graph[prev].Add(next);

            inDeg[next]++;
        }

        Queue<int> toComplete = new Queue<int>();
        for (int i = 0; i < numCourses; i++) {
            if (inDeg[i] == 0) {
                toComplete.Enqueue(i);
            }
        }

        List<int> ret = new List<int>();
        while (toComplete.Count != 0) {
            int node = toComplete.Dequeue();
            ret.Add(node);

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

        if (ret.Count == numCourses) return ret.ToArray();
        else return new int[0];
    }
}

/**
Algorithm: Graphs
Construct a graph of prerequisite nodes that keeps track of each course and its prerequisites. It also connects all prerequisite courses to their next course nodes. Then keep track of all courses to be completed first (no prereq) in a queue by checking their indegree. Every time we complete a course (dequeue), add that course to the return list then check all courses that this one is a prerequisite to. Reduce all of those edges by 1 then if any of those connected courses have indegree 0, add them to the queue to be completed next. 

Space: O(E + V), the graph data structure keeps track of all vectors and their edges
Time: O(E + V), all vectors are visited then for each one, all of its edges are visited
*/