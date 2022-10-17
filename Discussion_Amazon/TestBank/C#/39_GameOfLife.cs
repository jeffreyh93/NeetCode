/**
https://leetcode.com/problems/game-of-life/

According to Wikipedia's article: "The Game of Life, also known simply as Life, is a cellular automaton devised by the British mathematician John Horton Conway in 1970."

The board is made up of an m x n grid of cells, where each cell has an initial state: live (represented by a 1) or dead (represented by a 0). Each cell interacts with its eight neighbors (horizontal, vertical, diagonal) using the following four rules (taken from the above Wikipedia article):

Any live cell with fewer than two live neighbors dies as if caused by under-population.
Any live cell with two or three live neighbors lives on to the next generation.
Any live cell with more than three live neighbors dies, as if by over-population.
Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
The next state is created by applying the above rules simultaneously to every cell in the current state, where births and deaths occur simultaneously. Given the current state of the m x n grid board, return the next state.
*/

public class Solution {
    public void GameOfLife(int[][] board) {
        int m = board.Length, n = board[0].Length;

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                board[i][j] = CheckAdjacent(board, i, j, m, n);
            }
        }

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (board[i][j] == -1) board[i][j] = 0;
                else if (board[i][j] == 2) board[i][j] = 1;
            }
        }
    }

    public int CheckAdjacent(int[][] board, int r, int c, int m, int n) {
        int[] rDir = {1, 0, -1, 0, 1, 1, -1, -1};
        int[] cDir = {0, 1, 0, -1, 1, -1, 1, -1};

        int liveAdj = 0;
        for (int i = 0; i < rDir.Length; i++) {
            if (r + rDir[i] == m || r + rDir[i] < 0 || c + cDir[i] == n || c + cDir[i] < 0) continue;
            else {
                if (Math.Abs(board[r + rDir[i]][c + cDir[i]]) == 1) liveAdj++;
            }
        }

        if (board[r][c] == 1) {
            if (liveAdj < 2) return -1;
            else if (liveAdj < 4) return 1;
            else if (liveAdj > 3) return -1;
        }
        else {
            if (liveAdj == 3) return 2;
        }
        return 0;
    }
}

/**
Algorithm: Arrays and Hashing
Idea is that for every cell we need to check all directions. Then check the magnitudes of the adjacent cells, if the magnitude == 1 then it was alive before the next year. Then when we know the adjacent cell alive count during the first year, assign according to the conditions. If the cell was alive -> dead then assign it a -1 because we can check magnitude on future checks, if cell was dead -> alive assign it a 2 because we don't need to check on > 1s. Then on final iteration assign cells < 0 to be 0 and cells >= 1 to be 1.

Space: O(1), no extra space used
Time: O(m x n), all cells are iterated through
*/