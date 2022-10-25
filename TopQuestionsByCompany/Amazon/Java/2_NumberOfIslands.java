/**
https://leetcode.com/problems/number-of-islands/

Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.

An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.
 */

class Solution {
    public int numIslands(char[][] grid) {
        int m = grid.length, n = grid[0].length;
        boolean[][] visited = new bool[m][n];

        int ret = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == '1' && !visited[i][j]) {
                    ret++;
                    visitIsland(grid, visited, i, j, m, n);
                }
            }
        }
        return ret;
    }
    public void visitIsland(char[][] grid, boolean[][] visited, int r, int c, int m, int n) {
        if (r < 0 || r >= m || c < 0 || c >= n || grid[r][c] == '0' || visited[r][c]) return;

        visited[r][c] = true;
        int[] rDir = {1, 0, -1, 0};
        int[] cDir = {0, 1, 0, -1};
        for (int i = 0; i < 4; i++) {
            visitIsland(grid, visited, r + rDir[i], c + cDir[i], m, n);
        }
    }
}