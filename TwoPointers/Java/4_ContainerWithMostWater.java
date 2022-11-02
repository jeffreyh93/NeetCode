/**
https://leetcode.com/problems/container-with-most-water/

You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).

Find two lines that together with the x-axis form a container, such that the container contains the most water.

Return the maximum amount of water a container can store.

Notice that you may not slant the container.
*/

class Solution {
    public int maxArea(int[] height) {
        int maxArea = 0, left = 0, right = height.length - 1;
        while (left < right) {
            int area = Math.min(height[left], height[right]) * (right - left);
            maxArea = Math.max(area, maxArea);
            if (height[left] < height[right]) left++;
            else right--;
        }
        return maxArea;
    }
}

/**
Algorithm: use two pointers, calculate the area for every iteration and compare against the max. then decrease either the left or right pointer, whichever one is smaller

Space: O(1), no extra space used
Time: O(n), one pass through array using two ptrs
*/