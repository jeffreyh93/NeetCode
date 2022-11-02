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
    public boolean IsValidSudoku(char[][] board) {
        int n = board.length;
        List<HashSet<Character>> rows = new ArrayList();
        List<HashSet<Character>> cols = new ArrayList();
        List<HashSet<Character>> squares = new ArrayList();

        for (int i = 0; i < n; i++) {
            rows.add(new HashSet<Character>());
            cols.add(new HashSet<Character>());
            squares.add(new HashSet<Character>());
        }

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                char c = board[i][j];
                if (c == '.') continue;

                if (rows.get(i).contains(c)) return false;
                rows.get(i).add(c);

                if (cols.get(j).contains(c)) return false;
                cols.get(j).add(c);

                int sq = (i / 3) * 3 + (j / 3);
                if (squares.get(sq).contains(c)) return false;
                squares.get(sq).add(c);
            }
        }
        return true;
    }
}

/**
Algorithm: maintain 3 lists of hashsets that all keeps track of their own hashset. As we iterate through the grid, insert that character to the matching index in each of the lists then if it already contains that char then return false.

Space: O(n^2), use three lists (n) of hashsets (n) to keep track of the visited chars
Time: O(n^2), traverse each index in the grid
*/