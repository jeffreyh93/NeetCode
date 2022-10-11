/**
https://leetcode.com/problems/combination-sum/

Given an array of distinct integers candidates and a target integer target, return a list of all unique combinations of candidates where the chosen numbers sum to target. You may return the combinations in any order.

The same number may be chosen from candidates an unlimited number of times. Two combinations are unique if the frequency of at least one of the chosen numbers is different.

The test cases are generated such that the number of unique combinations that sum up to target is less than 150 combinations for the given input.


*/

public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        List<IList<int>> ret = new List<IList<int>>();
        Backtrack(ret, target, 0, new List<int>(), candidates);
        return ret;
    }

    public void Backtrack(List<IList<int>> ret, int remain, int start, List<int> curr, int[] candidates) {
        if (remain == 0) {
            ret.Add(new List<int>(curr));
            return;
        } else if (remain < 0) {
            return;
        }

        for (int i = start; i < candidates.Length; i++) {
            curr.Add(candidates[i]);
            Backtrack(ret, remain - candidates[i], i, curr, candidates);
            curr.RemoveAt(curr.Count - 1);
        }
    }
}

/**
Algorithm: Backtracking
Use a backtracking function to add the elements one by one then use that as the starting point for every other index.
Then keep track of the remaining value of the target and add to the return list only if remain = 0

Space: O(n), all candidates iterated through
Time: O(n), there are recursive calls for every element that satisfies the target condition
*/