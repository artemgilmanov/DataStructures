## What is Dynamic Programming?

Dynamic Programming (DP) is a programming paradigm that can systematically and efficiently explore all possible solutions to a problem.
As such, it is capable of solving a wide variety of problems that often have the following characteristics:

The problem can be broken down into "overlapping subproblems" - smaller versions of the original problem that are re-used multiple times.
The problem has an "optimal substructure" - an optimal solution can be formed from optimal solutions to the overlapping subproblems of the original problem.
As a beginner, these theoretical definitions may be hard to wrap your head around. Don't worry though - at the end of this chapter, we'll talk about how to practically spot when DP is applicable.
For now, let's look a little deeper at both characteristics.

The Fibonacci sequence is a classic example used to explain DP. For those who are unfamiliar with the Fibonacci sequence, it is a sequence of numbers that starts with 0, 1, and each subsequent number is obtained by adding the previous two numbers together.

If you wanted to find the Fibonacci number F(n), you can break it down into smaller subproblems - find F(n−1) and F(n−2) instead.
Then, adding the solutions to these subproblems together gives the answer to the original question, F(n−1)+F(n−2)=F(n), which means the problem has optimal substructure, since a solution F(n) to the original problem can be formed from the solutions to the subproblems.
These subproblems are also overlapping - for example, we would need F(4) to calculate both F(5) and F(6).

These attributes may seem familiar to you. Greedy problems have optimal substructure, but not overlapping subproblems. Divide and conquer algorithms break a problem into subproblems, but these subproblems are not overlapping (which is why DP and divide and conquer are commonly mistaken for one another).

Dynamic programming is a powerful tool because it can break a complex problem into manageable subproblems, avoid unnecessary recalculation of overlapping subproblems, and use the results of those subproblems to solve the initial complex problem. DP not only aids us in solving complex problems, but it also greatly improves the time complexity compared to brute force solutions. For example, the brute force solution for calculating the Fibonacci sequence has exponential time complexity, while the dynamic programming solution will have linear time complexity because it reuses the results of subproblems rather than recalculating the results for previously seen subproblems.
The difference in work required by the brute force approach compared to the dynamic programming approach is visually demonstrated on the next page.

## Top-down and Bottom-up

There are two ways to implement a DP algorithm:

Bottom-up, also known as tabulation.
Top-down, also known as memoization.

Bottom-up (Tabulation)
Bottom-up is implemented with iteration and starts at the base cases. Let's use the Fibonacci sequence as an example again. The base cases for the Fibonacci sequence are F(0)=0 and F(1)=1. 
With bottom-up, we would use these base cases to calculate F(2), and then use that result to calculate F(3), and so on all the way up to F(n).

```cshrp
// Pseudocode example for top-down

memo = hashmap
Function F(integer i):
    if i is 0 or 1: 
        return i
    if i doesn't exist in memo:
        memo[i] = F(i - 1) + F(i - 2)
    return memo[i]
```

Top-down (Memoization)
Top-down is implemented with recursion and made efficient with memoization. If we wanted to find the Fibonacci number F(n), we try to compute this by finding F(n−1) and F(n−2).
This defines a recursive pattern that will continue on until we reach the base cases F(0)=F(1)=1.
The problem with just implementing it recursively is that there is a ton of unnecessary repeated computation. Take a look at the recursion tree if we were to find F(5):

Notice that we need to calculate F(2) three times.
This might not seem like a big deal, but if we were to calculate F(6), this entire image would be only one child of the root. Imagine if we wanted to find F(100) - the amount of computation is exponential and will quickly explode. The solution to this is to memoize results.

Memoizing a result means to store the result of a function call, usually in a hashmap or an array, so that when the same function call is made again, we can simply return the memoized result instead of recalculating the result.

After we calculate F(2), let's store it somewhere (typically in a hashmap), so in the future, whenever we need to find F(2), we can just refer to the value we already calculated instead of having to go through the entire tree again. Below is an example of what the recursion tree for finding F(6) looks like with and without memoization:

### Which is better?
Any DP algorithm can be implemented with either method, and there are reasons for choosing either over the other. However, each method has one main advantage that stands out:

A bottom-up implementation's runtime is usually faster, as iteration does not have the overhead that recursion does.
A top-down implementation is usually much easier to write. This is because with recursion, the ordering of subproblems does not matter, whereas with tabulation, we need to go through a logical ordering of solving subproblems.
We'll be talking more about these two options throughout the card. For now, all you need to know is that top-down uses recursion, and bottom-up uses iteration.

## When to Use DP

When it comes to solving an algorithm problem, especially in a high-pressure scenario such as an interview, half the battle is figuring out how to even approach the problem. 
In the first section, we defined what makes a problem a good candidate for dynamic programming. 
Recall:

The problem can be broken down into "overlapping subproblems" - smaller versions of the original problem that are re-used multiple times
The problem has an "optimal substructure" - an optimal solution can be formed from optimal solutions to the overlapping subproblems of the original problem
Unfortunately, it is hard to identify when a problem fits into these definitions. Instead, let's discuss some common characteristics of DP problems that are easy to identify.

The first characteristic that is common in DP problems is that the problem will ask for the optimum value (maximum or minimum) of something, or the number of ways there are to do something. 
For example:

What is the minimum cost of doing...
What is the maximum profit from...
How many ways are there to do...
What is the longest possible...
Is it possible to reach a certain point...
Note: Not all DP problems follow this format, and not all problems that follow these formats should be solved using DP.
However, these formats are very common for DP problems and are generally a hint that you should consider using dynamic programming.

When it comes to identifying if a problem should be solved with DP, this first characteristic is not sufficient. Sometimes, a problem in this format (asking for the max/min/longest etc.) is meant to be solved with a greedy algorithm.
The next characteristic will help us determine whether a problem should be solved using a greedy algorithm or dynamic programming.

The second characteristic that is common in DP problems is that future "decisions" depend on earlier decisions.
Deciding to do something at one step may affect the ability to do something in a later step.
This characteristic is what makes a greedy algorithm invalid for a DP problem - we need to factor in results from previous decisions.
Admittedly, this characteristic is not as well defined as the first one, and the best way to identify it is to go through some examples.

House Robber is an excellent example of a dynamic programming problem. The problem description is:

You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security systems connected and it will automatically contact the police if two adjacent houses were broken into on the same night.

Given an integer array nums representing the amount of money of each house, return the maximum amount of money you can rob tonight without alerting the police.

In this problem, each decision will affect what options are available to the robber in the future. For example, with the test case nums = [2, 7, 9, 3, 1], the optimal solution is to rob the houses with 9, and 1 money.
However, if we were to iterate from left to right in a greedy manner, our first decision would be whether to rob the first or second house.
7 is way more money than 2, so if we were greedy, we would choose to rob house 7.
However, this prevents us from robbing the house with 9 money. 
As you can see, our decision between robbing the first or second house affects which options are available for future decisions.

Longest Increasing Subsequence is another example of a classic dynamic programming problem.
In this problem, we need to determine the length of the longest (first characteristic) subsequence that is strictly increasing.
For example, if we had the input nums = [1, 2, 6, 3, 5], the answer would be 4, from the subsequence [1, 2, 3, 5]. 
Again, the important decision comes when we arrive at the 6 - do we take it or not take it? If we decide to take it, then we get to increase our current length by 1, but it affects the future - we can no longer take the 3 or 5.
Of course, with such a small example, it's easy to see why we shouldn't take it - but how are we supposed to design an algorithm that can always make the correct decision with huge inputs?
Imagine if nums contained 10,000 numbers instead.

When you're solving a problem on your own and trying to decide if the second characteristic is applicable, assume it isn't, then try to think of a counterexample that proves a greedy algorithm won't work.
If you can think of an example where earlier decisions affect future decisions, then DP is applicable.

To summarize: if a problem is asking for the maximum/minimum/longest/shortest of something, the number of ways to do something, or if it is possible to reach a certain point, it is probably greedy or DP.
With time and practice, it will become easier to identify which is the better approach for a given problem.
Although, in general, if the problem has constraints that cause decisions to affect other decisions, such as using one element prevents the usage of other elements, then we should consider using dynamic programming to solve the problem. 
These two characteristics can be used to identify if a problem should be solved with DP.

Note: these characteristics should only be used as guidelines - while they are extremely common in DP problems, at the end of the day DP is a very broad topic.

## Framework for DP Problems

Now that we understand the basics of DP and how to spot when DP is applicable to a problem, we've reached the most important part: actually solving the problem. In this section, we're going to talk about a framework for solving DP problems. This framework is applicable to nearly every DP problem and provides a clear step-by-step approach to developing DP algorithms.

For this article's explanation, we're going to use the problem Climbing Stairs as an example, with a top-down (recursive) implementation. Take a moment to read the problem description and understand what the problem is asking.

Before we start, we need to first define a term: state. In a DP problem, a state is a set of variables that can sufficiently describe a scenario. These variables are called state variables, and we only care about relevant ones. For example, to describe every scenario in Climbing Stairs, there is only 1 relevant state variable, the current step we are on. We can denote this with an integer i. 
If i = 6, that means that we are describing the state of being on the 6th step. Every unique value of i represents a unique state.

You might be wondering what "relevant" means here. Picture this problem in real life: you are on a set of stairs, and you want to know how many ways there are to climb to say, the 10th step. We're definitely interested in what step you're currently standing on. However, we aren't interested in what color your socks are. You could certainly include sock color as a state variable. Standing on the 8th step wearing green socks is a different state than standing on the 8th step wearing red socks. However, changing the color of your socks will not change the number of ways to reach the 10th step from your current position. Thus the color of your socks is an irrelevant variable. In terms of figuring out how many ways there are to climb the set of stairs, the only relevant variable is what stair you are currently on.

The Framework
To solve a DP problem, we need to combine 3 things:

A function or data structure that will compute/contain the answer to the problem for every given state.

For Climbing Stairs, let's say we have an function dp where dp(i) returns the number of ways to climb to the ith step.
Solving the original problem would be as easy as return dp(n).

How did we decide on the design of the function? The problem is asking "How many distinct ways can you climb to the top?", so we decide that the function will represent how many distinct ways you can climb to a certain step - literally the original problem, but generalized for a given state.

Typically, top-down is implemented with a recursive function and hash map, whereas bottom-up is implemented with nested for loops and an array. When designing this function or array, we also need to decide on state variables to pass as arguments. This problem is very simple, so all we need to describe a state is to know what step we are currently on i. We'll see later that other problems have more complex states.

A recurrence relation to transition between states.

A recurrence relation is an equation that relates different states with each other. Let's say that we needed to find how many ways we can climb to the 30th stair. Well, the problem states that we are allowed to take either 1 or 2 steps at a time. Logically, that means to climb to the 30th stair, we arrived from either the 28th or 29th stair. Therefore, the number of ways we can climb to the 30th stair is equal to the number of ways we can climb to the 28th stair plus the number of ways we can climb to the 29th stair.

The problem is, we don't know how many ways there are to climb to the 28th or 29th stair. However, we can use the logic from above to define a recurrence relation. In this case, dp(i) = dp(i - 1) + dp(i - 2). As you can see, information about some states gives us information about other states.

Upon careful inspection, we can see that this problem is actually the Fibonacci sequence in disguise! This is a very simple recurrence relation - typically, finding the recurrence relation is the most difficult part of solving a DP problem. We'll see later how some recurrence relations are much more complicated, and talk through how to derive them.

Base cases, so that our recurrence relation doesn't go on infinitely.

The equation dp(i) = dp(i - 1) + dp(i - 2) on its own will continue forever to negative infinity. We need base cases so that the function will eventually return an actual number.

Finding the base cases is often the easiest part of solving a DP problem, and just involves a little bit of logical thinking. When coming up with the base case(s) ask yourself: What state(s) can I find the answer to without using dynamic programming? In this example, we can reason that there is only 1 way to climb to the first stair (1 step once), and there are 2 ways to climb to the second stair (1 step twice and 2 steps once). Therefore, our base cases are dp(1) = 1 and dp(2) = 2.

We said above that we don't know how many ways there are to climb to the 28th and 29th stairs. However, using these base cases and the recurrence relation from step 2, we can figure out how many ways there are to climb to the 3rd stair. With that information, we can find out how many ways there are to climb to the 4th stair, and so on. Eventually, we will know how many ways there are to climb to the 28th and 29th stairs.

### Example Implementations 

```cshrp
public class Solution {
    // A function that represents the answer to the problem for a given state
    private int Dp(int i) {
        if (i <= 2) return i; // Base cases
        return Dp(i - 1) + Dp(i - 2); // Recurrence relation
    }

    public int ClimbStairs(int n) {
        return Dp(n);
    }
}
```

Do you notice something missing from the code? We haven't memoized anything! The code above has a time complexity of O(2n) because every call to dp creates 2 more calls to dp. If we wanted to find how many ways there are to climb to the 250th step, the number of operations we would have to do is approximately equal to the number of atoms in the universe.

In fact, without the memoization, this isn't actually dynamic programming - it's just basic recursion. Only after we optimize our solution by adding memoization to avoid repeated computations can it be called DP. As explained in chapter 1, memoization means caching results from function calls and then referring to those results in the future instead of recalculating them. This is usually done with a hashmap or an array.

```cshrp
using System.Collections.Generic;

public class Solution {
    private Dictionary<int, int> memo = new Dictionary<int, int>();
    
    private int Dp(int i) {
        if (i <= 2) return i;
        
        // Check if value is already computed
        if (!memo.ContainsKey(i)) {
            memo[i] = Dp(i - 1) + Dp(i - 2);
        }

        return memo[i];
    }

    public int ClimbStairs(int n) {
        return Dp(n);
    }
}
```
With memoization, our time complexity drops to O(n) - astronomically better, literally.

You may notice that a hashmap is overkill for caching here, and an array can be used instead. This is true, but using a hashmap isn't necessarily bad practice as some DP problems will require one, and they're hassle-free to use as you don't need to worry about sizing an array correctly. Furthermore, when using top-down DP, some problems do not require us to solve every single subproblem, in which case an array may use more memory than a hashmap.

We just talked a whole lot about top-down, but what about bottom-up? Everything is pretty much the same, except we will start from our base cases and iterate up to our final answer. As stated before, bottom-up implementations usually use an array, so we will use an array dp where dp[i] represents the number of ways to climb to the i th step.

```cshrp
public class Solution {
    public int ClimbStairs(int n) {
        if (n == 1) return 1;

        // Array to hold the results of subproblems
        int[] dp = new int[n + 1];
        dp[1] = 1; // Base case
        dp[2] = 2; // Base case

        for (int i = 3; i <= n; i++) {
            dp[i] = dp[i - 1] + dp[i - 2]; // Recurrence rela
```
Notice that the implementation still follows the framework exactly - the framework holds for both top-down and bottom-up implementations.


To Summarize
With DP problems, we can use logical thinking to find the answer to the original problem for certain inputs, in this case we reason that there is 1 way to climb to the first stair and 2 ways to climb to the second stair. We can then use a recurrence relation to find the answer to the original problem for any state, in this case for any stair number. Finding the recurrence relation involves thinking about how moving from one state to another changes the answer to the problem.

### Example 198. House Robber

This is the first of 6 articles where we will use a framework to work through example DP problems. The framework provides a blueprint to solve DP problems, but when you are just starting to learn DP, deriving some of the logic yourself may be difficult. The objective of these articles is to talk through how to use the framework to work through each problem, and our goal is that, by the end of this, you will be able to independently tackle most DP problems using this framework.

In this article, we will be looking at the House Robber problem. In an earlier section of this explore card, we talked about how House Robber fits the characteristics of a DP problem. It's asking for the maximum of something, and our current decisions will affect which options are available for our future decisions. Let's see how we can use the framework to develop an algorithm for this problem.

1. A function or array that answers the problem for a given state

First, we need to decide on state variables. As a reminder, state variables should be fully capable of describing a scenario. Imagine if you had this scenario in real life - you're a robber and you have a lineup of houses. If you are at one of the houses, the only variable you would need to describe your situation is an integer - the index of the house you are currently at. Therefore, the only state variable is an integer, say i, that indicates the index of a house.

If the problem had an added constraint such as "you are only allowed to rob up to k houses", then k would be another necessary state variable. This is because being at, say house 4 with 3 robberies left is different than being at house 4 with 5 robberies left.

You may be wondering - why don't we include a state variable that is a boolean indicating if we robbed the previous house or not? We certainly could include this state variable, but we can develop our recurrence relation in a way that makes it unnecessary. Building an intuition for this is difficult at first, but it becomes easier with practice.

The problem is asking for "the maximum amount of money you can rob". Therefore, we would use either a function dp(i) that returns the maximum amount of money you can rob up to and including house i, or an array dp where dp[i] represents the maximum amount of money you can rob up to and including house i.

This means that after all the subproblems have been solved, dp[i] and dp(i) both return the answer to the original problem for the subarray of nums that spans 0 to i inclusive. To solve the original problem, we will just need to return dp[nums.length - 1] or dp(nums.length - 1), depending if we do bottom-up or top-down.

2. A recurrence relation to transition between states

For this part, let's assume we are using a top-down (recursive function) approach. Note that the top-down approach is closer to our natural way of thinking and it is generally easier to think of the recurrence relation if we start with a top-down approach.

Next, we need to find a recurrence relation, which is typically the hardest part of the problem. For any recurrence relation, a good place to start is to think about a general state (in this case, let's say we're at the house at index i), and use information from the problem description to think about how other states relate to the current one.

If we are at some house, logically, we have 2 options: we can choose to rob this house, or we can choose to not rob this house.

If we decide not to rob the house, then we don't gain any money. Whatever money we had from the previous house is how much money we will have at this house - which is dp(i - 1).
If we decide to rob the house, then we gain nums[i] money. However, this is only possible if we did not rob the previous house. 
This means the money we had when arriving at this house is the money we had from the previous house without robbing it, which would be however much money we had 2 houses ago, dp(i - 2). 
After robbing the current house, we will have dp(i - 2) + nums[i] money.
From these two options, we always want to pick the one that gives us maximum profits. Putting it together, we have our recurrence relation: 
dp(i)=max(dp(i - 1),
dp(i - 2) + nums[i]) .

3. Base cases

The last thing we need is base cases so that our recurrence relation knows when to stop. The base cases are often found from clues in the problem description or found using logical thinking. In this problem, if there is only one house, then the most money we can make is by robbing the house (the alternative is to not rob the house). If there are only two houses, then the most money we can make is by robbing the house with more money (since we have to choose between them). Therefore, our base cases are:

dp(0) = nums[0]
dp(1)=max(nums[0], nums[1])

### Top-down Implementation

Now that we have established all 3 parts of the framework, let's put it together for the final result. Remember: we need to memoize the function!

```cshrp
public class Solution {
    private Dictionary<int, int> memo = new Dictionary<int, int>();
    private int[] nums;

    private int Dp(int i) {
        // Base cases
        if (i == 0) return nums[0];
        if (i == 1) return Math.Max(nums[0], nums[1]);

        if (!memo.ContainsKey(i)) {
            memo[i] = Math.Max(Dp(i - 1), Dp(i - 2) + nums[i]);
        }
        return memo[i];
    }

    public int Rob(int[] nums) {
        this.nums = nums;
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];
        return Dp(nums.Length - 1);
    }
}
```

### Bottom-up Implementation

Here's the bottom-up approach: everything is the same, except that we use an array instead of a hash map and we iterate using a for-loop instead of using recursion.

```cshrp
public class Solution {
    public int Rob(int[] nums) {
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];

        int[] dp = new int[nums.Length];

        // Base cases
        dp[0] = nums[0];
        dp[1] = Math.Max(nums[0], nums[1]);

        for (int i = 2; i < nums.Length; i++) {
            dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]); // Recurrence relation
        }

        return dp[nums.Length - 1];
    }
}
```

For both implementations, the time and space complexity is O(n). We'll talk about time and space complexity of DP algorithms in depth at the end of this chapter. Here's an animation that shows the algorithm in action:

## Multidimensional DP

The dimensions of a DP algorithm refer to the number of state variables used to define each state. So far in this explore card, all the algorithms we have looked at required only one state variable - therefore they are one-dimensional. In this section, we're going to talk about problems that require multiple dimensions.

Typically, the more dimensions a DP problem has, the more difficult it is to solve. Two-dimensional problems are common, and sometimes a problem might even require five dimensions. The good news is, the framework works regardless of the number of dimensions.

The following are common things to look out for in DP problems that require a state variable:

- An index along some input. This is usually used if an input is given as an array or string. This has been the sole state variable for all the problems that we've looked at so far, and it has represented the answer to the problem if the input was considered only up to 
that index - for example, if the input is nums = [0, 1, 2, 3, 4, 5, 6], then dp(4) would represent the answer to the problem for the input nums = [0, 1, 2, 3, 4].
- A second index along some input. Sometimes, you need two index state variables, say i and j. In some questions, these variables represent the answer to the original problem if you considered the input starting at index i and ending at index j. Using the same example above, dp(1, 3) would solve the problem for the input nums = [1, 2, 3], if the original input was [0, 1, 2, 3, 4, 5, 6].
- Explicit numerical constraints given in the problem. For example, "you are only allowed to complete k transactions", or "you are allowed to break up to k obstacles", etc.
- Variables that describe statuses in a given state. For example "true if currently holding a key, false if not", "currently holding k packages" etc.
- Some sort of data like a tuple or bitmask used to indicate things being "visited" or "used". For example, "bitmask is a mask where the ith bit indicates if the i th city has been visited". Note that mutable data structures like arrays cannot be used - typically, only immutable data structures like numbers and strings can be hashed, and therefore memoized.
Multi-dimensional problems make us think harder about deciding what our function or array will represent, as well as what the recurrence relation should look like. In the next article, we'll walk through another example using the framework with a 2D DP problem.

## Top-down to Bottom-up

As we've said in the previous chapter, usually a top-down algorithm is easier to implement than the equivalent bottom-up algorithm. With that being said, it is useful to know how to take a completed top-down algorithm and convert it to bottom-up. There's a number of reasons for this: first, in an interview, if you solve a problem with top-down, you may be asked to rewrite your solution in an iterative manner (using bottom-up) instead. Second, as we mentioned before, bottom-up usually is more efficient than top-down in terms of runtime.

Steps to convert top-down into bottom-up

Start with a completed top-down implementation.

Initialize an array dp that is sized according to your state variables. For example, let's say the input to the problem was an array nums and an integer k that represents the maximum number of actions allowed. Your array dp would be 2D with one dimension of length nums.length and the other of length k. The values should be initialized as some default value opposite of what the problem is asking for. For example, if the problem is asking for the maximum of something, set the values to negative infinity. If it is asking for the minimum of something, set the values to infinity.

Set your base cases, same as the ones you are using in your top-down function. Recall in House Robber, dp(0) = nums[0] and dp(1) = max(nums[0], nums[1]). In bottom-up, dp[0] = nums[0] and dp[1] = max(nums[0], nums[1]).

Write a for-loop(s) that iterate over your state variables. If you have multiple state variables, you will need nested for-loops. These loops should start iterating from the base cases.

Now, each iteration of the inner-most loop represents a given state, and is equivalent to a function call to the same state in top-down. Copy the logic from your function into the for-loop and change the function calls to accessing your array. All dp(...) changes into dp[...].

We're done! dp is now an array populated with the answer to the original problem for all possible states. Return the answer to the original problem, by changing return dp(...) to return dp[...].

Let's try a quick example using the House Robber code from before. Here's a completed top-down solution:

```cshrp
public class Solution {
    private Dictionary<int, int> memo = new Dictionary<int, int>();
    private int[] nums;

    private int Dp(int i) {
        // Base cases
        if (i == 0) return nums[0];
        if (i == 1) return Math.Max(nums[0], nums[1]);

        if (!memo.ContainsKey(i)) {
            memo[i] = Math.Max(Dp(i - 1), Dp(i - 2) + nums[i]);
        }
        return memo[i];
    }

    public int Rob(int[] nums) {
        this.nums = nums;
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];
        return Dp(nums.Length - 1);
    }
}
```
First, we initialize an array dp sized according to our state variables. Our only state variable is i which can take n values.
```cshrp
public class Solution {
    public int Rob(int[] nums) {
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];

        int[] dp = new int[nums.Length];
        dp[0] = nums[0];
        dp[1] = Math.Max(nums[0], nums[1]);

        for (int i = 2; i < nums.Length; i++) {
            dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
        }

        return dp[nums.Length - 1];
    }
}
```
Second, we should set our base cases. 
dp[0] = nums[0] and dp[1] = max(nums[0], nums[1]). To avoid index out of bounds, we should also just return nums[0] if theres only one house.

```cshrp
public class Solution {
    public int Rob(int[] nums) {
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];

        int[] dp = new int[nums.Length];
        dp[0] = nums[0];
        dp[1] = Math.Max(nums[0], nums[1]);

        for (int i = 2; i < nums.Length; i++) {
            dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
        }

        return dp[nums.Length - 1];
    }
}
```
Next, write a for-loop to iterate over the state variables, starting from the base cases.

```cshrp
class Solution {
    public int rob(int[] nums) {
        if (nums.length == 1) return nums[0];
        
        int[] dp = new int[nums.length];
        
        // Base cases
        dp[0] = nums[0];
        dp[1] = Math.max(nums[0], nums[1]);
        
        for (int i = 2; i < nums.length; i++) {
            dp[i] = Math.max(dp[i - 1], dp[i - 2] + nums[i]);
        }

        return dp[nums.length - 1];
    }
}
```
Lastly, copy the recurrence relation over from the top-down solution and put it in the for-loop. Return 
```cshrp
public class Solution {
    public int Rob(int[] nums) {
        if (nums.Length == 1) return nums[0];
        
        int[] dp = new int[nums.Length];
        
        // Base cases
        dp[0] = nums[0];
        dp[1] = Math.Max(nums[0], nums[1]);
        
        for (int i = 2; i < nums.Length; i++) {
            dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]); // Recurrence relation
        }
        
        return dp[nums.Length - 1];
    }
}
```
### Time and Space Complexity

Finding the time and space complexity of a dynamic programming algorithm may sound like a daunting task. However, this task is usually not as difficult as it sounds. Furthermore, justifying the time and space complexity in an explanation is relatively simple as well. One of the main points with DP is that we never repeat calculations, whether by tabulation or memoization, we only compute a state once. Because of this, the time complexity of a DP algorithm is directly tied to the number of possible states.

If computing each state requires F time, and there are n possible states, then the time complexity of a DP algorithm is O(n⋅F). With all the problems we have looked at so far, computing a state has just been using a recurrence relation equation, which is O(1). Therefore, the time complexity has just been equal to the number of states. To find the number of states, look at each of your state variables, compute the number of values each one can represent, and then multiply all these numbers together.

Let's say we had 3 state variables: 
i, k, and holding for some made up problem. i is an integer used to keep track of an index for an input array nums, k is an integer given in the input which represents the maximum actions we can do, and holding is a boolean variable. What will the time complexity be for a DP algorithm that solves this problem? Let n = nums.length and K be the maximum actions possible given in the input. i can be from 0 to nums.length, k can be from 0 to K, and holding can be true or false. Therefore, there are n⋅K⋅2 states. If computing each state is O(1), then the time complexity will be O(n⋅K⋅2)=O(n⋅K).

Whenever we compute a state, we also store it so that we can refer to it in the future. In bottom-up, we tabulate the results, and in top-down, states are memoized. Since we store states, the space complexity is equal to the number of states. That means that in problems where calculating a state is O(1), the time and space complexity are the same. In many DP problems, there are optimizations that can improve both complexities - we'll talk about this later.

## Iteration in the recurrence relation

In all the problems we have looked at so far, the recurrence relation is a static equation - it never changes. Recall Min Cost Climbing Stairs. The recurrence relation was:
dp(i)=min(dp(i - 1) + cost[i - 1], dp(i - 2) + cost[i - 2])

because we are only allowed to climb 1 or 2 steps at a time. What if the question was rephrased so that we could take up to k steps at a time? The recurrence relation would become dynamic - it would be: dp(i)=min(dp(j) + cost[j]) for all (i - k)≤j<i

We would need iteration in our recurrence relation.

This is a common pattern in DP problems, and in this chapter, we're going to take a look at some problems using the framework where this pattern is applicable. While iteration usually increases the difficulty of a DP problem, particularly with bottom-up implementations, the idea isn't too complicated. Instead of choosing from a static number of options, we usually add a for-loop to iterate through a dynamic number of options and choose the best one.

## Example 1335. Minimum Difficulty of a Job Schedule

We'll start with a top-down approach.

In this article, we'll be using the framework to solve Minimum Difficulty of a Job Schedule. We can tell this is a problem where Dynamic Programming can be used because we are asked for the minimum of something, and deciding how many jobs to do on a given day affects the jobs we can do on all future days. Let's start solving:

1. A function that answers the problem for a given state

Let's first decide on state variables. What decisions are there to make, and what information do we need to make these decisions? Reading the problem description carefully, there are d total days, and on each day we need to complete some number of jobs. By the end of the d days, we must have finished all jobs (in the given order). Therefore, we can see that on each day, we need to decide how many jobs to take.

Let's use one state variable i, where i is the index of the first job that will be done on the current day.

Let's use another state variable day, where day indicates what day it currently is.

The problem is asking for the minimum difficulty, so let's have a function dp(i, day) that returns the minimum difficulty of a job schedule which starts on the i'th job and day. To solve the original problem, we will just return dp(0, 1), since we start on the first day with no jobs done yet.

2. A recurrence relation to transition between states

At each state, we are on day day and need to do job i. Then, we can choose to do a few more jobs. How many more jobs are we allowed to do? The problem says that we need to do at least one job per day. This means we must leave at least d - day jobs so that all the future days have at least one job that can be scheduled on that day. If n is the total number of jobs, jobDifficulty.length, that means from any given state (i, day), we are allowed to do the jobs from index i up to but not including index n - (d - day).

We should try all the options for a given day - try doing only one job, then two jobs, etc. until we can't do any more jobs. The best option is the one that results in the easiest job schedule.

The difficulty of a given day is the most difficult job that we did that day. Since the jobs have to be done in order, if we are trying all the jobs we are allowed to do on that day (iterating through them), then we can use a variable hardest to keep track of the difficulty of the hardest job done today. If we choose to do jobs up to the 
j'th job (inclusive), where i≤j<n - (d - day) (as derived above), then that means on the next day, we start with the (j+1) th  job. Therefore, our total difficulty is hardest + dp(j + 1, day + 1). This gives us our scariest recurrence relation so far:dp(i, day) = min(hardest + dp(j + 1, day + 1)) for all i≤j<n - (d - day), where hardest = max(jobDifficulty[k]) for all i≤k≤j.

The codified recurrence relation is a scary one to look at for sure. However, it is easier to understand when we break it down bit by bit. On each day, we try all the options - do only one job, then two jobs, etc. until we can't do any more (since we need to leave some jobs for future days). hardest is the hardest job we do on the current day, which means it is also the difficulty of the current day. We add hardest to the next state which is the next day, starting with the next job. After trying all the jobs we are allowed to do, choose the best result.

3. Base cases

Despite the recurrence relation being complicated, the base cases are much simpler. We need to finish all jobs in d days. Therefore, if it is the last day (day == d), we need to finish up all the remaining jobs on this day, and the total difficulty will just be the largest number in jobDifficulty on or after index i.

if day == d then return the maximum job difficulty between job i and the end of the array (inclusive).

We can precompute an array hardestJobRemaining where hardestJobRemaining[i] represents the difficulty of the hardest job on or after index i, so that this base case is handled in constant time.

Additionally, if there are more days than jobs (n < d), then it is impossible to do at least one job each day, and per the problem description, we should return -1. We can check for this case at the very start.

### Top-down Implementation
Let's combine these 3 parts for a top-down implementation. Again, we will use functools in Python, and a 2D array in Java for memoization. In the Python implementation, we are passing None to lru_cache which means the cache size is not limited. We are doing this because the number of states that will be re-used in this problem is large, and we don't want to evict a state early and have to re-calculate it.

```cshrp
public class Solution {
    private int n, d;
    private int[][] memo;
    private int[] jobDifficulty;
    private int[] hardestJobRemaining;

    private int Dp(int i, int day) {
        // Base case: last day, must finish all remaining jobs
        if (day == d) {
            return hardestJobRemaining[i];
        }

        if (memo[i][day] == -1) {
            int best = int.MaxValue;
            int hardest = 0;

            for (int j = i; j < n - (d - day); j++) {
                hardest = Math.Max(hardest, jobDifficulty[j]);
                best = Math.Min(best, hardest + Dp(j + 1, day + 1));
            }

            memo[i][day] = best;
        }

        return memo[i][day];
    }

    public int MinDifficulty(int[] jobDifficulty, int d) {
        n = jobDifficulty.Length;
        if (n < d) return -1;

        // Precompute hardestJobRemaining
        hardestJobRemaining = new int[n];
        int hardestJob = 0;
        for (int i = n - 1; i >= 0; i--) {
            hardestJob = Math.Max(hardestJob, jobDifficulty[i]);
            hardestJobRemaining[i] = hardestJob;
        }

        // Initialize memo with -1
        memo = new int[n][];
        for (int i = 0; i < n; i++) {
            memo[i] = Enumerable.Repeat(-1, d + 1).ToArray();
        }

        this.d = d;
        this.jobDifficulty = jobDifficulty;
        return Dp(0, 1);
    }
}
```

### Bottom-up Implementation
With bottom-up, we now use a 2D array where dp[i][day] represents the minimum difficulty of a job schedule that starts on day day and job i. It depends on the problem, but the bottom-up code generally has a faster runtime than its top-down equivalent. However, as you can see from the code, it looks like it is more challenging to implement. We need to first tabulate the base case and then work backwards from them using nested for loops.

The for-loops should start iterating from the base cases, and there should be one for-loop for each state variable. Remember that one of our base cases is that on the final day, we need to complete all jobs. Therefore, our for-loop iterating over day should iterate from the final day to the first day. Then, our next for-loop for i should conform to the restraints of the problem - we need to do at least one job per day.

```cshrp
public class Solution {
    public int MinDifficulty(int[] jobDifficulty, int d) {
        int n = jobDifficulty.Length;

        // If we cannot schedule at least one job per day, it is impossible to create a schedule
        if (n < d) return -1;

        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++) {
            dp[i] = new int[d + 1];
            for (int j = 0; j <= d; j++) {
                dp[i][j] = int.MaxValue;
            }
        }

        // Set base case for the last day
        dp[n - 1][d] = jobDifficulty[n - 1];

        for (int i = n - 2; i >= 0; i--) {
            dp[i][d] = Math.Max(dp[i + 1][d], jobDifficulty[i]);
        }

        // Fill the DP table from bottom up
        for (int day = d - 1; day > 0; day--) {
            for (int i = day - 1; i < n - (d - day); i++) {
                int hardest = 0;
                for (int j = i; j < n - (d - day); j++) {
                    hardest = Math.Max(hardest, jobDifficulty[j]);
                    if (dp[j + 1][day + 1] != int.MaxValue) {
                        dp[i][day] = Math.Min(dp[i][day], hardest + dp[j + 1][day + 1]);
                    }
                }
            }
        }

        return dp[0][1];
    }
}
```

The time and space complexity of these algorithms can be quite tricky, and as in this example, there are sometimes slight differences between the top-down and bottom-up complexities.

Let's start with the bottom-up space complexity, because it follows what we learned in the previous chapter about finding time and space complexity. For this problem, the number of states is n⋅d. This means the space complexity is O(n⋅d) as our dp table takes up that much space.

The top-down algorithm's space complexity is actually a bit better. In top-down, when we memoize results with a hashtable, the hashtable's size only grows when we visit a state and calculate the answer for it. Because of the restriction of needing to complete at least one task per day, we don't actually need to visit all n⋅d states. For example, if there were 10 jobs and 5 days, then the state (9, 2) (starting the final job on the second day) is not reachable, because the 3rd, 4th, and 5th days wouldn't have a job to complete. This is true for both implementations and is enforced by our for-loops, and as a result, we only actually visit d⋅(n−d) states. This means the space complexity for top-down is O(d⋅(n−d)). This is one advantage that top-down can have over bottom-up. With the bottom-up implementation, we can't really avoid allocating space for n⋅d states because we are using a 2D array.

The time complexity for both algorithms is more complicated. As we just found out, we only actually visit d⋅(n−d) states. At each state, we go through a for-loop (with variable j) that iterates on average n−d times. This means our time complexity for both algorithms is O(d⋅(n−d).

### To summarize:

Time complexity (both algorithms): O(d⋅(n−d) 
Space complexity (top-down): O((n−d)⋅d)

Space complexity (bottom-up): O(n⋅d)

While the theoretical space complexity is better with top-down, practically speaking, the 2D array is more space-efficient than a hashmap, and the difference in space complexities here doesn't justify saying that top-down will use less space than bottom-up.

### Example 139. Word Break

In this article, we'll use the framework to solve Word Break. So far, in this card, this is the most unique and perhaps the most difficult problem to see that dynamic programming is a viable approach. This is because, unlike all of the previous problems, we will not be working with numbers at all. When a question asks, "is it possible to do..." it isn't necessarily a dead giveaway that it should be solved with DP. However, we can see that in this question, the order in which we choose words from 
wordDict is important, and a greedy strategy will not work.

Recall back in the first chapter, we said that a good way to check if a problem should be solved with DP or greedy is to first assume that it can be solved greedily, then try to think of a counterexample.

Let's say that we had s= "abcdef" and wordDict = [ "abcde", "ef", "abc", "a", "d"]. A greedy algorithm (picking the longest substring available) will not be able to determine that picking "abcde" here is the wrong decision. Likewise, a greedy algorithm (picking the shortest substring available) will not be able to determine that picking "a" first is the wrong decision.

With that being said, let's develop a DP algorithm using our framework:

For this problem, we'll look at bottom-up first.

1. An array that answers the problem for a given state

Despite this problem being unlike the ones we have seen so far, we should still stick to the ideas of the framework. In the article where we learned about multi-dimensional dynamic programming, we talked about how an index variable, usually denoted i is typically used in DP problems where the input is an array or string. All the problems that we have looked at up to this point reflect this.

With this in mind, let's use a state variable i, which keeps track of which index we are currently at in s.

Do we need any other state variables? The other input is wordDict - however, it says in the problem that we can reuse words from wordDict as much as we want. Therefore, a state variable isn't necessary because wordDict and what we can do with it never changes. If the problem was changed so that we can only use a word once, or say k times, then we would need extra state variables to know what words we are allowed to use at each state.

In all the past problems, we had a function dp return the answer to the original problem for some state. We should try to do the same thing here. The problem is asking, is it possible to create s by combining words in wordDict. So, let's have an array dp where dp[i] represents if it is possible to build the string s up to index i from wordDict. To answer the original problem, we can return dp[s.length - 1] after populating dp.

2. A recurrence relation to transition between states

At each index i, what criteria determines if dp[i] is true? First, a word from wordDict needs to be able to end at index i. In terms of code, this means that there is some 
word from wordDict that matches the substring of s that starts at index i - word.length + 1 and ends at index i.

We can iterate through all states of i from 0 up to but not including s.length, and at each state, check all the words in wordDict for this criteria. For each word in wordDict, if s from index i - word.length + 1 to i is equal to word, that means word ends at i. However, this is not the sole criteria.

Remember, we are forming s by adding words together. That means, if a word meets the first criteria and we want to use it in a solution, we would add it on top of another string. We need to make sure that the string before it is also formable. If word meets the first criteria, it starts at index i - word.length + 1. The index before that is i - word.length, and the second criteria is that s up to this index is also formable from wordDict. This gives us our recurrence relation:

dp(i) = true if s.substring(i - word.length + 1, i + 1) == word and dp[i - word.length] == true for any word in wordDict, otherwise false.

In summary, the criteria is:

A wordDict can end at the current index i.

If that word is to end at index i, then it starts at index i - word.length + 1. The index before that i - word.length should also be formable from wordDict.

3. Base cases

The base case for this problem is another simple one. The first word used from wordDict starts at index 0, which means we would need to check dp[-1] for the second criteria, which is out of bounds. To fix this, we say that the second criteria can also be satisfied by i == word.length - 1.

### Bottom-up Implementation

```cshrp
public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) {
        bool[] dp = new bool[s.Length];

        for (int i = 0; i < s.Length; i++) {
            foreach (string word in wordDict) {
                if (i >= word.Length - 1 && (i == word.Length - 1 || dp[i - word.Length])) {
                    if (s.Substring(i - word.Length + 1, word.Length) == word) {
                        dp[i] = true;
                        break;
                    }
                }
            }
        }

        return dp[s.Length - 1];
    }
}
```

### Top-down Implementation

In the top-down approach, we can check for the base case by returning true if i < 0. In Java, we will memoize by using a -1 to indicate that the state is unvisited, 0 to indicate false, and 1 to indicate true.

```cshrp
public class Solution {
    private string s;
    private IList<string> wordDict;
    private int[] memo;

    private bool Dp(int i) {
        if (i < 0) return true;

        if (memo[i] == -1) {
            foreach (string word in wordDict) {
                if (i >= word.Length - 1 && Dp(i - word.Length)) {
                    if (s.Substring(i - word.Length + 1, word.Length) == word) {
                        memo[i] = 1;
                        break;
                    }
                }
            }
        }

        if (memo[i] == -1) {
            memo[i] = 0;
        }

        return memo[i] == 1;
    }

    public bool WordBreak(string s, IList<string> wordDict) {
        this.s = s;
        this.wordDict = wordDict;
        this.memo = Enumerable.Repeat(-1, s.Length).ToArray();
        return Dp(s.Length - 1);
    }
}
```
Let's say that n = s.length, k = wordDict.length, and L is the average length of the words in wordDict. While the space complexity for this problem is the same as the number of states n, the time complexity is much worse. At each state i, we iterate through wordDict and splice s to a new string with average length L. This gives us a time complexity of O(n⋅k⋅L).

## State Transition by Inaction

This is a small pattern that occasionally shows up in DP problems. Here, "doing nothing" refers to two different states having the same value. We're calling it "doing nothing" because often the way we arrive at a new state with the same value as the previous state is by "doing nothing" (we'll look at some examples soon). Of course, a decision making process needs to coexist with this pattern, because if we just had all states having the same value, the problem wouldn't really make sense (dp(i) = dp(i - 1)?) It is just that if we are trying to maximize or minimize a score for example, sometimes the best option is to "do nothing", which leads to two states having the same value. The actual recurrence relation would look something like dp(i, j) = max(dp(i - 1, j), ...).

Usually when we "do nothing", it is by moving to the next element in some input array (which we usually use i as a state variable for). As mentioned above, this will be part of a decision making process due to some restriction in the problem. For example, think back to House Robber: we could choose to rob or not rob each house we were at. Sometimes, not robbing the house is the best decision (because we aren't allowed to rob adjacent houses), then 
dp(i) = dp(i - 1).

### Example 188. Best Time to Buy and Sell Stock IV

For this one, we're back to starting with top-down.

In this article, we'll be using the framework to solve Best Time to Buy and Sell Stock IV. This problem is rated as "hard" and may seem daunting at first, but with the framework, the logic behind solving this problem is very intuitive. We'll also make use of the pattern of "doing nothing". Like usual, let's use the framework to develop an algorithm:

1. A function that answers the problem for a given state

What information do we need at each state/decision?

We need to know what day it is (so we can look up the current price of the stock), and we need to know how many transactions we have left. These two are directly related to the input.

The note in the problem description says that we cannot engage in multiple transactions at the same time. This means that at any moment, we are either holding one unit of stock or not holding any stock. We should have a state variable that indicates if we are currently holding stock. This variable is fine as a boolean, but for caching purposes, let's use an integer alternating between 0 and 1 (0 means not holding, 1 means holding).

To summarize, we have 3 state variables:
1. i, which represents we are on the ith day. The current price of the stock is prices[i].
2. transactionsRemaining, which represents how many transactions we have left. This number goes down by 1 whenever we sell a stock.
3. holding, which is equal to 0 if we are not holding a stock, and 1 if we are holding a stock. If holding is 0, we have the option to buy a stock. Otherwise, we have the option to sell a stock.

The problem is asking for a maximum achievable profit. Therefore, let's have a function dp where dp(i, transactionsRemaining, holding) returns the maximum achievable profit starting from the ith day with transactionsRemaining transactions remaining, and holding indicating if we start with a stock or not. To answer the original problem, we would return dp(0, k, 0), as we start on day 0 with k transactions remaining and not holding a stock.

2. A recurrence relation to transition between states

At each state, we need to make a decision that depends on what holding is. Let's split it up and look at our options one at a time:

- If we are holding stock, we have two options. We can sell, or not sell. If we choose to sell, we gain prices[i] money, and the next state will be (i + 1, transactionsRemaining - 1, 0). This is because it is the next day (i + 1), we lose a transaction as we completed one by selling (transactionsRemaining - 1), and we are no longer holding a stock (0). In total, our profit is prices[i] + dp(i + 1, transactionsRemaining - 1, 0). If we choose not to sell and do nothing, then we just move onto the next day with the same number of transactions, while still holding the stock. Our profit is dp(i + 1, transactionsRemaining, holding).

- If we are not holding stock, we have two options. We can buy, or not buy. If we choose to buy, we lose prices[i] money, and the next state will be (i + 1, transactionsRemaining, 1). This is because it is the next day, we have the same number of transactions because transactions are only completed on selling, and we now hold a stock. In total, our profit is -prices[i] + dp(i + 1, transactionsRemaining, 1). If we choose not to buy and do nothing, then we just move onto the next day with the same number of transactions, while still not having stock. Our profit is dp(i + 1, transactionsRemaining, holding).

Note that you could also set up the solution so that transactions are completed upon buying a stock instead.

Of course, we always want to make the best decision. We can see that in both scenarios, doing nothing is the same - dp(i + 1, transactionsRemaining, holding). Therefore, we have a recurrence relation of:

dp(i, transactionsRemaining, holding) = max(doNothing, sellStock) if holding == 1 otherwise max(doNothing, buyStock)

Where, doNothing = dp(i + 1, transactionsRemaining, holding), sellStock = prices[i] + dp(i + 1, transactionsRemaining - 1, 0), and buyStock = -prices[i] + dp(i + 1, transactionsRemaining, 1).

3. Base cases

Both base cases are very simple for this problem. If we are out of transactions (transactionsRemaining = 0), then we should immediately return 0 as we cannot make any more money. If the stock is no longer on the market (i = prices.length), then we should also return 0, as we cannot make any more money.

### Top-down Implementation

```cshrp
public class Solution {
    private int[] prices;
    private int[,,] memo;

    private int Dp(int i, int transactionsRemaining, int holding) {
        // Base cases
        if (transactionsRemaining == 0 || i == prices.Length) {
            return 0;
        }

        if (memo[i, transactionsRemaining, holding] == int.MinValue) {
            int doNothing = Dp(i + 1, transactionsRemaining, holding);
            int doSomething;

            if (holding == 1) {
                // Sell stock
                doSomething = prices[i] + Dp(i + 1, transactionsRemaining - 1, 0);
            } else {
                // Buy stock
                doSomething = -prices[i] + Dp(i + 1, transactionsRemaining, 1);
            }

            // Recurrence relation: maximize profit
            memo[i, transactionsRemaining, holding] = Math.Max(doNothing, doSomething);
        }

        return memo[i, transactionsRemaining, holding];
    }

    public int MaxProfit(int k, int[] prices) {
        this.prices = prices;
        int n = prices.Length;

        // Initialize memo array with a sentinel value
        memo = new int[n, k + 1, 2];
        for (int i = 0; i < n; i++) {
            for (int t = 0; t <= k; t++) {
                memo[i, t, 0] = int.MinValue;
                memo[i, t, 1] = int.MinValue;
            }
        }

        return Dp(0, k, 0);
    }
}
```

### Bottom-up Implementation

Again, the recurrence relation is the same with top-down, but we need to be careful about how we configure our for loops. The base cases are automatically handled because the 
dp array is initialized with all values set to 0. For iteration direction and order, remember with bottom-up we start at the base cases. Therefore we will start iterating from the end of the input and with only 1 transaction remaining.

```cshrp
public class Solution {
    public int MaxProfit(int k, int[] prices) {
        int n = prices.Length;
        int[,,] dp = new int[n + 1, k + 1, 2];

        for (int i = n - 1; i >= 0; i--) {
            for (int transactionsRemaining = 1; transactionsRemaining <= k; transactionsRemaining++) {
                for (int holding = 0; holding < 2; holding++) {
                    int doNothing = dp[i + 1, transactionsRemaining, holding];
                    int doSomething;

                    if (holding == 1) {
                        // Sell stock
                        doSomething = prices[i] + dp[i + 1, transactionsRemaining - 1, 0];
                    } else {
                        // Buy stock
                        doSomething = -prices[i] + dp[i + 1, transactionsRemaining, 1];
                    }

                    // Recurrence relation
                    dp[i, transactionsRemaining, holding] = Math.Max(doNothing, doSomething);
                }
            }
        }

        return dp[0, k, 0];
    }
}
```

The time and space complexity of this problem for both implementations is the number of states since the recurrence relation is just a constant time formula. If n = prices.length, then this means the time and space complexity is O(n⋅k⋅2)=O(n⋅k).

## State Reduction

In an earlier chapter when we used the framework to solve Maximum Score from Performing Multiplication Operations, we mentioned that we could use 2 state variables instead of 3 because we could derive the information the 3rd one would have given us from the other 2. By doing this, we greatly reduced the number of states (as we learned earlier, the number of states is the product of the number of values each state variable can take). In most cases, reducing the number of states will reduce the time and space complexity of the algorithm.

This is called state reduction, and it is applicable for many DP problems, including a few that we have already looked at. State reduction usually comes from a clever trick or observation. Sometimes, as is in the case of Maximum Score from Performing Multiplication Operations, state reduction can result in lower time and space complexity. Other times, only the space complexity will be improved while the time complexity remains the same.

State reduction can also be achieved in the recurrence relation. Recall when we looked at House Robber. Only one state variable was used, i, which indicates what house we are currently at. An alternative way to solve the problem would be adding an extra boolean state variable prev that indicates if we robbed the previous house or not, and that would look something like this:

```cshrp
public class Solution {
    private int[] nums;
    private Dictionary<(int, bool), int> memo = new();

    private int Dp(int i, bool prevRobbed) {
        if (i < 0) return 0;

        var key = (i, prevRobbed);
        if (memo.ContainsKey(key)) return memo[key];

        int result = Dp(i - 1, false);
        if (!prevRobbed) {
            result = Math.Max(result, Dp(i - 1, true) + nums[i]);
        }

        memo[key] = result;
        return result;
    }

    public int Rob(int[] nums) {
        this.nums = nums;
        return Dp(nums.Length - 1, false);
    }
}
```

However, we mentioned in the House Robber article: "We certainly could include this state variable, but we can develop our recurrence relation in a way that makes it unnecessary.". By using a clever recurrence relation and base case, we avoided the need for the extra state variable which reduces the number of states by a factor of 2.

Note: state reductions for space complexity usually only apply to bottom-up implementations, while improving time complexity by reducing the number of state variables applies to both implementations.

When it comes to reducing state variables, it's hard to give any general advice or blueprint. The best advice is to try and think if any of the state variables are related to each other, and if an equation can be created among them. If a problem does not require iteration, there is usually some form of state reduction possible.

Another common scenario where we can improve space complexity is when the recurrence relation is static (no iteration) along one dimension. Let's look back at where we started - Fibonacci. Recall that the ith Fibonacci number can be calculated with the recurrence relation: F(i)=F(i−1)+F(i−2)
Because this recurrence relation is static, to calculate the ith Fibonacci number, we only ever care about the previous two numbers. That means if we are using a bottom-up approach to find the nth Fibonacci number and start from the base cases, we don't actually need to use an array and remember every single Fibonacci number.

Let's say we wanted F(100). Starting from the base cases, we need to calculate every Fibonacci number from F(2) to F(99), but at the time of the actual calculation for F(100), we only care about F(98) and F(99). The other 90+ Fibonacci numbers aren't needed, so storing all of them is a waste of space.

Using only two variables instead, we can improve space complexity to O(1) from O(n) using an array. The time complexity remains the same.

```csharp
public class Solution {
    public int Fib(int n) {
        if (n <= 1) return n;

        int oneBack = 1;
        int twoBack = 0;

        for (int i = 2; i <= n; i++) {
            int temp = oneBack;
            oneBack += twoBack;
            twoBack = temp;
        }

        return oneBack;
    }
}
```

Whenever you notice that values calculated by a DP algorithm are only reused a few times and then never used again, try to see if you can save on space by replacing an array with some variables. A good first step for this is to look at the recurrence relation to see what previous states are used. For example, in Fibonacci, we only refer to the previous two states, so all results before n - 2 can be discarded.

## Counting DP

Most of the problems we have looked at in earlier chapters ask for either the maximum, minimum, or longest of something. However, it is also very common for a DP problem to ask for the number of distinct ways to do something. In fact, one of the first examples we looked at did this - recall that Climbing Stairs asked us to find the number of ways to climb to the top of the stairs.

Another term used to describe this class of problems is "counting DP".

What are the differences with counting DP? With the maximum/minimum problems, the recurrence relation typically involves a max() or min() function. This is true for all types of problems we have looked at - iteration, multi-dimensional, etc. With counting DP, the recurrence relation typically just sums the results of multiple states together. For example, in Climbing Stairs, the recurrence relation was dp(i) = dp(i - 1) + dp(i - 2). There is no max() or min(), just addition.

Another difference is in the base cases. In most of the problems we have looked at, if the state goes out of bounds, the base case equals 0. For example, in the Best Time to Buy and Sell Stock questions, when we ran out of transactions or ran out of days to trade, we returned 0 because we can't make any more profit. In Longest Common Subsequence, when we run out of characters for either string, we return 0 because the longest common subsequence of any string and an empty string is 0. With counting DP, the base cases are often not set to 0. This is because the recurrence relation usually only involves addition terms with other states, so if the base case was set to 0 then you would only ever add 0 to itself. Finding these base cases involves some logical thinking - for example, when we looked at Climbing Stairs - we reasoned that there is 1 way to climb to the first step and 2 ways to climb to the second step.

These next 3 problems are very good practice problems that ask for the number of distinct ways to do something. Try them on your own, but if you get stuck, come back here for hints:

276. Paint Fence
Click here to show hint regarding state variables and dp
Let dp(i) represent the number of ways to paint i posts.

Click here to show hint regarding recurrence relation
At each new fence post, we can either paint it the same color as the previous post, or a different color. If we choose a different color, then there are k - 1 colors to choose from. If we choose the same color, we need to make sure that the post at i - 1 and i - 2 are not the same color.

Click here to show hint regarding base cases
There are k ways to paint one fence post. Since we are allowed to paint 2 consecutive fence posts the same color, there are k⋅k ways to paint two fence posts.

518. Coin Change 2
Click here to show hint regarding state variables and dp
Let dp[i] represent the number of ways to make i money.

Click here to show hint regarding recurrence relation
For each coin, for each amount of money i, you can make i money by adding the coin to i - coin money. Make sure to stay in bounds.

Click here to show hint regarding base cases
Since our recurrence relation only involves addition with other states, we need dp[0] to be a nonzero value, otherwise we will only ever be adding 0 to itself.

91. Decode Ways
Click here to show hint regarding state variables and dp
Let dp(i) return the number of ways the string starting from index i can be decoded. Return dp(0).

Click here to show hint regarding recurrence relation
You can always treat the current number as a one digit number. In addition, if the current number and next number combined is between 10 and 26, you have an additional option.

Click here to show hint regarding base cases
If s[i] ==  "0", then there is no way for this string to ever be decoded to anything. If i goes out of bounds, we need to return a nonzero value.

## Kadane's Algorithm

Kadane's Algorithm is an algorithm that can find the maximum sum subarray given an array of numbers in O(n) time and O(1) space. Its implementation is a very simple example of dynamic programming, and the efficiency of the algorithm allows it to be a powerful tool in some DP algorithms. If you haven't already solved Maximum Subarray, take a quick look at the problem before continuing with this article - Kadane's Algorithm specifically solves this problem.

Kadane's Algorithm involves iterating through the array using an integer variable 
current, and at each index i, determines if elements before index i are "worth" keeping, or if they should be "discarded". The algorithm is only useful when the array can contain negative numbers. If current becomes negative, it is reset, and we start considering a new subarray starting at the current index.

Pseudocode for the algorithm is below:

```cshrp
// Given an input array of numbers "nums",
1. best = negative infinity
2. current = 0
3. for num in nums:
    3.1. current = Max(current + num, num)
    3.2. best = Max(best, current)

4. return best
```

Line 3.1 of the pseudocode is where the magic happens. If current has become less than 0 from including too many or too large negative numbers, the algorithm "throws it away" and resets.

While usage of Kadane's Algorithm is a niche, variations of Kadane's Algorithm can be used to develop extremely efficient DP algorithms. Try the next two practice problems with this in mind. No framework hints are provided here as implementations of Kadane's Algorithm do not typically follow the framework intuitively, although they are still technically dynamic programming (Kadane's Algorithm utilizes optimal sub-structures - it keeps the maximum subarray ending at the previous position in current).

## Example 62. Unique Paths

The bottom-up approach for pathing problems is often more intuitive than for other types of dynamic programming problems - so this is a good chance for us to practice starting with a bottom-up approach.

In this article, we'll use the framework to solve Unique Paths. This problem asks us to find the number of distinct ways to do something, which is a hint that we should consider using dynamic programming, and we discussed how to do so in the previous chapter. Let's get started:

1. An array that answers the problem for a given state

State variables are usually easy to find in pathing problems. Similar to how we need one index (i) for 1D array inputs, with pathing problems on a 2D matrix, we need two indices (row and col) to denote position. Some problems have added constraints that will require additional state variables, but there doesn't seem to be anything of the sort in this problem. Therefore, we will just use two state variables row which represents the current row, and col which represents the current column.

The problem is asking for the number of paths to the final square, so let's have dp[row][col] represent how many paths there are from the start (top-left corner) to the square at (row, col). We will return dp[m - 1][n - 1] where m and n are the number of rows and columns respectively.

2. A recurrence relation to transition between states

The problem says that we are allowed to move down or right. That means, if we are at some square, we arrived from either the square above or the square to the left. These two squares are (row - 1, col) and (row, col - 1). Since we can arrive at the current square from either of these squares, the number of ways to get to the current square is the sum of the number of ways to get to these two squares. Either of these may be out of the grid bounds, so we should make sure to check for that. This gives us our simple recurrence relation:

dp[row][col] = dp[row - 1][col] + dp[row][col - 1], where dp[row - 1][col] and dp[row][col - 1] is equal to 0 if out of bounds.

3. Base cases

In the previous chapter, when talking about counting DP problems, we said that the base cases need to be set to nonzero values so that the terms in the recurrence relation don't just stay stuck at zero. In this problem, we start in the top-left corner. How many ways are there for us to get to the first square? Only 1 - we start on it. Therefore, our base case is dp[0][0] = 1.

Note: If you have trouble coming up with the recurrence relation, sometimes it helps to come up with the base case(s) first. Then walk through how you would find the result for states that are slightly more complicated than the base case(s), such as dp[0][1], dp[1][1], and dp[2][1]. Often, this process of manually solving the problem for simple states can help you understand what the recurrence relation should be.

### Bottom-up Implementation

Putting it all together for the final solution:

```cshrp
public class Solution {
    public int UniquePaths(int m, int n) {
        int[,] dp = new int[m, n];
        dp[0, 0] = 1; // Base case

        for (int row = 0; row < m; row++) {
            for (int col = 0; col < n; col++) {
                if (row > 0) {
                    dp[row, col] += dp[row - 1, col];
                }
                if (col > 0) {
                    dp[row, col] += dp[row, col - 1];
                }
            }
        }

        return dp[m - 1, n - 1];
    }
}
```

### Top-down Implementation

As we know, one of the advantages of top-down implementations is that they are usually easier to implement. However, for some, bottom-up dynamic programming is more intuitive when it comes to pathing problems. As such, we implemented the bottom-up approach first in this example. That said, it is rare to convert bottom-up solutions to top-down solutions since the typical flow for dynamic programming problems is to come up with a top-down DP solution first, and then convert it to a bottom-up DP solution, if the bottom-up approach is more efficient. Below, for completeness, we have also included the top-down implementation.

```cshrp
public class Solution {
    private int[,] memo;

    private int Dp(int row, int col) {
        if (row + col == 0) {
            return 1; // Base case
        }

        if (memo[row, col] == 0) {
            int ways = 0;
            if (row > 0) {
                ways += Dp(row - 1, col);
            }
            if (col > 0) {
                ways += Dp(row, col - 1);
            }
            memo[row, col] = ways;
        }

        return memo[row, col];
    }

    public int UniquePaths(int m, int n) {
        memo = new int[m, n];
        return Dp(m - 1, n - 1);
    }
}
```

The time and space complexity of both solutions is O(m⋅n). We visit each square only once and do a constant amount of work. Here's a challenge to do on your own: try to use state reduction to improve the space complexity of the bottom-up approach to O(n) without modifying the input.

### Up next
As always, try the next 3 practice problems on your own, and come back here if you need hints:

63. Unique Paths II

Let dp[row][col] represent how many paths there are from the start to the square at (row, col).
We arrive at each square from the squares at (row - 1, col) and (row, col - 1), if they're in bounds. Make sure that they aren't obstacles, and that the square we currently are on isn't an obstacle either.
There is 1 "path" to the starting square - dp[0][0] = 1.

64. Minimum Path Sum

Let dp[row][col] represent the smallest sum possible for any path from the start to the square at (row, col).
We arrive at each square from the squares at (row - 1, col) and (row, col - 1), if they're in bounds. Choose the smallest value and add it to the current square's value.
Initially, dp = grid.

931. Minimum Falling Path Sum

Let dp[row][col] represent the smallest sum possible for any path from the start to the square at (row, col).
We arrive at each square from the squares at (row - 1, col - 1), (row - 1, col), and (row - 1, col + 1), if they're in bounds. Choose the smallest value and add it to the current square's value.
Initially, dp = matrix.

