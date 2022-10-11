/**
https://leetcode.com/problems/merge-intervals/

Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, and return an array of the non-overlapping intervals that cover all the intervals in the input.
*/

public class Solution {
    public class Interval : IComparable {
        public int start, end;
        public Interval(int start, int end) {
            this.start = start;
            this.end = end;
        }
        public int CompareTo(Object o) {
            return start - ((Interval) o).start;
        }
    }
    public int[][] Merge(int[][] intervals) {
        if (intervals.Length == 0) return null;

        List<Interval> track = new List<Interval>();
        foreach (int[] i in intervals) {
            track.Add(new Interval(i[0], i[1]));
        }
        track.Sort();

        int currStart = track[0].start;
        int currEnd = track[0].end;

        List<int[]> ret = new List<int[]>();
        foreach (Interval i in track) {
            if (i.start > currEnd) {
                ret.Add(new int[2] {currStart, currEnd});
                currStart = i.start;
                currEnd = i.end;
            } else {
                currEnd = Math.Max(currEnd, i.end);
            }
        }
        ret.Add(new int[2] {currStart, currEnd});
        return ret.ToArray();
    }
}

/**
Algorithm: Arrays and Hashing
Sort the list of intervals then iterate through the list. For every iteration keep track of the maximum end value, while the start of this iteration is less than the 
maximum end so far, it is considered part of the same interval. Once we reach a start time that exceeds the maximum end, add the start and max end times to the list and update the currstart and end values.

Space: O(logn), keeps track of n sorted intervals in a list
Time: O(nlogn), one pass through the list of intervals, sorts the list of intervals
*/