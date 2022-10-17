/**
https://leetcode.com/explore/interview/card/google/67/sql-2/3044/

Every valid email consists of a local name and a domain name, separated by the '@' sign. Besides lowercase letters, the email may contain one or more '.' or '+'.

For example, in "alice@leetcode.com", "alice" is the local name, and "leetcode.com" is the domain name.
If you add periods '.' between some characters in the local name part of an email address, mail sent there will be forwarded to the same address without dots in the local name. Note that this rule does not apply to domain names.

For example, "alice.z@leetcode.com" and "alicez@leetcode.com" forward to the same email address.
If you add a plus '+' in the local name, everything after the first plus sign will be ignored. This allows certain emails to be filtered. Note that this rule does not apply to domain names.

For example, "m.y+name@email.com" will be forwarded to "my@email.com".
It is possible to use both of these rules at the same time.

Given an array of strings emails where we send one email to each emails[i], return the number of different addresses that actually receive mails.
*/

public class Solution {
    public int NumUniqueEmails(string[] emails) {
        HashSet<string> track = new HashSet<string>();

        for (int i = 0; i < emails.Length; i++) {
            string filtered = FilterEmail(emails[i]);
            if (!track.Contains(filtered)) track.Add(filtered);
        }

        return track.Count;
    }
    public string FilterEmail(string email) {
        StringBuilder ret = new StringBuilder();

        bool atFound = false;
        for (int i = 0; i < email.Length; i++) {
            if (email[i] == '.' && !atFound) continue;
            else if (email[i] == '+' && !atFound) {
                while (i < email.Length && email[i] != '@') i++;
                atFound = true;
                ret.Append(email[i]);
            }
            else {
                if (email[i] == '@') atFound = true;
                ret.Append(email[i]);
            } 
        }

        return ret.ToString();
    }
}

/**
Algorithm: strings
loop through each email and filter each one, store each filtered in a hashset. While filtering, ignore the '.' character if before '@', if the '+' character then ignore all chars until '@'. After the '@' character just ignore all chars until the end of the string

Space: O(N * M), all N emails are iterated through and there are M average chars per email stored in the hashset
Time: O(N * M), all N emails are iterated through and all M characters are visited
*/