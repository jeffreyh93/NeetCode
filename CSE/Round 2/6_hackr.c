// https://hackr.io/blog/c-interview-questions

/**
How are global variables different from static variables?
- global variables are accessible by all functions unless hidden, defined outside function / block
- static variables have their values persist through entire program. Can be defined inside or outside of function / block
*/

/**
Explain static memory allocation and dynamic memory allocation
- static memory occurs during compile time and the amount of memory allocated is fixed
- dynamic memory occurs during run time and the size of the allocated memory can change
*/

/**
What are memory leaks? Why should it be addressed?
- memory leaks occur when memory is not freed after the memory location is no longer needed
- can lead to additional memory usage by the program
*/

/**
What is keyword volatile used for?
- tells the compiler not to optimize the variable
- the code can change the value of the variable from outside the scope at any time
- tells the compiler to read the value at the memory address
*/

/**
What is keyword extern used for?
- extern is used for variables that are defined in another file
- can then use the variable in the file
*/

/**
What are cmd line arguments?
- arguments that are passed to the program when running it
- the program can parse through the arguments
- argv[0] refers to the name of the program while argv[1], ... argv[argc - 1] are the arguments passed in
*/

int main(int argc, char* argv[]) {
    for (int i = 1; i < argc; i++) {} 
}

/**
What is a dangling pointer?
- a dangling pointer is one where it refers to a memory location that has been freed but is still used
*/

int *p = (int *)malloc(5 * sizeof(int));
free(p);

// p is a dangling pointer

/**
How is a null pointer different from void pointer?
- a null pointer is one that points to the null address, ie. address 0
- a void pointer means the value pointed to can be anything
*/

/**
What are calloc and malloc?
- both are used to dynamically allocate memory
- calloc initializes the elements to value 0 while malloc assigns them random numbers
*/

int *m = (int *)malloc(5 * sizeof(int));
int *c = (int *)calloc(5, sizeof(int));

/**
Call by value vs call by reference?
- in by value, the function receives a copy of the values passed in. Any changes made to these arguments inside the function are not reflected when function returns
- in by reference, this is achieved using address and pointer operators. Can change the values from within the function
*/

void swap_by_reference(int *a, int *b) {
    int tmp = *a;
    *a = *b;
    *b = tmp;
}
int main() {
    int x = 1, y = 2;
    swap_by_reference(&x, &y);
}

/**
What is keyword register for?
- register keyword is used to optimize the retrieval of the variable. The value is stored in register rather than RAM
- cannot use memory location for register variables
*/

/**
What is difference between lvalue and rvalue?
*/

/**
How are actual parameters different from formal parameters?
- actual parameters refer to the values passed into the functions while formal parameters are those from the function signature
*/

/**
What are bit fields?
- can be used to define how many bits a member variable uses 
- if a member's range is from 0-7 we can define it to use 3 bits
*/

struct {
    int flag : 1;
};

/**
What are various file opening modes?
- r opens a file for reading if exists
- w writes to text file, or creates one if it doesn't exist
- a appends to text file, or creates one if it doesn't exist
- can add + to any of the above to enable reading and write/append
- can add b to any of the above to enable binary mode
*/

/**
Write a program to check for prime numbers
*/

int is_prime(int n) {
    for (int i = 2; i <= n / 2; i++) {
        if (n % i == 0) return 0;
    }
    return 1;
}

/**
Write a program to find a number's factorial using recursion
factorial = n * (n-1) * (n-2) * ... * 2 * 1
*/

int compute_factorial_rec(int n) {
    if (n <= 1) return 1;
    return n * compute_factorial_rec(n - 1);
}

/**
Write a program to find a number's factorial without using recursion
*/

int compute_factorial_iter(int n) {
    if (n <= 1) return 1;
    int ret = 1;
    for (int i = 1; i <= n; i++) {
        ret *= i;
    }
    return ret;
}

/**
What is the auto keyword?
- auto keyword defines that a variable only exists within the current scope
- once scope leaves, the value is destroyed
- default scope
*/

/**
What is the sprintf function
- stores the string into the variable
- returns the number of chars stored
*/

/**
Difference between getch and getche?
- both get a character from console, getche prints those back to the console
*/

/**
What is typecasting?
- process of converting one data type to another
- can be implicit, ie. int d = 'a';
    - integer type d stores the character a, which is converted to decimal implicitly
    - upcasting occurs implicitly when we convert a smaller data type to a larger
- or explicit, ie. char c = (char) 260;
    - char type c stores the value 260, converted to char explicitly
        - binary: (256   128 64 32 16  8 4 2 1)
        - 260 = 1 0000 0100
        - (char) 260 = 0000 0100 = 4
        - printf("%d", c) gives 4
    - downcasting occurs explicitly when we convert from a larger data type to smaller
*/

/**
Write a program to check whether entered number is palindrome, use bounds checking and allow negative numbers
*/
#include <limits.h>

int is_palindrome(int n) {
    int rev = 0, tmp = n, is_neg = n < 0;
    if (is_neg) n *= -1;

    while (n) {
        int rem = n % 10;
        if (!is_neg && (rev > INT_MAX / 10 || (rev == INT_MAX / 10 && rem > INT_MAX % 10))) return 0;
        else if (is_neg && (-rev < INT_MIN / 10 || (-rev == INT_MIN && rem > INT_MIN % 10))) return 0;

        rev = rev * 10 + rem;
    }
    
    rev = is_neg ? -rev : rev;
    return rev == tmp;
}