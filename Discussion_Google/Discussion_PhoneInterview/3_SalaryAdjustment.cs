/**
https://leetcode.com/discuss/interview-question/351313/Google-or-Phone-Screen-or-Salary-Adjustment

Give an array of salaries. The total salary has a budget. At the beginning, the total salary of employees is larger than the budget. It is required to find the number k, and reduce all the salaries larger than k to k, such that the total salary is exactly equal to the budget.

Example 1:

Input: salaries = [100, 300, 200, 400], budget = 800
Output: 250
Explanation: k should be 250, so the total salary after the reduction 100 + 250 + 200 + 250 is exactly equal to 800.

You can assume that solution always exists.
*/

public class Solution {
    public double AdjustSalary(int[] salaries, int budget) {
        Array.Sort(salaries);

        int sum = 0;
        foreach (int s in salaries) sum += s;

        if (sum == budget) return salaries[salaries.Count - 1];

        for (int i = salaries.Count - 1; i >= 1; i--) {
            sum -= salaries[i];
            double k = (budget - sum) / (1.0 * (salaries.Count - i));
            if (i - 1 >= 0 && k >= salaries[i - 1] && k < salaries[i]) return k;
            else if (i == 0 && k <= salaries[i]) return k;
        }
        return -1.0;
    }
}