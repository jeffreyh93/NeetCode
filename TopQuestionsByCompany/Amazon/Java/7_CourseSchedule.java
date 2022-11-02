/**
https://leetcode.com/problems/course-schedule/

There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.

For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
Return true if you can finish all courses. Otherwise, return false.
*/

class Solution {
    public class Course {
        public int inDeg = 0;
        public ArrayList<Integer> outNodes = new ArrayList<Integer>();
    }
    public boolean canFinish(int numCourses, int[][] prerequisites) {
        if (prerequisites.length == 0) return true;
        HashMap<Integer, Course> map = new HashMap<Integer, Course>();
        for (int[] p : prerequisites) {
            Course preCourse = createCourse(p[0], map);
            Course postCourse = createCourse(p[1], map);

            preCourse.outNodes.add(p[1]);
            postCourse.inDeg++;
        }

        Queue<Course> track = new LinkedList<Course>();
        for (Map.Entry<Integer, Course> mapElement : map.entrySet()) {
            if (mapElement.getValue().inDeg == 0) {
                track.add(mapElement.getValue());
            }
        }

        int removedEdges = 0;
        while (track.size() > 0) {
            Course curr = track.remove();
            for (int out : curr.outNodes) {
                Course toTake = createCourse(out, map);
                removedEdges++;
                toTake.inDeg--;
                if (toTake.inDeg == 0) {
                    track.add(toTake);
                }
            }
        }
        return prerequisites.length == removedEdges;
    }
    public Course createCourse(int course, HashMap<Integer, Course> map) {
        if (!map.containsKey(course)) map.put(course, new Course());
        return map.get(course);
    }
}