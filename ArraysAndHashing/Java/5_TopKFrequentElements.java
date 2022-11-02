/**
https://leetcode.com/problems/top-k-frequent-elements/

Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.
*/

class Solution {
    public int[] topKFrequentHeap(int[] nums, int k) {
        HashMap<Integer, Integer> map = new HashMap();
        for (int n : nums) {
            map.put(n, map.getOrDefault(n, 0) + 1);
        }  

        Queue<Integer> pq = new PriorityQueue<>((n1, n2) -> map.get(n1) - map.get(n2));
        for (int n : map.keySet()) {
            pq.add(n);
            if (pq.size() > k) pq.poll();
        }

        int[] ret = new int[k];
        for (int i = k - 1; i >= 0; i--) ret[i] = pq.poll();
        return ret;
    }

    public int[] topKFrequentQuickSort(int[] nums, int k) {
        // LEARN THIS METHOD, QUICK SORT
    }
}