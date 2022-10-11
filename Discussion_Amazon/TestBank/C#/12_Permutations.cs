/**
https://leetcode.com/problems/permutations/

Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.
*/

public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        List<IList<int>> ret = new List<IList<int>>();
        Backtrack(ret, nums, new HashSet<int>(), new List<int>());
        return ret;
    }

    public void Backtrack(List<IList<int>> ret, int[] nums, HashSet<int> visited, List<int> curr) {
        if (nums.Length == curr.Count) {
            ret.Add(new List<int>(curr));
            return ret;
        }

        for (int i = 0; i < nums.Length; i++) {
            if (!visited.Contains(i)) {
                visited.Add(i)
                curr.Add(nums[i]);
                Backtrack(ret, nums, visited, curr);
                visited.Remove(i);
                curr.RemoveAt(curr.Count - 1);
            }
        }
    }
}

/**
Algorithm: Backtracking
loop through all of the elements, keep track of the already visited elements through a hashset. If not visited then add that number to the return list and
the index to the hashset.

Space: O(N!), there are N! recursive calls for every element in the array
Time: O(N X N!), for every element N, there are N! iterations to be done
*/