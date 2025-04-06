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

Following this article, we provide the Fibonacci number problem and another classic problem called climbing stairs, which could be really fun and challenging to solve.

In the next chapter, we will dive a bit into the complexity analysis of recursion algorithms.

## Time Complexity - Recursion

In this article, we will focus on how to calculate the time complexity for recursion algorithms.

Given a recursion algorithm, its time complexity 
O
(
T
)
O(T) is typically the product of the number of recursion invocations (denoted as 
R
R) and the time complexity of calculation (denoted as 
O
(
s
)
O(s)) that incurs along with each recursion call:

O
(
T
)
=
R
∗
O
(
s
)
O(T)=R∗O(s)

Let's take a look at some examples below.

 

Example
As you might recall, in the problem of printReverse, we are asked to print the string in the reverse order. A recurrence relation to solve the problem can be expressed as follows:

printReverse(str) = printReverse(str[1...n]) + print(str[0])

where str[1...n] is the substring of the input string str, without the leading character str[0].

As you can see, the function would be recursively invoked n times, where n is the size of the input string. At the end of each recursion, we simply print the leading character, therefore the time complexity of this particular operation is constant, i.e. 
O
(
1
)
O(1).

To sum up, the overall time complexity of our recursive function printReverse(str) would be 
O
(
p
r
i
n
t
R
e
v
e
r
s
e
)
=
n
∗
O
(
1
)
=
O
(
n
)
O(printReverse)=n∗O(1)=O(n).

 

Execution Tree
For recursive functions, it is rarely the case that the number of recursion calls happens to be linear to the size of input. For example, one might recall the example of Fibonacci number that we discussed in the previous chapter, whose recurrence relation is defined as f(n) = f(n-1) + f(n-2). At first glance, it does not seem straightforward to calculate the number of recursion invocations during the execution of the Fibonacci function.

In this case, it is better resort to the execution tree, which is a tree that is used to denote the execution flow of a recursive function in particular. Each node in the tree represents an invocation of the recursive function. Therefore, the total number of nodes in the tree corresponds to the number of recursion calls during the execution.

The execution tree of a recursive function would form an n-ary tree, with n as the number of times recursion appears in the recurrence relation. For instance, the execution of the Fibonacci function would form a binary tree, as one can see from the following graph which shows the execution tree for the calculation of Fibonacci number f(4).

In a full binary tree with n levels, the total number of nodes would be 
2
n
−
1
2 
n
 −1. Therefore, the upper bound (though not tight) for the number of recursion in f(n) would be 
2
n
−
1
2 
n
 −1, as well. As a result, we can estimate that the time complexity for f(n) would be 
O
(
2
n
)
O(2 
n
 ).

 

Memoization
In the previous chapter, we discussed the technique of memoization that is often applied to optimize the time complexity of recursion algorithms. By caching and reusing the intermediate results, memoization can greatly reduce the number of recursion calls, i.e. reducing the number of branches in the execution tree. One should take this reduction into account when analyzing the time complexity of recursion algorithms with memoization.

Let's get back to our example of Fibonacci number. With memoization, we save the result of Fibonacci number for each index n. We are assured that the calculation for each Fibonacci number would occur only once. And we know, from the recurrence relation, the Fibonacci number f(n) would depend on all n-1 precedent Fibonacci numbers. As a result, the recursion to calculate f(n) would be invoked n-1 times to calculate all the precedent numbers that it depends on. 

Now, we can simply apply the formula we introduced in the beginning of this chapter to calculate the time complexity, which is 
O
(
1
)
∗
n
=
O
(
n
)
O(1)∗n=O(n). Memoization not only optimizes the time complexity of algorithm, but also simplifies the calculation of time complexity.

In the next article, we will talk about how to evaluate the space complexity of recursion algorithms.

Space Complexity - Recursion
Report Issue
In this article, we will talk about how to analyze the space complexity of a recursive algorithm.

There are mainly two parts of the space consumption that one should bear in mind when calculating the space complexity of a recursive algorithm: recursion related and non-recursion related space.

 
Recursion Related Space
The recursion related space refers to the memory cost that is incurred directly by the recursion, i.e. the stack to keep track of recursive function calls. In order to complete a typical function call, the system allocates some space in the stack to hold three important pieces of information:

The returning address of the function call. Once the function call is completed, the program must know where to return to, i.e. the line of code after the function call.
The parameters that are passed to the function call. 
The local variables within the function call.
This space in the stack is the minimal cost that is incurred during a function call. However, once the function call is done, this space is freed. 

For recursive algorithms, the function calls chain up successively until they reach a base case (a.k.a. bottom case). This implies that the space that is used for each function call is accumulated.

For a recursive algorithm, if there is no other memory consumption, then this recursion incurred space will be the space upper-bound of the algorithm.

For example, in the exercise of printReverse, we don't have extra memory usage outside the recursive call, since we simply print a character. For each recursive call, let's assume it can use space up to a constant value. And the recursive calls will chain up to n times, where n is the size of the input string. So the space complexity of this recursive algorithm is 
O
(
n
)
O(n).

To illustrate this, for a sequence of recursive calls f(x1) -> f(x2) -> f(x3), we show the sequence of execution steps along with the layout of the stack:



A space in the stack will be allocated for f(x1) in order to call f(x2). Similarly in f(x2), the system will allocate another space for the call to f(x3). Finally in f(x3), we reach the base case, therefore there is no further recursive call within f(x3).

It is due to recursion-related space consumption that sometimes one might run into a situation called stack overflow, where the stack allocated for a program reaches its maximum space limit and the program crashes. Therefore, when designing a recursive algorithm, one should carefully check if there is a possibility of stack overflow when the input scales up.

 

Non-Recursion Related Space
As suggested by the name, the non-recursion related space refers to the memory space that is not directly related to recursion, which typically includes the space (normally in heap) that is allocated for the global variables.

Recursion or not, you might need to store the input of the problem as global variables, before any subsequent function calls. And you might need to save the intermediate results from the recursive calls as well. The latter is also known as memoization as we saw in the previous chapters. For example, in the recursive algorithm with memoization to solve the Fibonacci number problem, we used a map to keep track of all intermediate Fibonacci numbers that occurred during the recursive calls. Therefore, in the space complexity analysis, we must take the space cost incurred by the memoization into consideration.  

## Tail Recursion

In the previous article, we talked about the implicit extra space incurred on the system stack due to recursion calls. However, you should learn to identify a special case of recursion called tail recursion, which is exempted from this space overhead.

Tail recursion is a recursion where the recursive call is the final instruction in the recursion function. And there should be only one recursive call in the function.

We have already seen an example of tail recursion in the solution of Reverse String. Here is another example that shows the difference between non-tail-recursion and tail-recursion. Notice that in the non-tail-recursion example there is an extra computation after the very last recursive call.

The benefit of having tail recursion is that it could avoid the accumulation of stack overheads during the recursive calls, since the system could reuse a fixed amount space in the stack for each recursive call. 

For example, for the sequence of recursion calls f(x1) -> f(x2) -> f(x3), if the function f(x) is implemented as tail recursion, then here is the sequence of execution steps along with the layout of the stack:

Note that in tail recursion, we know that as soon as we return from the recursive call we are going to immediately return as well, so we can skip the entire chain of recursive calls returning and return straight to the original caller. That means we don't need a call stack at all for all of the recursive calls, which saves us space.

For example, in step (1), a space in the stack would be allocated for f(x1) in order to call f(x2). Then in step (2), the function f(x2) would recursively call f(x3). However, instead of allocating new space on the stack, the system could simply reuse the space allocated earlier for this second recursion call. Finally, in the function f(x3), we reach the base case, and the function could simply return the result to the original caller without going back to the previous function calls.

A tail recursion function can be executed as non-tail-recursion functions, i.e. with piles of call stacks, without impact on the result. Often, the compiler recognizes tail recursion pattern, and optimizes its execution. However, not all programming languages support this optimization. For instance, C and C++ support the optimization of tail recursion functions. On the other hand, Java and Python do not support tail recursion optimization. Although, while we will not cover how to do so here, it is possible to implement TCO by using lambda expressions in Python and Java. 

## Conclusion - Recursion I
Report Issue
Now, you might be convinced that recursion is indeed a powerful technique that allows us to solve many problems in an elegant and efficient way. But still, it is no silver bullet. Not every problem can be solved with recursion, due to the time or space constraints. And recursion itself might come with some undesired side effects such as stack overflow. 

In this chapter we would like to share a few more tips on how to better apply recursion to solve problems in the real world. 

When in doubt, write down the recurrence relationship.

Sometimes, at a first glance it is not evident that a recursion algorithm can be applied to solve a problem. However, it is always helpful to deduct some relationships with the help of mathematical formulas, since the recurrence nature in recursion is quite close to the mathematics that we are familiar with. Often, they can clarify the ideas and uncover the hidden recurrence relationship. Within this chapter, you can find a fun example named Unique Binary Search Trees II, which can be solved by recursion, with the help of mathematical formulas. 

Whenever possible, apply memoization.

When drafting a recursion algorithm, one could start with the most naive strategy. Sometimes, one might end up with the situation where there might be duplicate calculation during the recursion, e.g. Fibonacci numbers. In this case, you can try to apply the memoization technique, which stores the intermediate results in cache for later reuse. Memoization could greatly improve the time complexity with a bit of trade on space complexity, since it could avoid the expensive duplicate calculation.

When stack overflows, tail recursion might come to help. 

There are often several ways to implement an algorithm with recursion. Tail recursion is a specific form of recursion that we could implement. Different from the memoization technique, tail recursion could optimize the space complexity of the algorithm, by eliminating the stack overhead incurred by recursion. More importantly, with tail recursion, one could avoid the problem of stack overflow that comes often with recursion. Another advantage about tail recursion is that often times it is easier to read and understand, compared to non-tail-recursion. Because there is no post-call dependency in tail recursion (i.e. the recursive call is the final action in the function), unlike non-tail-recursion. Therefore, whenever possible, one should strive to apply the tail recursion.
