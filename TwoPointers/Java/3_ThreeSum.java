/**
https://leetcode.com/problems/3sum/

Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

Notice that the solution set must not contain duplicate triplets.
*/

class Solution {
    public List<List<Integer>> threeSum(int[] nums) {
        Arrays.sort(nums);
        List<List<Integer>> ret = new ArrayList();
        for (int i = 0; i < nums.length && nums[i] <= 0; i++) {
            if (i == 0 || nums[i - 1] != nums[i]) {
                int left = i + 1, right = nums.length - 1;
                while (left < right) {
                    int sum = nums[i] + nums[left] + nums[right];
                    if (sum < 0) left++;
                    else if (sum > 0) right--;
                    else {
                        ret.add(new ArrayList<>(Arrays.asList(nums[i], nums[left], nums[right]));
                        left++;
                        right--;
                        while (left < right && nums[left] == nums[right]) left++;
                    }
                }
            }
        }
        return ret;
    }
}

/**
Algorithm: sort the array and only consider indeces that are less than or equal to 0. Then do the two sum algorithm for the range between index and length - 1. Skip the duplicates by only considering indeces where the element is not equal to the one to the left of it. Then for every solution, decrease the window and skip the duplicates by increasing the left ptr.

Space: O(n), sorting algorithm is used
Time: O(n^2), there is sorting which is O(nlogn) but since we are using n^2 to iterate through the array, this is the dominant term
*/