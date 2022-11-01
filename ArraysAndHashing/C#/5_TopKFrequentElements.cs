/**
https://leetcode.com/problems/top-k-frequent-elements/

Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.
*/

public int[] TopKFrequent(int[] nuims, int k) {
    PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
    Dictionary<int, int> counts = new Dictionary<int, int>();
    foreach (int n in nums) {
        if (!counts.ContainsKey(n)) pq.Add(n, 0);
        pq[n]++;
    }

    foreach (var kvp in counts) {
        pq.Enqueue(kvp.Key, kvp.Value);
        if (pq.Count > k) pq.Dequeue();
    }

    int pqSize = pq.Count;
    int[] ret = new int[pqSize];
    for (int i = 0; i < pqSize; i++) {
        ret[i] = pq.Dequeue();
    }
    return ret;
}

/**
Algorithm:
Use a priorityqueue to insert the element counts one by one. Every time we insert, remove the smallest element then eventually the pq will only store the top k elements

Space: O(n), every element is stored in the dictionary
Time: O(n), each element is visited in the array
*/