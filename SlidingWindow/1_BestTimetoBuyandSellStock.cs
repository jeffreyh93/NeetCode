/**
https://leetcode.com/problems/best-time-to-buy-and-sell-stock/

You are given an array prices where prices[i] is the price of a given stock on the ith day.

You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.

Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
*/

public class Solution {
    public int MaxProfit(int[] prices) {
        int res = 0;
        int low = 0;

        for (int i = 1; i < prices.Length; i++) {
            if (prices[i] < prices[low]) low = i;
            res = Math.Max(res, prices[i] - prices[low]);
        }
        return res;
    }
}

/**
Algorithm:
Every iteration check whether the current index is less than the lowest up to that point. Then track the max difference between any index and the lowest up to that point

Space: O(1), no extra space used
Time: O(n), all elements considered
*/