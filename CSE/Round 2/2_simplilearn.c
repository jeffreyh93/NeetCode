// https://www.simplilearn.com/tutorials/c-tutorial/c-programming-interview-questions#advanced_c_programming_interview_questions
/**
What is calloc?
- used to dynamically allocate memory and set those values to 0
- gives number of elements and each element's size
*/

int *p = (int *)calloc(n, sizeof(int));
// dynamically allocates an array of size n, each element is an int type, and sets them all to 0

/**
What is the outout of the following code snippet?
*/

#include <stdio.h>
void local_static() {
    static int a;
    printf("%d ", a);
    a = a + 1;
}
int main() {
    local_static();
    local_static();
    return 0;
}

// static int a is initialized to 0, output is 0 1

/**
What is the output of the following code snippet?
*/

void display(unsigned int n) {
    if (n > 0) {
        display(n - 1);
        printf("%d ", n);
    }
}

// prints the numbers from 1 to n

/**
What is meant by call by reference vs call by value?
- call by reference means the address of the variable is passed into the function. by dereferencing the argument, we are able to change that memory locations' value and that will be reflected when function leaves scope
- call by value means the function receives a copy of the passed in arguments. Any changes to the arguments won't be reflected outside of the function's scope
*/

/**
What is the prototype of a function?
- contains the function's return type or void if none, name of the function, and defines the function's formal parameters to be passed in
*/

int fun(int a, int b);

// int is the return type, fun is the function name, a and b are the function's formal parameters

/**
What are volatile objects?
- volatile indicates that there should not be any optimization done when accessing the variable
- each time the variable's value is needed, it instructs the compiler to retrieve from the memory address
*/

/**
Write the equivalent FOR LOOP
*/

int a = 0;
while (a <= 10) {
    printf("%d\n", a * a);
    a++;
}

for (int a = 0; a <= 10; a++) {
    printf("%d\n", a * a);
}

/**
What is the output of the following program?
*/

#include <stdio.h>
int main(void) {
    int arr[] = {20, 40};
    int *a = arr;
    *a++;
    printf("arr[0] = %d, arr[1] = %d, *a = %d", arr[0], arr[1], *a);
}

// postfix has higher precedence than dereference operator and is LTR, *a++ same as *(a++)
// a++ = address at 40
// *(a++) = value 40, but nothing done to it
// prints; arr[0] = 20, arr[1] = 40, *a = 40

/**
How to free a block of memory that has been allocated previously?
- use free(void *ptr) to free the pointer's memory
*/

int *p = (int *)malloc(5 * sizeof(int));
... // do something with p
free(p);

int *p = (int *)realloc(p, 0); // can also use realloc

/**
Write a function pointer named fun that takes a single char pointer argument and returns a character
*/

(char) (*fun)(char*);

/**
What is the ouput of the following code?
*/

#include <stdio.h>
main() {
    char *a = "abc";
    a[2] = 'd';
    printf("%c", *a);
}

// compiler error since we are trying to change the contents of a string literal

/**
Explain struct vs union
- both are used to group together members that can have different data types, difference is with the size of each unit. 
- With a struct the total size is the sum of its members with some additional padding 
- With a union, all members share the same memory location
    -> changes to the value of one of its members will change that location directly so if we reference another member, that member's value will have changed
    -> good practice to only reference one member at a time
*/