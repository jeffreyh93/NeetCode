/**
https://leetcode.com/problems/permutation-in-string/

Given two strings s1 and s2, return true if s2 contains a permutation of s1, or false otherwise.

In other words, return true if one of s1's permutations is the substring of s2.
*/

class Solution {
    public boolean checkInclusion(String s1, String s2) {
        if (s1.length() > s2.length()) return false;
        int[] s1Count = new int[26], s2Count = new int[26];

        for (int i = 0; i < s1.length(); i++) {
            s1Count[s1.charAt(i) - 'a']++;
            s2Count[s2.charAt(i) - 'a']++;
        }

        for (int i = 0; i < s2.length() - s1.length(); i++) {
            if (checkMatches(s1Count, s2Count)) return true;
            s2Count[s2.charAt(i) - 'a']--;
            s2Count[s2.charAt(i + s1.length() - 'a')]++;
        }
        return checkMatches(s1Count, s2Count);
    }
    public boolean checkMatches(int[] s1Count, int[] s2Count) {
        for (int i = 0; i < 26; i++) {
            if (s1Count[i] != s2Count[i]) return false;
        }
        return true;
    }
}

/**
Algorithm: Use sliding window approach to have a fixed length of s1 then maintain a char count for that window for both strings. Then for each iteration in s2, check whether the counts match, if they don't then increment to the next element, decrement the count at i and increment the count at i + s1.length

Space: O(1), constant extra space used O(26) = O(1)
Time: O(l1 + 26 * (l2 - l1)), l1 is traversed and each checkmatches is called for l2-l1 length
*/