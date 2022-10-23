class Solution {
    public String longestPalindrome(String s) {
        int startIdx = 0, endIdx = 0;
        for (int i = 0; i < s.length(); i++) {
            int lenOdd = expandCenter(s, i, i);
            int lenEven = expandCenter(s, i, i + 1);
            int maxLen = Math.max(lenOdd, lenEven);
            if (maxLen > endIdx - startIdx) {
                startIdx = i - (maxLen - 1) / 2;
                endIdx = i + maxLen / 2;
            }
        }
        return s.substring(startIdx, endIdx + 1);
    }

    public int expandCenter(String s, int left, int right) {
        while (left >= 0 && right < s.length() && s.charAt(left) == s.charAt(right)) {
            left--;
            right++; 
        }
        return right - left - 1;
    }
}