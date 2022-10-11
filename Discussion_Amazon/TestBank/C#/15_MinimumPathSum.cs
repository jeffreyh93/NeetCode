/**
https://leetcode.com/problems/minimum-path-sum/

Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right, which minimizes the sum of all numbers along its path.

Note: You can only move either down or right at any point in time.
*/

public class Solution {
    public int MinPathSum(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        int[][] costs = new int[m][];
        for (int i = 0; i < m; i++) 
            costs[i] = new int[n];
        
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (i == m - 1 && j == n - 1) costs[i][j] = grid[i][j];
                else if (i == m - 1) costs[i][j] = grid[i][j] + costs[i][j + 1];
                else if (j == n - 1) costs[i][j] = grid[i][j] + costs[i + 1][j];
                else costs[i][j] = grid[i][j] + Math.Min(costs[i][j + 1], costs[i + 1], j);
            }
        }
        return costs[0][0];
    }
}

/**
Algorithm: Dynamic Programming
keep track of a 2d array that tracks the minimum path from bottom right - top left of any given cell. Then the top left index will store the total minimum path of the whole grid. Make sure the boundary conditions are considered such as the bottom-most row and right-most column

Space: O(m * n), a duplicate cost grid is used to store the minimum paths
Time: O(m * n), each element in the 2d array is iterated through
*/