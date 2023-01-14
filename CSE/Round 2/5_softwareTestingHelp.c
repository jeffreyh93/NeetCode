// https://www.softwaretestinghelp.com/c-programming-interview-questions/

/**
What is a dangling pointer?
- A pointer that references a memory location that has been freed
- Any reference to that pointer after is known as dangling
*/

/**
What is static function, static variable?
- Static functions can only be used in the file in which it is defined
- Static variables have their values persist through function calls. Only initialized once
*/

/**
Difference between ++a and a++?
- ++a is a prefix increment. The value is increased then used
- a++ is a postfix increment. The value is used then increased

postfix has higher precedence than * dereference and ++ prefix operator. Postfix reads LTR while the other two read RTL
*/

/**
What is the correct code for the following output using nested loops?

1
12
123
1234
12345
*/

void printShape(int n) {
    for (int i = 0; i < n; i++) {
        for (int j = 0; j <= i; j++) {
            printf("%d", j + 1);
        }
        printf("\n");
    }
}

/**
Process to generate random numbers in C?
*/

#include <stdlib.h>
int randint(int n, int min) {
    return min + rand() % n;
}

// above generates a random number between min and n - 1 (inclusive)