/**
https://leetcode.com/problems/number-of-islands/

Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.

An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.
*/

public class Solution {
    public int NumIslands(char[][] grid) {
        int m = grid.Length, n = grid[0].Length;

        bool[][] visited = new bool[m][];
        for (int i = 0; i < m; i++) visited[i] = new bool[n];

        int numIslands = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == '1' && !visited[i][j]) {
                    numIslands++;
                    VisitIsland(grid, visited, i, j, m, n);
                }
            }
        }
        return numIslands;
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
Algorithm: DFS
Idea is to loop through all cells and check whether the grid is equal to '1' and we haven't already visited the cell. If true then visit the entire island, check and visit each adjacent cell as long as we're within bounds, the surround cell is also '1', and we haven't already visited the cell.

Space: O(m x n), at worst case we recursively call VisitIsland which can go m x n deep
Time: O(m x n), all cells visited
*/