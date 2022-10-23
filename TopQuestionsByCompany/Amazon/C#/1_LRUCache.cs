/**
https://leetcode.com/problems/lru-cache/

Design a data structure that follows the constraints of a Least Recently Used (LRU) cache.

Implement the LRUCache class:

LRUCache(int capacity) Initialize the LRU cache with positive size capacity.
int get(int key) Return the value of the key if the key exists, otherwise return -1.
void put(int key, int value) Update the value of the key if the key exists. Otherwise, add the key-value pair to the cache. If the number of keys exceeds the capacity from this operation, evict the least recently used key.
The functions get and put must each run in O(1) average time complexity.
*/

public class LRUCache {
    public class CacheNode {
        public int cacheKey;
        public int cacheVal;
        public CacheNode(int key, int val) {
            this.cacheKey = key;
            this.cacheVal = val;
        }
    }

    LinkedList<CacheNode> lru;
    Dictionary<int, LinkedListNode<CacheNode>> track;
    int capacity;

    public LRUCache(int capacity) {
        this.capacity = capacity;
        lru = new LinkedList<CacheNode>();
        track = new Dictionary<int, LinkedListNode<CacheNode>>();
    }
    
    public int Get(int key) {
        if (!track.ContainsKey(key)) return -1;

        LinkedListNode<CacheNode> curr = track[key];
        lru.Remove(curr);
        lru.AddFirst(curr);

        return curr.Value.cacheVal;
    }
    
    public void Put(int key, int value) {
        if (track.ContainsKey(key)) {
            LinkedListNode<CacheNode> curr = track[key];
            curr.Value.cacheVal = value;

            lru.Remove(curr);
            lru.AddFirst(curr);
        } else {
            // create a new cache node and add it to dictionary and linked list
            CacheNode toAdd = new CacheNode(key, value);
            track.Add(key, new LinkedListNode<CacheNode>(toAdd));
            lru.AddFirst(track[key]);

            if (lru.Count > capacity) {
                // remove the last node in the linked list and that ref in the dictionary
                LinkedListNode<CacheNode> toRemove = lru.Last;
                track.Remove(toRemove.Value.cacheKey);
                lru.Remove(toRemove);
            }
        }
    }
}