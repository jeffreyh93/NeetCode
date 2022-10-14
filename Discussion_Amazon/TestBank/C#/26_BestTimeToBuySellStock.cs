/**
https://leetcode.com/problems/best-time-to-buy-and-sell-stock/

You are given an array prices where prices[i] is the price of a given stock on the ith day.

You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.

Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
*/

public class Solution {
    public int MaxProfit(int[] prices) {
        int diff = Int32.MinValue, min = prices[0];

        for (int i = 0; i < prices.Length; i++) {
            if (prices[i] < min) min = prices[i];
            if (prices[i] - min > diff) diff = prices[i] - min;
        }       

        return diff;
    }
}

/**
Algorithm: Arrays and Hashing
Loop through the array and keep track of the minimum value up to the current index. Then check the difference between the current index and the minimum, 
store and return the greatest difference.

Space: O(1), no extra space used
Time: O(n), all prices iterated through
*/