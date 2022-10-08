/**
https://leetcode.com/problems/valid-anagram/

Given two strings s and t, return true if t is an anagram of s, and false otherwise.

An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

Follow up: What if the inputs contain Unicode characters? How would you adapt your solution to such a case?
*/

public bool IsAnagram(string s, string t) {
    if (s.Length != t.Length) return false;
    int[] track = new int[26];
    for (int i = 0; i < s.Length; i++) {
        track[s[i] - 'a']++;
        track[t[i] - 'a']--;
    }
    for (int i = 0; i < 26; i++) {
        if (track[i] != 0) return false;
    }
    return true;
}

public bool IsAnagramFollowUp(string s, string t) {
    if (s.Length != t.Length) return false;
    Dictionary<char, int> lettersCount = new Dictionary<char, int>();
    for (int i = 0; i < s.Length; i++) {
        if (!lettersCount.ContainsKey(s[i])) lettersCount.Add(s[i], 0);
        if (!lettersCount.ContainsKey(t[i])) lettersCount.Add(t[i], 0);

        lettersCount[s[i]]++;
        lettersCount[t[i]]--;
    }
    foreach (var kvp in lettersCount) {
        if (kvp.Value != 0) return false;
    }
    return true;
}

/**
Algorithm:
Use a constant int array or dictionary to keep track of the counts of each letter. Increment for one of the strings and decrement for the other. If at the end of the iteration any index is not 0, return false because both strings need to have the same counts of each char

Base
Space: O(1), constant space used for int arrays
Time: O(n), length of the string

Follow-Up
Space: O(n), each element is stored in the dictionary
Time: O(n), length of the string
*/