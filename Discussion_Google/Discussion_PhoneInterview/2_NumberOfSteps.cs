/**
https://leetcode.com/discuss/interview-question/416381/Google-Phone-Interview-Question-DP

You start at index 0 in an array with length 'h'. At each step, you can move to the left, move to the right, or stay in the same place(Note! Stay in the same place also takes one step). How many possible ways are you still at index 0 after you have walked 'n' step?

Example： n = 3
1. right->left->stay
2. right->stay->left
3. stay->right->left
4. stay->stay->stay

Can anyone solve it in n^2
*/
public class Solution {
    // iterative
    int NumSteps(int numSteps, int height) {
        return Helper(0, 0, numSteps, height);
    }
    int Helper(int pos, int idx, int num, int height) {
        if (idx == num && pos == 0) return 1;
        if (idx == num) return 0;
        if (pos >= height || pos < 0) return 0;

        int ret = 0;

        ret += Helper(pos, idx + 1, num, height);
        ret += Helper(pos + 1, idx + 1, num, height);
        ret += Helper(pos - 1, idx + 1, num, height);

        return ret;
    }

    // using Cache - look into this
}

