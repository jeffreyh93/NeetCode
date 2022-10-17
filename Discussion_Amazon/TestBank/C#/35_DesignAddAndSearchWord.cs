/**
https://leetcode.com/problems/design-add-and-search-words-data-structure/

Design a data structure that supports adding new words and finding if a string matches any previously added string.

Implement the WordDictionary class:

WordDictionary() Initializes the object.
void addWord(word) Adds word to the data structure, it can be matched later.
bool search(word) Returns true if there is any string in the data structure that matches word or false otherwise. word may contain dots '.' where dots can be matched with any letter.
*/

public class WordDictionary {
    public class TrieNode {
        public Dictionary<char, TrieNode> track = new Dictionary<char, TrieNode>();
        public bool isWord = false;
    }
    public TrieNode trie;
    public WordDictionary() {
        trie = new TrieNode();
    }
    
    public void AddWord(string word) {
        TrieNode ptr = trie;
        foreach (char c in word) {
            if (!ptr.track.ContainsKey(c)) ptr.track.Add(c, new TrieNode());
            ptr = ptr.track[c];
        }
        ptr.isWord = true;
    }
    
    public bool Search(string word) {
        TrieNode ptr = trie;
        return SearchTrie(word, ptr);
    }

    public bool SearchTrie(string word, TrieNode ptr) {
        for (int i = 0; i < word.Length; i++) {
            char c = word[i];
            if (!ptr.track.ContainsKey(c)) {
                if (c != '.') return false;
                else {
                    foreach (var kvp in ptr.track) {
                        if (SearchTrie(word.Substring(i + 1), kvp.Value)) return true;
                    }
                    return false;
                }
            }
            else {
                ptr = ptr.track[c];
            }
        }
        return ptr.isWord;
    }
}

/**
Algorithm: Trie
Construct a trie data structure that stores each word. The idea is that each letter of the word stores what letters can go after it, then when we add a word to the dictionary, go through the word letter by letter. For each letter add an entry to the trie and assign the pointer to the next node. Once we get to the end of the word, assign the boolean to be true for that word. When searching for words we need to loop through the letters of the word one by one, if the letter is not '.' then just go in normally and when we reach the end of the word, simply return ptr.isWord. If the letter is '.' then we need to check all of the entries in that node's dictionary then see if any of those leaf nodes are words

Space: O(1), if the word does not contain '.', if it does then O(M), for each of the dots we need to dig further into each entry into the dictionary (up to 26 letters)
Time: O(M), if the word does not contain '.', loop through each letter in the word. If it does contain '.' then the time is O(N * 26^M) because for each letter we need to check all entries in the dictionary 
*/