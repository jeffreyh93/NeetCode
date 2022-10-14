/**
https://leetcode.com/problems/number-of-islands/

Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.

An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.
*/

public class Solution {
    public int NumIslands(char[][] grid) {
        int count = 0, m = grid.Length, n = grid[0].Length;
        bool[][] visited = new bool[m][];
        for (int i = 0; i < m; i++) visited[i] = new bool[n];

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == '1' && !visited[i][j]) {
                    count++;
                    VisitIsland(grid, visited, i, j, m, n);
                }
            }
        }
        return count;
    }

    public void VisitIsland(char[][] grid, bool[][] visited, int r, int c, int m, int n) {
        if (r < 0 || r >= m || c < 0 || c >= n || grid[r][c] == '0' || visited[r][c]) return;

        visited[r][c] = true;
        int[] rDir = {1, 0, -1, 0};
        int[] cDir = {0, 1, 0, -1};

        for (int i = 0; i < 4; i++) {
            VisitIsland(grid, visited, r + rDir[i], c + cDir[i], m, n);
        }
    }
}

/**
Algorithm: Graphs
Keep track of the cells already visited, then loop through the entire grid. Every time we find a '1' value, visit all adjacent '1's and mark them all as visited. Then exit condition is if the r / c is out of bounds, the cell is already visited, or the grid value is '0'.

Space: O(m x n), extra 2d array used to keep track of the visited cells.
Time: O(m x n), all cells visited in the 2d array
*/