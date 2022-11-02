/**
https://leetcode.com/problems/search-suggestions-system/

You are given an array of strings products and a string searchWord.

Design a system that suggests at most three product names from products after each character of searchWord is typed. Suggested products should have common prefix with searchWord. If there are more than three products with a common prefix return the three lexicographically minimums products.

Return a list of lists of the suggested products after each character of searchWord is typed.
*/

class Solution {
    class TrieNode {
        boolean isWord = false;
        HashMap<char, TrieNode> track = new HashMap<char, TrieNode>();
    }
    public List<List<String>> suggestedProducts(String[] products, String searchWord) {
        TrieNode root = new TrieNode();
        // construct the trie
        for (String p : products) {
            TrieNode ptr = root;
            for (char c : p) {
                if (!ptr.containsKey(c)) {
                    ptr.put(c, new TrieNode());
                }
                ptr = ptr.get(c);
            }
            ptr.isWord = true;
        }

        // traverse the tree based on chars in searchword
        ArrayList<ArrayList<String>> ret = new ArrayList<ArrayList<String>>();
        TrieNode ptr = root;
        for (char c : searchWord) {
            ptr = ptr.track.get(c);
            TrieNode itr = ptr;
            ArrayList<String> toAdd = new ArrayList<String>();
            for (char letter = 'a'; letter <= 'z'; letter++) {
                if (itr.track.containsKey(letter)) {
                    itr = itr.track.get(letter);
                    if (itr.isWord) {
                        toAdd.
                    }
                }
            }
        }
        return ret;
    }
}