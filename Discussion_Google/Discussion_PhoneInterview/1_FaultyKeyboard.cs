/**
https://leetcode.com/discuss/interview-question/643158/Google-or-Phone-or-Faulty-Keyboard

This was the question:

There's a faulty keyboard which types a space whenever key 'e' is hit.

Location: US
Position: SWE at Google

Given a string which is the sentence typed using that keyboard and a dictionary of valid words, return all possible correct formation of the sentence.

Example:

Input: s = "I lik   to   xplor   univ rs ", dictionary  = {"like", "explore", "toe", "universe", "rse"}
Output:
["I like to explore universe",
"I like toe xplor  universe",
"I like to explore univ rse",
"I like toe xplor  univ rse"]

There are two spaces after "lik", "to" and before "univ" in the sentence indicating one is actual space and another one is resulted by hitting key 'e'.
*/

public class Solution {
    public class TrieNode {
        public Dictionary<char, TrieNode> map = new Dictionary<char, TrieNode>();
        public bool isWord = false;
    }
    
    public IList<string> FaultyKeyboard(string s, List<string> dictionary) {
        // first construct the trie of existing words
        TrieNode root = new TrieNode();
        foreach (string d in dictionary) {
            ConstructTrie(root, d);
        }

        List<string> ret = new List<string>();
        SearchWords(root, s, ret, new StringBuilder());
        return ret;
    }

    private void ConstructTrie(TrieNode root, string word) {
        TrieNode ptr = root;
        foreach (char c in word) {
            if (!ptr.map.ContainsKey(c)) {
                ptr.map.Add(c, new TrieNode());
            }
            ptr = ptr.map[c];
        }
        ptr.isWord = true;
    }

    private bool IsValidWord(TrieNode root, string word) {
        // check for spaces here, assume they are all typos
        TrieNode ptr = root;
        for (int i = 0; i < word.Length; i++) {
            char c = word[i];
            if (c != ' ') {
                if (!ptr.map.ContainsKey(c)) return false;
                ptr = ptr.map[c];
            } else {
                if (!ptr.map.ContainsKey('e')) return false;
                else if (IsValidWord(ptr.map['e'], 'e' + word.Substring(i + 1))) return true;
                else return false;
            }
        }
        return ptr.isWord;
    }

    public void SearchWords(TrieNode ptr, string s, List<string> ret, StringBuilder curr) {
        
    }
}

/**
Algorithm: Trie Structure

Space:
Time:
*/