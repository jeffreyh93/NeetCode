/**
https://leetcode.com/problems/reorder-data-in-log-files/

You are given an array of logs. Each log is a space-delimited string of words, where the first word is the identifier.

There are two types of logs:

Letter-logs: All words (except the identifier) consist of lowercase English letters.
Digit-logs: All words (except the identifier) consist of digits.
Reorder these logs so that:

The letter-logs come before all digit-logs.
The letter-logs are sorted lexicographically by their contents. If their contents are the same, then sort them lexicographically by their identifiers.
The digit-logs maintain their relative ordering.
Return the final order of the logs.
*/

public class Solution {
    public class Log : IComparable<Log> {
        public string identifier;
        public List<string> content;
        public int order;
        public bool isLetter;

        public Log(string identifier, List<string> content, int order, bool isLetter) {
            this.identifier = identifier;
            this.content = content;
            this.order = order;
            this.isLetter = isLetter;
        }

        public int CompareTo(Log l) {
            if (!this.isLetter && !l.isLetter) {
                return this.order - l.order;
            } else if (this.isLetter && l.isLetter) {
                for (int i = 0; i < Math.Min(this.content.Count, l.content.Count); i++) {
                    if (!this.content[i].Equals(l.content[i])) {
                        return this.content[i].CompareTo(l.content[i]);
                    }
                }
                if (this.content.Count != l.content.Count) {
                    return this.content.Count < l.content.Count ? -1 : 1;
                } else {
                    return this.identifier.CompareTo(l.identifier);
                }
            } else {
                return this.isLetter ? -1 : 1;
            }
        }

        public override string ToString() {
            string ret = identifier;
            foreach (string s in content) {
                ret = ret + " " + s;
            }
            return ret;
        }
    }
    public string[] ReorderLogFiles(string[] logs) {
        List<Log> logObjList = new List<Log>();
        for (int i = 0; i < logs.Length; i++) {
            string[] splitStr = logs[i].Split(' ');
            string id = splitStr[0];
            bool isLetter = false;
            List<string> content = new List<string>();
            for (int j = 1; j < splitStr.Length; j++) {
                if (Char.IsLetter(splitStr[j][0])) isLetter = true;
                content.Add(splitStr[j]);
            }
            logObjList.Add(new Log(id, content, i, isLetter));
        }
        logObjList.Sort();

        List<string> ret = new List<string>();
        foreach (Log l in logObjList) {
            ret.Add(l.ToString());
        }
        return ret.ToArray();
    }
}