/**
 * 7. What is the use of printf() and scanf() functions?
 * - printf is used to print to the stream while scanf is used to read from the stream and assign to variable
*/

/**
 * 8. What is the difference between the local and global variable in C?
 * - global variables can be accessed from any function in the program
 * - local variables only exist within the function or block scope
*/

/**
 * 9. What is the use of a static variable in C?
 * - their values persist through function calls, only initialized once
*/

/**
 * 11. What is the difference between call by value and call by reference in C?
 * - by value, the function receives a copy of the arguments value. any changes to the values inside the function are not reflected outside
 * - by reference, the function receives a memory address from which it can dereference and alter the value at that location directly. When function exits any changes to the memory location are reflected outside
*/

/**
 * 13. What is an array in C?
 * - sequential collection of data that share the same data type
*/

/**
 * 14. What is a pointer in C?
 * - referes to a memory location that stores a value. Can pass pointers to functions as 'call by reference' 
*/

/**
 * 15. What is the use of a pointer in C?
 * - able to simulate pass by reference, references  location in memory and any function can work with the memory location to change the value directly
*/

/**
 * 16. What is a NULL pointer in C?
 * - refers to memory address 0, means the pointer does not point to anything
*/

/**
 * 18. What is a dangling pointer in C?
 * - when we reference a memory location then we free that memory location, the ptr is known as dangling 
*/

int* ptr = malloc(5 * sizeof(int));
free(ptr);

ptr[0] = 0; // ptr is a dangling pointer

/**
 * 19. What is a pointer to pointer in C?
 * - pointer that points to another pointer's memory address, useful when we want to swap pointers inside a function
 * - can also be used to define multi dimensional arrays
*/

/**
 * 20. What is static memory allocation?
 * - memory is allocated during compile time and its size can't be changed through duration of the program
 * - implemented using stacks / heap
*/

/**
 * 21. What is dynamic memory allocation?
 * - malloc() or calloc() is used to dynamically allocated bytes of memory
*/

/**
 * 22. What functions are used for dynamic memory allocation in C?
 * - malloc(), calloc(), realloc(), free()
*/

/**
 * 23. What is the difference between malloc() and calloc()?
 * - they both allocate bytes of memory
 * - malloc leaves these indeces uninitialized while calloc initializes them to 0
*/

/**
 * 24. What is the structure?
 * - a structure is a collection of different data types under one unit
 * - size of the struct is the total size of its members with padding consideration
*/

/**
 * 25. What is a union?
 * - same as structure in that it is used to group members of different data types
 * - all members share the same memory location, its size = size of largest member
 * - that means if we change any member's value, all of its members will have their values changed
 *      - general practice is to access them one at a time
*/

/**
 * 26. What is an auto keyword in C?
 * - used to define local scope of a variable
 * - it is the default when a variable is defined within a function
 * - if no value initialized then it contains a garbage value
*/

/**
 * 27. What is the purpose of sprintf() function?
 * - assigns the contents to a string, returns total number of chars in the string
*/

/**
 * 28. Can we compile a program without main() function?
*/

#include <stdio.h>
#define abc main

int abc() {...}

/**
 * 30. What is command line argument?
 * - arguments passed into the main function
 * - can parse through the arguments starting from argv[1] up to argc - 1, argv[0] reserved for the name of the function
*/

int main(int argc, char* argv[]) {
    for (int i = 1; i < argc; i++) {
        printf("cmd line argument %d = %s\n", i, argv[i]);
    }
}

/**
 * 31. What is the difference between getch() and getche()?
 * - both receive char input from the user, getch does not use buffer so it does assignment. getche prints to the screen
*/

/**
 * 41. Write a program to print "hello world" without using semicolon
*/

int main() {
    if (printf("hello world"))
}

/**
 * 42. Write a program to swap two numbers without using the third variable
*/

void swap(int *a, int *b) {
    *a = *a + *b;
    *b = *a - *b;
    *a = *a - *b;
}

/**
 * 43. Write a program to calculate fibonacci sequence without using recursion
*/

// 0, 1, 1, 2, 3, 5, ..
int fib(int n) {
    if (n == 0 || n == 1) return n;
    int prev = 0, count = 2, curr = 1, sum;
    while (count <= n) {
        sum = curr + prev;
        prev = curr;
        curr = sum;
        count++;
    }
    return sum;
}

/**
 * 44. Write a program to calculate fibonacci series using recursion
*/

// 0, 1, 1, 2, 3, 5, ..
int fib(int n) {
    if (n == 0 || n == 1) return n;
    return fib(n - 2) + fib(n - 1);
}

/**
 * 45. Write a program to check prime number in C?
*/

int is_prime(int n) {
    for (int i = 2; i <= n / 2; i++) {
        if (n % i == 0) return 0;
    }
    return 1;
}

/**
 * 46. Write a program to check palindrome number in C?
*/
#include <limits.h>

int is_palindrome(int n) {
    int tmp = n, rev = 0;
    while (n) {
        int rem = n % 10;
        // error checking here
        if (rev > INT_MAX / 10 || (rev == INT_MAX && rem > INT_MAX % 10)) return 0;
        rev = rev * 10 + rem;
        n /= 10;
    }
    return rev == tmp;
}

/**
 * 47. Write a program to print factorial of given number without using recursion
*/

int factorial_iter(int n) {
    if (n <= 1) return n;
    int ret = 1;
    while (n > 1) {
        ret *= n--;
    }
    return ret;
}

/**
 * 48. Write a program to print factorial of given number using recursion
*/

int factorial_rec(int n) {
    if (n <= 1) return n;
    return n * factorial_rec(n - 1);
}

/**
 * 49. Write a program to check Armstrong number in C?
*/

int is_armstrong(int n) {
    int tmp = n, arm = 0;
    while (n) {
        int rem = n % 10;
        arm += pow(rem, 3);
        n /= 10;
    }
    return arm == tmp;
}

/**
 * 50. Write a program to reverse a number in C
*/

int reverse_number(int n) {
    int rev = 0;
    while (n) {
        rev = rev * 10 + n % 10;
        n /= 10;
    }
    return rev;
}