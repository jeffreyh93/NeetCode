/**
https://leetcode.com/problems/restore-ip-addresses/

A valid IP address consists of exactly four integers separated by single dots. Each integer is between 0 and 255 (inclusive) and cannot have leading zeros.

    For example, "0.1.2.201" and "192.168.1.1" are valid IP addresses, but "0.011.255.245", "192.168.1.312" and "192.168@1.1" are invalid IP addresses.

Given a string s containing only digits, return all possible valid IP addresses that can be formed by inserting dots into s. You are not allowed to reorder or remove any digits in s. You may return the valid IP addresses in any order.
*/

public class Solution {
    public IList<string> RestoreIpAddresses(string s) {
        List<string> ret = new List<string>();
        Backtrack(s, ret, "", 0, 0);
        return ret;
    }

    public void Backtrack(string s, List<string> ret, string curr, int idx, int level) {
        if (idx > s.Length || level > 4) {
            return;
        }
        else if (idx == s.Length && level == 4) {
            ret.Add(new string(curr));
            return;
        }

        for (int i = 1; i <= 3; i++) {
            if (idx + i > s.Length) break;
            string tmp = s.Substring(idx, i);
            if ((tmp.StartsWith("0") && i > 1) || (i == 3 && Int32.Parse(tmp) >= 256)) continue;
            Backtrack(s, ret, curr + tmp + (level == 3 ? "" : "."), idx + i, level + 1);
        }
    }
}

/**
Algorithm: Backtracking
Use backtracking to check every section of 1 - 3 chars, make sure they meet the conditions (ie. no leading 0s except 0 itself and <= 255). 
Break conditions of backtrack is if the index exceeds string length or the level we're at exceeds 4. Satisfy condition if we reach the end of the string 
and we've met the 4 levels of the ip.

Space: O(1), no extra space used 
Time: O(1), constant space, it really is O(3^4) since there are 4 levels and 3 digits per level to check
*/