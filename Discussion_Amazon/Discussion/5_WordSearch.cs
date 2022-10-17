/**
https://leetcode.com/problems/word-search/

Given an m x n grid of characters board and a string word, return true if word exists in the grid.

The word can be constructed from letters of sequentially adjacent cells, where adjacent cells are horizontally or vertically neighboring. The same letter cell may not be used more than once.
*/

public class Solution {
    public bool Exist(char[][] board, string word) {
        bool[][] visited = new bool[board.Length][];
        for (int i = 0; i < board.Length; i++) board[i] = new bool[board[0].Length];

        for (int i = 0; i < board.Length; i++) {
            for (int j = 0; j < board[0].Length; j++) {
                if (board[i][j] == word[0] && !visited[i][j]) {
                    if (Backtrack(board, word, visited, 0, i, j)) {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public bool Backtrack(char[][] board, string word, bool[][] visited, int idx, int r, int c) {
        if (idx == word.Length) return true;

        if (r < 0 || r >= board.Length || c < 0 || c >= board[0].Length || board[r][c] != word[idx] || visited[r][c]) return false;

        visited[r][c] = true;
        int[] rDir = {1, 0, -1, 0};
        int[] cDir = {0, 1, 0, -1};
        bool ret = false;
        for (int i = 0; i < 4; i++) {
            ret = Backtrack(board, word, visited, idx + 1, r + rDir[i], c + cDir[i]);
            if (ret) break;
        }
        visited[r][c] = false;
        return ret;
    }
}

/**
Algorithm: Backtracking
Iterate through the board and visit the cells only if the char matches the first letter in the word. If it does then mark it as visited and visit all the surround cells directions and visit those cells as well. The exit conditions are if we've reached the end of the word then return true, if the r / c are out of bounds, the chars don't match, or if the cell was already visited then return false

Space: O(n x m + L), for every letter l in the word, there are that many calls in the recursion stack. The visited array size is also n x m
Time: O(n x m x 3^L), every cell in the board is visited if it meets conditions then all directions are visited for every letter in the word
*/