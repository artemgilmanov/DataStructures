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

## D&C Introduction

Divide and conquer (D&C) is one of the most important paradigms in algorithm design and is widely used.

A divide-and-conquer algorithm works by recursively breaking the problem down into two or more subproblems of the same or related type, until these subproblems become simple enough to be solved directly [1]. Then one combines the results of subproblems to form the final solution.

As you can see, divide-and-conquer algorithm is naturally implemented in the form of recursion. Another subtle difference that tells a divide-and-conquer algorithm apart from other recursive algorithms is that we break the problem down into two or more subproblems in the divide-and-conquer algorithm, rather than a single smaller subproblem. The latter recursive algorithm sometimes is called decrease and conquer instead, such as Binary Search.

There are in general three steps that one can follow in order to solve the problem in a divide-and-conquer manner.

1. Divide. Divide the problem S into a set of subproblems: {S 1,S 2,...S n} where n≥2, i.e. there are usually more than one subproblem.
2. Conquer. Solve each subproblem recursively.
3. Combine. Combine the results of each subproblem.

## Merge Sort
One of the classic examples of the divide-and-conquer algorithm is the merge sort algorithm [1]. Merge sort is an efficient and general-purpose sorting algorithm. 

 
Intuition
There are two approaches to implement the merge sort algorithm: top down or bottom up. Here, we will explain the top down approach as it can be implemented naturally using recursion.

The merge sort algorithm can be divided into three steps, like all divide-and-conquer algorithms:

Divide the given unsorted list into several sublists.  (Divide)
 
Sort each of the sublists recursively.  (Conquer)
 
Merge the sorted sublists to produce new sorted list.  (Combine)
 
Top-down Approach
Let us look at a concrete example to see how the top-down merge sort algorithm works. As shown in the figure below, we are given an unordered list with 8 elements. The task is to sort the list in ascending order. 



Fig.1  Top-down Merge Sort

 

In the first step, we divide the list into two sublists.  (Divide)
 
Then in the next step, we recursively sort the sublists in the previous step.  (Conquer)
 
Finally we merge the sorted sublists in the above step repeatedly to obtain the final list of sorted elements.  (Combine)
 

The recursion in step (2) would reach the base case where the input list is either empty or contains a single element (see the nodes in blue from the above figure).

Now, we have reduced the problem down to a merge problem, which is much simpler to solve. Merging two sorted lists can be done in linear time complexity 
O
(
N
)
O(N), where 
N
N is the total lengths of the two lists to merge.

We demonstrate an example of the merge process as following:



Here is a sample implementation of the top-down merge sort algorithm.

```cshrp
using System;

public class Solution 
{
    public int[] MergeSort(int[] input) 
    {
        if (input.Length <= 1) 
        {
            return input;
        }
        int pivot = input.Length / 2;
        int[] leftList = MergeSort(input[0..pivot]);
        int[] rightList = MergeSort(input[pivot..]);
        return Merge(leftList, rightList);
    }
    
    public int[] Merge(int[] leftList, int[] rightList) 
    {
        int[] ret = new int[leftList.Length + rightList.Length];
        int leftCursor = 0, rightCursor = 0, retCursor = 0;

        while (leftCursor < leftList.Length && rightCursor < rightList.Length) 
        {
            if (leftList[leftCursor] < rightList[rightCursor]) 
            {
                ret[retCursor++] = leftList[leftCursor++];
            } 
            else 
            {
                ret[retCursor++] = rightList[rightCursor++];
            }
        }
        
        // Append remaining elements
        while (leftCursor < leftList.Length) 
        {
            ret[retCursor++] = leftList[leftCursor++];
        }
        while (rightCursor < rightList.Length) 
        {
            ret[retCursor++] = rightList[rightCursor++];
        }
        
        return ret;
    }
}
```
Bottom-up Approach
In the bottom up approach, we divide the list into sublists of a single element at the beginning. Each of the sublists is then sorted already. Then from this point on, we merge the sublists two at a time until a single list remains.

We illustrate how the bottom up approach works in the below figure. The bottom up approach can be implemented iteratively. Try to implement it yourself! We have an exercise that you can practice following this article.

 



Fig. 2   Bottom-up Merge Sort

 

 

Complexity
The overall time complexity of the merge sort algorithm is 
O
(
N
log
⁡
N
)
O(NlogN), where 
N
N is the length of the input list. To calculate the complexity, we break it down to the following steps:

We recursively divide the input list into two sublists, until a sublist with single element remains. This dividing step computes the midpoint of each of the sublists, which takes 
O
(
1
)
O(1) time. This step is repeated 
N
N times until a single element remains, therefore the total time complexity is 
O
(
N
)
O(N).
 
Then, we repetitively merge the sublists, until one single list remains. The recursion tree in Fig. 1 or Fig. 2 above is useful for visualizing how the recurrence is iterated. As shown in the recursion tree, there are a total of 
N
N elements on each level. Therefore, it takes 
O
(
N
)
O(N) time for the merging process to complete on each level. And since there are a total of 
log
⁡
N
logN levels, the overall complexity of the merge process is 
O
(
N
log
⁡
N
)
O(NlogN).
Taking into account the complexity of the above two parts in the merge sort algorithm, we conclude that the overall time complexity of merge sort is 
O
(
N
log
⁡
N
)
O(NlogN).

The space complexity of the merge sort algorithm is 
O
(
N
)
O(N), where 
N
N is the length of the input list, since we need to keep the sublists as well as the buffer to hold the merge results at each round of merge process.

## D&C Template

In the previous article of merge sort, we have introduced the general steps involved in all the divide-and-conquer algorithms. In this article, we will present you a pseudocode template that could help you to structure your code when implementing the algorithm in the divide-and-conquer paradigm. Furthermore, we will demonstrate with some concrete examples on how to apply the template.

 

Template
There are in general three steps that one can follow in order to solve the problem in a divide-and-conquer manner.

1. Divide. Divide the problem 
S
S into a set of subproblems: 
{
S
1
,
S
2
,
.
.
.
S
n
}
{S 
1
​
 ,S 
2
​
 ,...S 
n
​
 } where 
n
≥
2
n≥2, i.e. there are usually more than one subproblem.

2. Conquer. Solve each subproblem recursively. 

3. Combine. Combine the results of each subproblem.

We can summarize the above steps in the following pseudocode template.
```cshrp
using System;
using System.Collections.Generic;
using System.Linq;

public class DivideAndConquer
{
    public T DivideAndConquer<T>(T problem)
    {
        // Base case: if the problem is small enough, solve it directly
        if (IsSimple(problem))
        {
            return SolveDirectly(problem);
        }

        // (1) Divide the problem into subproblems
        List<T> subproblems = Divide(problem);

        // (2) Solve subproblems recursively
        List<T> results = new List<T>();
        foreach (var subproblem in subproblems)
        {
            results.Add(DivideAndConquer(subproblem));
        }

        // (3) Combine the results
        return Combine(results);
    }

    // Example implementation for an array sum problem
    public int DivideAndConquerSum(int[] array)
    {
        if (array.Length <= 1)
        {
            return array.Length == 0 ? 0 : array[0];
        }

        int mid = array.Length / 2;
        int[] left = array.Take(mid).ToArray();
        int[] right = array.Skip(mid).ToArray();

        int leftSum = DivideAndConquerSum(left);
        int rightSum = DivideAndConquerSum(right);

        return leftSum + rightSum;
    }

    // Helper methods would be implemented based on specific problems
    private bool IsSimple<T>(T problem)
    {
        // Implementation depends on the specific problem
        throw new NotImplementedException();
    }

    private T SolveDirectly<T>(T problem)
    {
        // Implementation depends on the specific problem
        throw new NotImplementedException();
    }

    private List<T> Divide<T>(T problem)
    {
        // Implementation depends on the specific problem
        throw new NotImplementedException();
    }

    private T Combine<T>(List<T> results)
    {
        // Implementation depends on the specific problem
        throw new NotImplementedException();
    }
}
```
As one can see from the above template, the essential part of the divide and conquer is to figure out the recurrence relationship between the subproblems and the original problem, which subsequently defines the functions of divide() and combine(). 

In the next sections, we will show you how to apply the above template to implement the algorithms for some concrete examples.

 
Validate Binary Search Tree
Sometimes, tree related problems can be solved using divide-and-conquer algorithms.

For example, look at the following problem statement:

Given a binary tree, validate if the given tree is a binary search tree (BST). The BST must meet all of the following properties:

All values on the left subtree of a node should be less than the value of the node.
All values on the right subtree of a node should be greater than the value of the node.
Both the left and right subtrees must also be binary search trees.
 

Read point no. 3 above very carefully. The definition of BST is recursive in nature, making this a natural divide and conquer problem.

Below is an example of a BST shown in the following figure.



Fig 2. Binary Search Tree

1. In the first step, we divide the tree into two subtrees -- its left child and right child.  (Divide)

2. Then in the next step, we recursively validate each subtree is indeed a binary search tree.  (Conquer)

3. Upon the results of the subproblems from Step 2, we return true if and only if both subtrees are both valid BST.  (Combine)

 

The recursion in Step 2. would reach the base case where the subtree is either empty or contains a single node, which is a valid BST itself.

Notice some important details are still missing from Step 2. above, which are left as an exercise for the reader. For example, how do you verify these two properties which are also required for a BST?

All values on the left subtree of a node should be less than the value of the node.
All values on the right subtree of a node should be greater than the value of the node.
 

Following this article you can try solving this exercise by yourself. We also provide a step-by-step solution if you are still stuck following the exercise.

 

Search a 2D Matrix II
Write an efficient algorithm that searches for an integer value in an 
[
m
×
n
]
[m×n] matrix. This matrix has the following properties:

Integers in each row are sorted in ascending from left to right.
Integers in each column are sorted in ascending from top to bottom.
 

There are several ways to solve the above problem. Here we give an overall idea to solve it in the divide-and-conquer manner. 

As one might notice, given the matrix, if we divide it into some sub-matrices by cutting it either by row and/or column, the resulting matrices would still keep the above two properties of the original matrix. Given the above insight, here is how we can apply the template to solve the problem.

1. We divide the matrix into 4 sub-matrices by choosing a pivot point based on a row and a column.  (Divide)

2. Then we recursively look into each sub-matrix to search for the desired target.  (Conquer)

3. If we find the target in either of the sub-matrices, we stop the search and return the result immediately.  (Combine)

 

The base cases in the above recursion would be either the input matrix is empty or it contains only a single element. As a simple strategy, one can choose the middle point both on the row and column as the pivot points to divide the matrix.

Do we really need to look into each of the divided 4 sub-matrices? Notice that the smallest and the largest element of the input matrix is located in the top left and bottom right corner respectively, which also applies to each of the divided sub-matrices. In fact, we need to only look into 3 of the sub-matrices.

If our target is equal to the pivot, we have found our target and immediately return the result.
If our target is less than the pivot, we can discard the bottom-right sub-matrix. All elements in that region must be greater or equal than the pivot.
If our target is greater than the pivot, we can discard the top-left sub-matrix. All elements in that region must be less than or equal than the pivot.
 

We have just finished the divide-and-conquer approach, now try to code the solution yourself! As a follow up exercise, can you derive the time complexity? At the end of this chapter, we provide Master Theorem as an alternative way to derive time complexity like this problem.

 

The above divide-and-conquer algorithm can still be further improved, which we will provide insights below.

As an improvement to the above divide-and-conquer algorithm, we could devise a better strategy by choosing the pivot points wisely.

 

We illustrate a strategy in the following figure, to reduce the search zones into 2 sub-matrices, instead of 3 sub-matrices.



Fig 1. Search 2D Matrix II

First, we choose the middle point on the column which divides the matrix into two sub-matrices. We then fix on this middle column to further determine an optimal row to divide the matrix. We scan the elements along the chosen middle column, to locate the boundary where the value of the element just goes beyond the target value, i.e.  
{
V
i
−
1
<
target
<
V
i
}
{V 
i−1
​
 <target<V 
i
​
 }. From this point, we divide the original matrix into 4 sub-matrices. And we just need to zoom into the bottom left and top right sub-matrices to look for the target value, while ignoring the top left and bottom right sub-matrices.

We ignore the top left sub-matrix that ends with the element 
V
i
−
1
V 
i−1
​
 , because all the elements within this sub-matrix would be less than the target value. Similarly, we ignore the bottom right sub-matrices that starts with the element 
V
i
V 
i
​
 , because we know that all the elements within this sub-matrix would be greater than the target value.

 ## Quick Sort

In the previous articles, we explained the merge sort algorithm, which is a classical example of the divide-and-conquer algorithm. As a comparison to merge sort algorithm, in this article, we will present you another well-known sorting algorithm called quick sort.

Quick sort [1] is another classical divide-and-conquer algorithm for sorting, which was developed by the British computer scientist Tony Hoare in 1959. When implemented well, quick sort algorithm can be two or three times faster than its predecessors and competitors such as merge sort, which is why it gains its name. 

 
Intuition
Following the pseudocode template of the divide-and-conquer algorithm, as we presented before, the quick sort algorithm can be implemented in three steps, namely dividing the problem, solving the subproblems and combining the results of subproblems.

In detail, given a list of values to sort, the quick sort algorithm works in the following steps:

First, it selects a value from the list, which serves as a pivot value to divide the list into two sublists. One sublist contains all the values that are less than the pivot value, while the other sublist contains the values that are greater than or equal to the pivot value. This process is also called partitioning. The strategy of choosing a pivot value can vary. Typically, one can choose the first element in the list as the pivot, or randomly pick an element from the list.

After the partitioning process, the original list is then reduced into two smaller sublists. We then recursively sort the two sublists.

After the partitioning process, we are sure that all elements in one sublist are less or equal than any element in another sublist. Therefore, we can simply concatenate the two sorted sublists that we obtain in step [2] to obtain the final sorted list. 
The base cases of the recursion in step [2] are either when the input list is empty or contains only a single element. In either case, the input list can be considered as sorted already.

As one can see, the essential idea of the quick sort algorithm is the partitioning process, which elegantly reduces the problems into smaller scale and meanwhile moves towards the final solution, i.e. after each partitioning, the overall values become more ordered. 

 
Algorithm
In the following figure, we demonstrate how the quick sort algorithm works to sort a list of integer values. The input list contains 8 elements.

 



Fig.1 Quick Sort Illustration (elements in color are pivots)

 

As shown above, in the first round of quick sort, we pick the last element 4 as the pivot, which partitions the original list into two sublists: [1, 3, 2] and [8, 7, 6, 5] respectively.

Next, we recursively sort the above two sublists. For instance, for the sublist [1, 3, 2], again we pick the last element (i.e. 2) as the pivot value. After this partitioning, we obtain two sublists with a single element, which is the base case of the recursion.

Once we sorted the sublists [1, 3, 2] and [8, 7, 6, 5] respectively, we simply concatenate the sorted results together with the pivot value (4) to form the final result, i.e. [1, 2, 3] + [4] + [5, 6, 7, 8].

Here is the sample implementation of the quick sort algorithm.

```cshrp
public class Solution 
{
    public void QuickSort(int[] lst) 
    {
        /* Sorts an array in ascending order in O(n log n) time */
        int n = lst.Length;
        QSort(lst, 0, n - 1);
    }

    private void QSort(int[] lst, int lo, int hi) 
    {
        if (lo < hi) 
        {
            int p = Partition(lst, lo, hi);
            QSort(lst, lo, p - 1);
            QSort(lst, p + 1, hi);
        }
    }

    private int Partition(int[] lst, int lo, int hi) 
    {
        /*
        Picks the last element hi as a pivot
        and returns the index of pivot value in the sorted array */
        int pivot = lst[hi];
        int i = lo;
        for (int j = lo; j < hi; ++j) 
        {
            if (lst[j] < pivot) 
            {
                // Swap elements at i and j
                (lst[i], lst[j]) = (lst[j], lst[i]);
                i++;
            }
        }
        // Swap pivot to its correct position
        (lst[i], lst[hi]) = (lst[hi], lst[i]);
        return i;
    }
}
```
Complexity
Depending on the pivot values, the time complexity of the quick sort algorithm can vary from 
O
(
N
log
⁡
2
N
)
O(Nlog 
2
​
 N) in the best case and 
O
(
N
2
)
O(N 
2
 ) in the worst case, with 
N
N as the length of the list.

In the best case, if the pivot value happens to be median value of the list, then at each partition the list would be divided into two sublists of equal size. At the end, we actually construct a balanced binary search tree (BST) out of the list. One can infer that the height of the tree would be 
log
⁡
2
N
log 
2
​
 N, and at each level of the tree the input list would be scanned once with the complexity 
O
(
N
)
O(N) due to the partitioning process. As a result, the overall time complexity of the algorithm in this case would be 
O
(
N
log
⁡
2
N
)
O(Nlog 
2
​
 N).

While in the worst case, if the pivot value happens to be the extreme value of the list, i.e. either the smallest or the biggest element in the list, then at each partition we end up with only one single sublist (i.e. the other sublist is empty). The reduction of the problem still works, but at a rather slow pace, i.e. one element at a time. The partitioning would then occur 
N
N times, and each time the partitioning scans at most 
N
N elements. Therefore, the overall time complexity of the quick sort algorithm in this case would be 
O
(
N
2
)
O(N 
2
 ). Actually, in this case, the quick sort algorithm ends up to be exactly as the insertion sort.

On average, as proved mathematically, the time complexity of quick sort is 
O
(
N
log
⁡
N
)
O(NlogN).  

Next
There are common patterns while analyzing the time complexity of many divide-and-conquer algorithms. In the next article, we will present a theoretical tool called master theorem, which can help us to obtain the complexity of certain divide-and-conquer algorithms simply by applying a mathematical formula.

## Master Theorem

Other than evaluating the time complexity of recursion algorithms case by case, sometimes you can apply a method called Master Theorem to quickly calculate the time complexity of many recursion algorithms. 

Master Theorem, also known as Master Method, provides asymptotic analysis (i.e. the time complexity) for many of the recursion algorithms that follow the pattern of divide-and-conquer. 

Note that Master Theorem is an advanced technique to estimate the time complexity of certain recursive algorithms. It does not apply to all recursion algorithms. Certainly, one is not expected to memorize by heart all the formulas involved in Master Theorem during the interviews.

```cshrp
using System;
using System.Collections.Generic;

public class DivideAndConquer
{
    private const int K = 10; // Threshold for direct solution

    // Generic divide-and-conquer function
    public T DAC<T>(T problem, Func<T, bool> isBaseCase, Func<T, T> solveDirectly, 
                   Func<T, List<T>> divide, Func<List<T>, T> combine)
    {
        // Base case: if problem is small enough, solve directly
        if (isBaseCase(problem))
        {
            return solveDirectly(problem);
        }

        // [1] Divide the problem into subproblems
        List<T> subproblems = divide(problem);

        // [2] Solve subproblems recursively
        List<T> results = new List<T>();
        foreach (var subproblem in subproblems)
        {
            results.Add(DAC(subproblem, isBaseCase, solveDirectly, divide, combine));
        }

        // [3] Combine the results
        return combine(results);
    }

    // Example: Calculating sum of array using divide-and-conquer
    public int Sum(int[] array)
    {
        return DAC(
            problem: array,
            isBaseCase: arr => arr.Length <= K,
            solveDirectly: arr => {
                int sum = 0;
                foreach (int num in arr) sum += num;
                return sum;
            },
            divide: arr => {
                int mid = arr.Length / 2;
                return new List<int[]> { 
                    arr[..mid], 
                    arr[mid..] 
                };
            },
            combine: results => results[0] + results[1]
        );
    }

    // Example usage
    public static void Main()
    {
        var dc = new DivideAndConquer();
        int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15};
        int total = dc.Sum(numbers);
        Console.WriteLine($"The sum is: {total}");
    }
}
```

For the recursion algorithms that follow the above pattern, one can apply the master theorem to calculate their time complexity. 

If we define the time complexity of the above recursion algorithm as 
T
(
n
)
T(n), then we can express it as follows:

T
(
n
)
=
a
⋅
T
(
n
b
)
+
f
(
n
)
T(n)=a⋅T( 
b
n
​
 )+f(n)

where 
f
(
n
)
f(n) is the time complexity that it takes to divide the problems into subproblems and also to combine the results from the subproblems. We can further represent 
f
(
n
)
f(n) as 
O
(
n
d
)
O(n 
d
 ) and 
d
≥
0
d≥0.  

Then, Master Theorem provides us three formulas to calculate the time complexity of the recursion algorithm, according to the relationship among 
a
,
b
,
d
a,b,d. They are stated as follows:

 

if 
a
>
b
d
a>b 
d
  i.e. 
d
<
log
⁡
b
a
=
log
⁡
2
a
log
⁡
2
b
d<log 
b
​
 a= 
log 
2
​
 b
log 
2
​
 a
​
 , then 
T
(
n
)
=
O
(
n
log
⁡
b
a
)
T(n)=O(n 
log 
b
​
 a
 );

if 
a
=
b
d
a=b 
d
  i.e. 
d
=
log
⁡
b
a
=
log
⁡
2
a
log
⁡
2
b
d=log 
b
​
 a= 
log 
2
​
 b
log 
2
​
 a
​
 , then 
T
(
n
)
=
O
(
n
d
log
⁡
n
)
=
O
(
n
log
⁡
b
a
log
⁡
n
)
T(n)=O(n 
d
 logn)=O(n 
log 
b
​
 a
 logn);

if 
a
<
b
d
a<b 
d
  i.e. 
d
>
log
⁡
b
a
=
log
⁡
2
a
log
⁡
2
b
d>log 
b
​
 a= 
log 
2
​
 b
log 
2
​
 a
​
 , then  
T
(
n
)
=
O
(
n
d
)
T(n)=O(n 
d
 );
 

The conditions for each case correspond to the intuition of whether the work to split problems and combine results (i.e. 
f
(
n
)
f(n)) outweighs the work of subproblems (i.e. 
a
⋅
T
(
n
b
)
a⋅T( 
b
n
​
 )).

For example, in case (1), the work to split problems and combine results is dwarfed by the subproblems. Therefore, the time complexity of the overall recursion algorithm can be reduced to the complexity of the subproblems (i.e. 
a
⋅
T
(
n
b
)
a⋅T( 
b
n
​
 )). 

We list a few examples that correspond to each of the above cases in the rest of the article. 

 

Examples
Case 1)
T
(
n
)
=
O
(
n
log
⁡
b
a
)
T(n)=O(n 
log 
b
​
 a
 )

Binary tree traversal related algorithms are the algorithms where one needs to traverse a binary tree in order to solve the problem. Often you can apply a strategy named Depth-First Search (DFS) to traverse the binary tree, which can be implemented as a recursion algorithm and fits the pattern as we described above. Here is one example, Maximum Depth of Binary Tree, where you have to find the maximum depth for a given binary tree.

In a DFS recursion algorithm, first we divide the problem into two halves at each recursion, i.e. left child and right child, then we make a recursion call for each of the two subproblems, and finally, we combine the results from the two recursion calls.

According to the pattern that we describe at the beginning of the article, for DFS recursion algorithms, we then can figure out the values for the parameters in Master Theorem,  i.e. 
b
=
2
b=2 (problem divided into halves), 
a
=
2
a=2 (both subproblems needed to be solved), and 
f
(
n
)
=
O
(
1
)
f(n)=O(1) therefore 
d
=
0
d=0. In particular, the reason behind 
f
(
n
)
=
O
(
1
)
f(n)=O(1) is twofold: 1). The effort to split the problems in DFS is constant, since the input is already organized as a collection of subproblems, i.e. children subtrees. 2). The effort to combine the results from the recursion calls is also constant.  

As a result, by applying the Master Theorem, we can obtain the time complexity of DFS recursion algorithm, as follows:

Since 
a
=
2
,
b
=
2
,
d
=
0
a=2,b=2,d=0, so 
d
<
log
⁡
b
a
d<log 
b
​
 a, i.e. 
0
<
log
⁡
2
2
=
1
0<log 
2
​
 2=1, therefore 
T
(
n
)
=
O
(
n
log
⁡
b
a
)
=
O
(
n
)
T(n)=O(n 
log 
b
​
 a
 )=O(n)

As many of you know, the time complexity for DFS recursion algorithm is indeed 
O
(
n
)
O(n), since we visit each node in the tree one by one during DFS, which is consistent with the complexity estimation obtained by applying the Master Theorem.

 
Case 2)
 
T
(
n
)
=
O
(
n
d
log
⁡
n
)
=
O
(
n
log
⁡
b
a
log
⁡
n
)
T(n)=O(n 
d
 logn)=O(n 
log 
b
​
 a
 logn)

Binary search, is a search algorithm that finds the position of the target value in a sorted array. The algorithm would divide the size of the problem into halves at each iteration, and then focus on one of the halves subproblems. One can find a similar problem here.

According to the pattern, for binary search algorithm, we can figure out the values for the parameters in Master Theorem, i.e. 
b
=
2
b=2 (problem divided into halves), 
a
=
1
a=1 (only one of the subproblems needed to be solved), and 
f
(
n
)
=
O
(
1
)
f(n)=O(1) therefore 
d
=
0
d=0. The reason why 
f
(
n
)
=
O
(
1
)
f(n)=O(1) is twofold: 1). The effort to split the problem into halves could be constant, since the given input is a sorted array and one can refer to a range of elements simply by index without iterating through the array; 2). The effort to combine the results of subproblems is constant as well in this case, since we can simply return the result of subproblem without any further processing.

As a result, by applying the Master Theorem, we can obtain the time complexity of binary search algorithm, as follows:

Since 
a
=
1
,
b
=
2
,
d
=
0
a=1,b=2,d=0, so 
d
=
log
⁡
b
a
d=log 
b
​
 a i.e. 
0
=
log
⁡
2
1
0=log 
2
​
 1, therefore 
T
(
n
)
=
O
(
n
d
log
⁡
n
)
=
O
(
log
⁡
n
)
T(n)=O(n 
d
 logn)=O(logn)

As many of you know, the time complexity of binary search algorithm is indeed 
O
(
log
⁡
n
)
O(logn). Once again, the result complies with the Master Theorem.

Another example that falls into this category, is called merge sort, whose time complexity is 
O
(
n
log
⁡
n
)
O(nlogn).

 
Case 3)
T
(
n
)
=
O
(
n
d
)
T(n)=O(n 
d
 )

This case is a bit tricky. Here, the efforts of dividing problems and aggregating results overweight the efforts of solving subproblems.

One of the examples that fall into this case would be the quickselect, which is an algorithm that selects the kth largest/smallest element in an unsorted list (one can also find the problem here). Similar to the binary search algorithm, quickselect algorithm partitions the input list with certain pivot, which eventually reduces the problem into a smaller scale.

Let's assume that each time the algorithm partitions the input into halves exactly, i.e. the chosen pivot is the median of the input, so its complexity can be expressed with the Master Theorem as 
T
(
n
)
=
T
(
n
2
)
+
O
(
n
)
T(n)=T( 
2
n
​
 )+O(n), where 
a
=
1
a=1 since we only need to look into one of the partitions and 
b
=
2
b=2 since the input is divided into halves, and finally 
d
=
1
d=1 since it takes 
O
(
n
)
O(n) complexity to partition the input each time. As a result,  
d
=
1
>
log
⁡
2
1
d=1>log 
2
​
 1, it falls into the case 3 of the Master Theorem. The case where the chosen pivot is the median of the input can be considered as the average case for the quickselect algorithm, which usually selects the pivot by random. Therefore, the expected time complexity of quickselect is 
O(nd)=O(n)O(nd)=O(n), by applying the Master Theorem. 

Other cases, where the sizes of subproblems are different. 

Master Theorem has its limitations though, since it only applies to the cases where the subproblems are of equal size. Now as it might come to your mind, we cannot apply the Master Theorem to the recursion algorithm for our Fibonacci number. As a reminder, here is the recurrence relation for Fibonacci number: 
F(n)=F(n−1)+F(n−2), where the problem is divided into two subproblems of different size.

In this case, to estimate the time complexity, we can resort to the Akra-Bazzi Theorem, also known as Akra-Bazzi method, which is a generalization of Master Theorem in order to deal with cases where subproblems are of different size. 

Further Readings
- The original paper of Master Theorem, by Bentley, Jon Louis; Haken, Dorothea; Saxe, James B.(September 1980), "A general method for solving divide-and-conquer recurrences"
- Akra-Bazzi Theorem, a generalization of Master Theorem, where subproblems can have different sizes. 

## Backtracking
In this article, we introduce another paradigm called backtracking, which is also often implemented in the form of recursion.

Backtracking is a general algorithm for finding all (or some) solutions to some computational problems (notably Constraint satisfaction problems or CSPs), which incrementally builds candidates to the solution and abandons a candidate ("backtracks") as soon as it determines that the candidate cannot lead to a valid solution. [1] 

Conceptually, one can imagine the procedure of backtracking as the tree traversal. Starting from the root node, one sets out to search for solutions that are located at the leaf nodes. Each intermediate node represents a partial candidate solution that could potentially lead us to a final valid solution. At each node, we would fan out to move one step further to the final solution, i.e. we iterate the child nodes of the current node. Once we can determine if a certain node cannot possibly lead to a valid solution, we abandon the current node and backtrack to its parent node to explore other possibilities. It is due to this backtracking behaviour, the backtracking algorithms are often much faster than the brute-force search [2] algorithm, since it eliminates many unnecessary exploration. 

Example 1
Let's try to understand the concept of backtracking by a very basic example. We are given a set of words represented in the form of a tree. The tree is formed such that every branch ends in a word.

Word Tree

Our task is to find out if a given word is present in the tree. Let's say we have to search for the word AIM. A very brute way would be to go down all the paths, find out the word corresponding to a branch and compare it with what you are searching for. You will keep doing this unless you have found out the word you were looking for.

Brute

In the diagram above our brute approach made us go down the path for ANT and AND before it finally found the right branch for the word AIM.

The backtracking way of solving this problem would stop going down a path when the path doesn't seem right. When we say the path doesn't seem right we mean we come across a node which will never lead to the right result. As we come across such node we back-track. That is go back to the previous node and take the next step.

Brute

In the above diagram backtracking didn't make us go down the path from node N. This is because there is a mismatch we found early on and we decided to go back to the next step instead. Backtracking reduced the number of steps taken to reach the final result. This is known as pruning the recursion tree because we don't take unnecessary paths.

Example 2
One of the most classical problems that can be solved with the backtracking algorithm is the N-Queen puzzle.

The N-queens puzzle is the problem of placing 
N
N queens on an 
[
N
×
N
]
[N×N] chessboard such that no two queens can attack each other. One is asked to count the number of solutions to place the 
N
N queens on the board. 

As a reminder, a queen can attack any piece that is situated at the same row, column or diagonal as the queen. As shown in the board below, if we place a queen at the row 1 and column 1 of the board, we then cross out all the cells that could be attacked by this queen. 

In order to count the number of possible solutions to place the N queens, we can break it down into the following steps:

        (1). Overall, we iterate over each row in the board, i.e. once we reach the last row of the board, we should have explored all the possible solutions.

        (2). At each iteration (we are located at certain row), we then further iterate over each column of the board, along the current row. At this second iteration, we then can explore the possibility of placing a queen on a particular cell.

        (3). Before, we place a queen on the cell with index of (row, col), we need to check if this cell is under the attacking zone of the queens that have been placed on the board before. Let us assume there is a function called is_not_under_attack(row, col) that can do the check.

        (4). Once the check passes, we then can proceed to place a queen. Along with the placement, one should also mark out the attacking zone of this newly-placed queen. Let us assume there is another function called place_queen(row, col) that can help us to do so.

        (5). As an important behaviour of backtracking, we should be able to abandon our previous decision at the moment we decide to move on to the next candidate. Let us assume there is a function called remove_queen(row, col) that can help us to revert the decision along with the changes in step (4). 
```cshrp
using System;

public class NQueensSolver
{
    private int n;
    private int[] queens; // queens[row] = column position of queen in that row
    private int[] cols;   // columns that are under attack
    private int[] diag1;  // diagonal 1 (top-left to bottom-right) under attack
    private int[] diag2;  // diagonal 2 (top-right to bottom-left) under attack

    public NQueensSolver(int size)
    {
        n = size;
        queens = new int[n];
        cols = new int[n];
        diag1 = new int[2 * n - 1]; // number of diagonals of type 1
        diag2 = new int[2 * n - 1]; // number of diagonals of type 2
    }

    public int Solve()
    {
        return BacktrackNQueen();
    }

    private int BacktrackNQueen(int row = 0, int count = 0)
    {
        for (int col = 0; col < n; col++)
        {
            // iterate through columns at the current row
            if (IsNotUnderAttack(row, col))
            {
                // explore this partial candidate solution
                PlaceQueen(row, col);
                
                if (row + 1 == n)
                {
                    // we reach the bottom, i.e. we find a solution!
                    count++;
                }
                else
                {
                    // we move on to the next row
                    count = BacktrackNQueen(row + 1, count);
                }
                
                // backtrack, i.e. remove the queen
                RemoveQueen(row, col);
            }
        }
        return count;
    }

    private bool IsNotUnderAttack(int row, int col)
    {
        return cols[col] == 0 && diag1[row - col + n - 1] == 0 && diag2[row + col] == 0;
    }

    private void PlaceQueen(int row, int col)
    {
        queens[row] = col;
        cols[col] = 1;
        diag1[row - col + n - 1] = 1; // mark diagonal 1
        diag2[row + col] = 1;        // mark diagonal 2
    }

    private void RemoveQueen(int row, int col)
    {
        queens[row] = 0;
        cols[col] = 0;
        diag1[row - col + n - 1] = 0; // unmark diagonal 1
        diag2[row + col] = 0;         // unmark diagonal 2
    }
}

// Usage example:
// var solver = new NQueensSolver(8); // for 8-queens problem
// int solutions = solver.Solve();
// Console.WriteLine($"Number of solutions: {solutions}");
```
Now, with the above steps and functions, we can organize them in the form of recursion in order to implement the algorithm. In the following, we present the pseudocode of the backtracking algorithm.

By filling out those above-mentioned functions, one should be able to implement his/her own algorithm to solve the N-queen problem. Note: one can find the exercise of N-queen problem later in this chapter.

## Backtracking Template

In this article, we will present you a pseudocode template that summarizes some common patterns for the backtracking algorithms. Furthermore, we will demonstrate with some concrete examples on how to apply the template. 

Template
With the N-queen example as we presented in the previous article, one might have noticed some patterns about the backtracking algorithm. In the following, we present you a pseudocode template, which could help you to clarify the idea and structure the code when implementing the backtracking algorithms.

```cshrp
using System;
using System.Collections.Generic;

public class BacktrackingTemplate<T>
{
    // These are the functions that need to be implemented for specific problems
    protected virtual bool FindSolution(T candidate) { /* implementation for specific problem */ }
    protected virtual void Output(T candidate) { /* implementation for specific problem */ }
    protected virtual IEnumerable<T> ListOfCandidates(T current) { /* implementation for specific problem */ }
    protected virtual bool IsValid(T candidate) { /* implementation for specific problem */ }
    protected virtual void Place(T candidate) { /* implementation for specific problem */ }
    protected virtual void Remove(T candidate) { /* implementation for specific problem */ }

    public void Backtrack(T candidate)
    {
        if (FindSolution(candidate))
        {
            Output(candidate);
            return;
        }

        // Iterate all possible candidates
        foreach (var nextCandidate in ListOfCandidates(candidate))
        {
            if (IsValid(nextCandidate))
            {
                // Try this partial candidate solution
                Place(nextCandidate);
                
                // Given the candidate, explore further
                Backtrack(nextCandidate);
                
                // Backtrack
                Remove(nextCandidate);
            }
        }
    }
}
```
To use this template for a specific problem (like N-Queens), you would create a derived class:

csharp

```cshrp
public class NQueensSolver : BacktrackingTemplate<int[]>
{
    private int n;
    private int[] queens;
    private int[] cols;
    private int[] diag1;
    private int[] diag2;
    private int solutionCount = 0;

    public NQueensSolver(int size)
    {
        n = size;
        queens = new int[n];
        cols = new int[n];
        diag1 = new int[2 * n - 1];
        diag2 = new int[2 * n - 1];
    }

    protected override bool FindSolution(int[] candidate)
    {
        // Solution found when we've placed queens in all rows
        return candidate.Length == n;
    }

    protected override void Output(int[] candidate)
    {
        solutionCount++;
        // Could print the solution here if desired
    }

    protected override IEnumerable<int[]> ListOfCandidates(int[] current)
    {
        int row = current.Length;
        for (int col = 0; col < n; col++)
        {
            var newCandidate = new int[row + 1];
            Array.Copy(current, newCandidate, row);
            newCandidate[row] = col;
            yield return newCandidate;
        }
    }

    protected override bool IsValid(int[] candidate)
    {
        int row = candidate.Length - 1;
        int col = candidate[row];
        
        // Check column
        for (int i = 0; i < row; i++)
        {
            if (candidate[i] == col) return false;
            if (Math.Abs(candidate[i] - col) == row - i) return false;
        }
        return true;
    }

    protected override void Place(int[] candidate)
    {
        // For N-Queens, placement is handled in the candidate generation
    }

    protected override void Remove(int[] candidate)
    {
        // For N-Queens, removal is handled by backtracking to previous candidate
    }

    public int Solve()
    {
        Backtrack(Array.Empty<int>());
        return solutionCount;
    }
}

// Usage:
// var solver = new NQueensSolver(8);
// int count = solver.Solve();
// Console.WriteLine($"Number of solutions: {count}");
```
Here are a few notes about the above pseudocode.

Overall, the enumeration of candidates is done in two levels: 1). at the first level, the function is implemented as recursion. At each occurrence of recursion, the function is one step further to the final solution.  2). as the second level, within the recursion, we have an iteration that allows us to explore all the candidates that are of the same progress to the final solution.

The backtracking should happen at the level of the iteration within the recursion. 

Unlike brute-force search, in backtracking algorithms we are often able to determine if a partial solution candidate is worth exploring further (i.e. is_valid(next_candidate)), which allows us to prune the search zones. This is also known as the constraint, e.g. the attacking zone of queen in N-queen game. 

There are two symmetric functions that allow us to mark the decision (place(candidate)) and revert the decision (remove(candidate)).  
In the next sections, we show some concrete examples and explain how to apply the above pseudocode template.

Robot Room Cleaner
Given a room that is represented as a grid of cells, where each cell contains a value that indicates whether it is an obstacle or not, we are asked to clean the room with a robot cleaner which can turn in four directions and move one step at a time. 

This is a typical problem that can be solved with the backtracking paradigm, as many of you might have figured out from the description of the problem.

Before diving into the algorithm, to facilitate the explanation, we plot a figure below with the grid of room and the movements of robot. As one can see, the robot is denoted as the red dot and each step that the robot takes is marked as a footprint.

Fig 1. Robot Room Cleaner

We give the general idea below on how one can apply the above pseudocode template to implement a backtracking algorithm.

- [1]. One can model each step of the robot as a recursive function (i.e. backtrack()).

- [2]. At each step, technically the robot would have four candidates of direction to explore, e.g. the robot located at the coordinate of (0, 0). Since not each direction is available though, one should check if the cell in the given direction is an obstacle or it has been cleaned before, i.e. is_valid(candidate). Another benefit of the check is that it would greatly reduce the number of possible paths that one needs to explore.

- [3]. Once the robot decides to explore the cell in certain direction, the robot should mark its decision (i.e. place(candidate)). More importantly, later the robot should be able to revert the previous decision (i.e. remove(candidate)), by going back to the cell and restore its original direction.

- [4]. The robot conducts the cleaning step by step, in the form of recursion of the backtrack() function. The backtracking would be triggered whenever the robot reaches a point that it is surrounded either by the obstacles (e.g. cell at the row 1 and the column -3) or the cleaned cells. At the end of the backtracking, the robot would get back to the its starting point, and each cell in the grid would be traversed at least once. As a result, the room is cleaned at the end.

Sudoku Solver
Sudoku is a popular game that many of you are familiar with. The main idea of the game is to fill a grid with only the numbers from 1 to 9, while ensuring that each row and each column as well as each sub-grid of 9 elements does not contain duplicate numbers.

Fig 2. Sudoku Game

Once again, from the description of the Sudoku problem, one might have noticed the characteristics that hint on the solution of backtracking, such as the recursive nature of problem, a number of candidate solutions and some rules to filter out the candidates etc.

Indeed, we could solve the problem with the paradigm of backtracking. We break down on how to apply the backtracking template to implement a sudoku solver in the following.

- [1]. Given a grid with some pre-filled numbers, the task is to fill the empty cells with the numbers that meet the constraint of Sudoku game. We could model the each step to fill an empty cell as a recursion function (i.e. our famous backtrack() function).

- [2]. At each step, technically we have 9 candidates at hand to fill the empty cell. Yet, we could filter out the candidates by examining if they meet the rules of the Sudoku game, (i.e. is_valid(candidate)).

- [3]. Then, among all the suitable candidates, we can try out one by one by filling the cell (i.e. place(candidate)). Later we can revert our decision (i.e. remove(candidate)), so that we could try out the other candidates.

- [4]. The solver would carry on one step after another, in the form of recursion by the backtrack function. The backtracking would be triggered at the points where either the solver cannot find any suitable candidate (as shown in the above figure), or the solver finds a solution to the problem. At the end of the backtracking, we would enumerate all the possible solutions to the Sudoku game. 

Note: one can find the exercises to the above example within this chapter. One can try out the exercises with the above pseudocode template.

## Unfold Recursion
In this article, we illustrate how to convert a recursion algorithm to non-recursion one, i.e. unfold the recursion.

Recursion could be an elegant and intuitive solution, when applied properly. Nevertheless, sometimes, one might have to convert a recursive algorithm to iterative one for various reasons.

Risk of Stackoverflow

    The recursion often incurs additional memory consumption on the system stack, which is a limited resource for each program. If not used properly, the recursion algorithm could lead to stackoverflow. One might argue that a specific type of recursion called tail recursion could solve this problem. Unfortunately, not every recursion can be converted to tail recursion, and not every compiler supports the optimization of the tail recursion.

Efficiency

    Along with the additional memory consumption, the recursion could impose at least the additional cost of function calls, and in a worse case duplicate calculation, i.e. one of the caveats of recursion that we discussed previously in the Explore card of Recursion I.  

Complexity

    The nature of recursion is quite close to the mathematics, which is why the recursion appears to be more intuitive and comprehensive for many people. However, when we abuse the recursion, the recursive program could become more difficult to read and understand than the non-recursive one, e.g. nested recursion etc.

The good news is that we can always convert a recursion to iteration. In order to do so, in general, we use a data structure of stack or queue, which replaces the role of the system call stack during the process of recursion. 

In the next section, we will show you some examples on how to convert the recursion to iteration. 

Example
The problem that we would like to solve here is to determine if two binary trees are the same or not. Here is the description of the problem. 

Given two binary trees, write a function to check if they are the same or not.

Two binary trees are considered the same if they are structurally identical and the nodes have the same value.

First, let us start with a recursive solution. 
```cshrp
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public bool IsSameTree(TreeNode p, TreeNode q) {
        // p and q are both null
        if (p == null && q == null) return true;
        // one of p and q is null
        if (p == null || q == null) return false;
        // values don't match
        if (p.val != q.val) return false;
        // recursively check subtrees
        return IsSameTree(p.right, q.right) && 
               IsSameTree(p.left, q.left);
    }
}
```
As one can see, the above recursion approach is rather intuitive, which follows directly the definition of the problem. Given two nodes, first, we check if the values of the nodes are equal. If this is the case, we then recursively check the left and right child nodes of the given input nodes.

For comparison, here are some sample solutions that convert the above recursion approach to iteration. 
```cshrp
using System.Collections.Generic;

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Solution {
    private bool Check(TreeNode p, TreeNode q) {
        // Both nodes are null
        if (p == null && q == null) return true;
        // One of the nodes is null
        if (p == null || q == null) return false;
        // Values don't match
        if (p.val != q.val) return false;
        return true;
    }

    public bool IsSameTree(TreeNode p, TreeNode q) {
        if (p == null && q == null) return true;
        if (!Check(p, q)) return false;
        
        // Initialize queues for BFS traversal
        Queue<TreeNode> queueP = new Queue<TreeNode>();
        Queue<TreeNode> queueQ = new Queue<TreeNode>();
        queueP.Enqueue(p);
        queueQ.Enqueue(q);

        while (queueP.Count > 0) {
            p = queueP.Dequeue();
            q = queueQ.Dequeue();

            if (!Check(p, q)) return false;
            
            if (p != null) {
                // Check left children
                if (!Check(p.left, q.left)) return false;
                if (p.left != null) {
                    queueP.Enqueue(p.left);
                    queueQ.Enqueue(q.left);
                }
                
                // Check right children
                if (!Check(p.right, q.right)) return false;
                if (p.right != null) {
                    queueP.Enqueue(p.right);
                    queueQ.Enqueue(q.right);
                }
            }
        }
        return true;
    }
}
```
To convert a recursion approach to an iteration one, we could perform the following two steps:

We use a stack or queue data structure within the function, to replace the role of the system call stack. At each occurrence of recursion, we simply push the parameters as a new element into the data structure that we created, instead of invoking a recursion.

In addition, we create a loop over the data structure that we created before. The chain invocation of recursion would then be replaced with the iteration within the loop.
 
Next
In the rest of the chapters, one can find some more problems to practice on. One can try to implement both recursion and iteration approaches for each problem.

## Beyond Recursion

In this card, we introduced the paradigms of divide-and-conquer and backtracking, which often implemented in the form of recursion. Each of the paradigms is well suited for certain types of problems. In this article, we give a brief summary of these paradigms and highlight their differences. 

In the rest of the chapter, we list a few more exercises for one to practice these paradigms. If you have any doubt or question, you can always make a post in the Forum that is located at the end of the card. We will try our best to get back to you as soon as possible.

Divide and Conquer
A divide-and-conquer algorithm works by recursively breaking the problem down into two or more subproblems of the same or related type, until these subproblems become simple enough to be solved directly [1]. Then one combines the results of subproblems to form the final solution.
 
Backtracking
Backtracking is a general algorithm for finding all (or some) solutions to some computational problems (notably constraint satisfaction problems), which incrementally builds candidates to the solution and abandons a candidate ("backtracks") as soon as it determines that the candidate cannot leads to a valid solution. [2]

Divide and Conquer VS. Backtracking 
Often the case, the divide-and-conquer problem has a sole solution, while the backtracking problem has unknown number of solutions. For example, when we apply the merge sort algorithm to sort a list, we obtain a single sorted list, while there are many solutions to place the queens for the N-queen problem.

Each step in the divide-and-conquer problem is indispensable to build the final solution, while many steps in backtracking problem might not be useful to build the solution, but serve as attempts to search for the potential solutions. For example, each step in the merge sort algorithm, i.e. divide, conquer and combine, are all indispensable to build the final solution, while there are many trials and errors during the process of building solutions for the N-queen problem.

When building the solution in the divide-and-conquer algorithm, we have a clear and predefined path, though there might be several different manners to build the path. While in the backtracking problems, one does not know in advance the exact path to the solution. For example, in the top-down merge sort algorithm, we first recursively divide the problems into two subproblems and then combine the solutions of these subproblems. The steps are clearly defined and the number of steps is fixed as well. While in the N-queen problem, if we know exactly where to place the queens, it would only take N steps to do so. When applying the backtracking algorithm to the N-queen problem, we try many candidates and many of them do not eventually lead to a solution but abandoned at the end. As a result, we do not know beforehand how many steps exactly it would take to build a valid solution. 
