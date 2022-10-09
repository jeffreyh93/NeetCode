public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Map<Integer, Integer> track = new HashMap<>();
        for (int i = 0; i < nums.length; i++) {
            if (track.containsKey(target - nums[i])) return new int[] {i, track.get(target - nums[i])};

            if (!track.containsKey(nums[i])) track.put(nums[i], i);
        }
        return null;
    }
}

