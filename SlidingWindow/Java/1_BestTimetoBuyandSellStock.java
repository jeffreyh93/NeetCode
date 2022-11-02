/**
https://leetcode.com/problems/best-time-to-buy-and-sell-stock/

You are given an array prices where prices[i] is the price of a given stock on the ith day.

You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.

Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
*/

class Solution {
    public int maxProfit(int[] prices) {
        int ret = 0, currLowest = prices[0];
        for (int i = 0; i < prices.length; i++) {
            if (ret < prices[i] - currLowest) {
                ret = prices[i] - currLowest;
            } else if (prices[i] < currLowest) {
                currLowest = prices[i];
            }
        }
        return currLowest;
    }
}

/**
Algorithm: traverse the array and keep track of the max diff between the element and the lowest up to that point. If the current element is less than the lowest up to that point then update that value.

Space: O(1), no extra space used
Time: O(n), all elements traversed in the array
*/