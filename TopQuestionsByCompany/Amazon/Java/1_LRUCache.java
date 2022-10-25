/**
https://leetcode.com/problems/lru-cache/

Design a data structure that follows the constraints of a Least Recently Used (LRU) cache.

Implement the LRUCache class:

LRUCache(int capacity) Initialize the LRU cache with positive size capacity.
int get(int key) Return the value of the key if the key exists, otherwise return -1.
void put(int key, int value) Update the value of the key if the key exists. Otherwise, add the key-value pair to the cache. If the number of keys exceeds the capacity from this operation, evict the least recently used key.
The functions get and put must each run in O(1) average time complexity.
 */

class LRUCache {
    class Cache {
        public int cacheVal;
        public int cacheKey;
        public Cache(int key, int val) {
            cacheKey = key;
            cacheVal = val;
        }
    }

    LinkedList<Cache> lru;
    HashMap<Integer, Cache> track;
    int capacity;

    public LRUCache(int capacity) {
        this.capacity = capacity;
        lru = new LinkedList<Cache>();
        track = new HashMap<Integer, Cache>();
    }
    
    public int get(int key) {
        if (!track.containsKey(key)) return -1;

        Cache toUpdate = track.get(key);
        lru.remove(toUpdate);
        lru.addFirst(toUpdate);

        return toUpdate.cacheVal;
    }
    
    public void put(int key, int value) {
        if (track.containsKey(key)) {
            Cache toUpdate = track.get(key);

            toUpdate.cacheVal = value;
            lru.remove(toUpdate);
            lru.addFirst(toUpdate);
        } else {
            Cache toAdd = new Cache(key, value);

            track.put(key, toAdd);
            lru.addFirst(toAdd);

            if (lru.size() > capacity) {
                Cache toRemove = lru.peekLast();

                track.remove(toRemove.cacheKey);
                lru.removeLast();
            }
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.get(key);
 * obj.put(key,value);
 */