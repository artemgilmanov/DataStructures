##  Principle of Recursion
Recursion is an approach to solving problems using a function that calls itself as a subroutine.

You might wonder how we can implement a function that calls itself. The trick is that each time a recursive function calls itself, it reduces the given problem into subproblems. The recursion call continues until it reaches a point where the subproblem can be solved without further recursion.

A recursive function should have the following properties so that it does not result in an infinite loop:

A simple base case (or cases) — a terminating scenario that does not use recursion to produce an answer.
A set of rules, also known as recurrence relation that reduces all other cases towards the base case.
Note that there could be multiple places where the function may call itself.

## Example
Let's start with a simple programming problem:

Print a string in reverse order.

You can easily solve this problem iteratively, i.e. looping through the string starting from its last character. But how about solving it recursively?

First, we can define the desired function as printReverse(str[0...n-1]), where str[0] represents the first character in the string. Then we can accomplish the given task in two steps:

printReverse(str[1...n-1]): print the substring str[1...n-1] in reverse order.
print(str[0]): print the first character in the string.
Notice that we call the function itself in the first step, which by definition makes the function recursive.

Here is the code snippet:
```cshrp
private static void PrintReverse(char[] str)
{
    Helper(0, str);
}

private static void Helper(int index, char[] str)
{
    if (str == null || index >= str.Length)
    {
        return;
    }
    Helper(index + 1, str);
    Console.Write(str[index]);
}
```
## Recurrence Relation

There are two important things that one needs to figure out before implementing a recursive function:

recurrence relation: the relationship between the result of a problem and the result of its subproblems.
base case: the case where one can compute the answer directly without any further recursion calls. Sometimes, the base cases are also called bottom cases, since they are often the cases where the problem has been reduced to the minimal scale, i.e. the bottom, if we consider that dividing the problem into subproblems is in a top-down manner.
Once we figure out the above two elements, to implement a recursive function we simply call the function itself according to the recurrence relation until we reach the base case.

To explain the above points, let's look at a classic problem, Pascal's Triangle:

Pascal's triangle are a series of numbers arranged in the shape of triangle. In Pascal's triangle, the leftmost and the rightmost numbers of each row are always 1. For the rest, each number is the sum of the two numbers directly above it in the previous row.

Here's the illustration of the Pascal's Triangle with 5 rows: Given the above definition, one is asked to generate the Pascal's Triangle up to a certain number of rows.

Recurrence Relation
Let's start with the recurrence relation within the Pascal's Triangle.

First of all, we define a function 
f(i,j) which returns the number in the Pascal's Triangle in the i-th row and j-th column.

We then can represent the recurrence relation with the following formula:
f(i,j)=f(i−1,j−1)+f(i−1,j)

Base Case
As one can see, the leftmost and rightmost numbers of each row are the base cases in this problem, which are always equal to 1.

As a result, we can define the base case as follows:
f(i,j)=1wherej=1orj=i

Demo
As one can see, once we define the recurrence relation and the base case, it becomes much more intuitive to implement the recursive function, especially when we formulate these two elements in terms of mathematical formulas.

Here is an example of how we can apply the formula to recursively calculate 
f(5,3), i.e. the 3rd number in the 5th row of the Pascal Triangle:

Starting from 
f(5,3), we can break it down as 
f(5,3)=f(4,2)+f(4,3), we then call 
f(4,2) and 
f(4,3) recursively:

For the call of 
f(4,2), we could extend it further until we reach the base cases, as follows:
f(4,2)=f(3,1)+f(3,2)=f(3,1)+(f(2,1)+f(2,2))=1+(1+1)=3


For the call of 
f(4,3), similarly we break it down as:
f(4,3)=f(3,2)+f(3,3)=(f(2,1)+f(2,2))+f(3,3)=(1+1)+1=3

Finally we combine the results of the above subproblems:
f(5,3)=f(4,2)+f(4,3)=3+3=6

Next
In the above example, you might have noticed that the recursive solution can incur some duplicate calculations, i.e. we compute the same intermediate numbers repeatedly in order to obtain numbers in the last row. For instance, in order to obtain the result for the number 
f(5,3), we calculate the number 
f(3,2) twice both in the calls of 
f(4,2) and 
f(4,3).

We will discuss how to avoid these duplicate calculations in the next chapter of this Explore card.

Following this article, you will find exercises for problems related to Pascal's Triangle.

## Duplicate Calculation in Recursion

Recursion is often an intuitive and powerful way to implement an algorithm. However, it might bring some undesired penalty to the performance, e.g. duplicate calculations, if we do not use it wisely. For instance, at the end of the previous chapter, we have encountered the duplicate calculations problem in Pascal's Triangle, where some intermediate results are calculated multiple times.

In this article we will look closer into the duplicate calculations problem that could happen with recursion. We will then propose a common technique called memoization that can be used to avoid this problem.

To demonstrate another problem with duplicate calculations, let's look at an example that most people might be familiar with, the Fibonacci number. If we define the function F(n) to represent the Fibonacci number at the index of n, then you can derive the following recurrence relation:

F(n) = F(n - 1) + F(n - 2)
with the base cases:

F(0) = 0, F(1) = 1
Given the definition of a Fibonacci number, one can implement the function as follows:

```cshrp
public static int Fibonacci(int n)
{
    if (n < 2)
    {
        return n;
    }
    else
    {
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}
```
Now, if you would like to know the number of F(4), you can apply and extend the above formulas as follows:

F(4) = F(3) + F(2) = (F(2) + F(1)) + F(2)
As you can see, in order to obtain the result for F(4), we would need to calculate the number F(2) twice following the above deduction: the first time in the first extension of F(4) and the second time for the intermediate result F(3).

Here is the tree that shows all the duplicate calculations (grouped by colors) that occur during the calculation of F(4).

## Memoization

To eliminate the duplicate calculation in the above case, as many of you would have figured out, one of the ideas would be to store the intermediate results in the cache so that we could reuse them later without re-calculation.

This idea is also known as memoization, which is a technique that is frequently used together with recursion.

Memoization is an optimization technique used primarily to speed up computer programs by storing the results of expensive function calls and returning the cached result when the same inputs occur again. (Source: wikipedia)

Back to our Fibonacci function F(n). We could use a hash table to keep track of the result of each F(n) with n as the key. The hash table serves as a cache that saves us from duplicate calculations. The memoization technique is a good example that demonstrates how one can reduce compute time in exchange for some additional space.

For the sake of comparison, we provide the implementation of Fibonacci number solution with memoization below.

As an exercise, you could try to make memoization more general and non-intrusive, i.e. applying memoization without changing the original function. (Hint: one can refer to a design pattern called decorator).

```cshrp
using System.Collections.Generic;

public class MainClass
{
    private Dictionary<int, int> cache = new Dictionary<int, int>();

    private int Fib(int N)
    {
        if (cache.ContainsKey(N))
        {
            return cache[N];
        }
        
        int result;
        if (N < 2)
        {
            result = N;
        }
        else
        {
            result = Fib(N - 1) + Fib(N - 2);
        }
        
        cache[N] = result;
        return result;
    }
}
```

