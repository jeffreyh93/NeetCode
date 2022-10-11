/**
https://leetcode.com/problems/valid-sudoku/

Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:

    Each row must contain the digits 1-9 without repetition.
    Each column must contain the digits 1-9 without repetition.
    Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.

Note:

    A Sudoku board (partially filled) could be valid but is not necessarily solvable.
    Only the filled cells need to be validated according to the mentioned rules.

*/

public class Solution {
    public bool IsValidSudoku(char[][] board) {
        int N = 9;
        List<HashSet<char>> trackRows = new List<HashSet<char>>();
        List<HashSet<char>> trackCols = new List<HashSet<char>>();
        List<HashSet<char>> trackSquares = new List<HashSet<char>>();

        for (int i = 0; i < N; i++) {
            trackRows.Add(new HashSet<char>());
            trackCols.Add(new HashSet<char>());
            trackSquares.Add(new HashSet<char>());
        }

        for (int r = 0; r < N; r++) {
            for (int c = 0; c < N; c++) {
                char val = board[r][c];
                
                if (val == '.') continue;

                if (trackRows[r].Contains(val)) return false;
                trackRows[r].Add(val);

                if (trackCols[c].Contains(val)) return false;
                trackCols[c].Add(val);

                int square = (r / 3) * 3 + c / 3;
                if (trackSquares[square].Contains(val)) return false;
                trackSquares[square].Add(val);
            }
        }
        return true;
    }
}

/**
Algorithm: Arrays and hashing
use a list of hashsets for every row, col, and square then for every index check that corresponding index in their lists
If not already found in the hashset then add that value

Space: O(n^2), for every row, col, squ there are n hashsets and each hashset can contain n elements
Time: O(n^2), every element in the 2d array is iterated through
*/