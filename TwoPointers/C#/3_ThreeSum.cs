/**
https://leetcode.com/problems/3sum/

Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

Notice that the solution set must not contain duplicate triplets.
*/

public IList<IList<int>> ThreeSum(int[] nums) {
    Array.Sort(nums);
    var ret = new List<IList<int>>();

    for (int i = 0; i < nums.Length && nums[i] <= 0; i++) {
        if (i == 0 || nums[i] != nums[i - 1]) {
            TwoSum(nums, i, ret);
        }
    }
    return ret;
}

public void TwoSum(int[] nums, int i, List<IList<int>> ret) {
    int start = i + 1, end = nums.Length - 1;
    while (start < end) {
        int sum = nums[i] + nums[start] + nums[end];
        if (sum < 0) start++;
        else if (sum > 0) end--;
        else {
            ret.Add(new List<int> {nums[i], nums[start], nums[end]});
            start++;
            end--;
            while (start < end && nums[start] == nums[start - 1]) start++;
        }
    }
}

/**
Algorithm:
First sort the array, then only use the indeces where the element < 0 to start with
Then use the two sum algorithm to start from the starting point and check whether the sum of all 3 = 0. If they are < 0 then increase left ptr, otherwise dec right ptr

Space: O(logn), used to sort the array
Time: O(n^2), all elements entered and at worst case twosum is called n times. TwoSum itself has O(n) complexity
*/