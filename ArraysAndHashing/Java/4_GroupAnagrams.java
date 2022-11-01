/**
https://leetcode.com/problems/group-anagrams/

Given an array of strings strs, group the anagrams together. You can return the answer in any order.

An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
*/

class Solution {
    public List<List<String>> groupAnagrams(String[] strs) {
        HashMap<String, ArrayList<String>> map = new HashMap();
        for (String s : strs) {
            char[] tmp = s.toCharArray();
            Arrays.sort(tmp);
            String sorted = new String(tmp);
            if (!map.containsKey(sorted)) map.put(sorted, new ArrayList<String>());
            map.get(sorted).add(s);
        }       
        return new ArrayList(map.values());
    }
}

/**
Algorithm: for each string, sort the char arrays then add that resulting string to a dictionary. The dictionary keeps track of the sorted string as the key then a list of all unsorted strings as its value. Then return all values in a list.

Space: O(nk), all strings are stored in the dictionary
Time: O(nklogk), all strings are looped through (n), then each string is sorted (klogk)
*/