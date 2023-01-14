// https://www.naukri.com/learning/articles/c-programming-interview-questions-answers/

/**
Name and describe the 4 different storage classes
- auto = default storage class for local variables, freed once it leaves scope
    - can only be defined within a function or block
    - variables are implicitly auto
- extern = refers to a variable that is defined in another file
    - no memory allocated if only declared
    - functions are implicitly extern
- register = variable that requires quick and constant access
    - instructs compiler to store the value in the register rather than RAM
    - does not have a memory address
- static = variable that has its value persist through the program
    - only initialized once, function calls will have its updated value
    - static functions are restricted to the file that it is defined in
*/

/**
What is scope and lifetime of a variable
- scope in which we can refer to the variable, once it leaves the scope the variable is freed from memory
- can be function or block
*/

/**
What is null pointer?
- pointer that points to NULL, ie. 0 memory address
- indicates that the pointer does not point to anything
*/

/**
What is dangling pointer?
- pointer that refers to a location in memory but that address is then freed
- any reference to that ptr after free is called dangling
*/

/**
What is the difference between local, global, extern, and static variables?
- with local variables, their scope is within the function or block it is defined in
- with global variables, they are defined outside of any function and any function can access these variables
- with extern variables, they are defined in another file, indicates that this variable's value should be read from another file
- with static variables, their value persists through multiple function calls and only initialized once
*/

/**
What is static memory allocation?
- fixed size memory allocation, can't allocate more or less memory
int c[10];
*/

/**
What is dynamic memory allocation?
- able to variably allocate memory, use malloc, calloc, realloc, and free to manage the dynamic memory
*/

/**
Difference between calloc() and malloc()?
- both allocate n * size memory 
- with calloc, these memory locations are set to 0 while malloc leaves them unitialized
int *a = malloc(n * sizeof(int));
int *b = calloc(n, sizeof(int));
*/

/**
What is the output of the following C code?
*/

#include <stdlib.h>
#include <stdio.h>

enum {false, true};

int main() {
    int i = 1;
    do {
        printf("%d\n", i);
        i++;
        if (i < 15) continue;
    } while (false)
    getchar();
    return 0;
}

// 1
// first the value of i gets printed, then incremented
// next i < 15 so we continue through the loop and the while expression gets evaluated
// since false = 0, the loop is exited

/**
How is a negative integer stored in C?
- using 2's complement, idea is to flip the bits and add 1. the MSB is reserved to indicate whether it is positive (0) or negative (1)
- ie. -1:
1 = 0000 0001
2's: 1111 1110
+1 : 1111 1111 <- this is -1
*/

/**
Show an example of a nested structure
*/

struct Name {
    char fName[10];
    char lName[10];
};

struct Student {
    struct Name name;
    int id;
}

/**
Write a program to swap two numbers passed by reference without using a third variable
*/

void swap(int *a, int *b) {     // input: 1, 2
    *a = *a + *b;               // *a = (1) + (2) = 3
    *b = *a - *b;               // *b = (3) - (2) = 1
    *a = *a - *b;               // *a = (3) - (1) = 2
}

/**
Write a program to find fibonacci sequence
0, 1, 1, 2, 3, 5, ....
*/

int fib_r(int n) {
    if (n <= 1) return n;
    return fib_r(n-2) + fib_r(n-1);
}

int fib_i(int n) {
    if (n <= 1) return n;
    int curr = 1, prev = 0, count = 1, sum = 0;
    while (count <= n) {
        prev = curr;
        curr = sum;
        sum = sum + prev;
        count++;
    }
    return sum;
}

/**
Difference between rvalue and lvalue
- lvalue refers to an object that contains a memory location, can appear on either left or right side of the assignment operator
- rvalue does not have a memory location, only can appear on right side
*/

int a = 10; // a = lvalue, 10 = rvalue
int a = b; // a = lvalue, b = lvalue
10 = a; // invalid, rvalue appears on the left side of operator

/**
Find the factorial of a number
n * (n-1) * (n-2) * ... (2)
*/

int fact_r(int n) {
    if (n <= 1) return n;
    return n * fact_r(n - 1);
}

int fact_i(int n) {
    if (n < 1) return n;
    int ret = 1;
    while (n > 0) {
        ret = ret * n--;
    }
    return ret;
}

/**
Write a program to find the sum of the first N natural numbers
*/

int naturalSum(int n) {
    int ret = 0;
    for (int i = 1; i <= n; i++) {
        ret += i;
    }
    return ret;
}

/**
What is typecasting?
- when converting a data type to another, can occur in narrowing and widening
- narrowing = larger data type to smaller
    - ex. char c = (char) 260;
- widening = smaller data type to larger
    - ex. int i = 'c';
*/

/**
How are random numbers generated? Give an example
- makes use of stdlib.h
*/

int rng = rand() % range + min;

// generates a random number from [min, min + range)

/**
Write a program to reverse a number
*/
#include <limits.h>

int rev_number(int n) {
    int rev = 0;
    while (n) {
        int rem = n % 10;
        if (rev > INT_MAX / 10 || (rev == INT_MAX / 10 && rem > INT_MAX % 10)) return -1;
        rev = rev * 10 + rem;
        n /= 10;
    }
    return rev;
}

/**
Write a program to check prime number
*/

int is_prime(int n) {
    if (n <= 2) return 1;
    for (int i = 2; i <= n / 2; i++) {
        if (n % i == 0) return 0;
    }
    return 1;
}

/**
Write a program to check armstrong number
*/

int is_armstrong(int n) {
    int tmp = 0, check = n;
    while (n) {
        int rem = n % 10;
        tmp = tmp + rem * rem * rem;
        n /= 10;
    }
    return tmp == check;
}

/**
Write a program to check palindrome number
*/

int is_palindrome(int n) {
    int rev = 0;
    int tmp = n;
    while (n) {
        int rem = n % 10;
        if (rev > INT_MAX / 10 || (rev == INT_MAX / 10 && rem > INT_MAX % 10)) return -1;
        rev = rev * 10 + rem;
        n /= 10;
    }
    return rev == tmp;
}

/**
Difference between stack and union?
- both are used to group multiple data members under one unit
- the size of a structure is equal to the total size of its members + padding and alignment
- the size of a union is equal to its largest member, all members share the same memory location
*/

/**
What is memory leak in C?
- when memory is dynamically allocated in the heap but never freed
*/

/**
Difference between null and void pointer
- with a null ptr, it indicates that the ptr does not point to any location in memory
- with a void ptr, this is general ptr, means the address it points to can be of any data type
*/

/**
What is call by value and call by reference?
- call by value = function receives the value from the variable
- call by reference = function receives the variable's memory address and can alter the variable's value from within the function
    - makes use of address and pointer operators
*/

/**
Difference between const char* p and char const* p
- const char* p: p is a pointer to a constant character
- char const* p: p is a constant pointer to a character

- the first one, can't change the value pointed to by p but we can change what p points to
- with second, can change the value at the pointer but can't change the address it points to
*/

/**
How to compare strings in C?

int strcmp(const char* s1, const char* s2);
- use strcmp to compare strings, returns 0 if they're equal, -ve if s1 comes before s2 and +ve if s2 comes after
*/

/**
Use of toupper() in C?

- used to convert a character to its upper case form
*/

int toupper(int c);

/**
Explain and implement bubble sort
- with bubble sort, elements are compared to its next index and if curr > next then they are swapped
- each iteration, the last section of the array is sorted
*/
void swap(int *a, int *b) {
    int tmp = *a;
    *a = *b;
    *b = tmp;
}

void bubble_sort(int arr[], size_t n) {
    int i, j;
    for (i = 0; i < n - 1; i++) 
        for (int j = 0; j < n - i - 1; j++)         
            if (arr[j] > arr[j + 1]) 
                swap(&arr[j], &arr[j + 1]);
}

/**
Explain and implement insertion sort
- with insertion sort, the first section of the array is sorted
- the key (current element) is placed in the correct spot of the sorted array section
*/
void insertion_sort(int arr[], size_t n) {
    int i, j, key;
    for (i = 1; i < n; i++) {
        key = arr[i];
        j = i - 1;
        while (j >= 0 && arr[j] > key) {
            arr[j + 1] = arr[j];
            j--;
        }
        arr[j + 1] = key;
    }
}

/**
Explain and implement binary search
- given a sorted array, able to search for an element in the array by continuously dividing the array in half with the mid point as a pivot
- if key = mid then we found it
- if key > mid then set the left bound to be mid + 1
- if key < mid then set the right bound to be mid - 1
*/

size_t binary_search(int arr[], size_t n, int key) {
    size_t left = 0, right = n - 1;
    while (left <= right) {
        size_t mid = left + (right - left) / 2;

        if (arr[mid] == key) return mid;
        else if (arr[mid] > key) left = mid + 1;
        else right = mid - 1;
    }
    return -1;
}

size_t binary_search_rec(int arr[], size_t n, int key) {
    return helper(arr, 0, n - 1, key);
}

size_t helper(int arr[], size_t left, size_t right, int key) {
    if (left > right) return -1;

    size_t mid = left + (right - left) / 2;

    if (arr[mid] == key) return mid;
    else if (arr[mid] > key) return helper(arr, mid + 1, right, key);
    else return helper(arr, left, mid - 1, key);
}