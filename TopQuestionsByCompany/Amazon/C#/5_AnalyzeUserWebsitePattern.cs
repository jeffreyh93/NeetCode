/**
https://leetcode.com/problems/analyze-user-website-visit-pattern/

You are given two string arrays username and website and an integer array timestamp. All the given arrays are of the same length and the tuple [username[i], website[i], timestamp[i]] indicates that the user username[i] visited the website website[i] at time timestamp[i].

A pattern is a list of three websites (not necessarily distinct).

For example, ["home", "away", "love"], ["leetcode", "love", "leetcode"], and ["luffy", "luffy", "luffy"] are all patterns.
The score of a pattern is the number of users that visited all the websites in the pattern in the same order they appeared in the pattern.

For example, if the pattern is ["home", "away", "love"], the score is the number of users x such that x visited "home" then visited "away" and visited "love" after that.
Similarly, if the pattern is ["leetcode", "love", "leetcode"], the score is the number of users x such that x visited "leetcode" then visited "love" and visited "leetcode" one more time after that.
Also, if the pattern is ["luffy", "luffy", "luffy"], the score is the number of users x such that x visited "luffy" three different times at different timestamps.
Return the pattern with the largest score. If there is more than one pattern with the same largest score, return the lexicographically smallest such pattern.
*/

public class Solution {
    public class Visit : IComparable<Visit> {
        public int timestamp;
        public string website;
        public Visit(int timestamp, string website) {
            this.timestamp = timestamp;
            this.website = website;
        }
        public int CompareTo(Visit v) {
            return this.timestamp - v.timestamp;
        }
    }

    public class Score {
        public string web1;
        public string web2;
        public string web3;
        
        public Score(string web1, string web2, string web3) {
            this.web1 = web1;
            this.web2 = web2;
            this.web3 = web3;
        }

        public override bool Equals(Object o) {
            Score s = (Score) o;
            return this.web1.Equals(s.web1) && this.web2.Equals(s.web2) && this.web3.Equals(s.web3);
        }

        public override int GetHashCode() {
            return web1.GetHashCode() + web2.GetHashCode() + web3.GetHashCode();
        }
        public override string ToString() {
            return web1 + ", " + web2 + ", " + web3;
        }
        public List<string> ConvToList() {
            return new List<string> {web1, web2, web3};
        }
        public int CompareTo(Object o) {
            Score s = (Score) o;
            if (!this.web1.Equals(s.web1)) return this.web1.CompareTo(s.web1);
            else if (!this.web2.Equals(s.web2)) return this.web2.CompareTo(s.web2);
            else return this.web3.CompareTo(s.web3);
        }
    }

    public IList<string> MostVisitedPattern(string[] username, int[] timestamp, string[] website) {
        Dictionary<string, List<Visit>> userVisits = new Dictionary<string, List<Visit>>();
        // have a dictionary of users and a list of their visits
        for (int i = 0; i < username.Length; i++) {
            if (!userVisits.ContainsKey(username[i])) 
                userVisits.Add(username[i], new List<Visit>());
            
            userVisits[username[i]].Add(new Visit(timestamp[i], website[i]));
        }
        List<HashSet<Score>> userScores = new List<HashSet<Score>>();
        foreach (var kvp in userVisits) {
            // sort the users' visits by their time stamp using the defined CompareTo function
            List<Visit> currUserVisit = kvp.Value;
            currUserVisit.Sort();
            
            // create a new hashset of scores for this user
            HashSet<Score> currUserScore = new HashSet<Score>();
            userScores.Add(currUserScore);

            // go through every triplet in the visit and add that score to this user's hashset
            for (int i = 0; i < currUserVisit.Count - 2; i++) {
                for (int j = i + 1; j < currUserVisit.Count - 1; j++) {
                    for (int k = j + 1; k < currUserVisit.Count; k++) {
                        Score score = new Score(currUserVisit[i].website, currUserVisit[j].website, currUserVisit[k].website);
                        if (!currUserScore.Contains(score)) {
                            currUserScore.Add(score);
                        }
                    }
                }
            }
        }

        Dictionary<Score, int> counts = new Dictionary<Score, int>();
        foreach (HashSet<Score> h in userScores) {
            foreach (Score s in h) {
                if (!counts.ContainsKey(s)) counts.Add(s, 1);
                else counts[s]++;
            }
        }
        Score maxScore = null;
        int maxCount = 0;
        foreach (var kvp in counts) {
            if (kvp.Value > maxCount) {
                maxScore = kvp.Key;
                maxCount = kvp.Value;
            } else if (kvp.Value == maxCount) {
                maxScore = kvp.Key.CompareTo(maxScore) > 0 ? maxScore : kvp.Key;
            }
        }
        
        return maxScore.ConvToList();
    }
}