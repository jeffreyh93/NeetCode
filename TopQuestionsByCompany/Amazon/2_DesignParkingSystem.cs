/**
https://leetcode.com/problems/design-parking-system/

Design a parking system for a parking lot. The parking lot has three kinds of parking spaces: big, medium, and small, with a fixed number of slots for each size.

Implement the ParkingSystem class:

    ParkingSystem(int big, int medium, int small) Initializes object of the ParkingSystem class. The number of slots for each parking space are given as part of the constructor.
    bool addCar(int carType) Checks whether there is a parking space of carType for the car that wants to get into the parking lot. carType can be of three kinds: big, medium, or small, which are represented by 1, 2, and 3 respectively. A car can only park in a parking space of its carType. If there is no space available, return false, else park the car in that size space and return true.

*/

public class ParkingSystem {

    int[] track;
    public ParkingSystem(int big, int medium, int small) {
        track = new int[3] {big, medium, small};
    }
    
    public bool AddCar(int carType) {
        if (track[carType - 1] == 0) return false;
        else {
            track[carType - 1]--;
            return true;
        }
    }
}

/**
 * Your ParkingSystem object will be instantiated and called as such:
 * ParkingSystem obj = new ParkingSystem(big, medium, small);
 * bool param_1 = obj.AddCar(carType);
 */

/**
Algorithm: Initialize an array with each quantity stored in its own index. For every car added, decrement that matching index then return false if we can't dec

Space: O(1), constant array space used
Time: O(1), access the index takes linear time
 */