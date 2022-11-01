/**
https://leetcode.com/problems/group-anagrams/

Given an array of strings strs, group the anagrams together. You can return the answer in any order.

An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
*/

public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        Dictionary<string, List<string>> track = new Dictionary<string, List<string>>();
        List<IList<string>> ret = new List<IList<string>>();

        foreach (string s in strs) {
            char[] tmp = s.ToCharArray();
            Array.Sort(tmp);
            string sorted = new string(tmp);

            if (!track.ContainsKey(sorted)) track.Add(sorted, new List<string>());
            track[sorted].Add(s);
        }

        foreach (var kvp in track) {
            ret.Add(kvp.Value);
        }
        return ret;
    }
}