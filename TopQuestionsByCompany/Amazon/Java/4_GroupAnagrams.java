/**
https://leetcode.com/problems/group-anagrams/

Given an array of strings strs, group the anagrams together. You can return the answer in any order.

An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
*/

class Solution {
    public List<List<String>> groupAnagrams(String[] strs) {
        HashMap<String, ArrayList<String>> map = new HashMap<String, ArrayList<String>>();
        for (String s : strs) {
            char[] tmp = s.toCharArray();
            Arrays.sort(tmp);
            String sorted = new String(tmp);
            if (!map.containsKey(sorted)) {
                map.put(sorted, new ArrayList<String>());
            }
            map.get(sorted).add(s);
        }
        return new ArrayList(map.values());
    }
}