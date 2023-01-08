// https://www.geeksforgeeks.org/c-language-2-gq/

// C Input and Output - https://www.geeksforgeeks.org/c-language-2-gq/input-and-output-gq/

// 1. Predict the output of the following program
#include "stdio.h"
int main() {
    char arr[100];
    printf("%d", scanf("%s", arr));
    /*Suppose that input value given for above scanf is GeeksQuiz*/
    return 1;
}

/**
 * 1
 * scanf return value is the number of variable arguments successfully assigned a value
*/

// 3. Predict the output of the following program
#include <stdio.h>
int main() 
{ 
  printf(" \"GEEKS %% FOR %% GEEKS\""); 
  getchar(); 
  return 0; 
}

/**
 * "GEEKS % FOR % GEEKS"
 * \" prints the " character, and %% prints the % character for printf
*/

// 4. Predict the output of the following program
#include <stdio.h>
// Assume base address of "GeeksQuiz" to be 1000
int main()
{
   printf(5 + "GeeksQuiz");
   return 0;
}

/**
 * Quiz
 * prints the "GeeksQuiz" but starting address shifts to the right by 5
*/

// 5. Predict the output of the following program
#include <stdio.h>
int main()
{
    printf("%c ", 5["GeeksQuiz"]);
    return 0;
}

/**
 * Q
 * prints the singular character Q, acts the same as *(5 + "GeeksQuiz") which is the letter Q
*/

// 6. Predict the output of the following program
#include <stdio.h>
int main()
{
    printf("%c ", "GeeksQuiz"[5]);
    return 0;
}

/**
 * Q
 * same as question 5, acts the same as *("GeeksQuiz" + 5)
*/

// 8. Which of the following is true

// A: gets() can read a string with newline characters but a normal scanf() with %s can not.
// B: gets() can read a string with spaces but a normal scanf() with %s can not.
// C: gets() can always replace scanf() without any additional code.
// D: None of the above

/**
 * B
 * gets() can be used to read an input string with spaces, scanf can not handle spaces.
 * gets() reads until newline or EOF, while scanf reads until whitespace, newline, or EOF
*/

// 9. Which of the following is true

// A: gets() doesn't do any array bound testing and should not be used
// B: fgets() should be used in place of gets() only for files, otherwise gets() is fine
// C: gets() cannot read strings with spaces
// D: None of the above

// A
// does not do max limit testing, if want to handle spaces and assign an upper limit of chars to read then use fgets
#define MAX_LIMIT 20
int main() {
    char str[MAX_LIMIT];
    fgets(str, MAX_LIMIT, stdin);
}
// above code reads 20 chars from the stdin stream and assigns to str

// 10. What does the following C statement mean?
int main() {
    char str[20];
    scanf("%4s", str);
}

// A: Read exactly 4 characters from the console
// B: Read maximum 4 characters from console
// C: Read a string str in multiples of 4
// D: Nothing

// B
// reads a maximum of 4 characters from the console input

// 11. Predict the following output
#include<stdio.h>
int main()
{
    char *s = "Geeks Quiz";
    int n = 7;
    printf("%.*s", n, s);
    return 0;
}

// Geeks Q
// the .* means there is an additional argument that specifies character length

// 12. Predict the following output
#include <stdio.h>
int main(void) 
{
   int x = printf("GeeksQuiz");
   printf("%d", x);
   return 0;
}

// GeeksQuiz9
// prints GeeksQuiz in first statement, then 9 because printf returns the number of chars printed to the string and assigns to x

// 13. Predict the following output
#include<stdio.h>
int main()
{
    printf("%d", printf("%d", 1234));
    return 0;
}

// 12344
// executes the argument first, printf("%d", 1234) then prints the return value of that printf which is 4

// 14. What is the return type of getchar()?

// A: int
// B: char
// C: unsigned char
// D: float

// A
// needs to return an int to handle EOF return value for failure case

// 15. Normally user programs are prevented from handling I/O directly by I/O instructions in them. For CPUs having explicit I/O instructions, such I/O protection is ensured by having the I/O instructions privileged. In a CPU with memory mapped I/O, there is no explicit I/O instruction. Which one of the following is true for a CPU with memory mapped I/O?

// A: I/O protection is ensured by operating system routine(s)
// B: I/O protection is ensured by a hardware trap
// C: I/O protection is ensured during system configuration
// D: I/O protection is not possible

// A
// I/O is controlled by OS routines and performed in kernel mode

// 16. Which of the following functions from "stdio.h" can be used in place of printf()?

// A: fputs() with FILE stream as stdout
// B: fprintf() with FILE stream as stdout
// C: fwrite() with FILE stream as stdout
// D: all of the above
// E: in "stdio.h", there is no other equivalent

// B
// although A and C could write to the screen using stdout, it won't be string formatted like we would expect with printf
// fprintf(stdout, "%d", a) is equivalent to printf("%d", a)

// 17. Consider the following code. The function myStrcat concatenates two strings. It appends all characters of b to end of a. So the expected output is "Geeks Quiz". The program compiles fine but produces segmentation fault when run.
void myStrcat(char *a, char *b)
{
    int m = strlen(a);
    int n = strlen(b);
    int i;
    for (i = 0; i <= n; i++)
       a[m+i]  = b[i];
}
 
int main()
{
    char *str1 = "Geeks ";
    char *str2 = "Quiz";
    myStrcat(str1, str2);
    printf("%s ", str1);
    return 0;
}
// Which of the following changes can correct the program so that it prints "Geeks Quiz"?

// A: char *str1 = "Geeks"; can be changed to char str1[100] = "Geeks ";
// B: char *str1 = "Geeks"; can be changed to char str1[100] = "Geeks "; and a line a[m + n - 1] = '\0' is added at the end of myStrcat
// C: A line a[m + n - 1] = '\0' is added at the end of myStrcat
// D: A line 'a = (char *) malloc(sizeof(char) * (strlen(a) + strlen(b) + 1)) is added at the beginning of myStrcat()

// A
// when declared as char *, we can not alter the string because it is stored in read-only memory. change to array to alter it within the function and save to a string var

// 18. Predict the output
int fun(char *str1)
{
  char *str2 = str1;
  while(*++str1);
  return (str1-str2);
}
 
int main()
{
  char *str = "GeeksQuiz";
  printf("%d", fun(str));
  return 0;
}

// 9
// counts the number of chars in the input string, the (*++str1) loops until '\0' is reached, then the difference between str1 and str2 is just the memory address value difference

// 19. Predict the output
#include <stdio.h>
#include <stdarg.h>
int fun(int n, ...)
{
    int i, j = 1, val = 0;
    va_list p;
    va_start(p, n);
    for (; j < n; ++j)
    {
        i = va_arg(p, int);
        val += i;
    }
    va_end(p);
    return val;
}
int main()
{
    printf("%d\n", fun(4, 1, 2, 3));
    return 0;
}

// 6
// above code iterates through the argument list and adds them together. the n value is used to indicate how many args there are (-1) and va_start(p, n) loops through the arg list with va_arg

// 20. Predict the output
#include "stdio.h"
int main()
{
 int a = 10;
 int b = 15;
 
 printf("=%d",(a+1),(b=a+2));
 printf(" %d=",b);
 
 return 0;
}

// =11 12=
// all arguments of printf are executed regardless of whether they are printed or not, first one prints a + 1, then b gets assigned a + 2

// 21. Consider the following C code
#include "stdio.h"
 
int foo(int a)
{
 printf("%d",a);
 return 0;
}
 
int main()
{
 foo;
 return 0;
}

// Which of the following is correct?

// A: It'll result in compile error because foo is used without parentheses
// B: No compile error and some garbage value would be passed to foo function. This would make foo to be executed with output "garbage integer"
// C: No compile error but foo function wouldn't be executed. The program wouldn't print anything
// D: No compile error and ZERO (ie 0) would be passed to foo function. This would make foo to be executed with output 0

// C
// if no parentheses, then a pointer to the function would be generated but nothing assigned to so the function is never called

// 22. Consider the following C program
#include <stdio.h>
struct Ournode {
  char x, y, z;
};
 
int main() {
  struct Ournode p = {'1', '0', 'a' + 2};
  struct Ournode *q = &p;
  printf("%c, %c", *((char *)q + 1), *((char *)q + 2));
  return 0;
}

// 0, c
// p is initially assigned x = '1', y = '0', and z = 'c' then q is assigned the same memory address. After dereferencing, the 0 address is x, 1 address is y, and 2 address is z

// 23. Consider the following C code. Assume that unsigned long int type length is 64 bits
unsigned long int fun(unsigned long int n) {
        unsigned long int i, j = 0, sum = 0;
        for( i = n; i > 1; i = i/2) j++;
        for( ; j > 1; j = j/2) sum++;
        return sum;
}
// The value returned when we call fun with the input 2^40 is

// 5
// First i - loop divides the 2^40 by 2 40 times, j = 40. Then the second loop divides j by 2, this is 5 because the closest power of 2 to 40 is 32, ie. 2^5 = 32 so sum = 5

// 24. What is the output of the C program
#include <stdio.h>
void fun1(char *s1, char *s2) {
  char *temp;
  temp = s1;
  s1 = s2;
  s2 = temp;
}
void fun2(char **s1, char **s2) {
  char *temp;
  temp = *s1;
  *s1 = *s2;
  *s2 = temp;
}
int main() {
  char *str1 = "Hi", *str2 = "Bye";
  fun1(str1, str2);
  printf("%s %s", str1, str2);
  fun2(&str1, &str2);
  printf("%s %s", str1, str2);
  return 0;
}

// Hi Bye Bye Hi
// fun1 does not actually swap the strings, the assignment is local to the function and won't affect the output when the function returns. fun2 swaps the memory addresses of the double ptr s1 and s2 so this is reflected when function exits

// 25. What is the value returned by the function f given below when n = 100? int f (int n) {if (n == 0) then return n; else return n + f(n - 2);}

// 2550
// 100 + 98 + 96 + 94.... = sum_formula(50) * 2 = 50 * 51 = 2550

// 26. What will be the output of the following C code?
#include <stdio.h>
int main() {
    int x = 128;
    printf("n%d", 1 + x++);
}

// since there is a post increment, it is applied after the printf statement is executed so only 1 + x is printed

// 27. What is the output of the C program
#include <stdio.h> 
int main ()  { 
    int  a[4][5] = {{1, 2, 3, 4, 5}, 
                    {6, 7, 8, 9, 10}, 
                    {11, 12, 13, 14, 15}, 
                    {16, 17, 18, 19, 20}}; 
    printf("%dn", *(*(a+**a+2)+3)); 
    return(0); 
}  

// 19
// a + **a + 2 = a + 1 + 2 = a + 3 gives the {16, 17....} row
// *(*(4th row) + 3) == 19

// 28. What is the return value of fun2(5)
#include <stdio.h> 
int fun1(int n) {
    static int i= 0;
    if (n > 0) {
        ++i;
        fun1(n-1);
    }
    return (i);
}
int fun2(int n) {
    static int i= 0;
    if (n>0) {
        i = i + fun1(n);
        fun2(n-1);
    }
    return (i);
}

// 55
// n = 5, fun1(5) returns 0 + 5 so fun1_i = 5 and fun2_i = 0 + fun1_i = 5
// n = 4, fun1(4) returns 5 + 4 so fun1_i = 9 and fun2_i = 5 + fun1_i = 14
// n = 3, fun1(3) returns 9 + 3 so fun1_i = 12 and fun2_i = 14 + fun1_i = 26
// n = 2, fun1(2) returns 12 + 2 so fun1_i = 14 and fun2_i = 26 + fun1_i = 40
// n = 1, fun1(1) returns 14 + 1 so fun1_i = 15 and fun2_i = 40 + fun1_i = 55
// n = 0, exits out of fun2

// 29. What is the return value of pp(3,4)
#include <stdio.h>
int tob (int b, int* arr) {
    int i;
    for (i = 0; b>0; i++)  {
        if (b%2)  arr[i] = 1;
        else      arr[i] = 0;
        b = b/2;
    }
    return (i);
}
  
 
int pp(int a, int b)  {
    int  arr[20];
    int i, tot = 1, ex, len;
    ex = a;
    len = tob(b, arr);
    for (i = 0; i < len; i++) {
         if (arr[i] == 1)
             tot = tot * ex;
         ex= ex*ex;
    }
    return (tot);
}

// 81
// pp(3, 4) calls tob(4, arr)
//      arr = {0, 0, 1}, len = 3
// for (i = 0; i < 3; i++) 
//      arr[0] == 0, ex = 9
//      arr[1] == 0, ex = 81
//      arr[2] == 1, tot = 1 * 81 = 81

// 30. Consider the following C program
#include <stdio.h>
int main() {
    int i, j, count;
    count = 0;
    i = 0;
    for (j = -3; j <= 3; j++) {
        if ((j >= 0) && (i++))
            count = count + j;
    }
    count = count + i;
    printf("%d", count);
    return 0;
}

// Which of the following is correct?
// A: the program will not compile successfully
// B: the program will compile successfully and output 10 when executed
// C: '                                     '   output 8 when executed
// D: '                                     '   output 13 when executed

// B
// j = -3 to j - 1, count = 0.
// j = 0, i++ -> i = 1, count = count + j = 0 + 0 = 0
// j = 1, i++ -> i = 2, count = count + j = 0 + 1 = 1
// j = 2, i++ -> i = 3, count = count + j = 1 + 2 = 3
// j = 3, i++ -> i = 4, count = count + j = 3 + 3 = 6
// count = count + i = 6 + 4 = 10

// 31. Consider the following C function
int SimpleFunction(int Y[], int n, int x)
{
    int total = Y[0], loopIndex;
    for (loopIndex=1; loopIndex<=n-1; loopIndex++)
        total=x*total +Y[loopIndex];
    return total;
} 

// Let Z be an array of 10 elements with Z[i] = 1, for all i such that 0 <= i <= 9. The value returned by SimpleFunction(Z, 10, 2) is

// 1023
// Y[] = {1, 1, 1, ... 1}, n = 10, x = 2
// total = 1
// for (loopIndex = 1; loopIndex <= 9; loopIndex++)
//      loopIndex = 1: total = x * total + Y[loopIndex] = 2 * 1 + 1 = 3
//      loopIndex = 2: total = '                      ' = 2 * 3 + 1 = 7
//      loopIndex = 3: total = '                      ' = 2 * 7 + 1 = 15
//      loopIndex = 4: total = 31
//      5: 63
//      6: 127
//      7: 255
//      8: 511
//      9: 1023 

// 32. Consider the following C program
#include <stdio.h>
int main( ) 
{
    int arr[4][5];
    int  i, j;
    for (i=0; i<4; i++) ​​​​​{
        for (j=0; j<5; j++) 
        {
            arr[i][j] = 10 * i + j;
        }
    }
    printf("%d", *(arr[1]+9));
    return 0;
} 
// What is the output of the above program?

// 24
// for *(arr[1] + 9), this equates to *arr[1][9] which wraps around to *arr[2][4] so i = 2, j = 4, arr[i][j] = 10 * 2 + 4 = 24

// 33. Consider the following function
int someFunction(int x, int y) {
    if ((x == 1) || (y == 1)) return 1;
    if (x == y) return x;
    if (x > y) return someFunction(x - y, y);
    if (y > x) return someFunction(x, y - x);
}
// the value returned by someFunction(15, 255) is

// 15
// x = 15, y = 255
//      y > x; return someFunction(15, 240)
// ....
// x = 15, y = 15 so return 15