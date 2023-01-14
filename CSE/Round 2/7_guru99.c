// https://www.guru99.com/c-programming-interview-questions.html

/**
Call by value vs call by reference?
- with call by value, the function receives a copy of the argument passed
    - any changes to the argument is not reflected once function leaves scope
- with call by reference, it is simulated using address and pointer operators
    - the function works with the argument's memory address then any changes to the address when function leaves is reflected
*/

/**
What is a stack?
*/

/**
What is a heap?
*/

/**
What is variable initialization and why is it important?
- variable initialization is when we give a variable a value before using it
- this is so that we ensure that a variable has an expected value to prevent unexpected outcomes
*/

/**
Write a nested loop that will print the following:

54321
5432
543
54
5
*/

void print_shape(int n) {
    for (int i = n; i >= 1; i--) {
        for (int j = n; j >= n - i + 1; j--) {
            printf("%d", j);
        }
        printf("\n");
    }
}

/**
What is wrong in the following statement?
*/

int x;
scanf("%d", x);

// scanf needs the address of the variable so that it can assign the value read

/**
How to generate random numbers?
- use stdlib.h library, then rand() % range + min gives a random number from min to min + range - 1 inclusive
*/

#include <stdlib.h>
int main() {
    int a = rand() % 5 + 5; // gives a random value from 5 to 9
}

/**
What does the format %10.2 mean when included in a printf?
- provides a formatted output where the alloted width = 10 and the number of decimals allowed is up to 2
- if the value is less than 10 spaces, there is a padding done before the number
*/

/**
What is wrong with the following statement?
*/

char myName[10];
myName = "Jeff";

// can't assign string literal to an array, use strcpy to fix this

strcpy(myName, "Jeff");

// strcpy also appends the string literal with a null char

/**
How to determine length of string in a variable?
- can use strlen to determine the length of the string up to but not including the null char
*/