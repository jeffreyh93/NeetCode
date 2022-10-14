/**
https://leetcode.com/problems/word-search/

Given an m x n grid of characters board and a string word, return true if word exists in the grid.

The word can be constructed from letters of sequentially adjacent cells, where adjacent cells are horizontally or vertically neighboring. The same letter cell may not be used more than once.
*/

public class Solution {
    public bool Exist(char[][] board, string word) {
        int m = board.Length, n = board[0].Length;
        
        bool[][] visited = new bool[m][];
        for (int i = 0; i < m; i++) {
            visited[i] = new bool[n];
        }       

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (word[0] == board[i][j] && Backtrack(board, word, visited, 0, i, j)) {
                    return true;
                } 
            }
        }
        return false;
    }

    public bool Backtrack(char[][] board, string word, bool[][] visited, int idx, int r, int c) {
        if (idx == word.Length) return true;
        else if (r < 0 || r >= board.Length || c < 0 || c >= board[0].Length || visited[r][c] || board[r][c] != word[idx]) return false;

        visited[r][c] = true;
        int rDir = {1, 0, -1, 0};
        int cDir = {0, 1, 0, -1};
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
Use an auxilary visited array that keeps track of the array visited cells. Every iteration of the board check whether the char matches the first 
letter of the word. If it does then enter / visit that cell then for every adjacent cell, visit those in a backtracking way, keep track of the visited cells
then mark them as unvisited after returned.

Space: O(n^2 + L), uses an extra 2d array to keep track of the visited cells, the recursive calls are for each letter in the word, L
Time: O(n^2 * 3L), every element in the grid is iterated through, for every visited cell there are 3 directions to visit for each letter of the word, L
*/