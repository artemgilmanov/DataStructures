# Static and Dynamic Arrays

## Static Arrays

## What Is an Array?

An array is a basic data structure to store a collection of elements sequentially. But elements can be accessed randomly since each element in the array can be identified by an array index.
An array can have one or more dimensions. 

An array is a collection of elements of the same type, stored in contiguous memory locations. This guarantees:

1. **Contiguous Memory**:  Ensures quick access because elements are stored sequentially in memory.
2. **Homogeneous Data**: All elements are of the same type, occupying equal memory.
3. **Indexed Access**: Each element can be accessed via its index.
4. **Fixed Size**: Size is defined at creation and cannot be changed.
5. **Efficient Access**: Accessing any element by index is O(1).

As it was mentioned before, an array has a fixed capacity and we need to specify the size of the array when we initialize it. Sometimes this will be somewhat inconvenient and wasteful. Therefore, most programming languages offer built-in dynamic array which is still a random access list data structure but with variable size. For example, we have vector in C++ and ArrayList in Java.

## Array Capacity VS Length

## Array Capacity

Let's say we've created a new Array like this.

DVD[] array = new DVD[6]
Is it a valid operation to insert an element at array[6]? What about at array[10]?

Nope, neither of these are valid. When we created the Array, we specified that it can hold up to 6 DVD's. This is the Array's capacity.

Remembering that indexing starts at 0, we can only insert items at array[0], array[1], array[2], array[3], array[4], and array[5]. Trying to put an element anywhere else, such as array[-3], array[6], or array[100] will cause your code to crash with an ArrayIndexOutOfBoundsException!

The Array's capacity must be decided when the Array is created. The capacity cannot be changed later. Going back to our DVD's-in-a-cardboard-box-analogy, changing the capacity of an Array would be akin to trying to make a cardboard box bigger. Trying to make a fixed-size cardboard box bigger is impractical, and it's the same as an Array on a computer!

So, what do we do if we get a 7th DVD and we'd like all our DVD's in the same Array? Well, unfortunately it's the same as it is with our cardboard box. We'll need to go get a larger one, and then move all the existing DVD's into it, along with the new one.

The capacity of an Array in C# can be checked by looking at the value of its length attribute. This is done using the code arr.length, where arr is the name of the Array. Different programming languages have different ways of checking the length of an Array.

## Array Length

The other definition of length is the number of DVDs, or other items, currently in the Array. This is something you'll need to keep track of yourself, and you won't get any errors if you overwrite an existing DVD, or if you leave a gap in the Array.

You might have noticed that we've been using a length variable in our previous examples, to keep track of the next empty index.

```csharp
// Create a new array with a capacity of 6.
int[] array = new int[6];

// Current length is 0, because it has 0 elements.
int length = 0;

// Add 3 items into it.
for (int i = 0; i < 3; i++)
{
    array[i] = i * i;
    // Each time we add an element, the length goes up by one.
    length++;
}

Console.WriteLine("The Array has a capacity of " + array.Length);
Console.WriteLine("The Array has a length of " + length);
```
Running this code will give the following output:

The Array has a capacity of 6
The Array has a length of 3

# Basic Array Operations

# Array Insertions

## Inserting at the End of an Array

At any point in time, we know the index of the last element of the Array, as we've kept track of it in our length variable. All we need to do for inserting an element at the end is to assign the new element to one index past the current last element.

This is pretty much the same as we've already seen. Here's the code to make a new Array that can hold up to 6 items, and then add items into the first 3 indexes.

```csharp
// Declare an integer array of 6 elements
int[] intArray = new int[6];
int length = 0;

// Add 3 elements to the Array
for (int i = 0; i < 3; i++)
{
    intArray[length] = i;
    length++;
}
```
Let's define a function, printArray, to help us visualise what's happening.

```csharp
for (int i = 0; i < intArray.Length; i++)
{
    Console.WriteLine("Index " + i + " contains " + intArray[i]);
}
```
Index 0 contains 0.
Index 1 contains 1.
Index 2 contains 2.
Index 3 contains 0.
Index 4 contains 0.
Index 5 contains 0

If we run our printArray function, we'll get the following output.

Notice how indexes 3, 4, and 5 all contain 0? This is because C# fills unused int Array slots with 0s.

Let's now add a 4th element. We'll add the number 10.

```csharp
// Insert a new element at the end of the Array. Again,
// it's important to ensure that there is enough space
// in the array for inserting a new element.
intArray[length] = 10;
length++;
```
Notice why we also incremented the length? It is significant to increase the length by 1. If skipping this step, next time when we add another element, we'll accidentally overwrite the one we just added!

Running printArray again, we'll get the following:

Index 0 contains 0.
Index 1 contains 1.
Index 2 contains 2.
Index 3 contains 10.
Index 4 contains 0.
Index 5 contains 0.

## Inserting at the Start of an Array

To insert an element at the start of an Array, we'll need to shift all other elements in the Array to the right by one index to create space for the new element. This is a very costly operation, since each of the existing elements has to be shifted one step to the right. The need to shift everything implies that this is not a constant time operation. In fact, the time taken for insertion at the beginning of an Array will be proportional to the length of the Array. In terms of time complexity analysis, this is a linear time complexity: O(N), where N is the length of the Array.

Here's what this looks like in code.

```csharp
// First, we will have to create space for a new element.
// We do that by shifting each element one index to the right.
// This will firstly move the element at index 3, then 2, then 1, then finally 0.
// We need to go backwards to avoid overwriting any elements.
for (int i = 3; i >= 0; i--)
{
    intArray[i + 1] = intArray[i];
}

// Now that we have created space for the new element,
// we can insert it at the beginning.
intArray[0] = 20;
```
And here's the result of running printArray.

Index 0 contains 20.
Index 1 contains 0.
Index 2 contains 1.
Index 3 contains 2.
Index 4 contains 10.
Index 5 contains 0.

## Inserting Anywhere in the Array

Similarly, for inserting at any given index, we first need to shift all the elements from that index onwards one position to the right. Once the space is created for the new element, we proceed with the insertion. If you think about it, insertion at the beginning is basically a special case of inserting an element at a given index—in that case, the given index was 0.

Again, this is also a costly operation since we could potentially have to shift almost all the other elements to the right before actually inserting the new element. As you saw above, shifting lots of elements one place to the right adds to the time complexity of the insertion task.

Here's what it looks like in code.

```csharp
// Say we want to insert the element at index 2.
// First, we will have to create space for the new element.
for (int i = 4; i >= 2; i--)
{
    // Shift each element one position to the right.
    intArray[i + 1] = intArray[i];
}

// Now that we have created space for the new element,
// we can insert it at the required index.
intArray[2] = 30;
```
And here's the result of running printArray.

Index 0 contains 20.
Index 1 contains 0.
Index 2 contains 30.
Index 3 contains 1.
Index 4 contains 2.
Index 5 contains 10.

Does that all sound good? The main thing to be careful of is remembering that array.length gives you the total capacity of the Array. If you want to know the last used slot, you'll need to keep track of this yourself using a length variable. Other than that, just be careful to read any elements you want to keep, before you overwrite them!

# Array Deletions

Now that we know how insertion works, it's time to look at its complement—deletion!

Deletion in an Array works in a very similar manner to insertion, and has the same three different cases:

Deleting the last element of the Array.
Deleting the first element of the Array.
Deletion at any given index.

## Deleting From the End of an Array

Deletion at the end of an Array is similar to people standing in a line, also known as a queue. The person who most recently joined the queue (at the end) can leave at any time without disturbing the rest of the queue. Deleting from the end of an Array is the least time consuming of the three cases. Recall that insertion at the end of an Array was also the least time-consuming case for insertion.

So, how does this work in code? Before we look at this, let's quickly remind ourselves what the length of an Array means. Here is some code that creates an Array with room for 10 elements, and then adds elements into the first 6 indexes of it.

```csharp
// Declare an integer array of 10 elements.
int[] intArray = new int[10];

// The array currently contains 0 elements
int length = 0;

// Add elements at the first 6 indexes of the array.
for (int i = 0; i < 6; i++)
{
    intArray[length] = i;
    length++;
}
```

Notice the length variable. Essentially, this variable keeps track of the next index that is free for inserting a new element. This is always the same value as the overall length of the Array. Note that when we declare an Array of a certain size, we simply fix the maximum number of elements it could contain. Initially, the Array doesn't contain anything. Thus, when we add new elements, we also increment the length variable accordingly.

Anyway, here's the code for deleting the last element of an Array.

```csharp
// Deletion from the end is as simple as reducing the length
// of the array by 1.
length--;
```
Remember how for insertion we were using this printArray function?

```csharp
for (int i = 0; i < intArray.Length; i++)
{
    Console.WriteLine("Index " + i + " contains " + intArray[i]);
}
```
Well, if we run it here, we'll get the following result, regardless of whether we run it before or after removing the last element.

Index 0 contains 0.
Index 1 contains 1.
Index 2 contains 2.
Index 3 contains 3.
Index 4 contains 4.
Index 5 contains 5.
Index 6 contains 0.
Index 7 contains 0.
Index 8 contains 0.
Index 9 contains 0.

What's gone wrong? Well, remember how there's two different definitions of length? When we use intArray.length, we're looking every valid index of the Array. When in fact, we only want to look at the ones that we've put values into. The fix is easy, we just iterate up to our own length variable instead.
Here is the equivalent C# code:

```csharp
for (int i = 0; i < length; i++)
{
    Console.WriteLine("Index " + i + " contains " + intArray[i]);
}
```
Run this, and you'll get the following before the deletion:

Index 0 contains 0.
Index 1 contains 1.
Index 2 contains 2.
Index 3 contains 3.
Index 4 contains 4.
Index 5 contains 5.
And the following after:

Index 0 contains 0.
Index 1 contains 1.
Index 2 contains 2.
Index 3 contains 3.
Index 4 contains 4.

Yup, that's it! Even though we call it a deletion, it's not like we actually freed up the space for a new element, right? This is because we don't actually need to free up any space. Simply overwriting the value at a certain index deletes the element at that index. Seeing as the length variable in our examples tells us the next index where we can insert a new element, reducing it by one ensures the next new element is written over the deleted one. This also indicates that the Array now contains one less element, which is exactly what we want programmatically.

## Deleting From the Start of an Array

Next comes the costliest of all deletion operations for an Array—deleting the first element. If we want to delete the first element of the Array, that will create a vacant spot at the 0th index. To fill that spot, we will shift the element at index 1 one step to the left. Going by the ripple effect, every element all the way to the last one will be shifted one place to the left. This shift of elements takes O(N) time, where N is the number of elements in the Array.

Here is how deleting the first element looks in code.

```csharp
// Starting at index 1, we shift each element one position to the left.
for (int i = 1; i < length; i++)
{
    // Shift each element one position to the left
    intArray[i - 1] = intArray[i];
}

// Reduce the length of the array by 1 to maintain consistency.
length--;
```
Starting from index 1, we'll move every element one position to its left, effectively "deleting" the element at index 0. We also need to reduce length by 1 so that the next new element is inserted in the correct position.

And here's the output we'll get, with our updated printArray function.

Index 0 contains 1.
Index 1 contains 2.
Index 2 contains 3.
Index 3 contains 4.

## Deleting From Anywhere in the Array

For deletion at any given index, the empty space created by the deleted item will need to be filled. Each of the elements to the right of the index we're deleting at will get shifted to the left by one. Deleting the first element of an Array is a special case of deletion at a given index, where the index is 0. This shift of elements takes O(K) time where K is the number of elements to the right of the given index. Since potentially K=N, we say that the time complexity of this operation is also O(N).

Here is the code to delete the element at index 1. To do this, we'll need to move over the elements after it in the Array.

```csharp
// Say we want to delete the element at index 1
for (int i = 2; i < length; i++)
{
    // Shift each element one position to the left
    intArray[i - 1] = intArray[i];
}

// Reduce the length of the array to maintain consistency
length--;
```
Notice that this works exactly like deleting the first element, except that we don't touch the elements that are at lower indexes than the element we're deleting.

Here is the output from the printArray function.

Index 0 contains 1.
Index 1 contains 3.
Index 2 contains 4.

Did that all make sense? To help you cement what you've learned, here's a couple of programming problems for you to try. You should try to solve them without making a new Array. Do this by using the deletion techniques we've investigated above.

## Search in an Array

Finally, we're going to look at the most important operation of all. More often than not, it comes down to the speed of searching for an element in a data structure that helps programmers make design choices for their codebases.

There's more than one way of searching an Array, but for now, we're going to focus on the simplest way. Searching means to find an occurrence of a particular element in the Array and return its position. We might need to search an Array to find out whether or not an element is present in the Array. We might also want to search an Array that is arranged in a specific fashion to determine which index to insert a new element at.

If we know the index in the Array that may contain the element we're looking for, then the search becomes a constant time operation—we simply go to the given index and check whether or not the element is there.

Linear Search
If the index is not known, which is the case most of the time, then we can check every element in the Array. We continue checking elements until we find the element we're looking for, or we reach the end of the Array. This technique for finding an element by checking through all elements one by one is known as the linear search algorithm. In the worst case, a linear search ends up checking the entire Array. Therefore, the time complexity for a linear search is O(N).

Let's see the linear search algorithm in action, with all the edge cases handled properly. When we say edge cases, we basically mean scenarios that you wouldn't expect to encounter. For example, the element you're searching for might not even exist in the Array. Or, an even rarer, but possible, scenario is that the input Array doesn't contain any elements at all, or perhaps it is null. It's important to handle all of these edge cases within the code.

```csharp
public static bool LinearSearch(int[] array, int length, int element)
{
    // Check for edge cases. Is the array null or empty?
    // If it is, then we return false because the element we're
    // searching for couldn't possibly be in it.
    if (array == null || length == 0)
    {
        return false;
    }

    // Carry out the linear search by checking each element,
    // starting from the first one.
    for (int i = 0; i < length; i++)
    {
        // We found the element at index i.
        // So we return true to say it exists.
        if (array[i] == element)
        {
            return true;
        }
    }

    // We didn't find the element in the array.
    return false;
}
```
That's the function we can call to determine whether or not a particular element is in an Array. Notice how we take care of the edge cases before proceeding with the actual search, and that we don't check the rest of the elements once we'd found the element we were looking for.

There are many variations to this algorithm, such as returning the first location, last location, or all the locations (an element could be in the Array more than once). Let's see what happens when we call the linearSearch function.

```csharp
using System;

public class ArraySearch
{
    public static void Main(string[] args)
    {
        // Declare a new array of 6 elements
        int[] array = new int[6];

        // Variable to keep track of the length of the array
        int length = 0;

        // Iterate through the 6 indexes of the array.
        for (int i = 0; i < 6; i++)
        {
            // Add a new element and increment the length as well
            array[length++] = i;
        }

        // Print out the results of searching for 4 and 30
        Console.WriteLine("Does the array contain the element 4? - " + LinearSearch(array, length, 4));
        Console.WriteLine("Does the array contain the element 30? - " + LinearSearch(array, length, 30));

        // Output:
        // Does the array contain the element 4? - True
        // Does the array contain the element 30? - False
    }

    public static bool LinearSearch(int[] array, int length, int element)
    {
        // Check for edge cases
        if (array == null || length == 0)
        {
            return false;
        }

        // Check each element starting from the first one
        for (int i = 0; i < length; i++)
        {
            // We found the element at index i, so return true.
            if (array[i] == element)
            {
                return true;
            }
        }

        // We didn't find the element in the array.
        return false;
    }
}
```
As expected, we're able to find the element 4 in the Array, but not 30.

## Binary Search

This section is optional. It briefly introduces a more advanced searching algorithm that you will learn more about in a later Explore Card.

There is another way of searching an Array. If the elements in the Array are in sorted order, then we can use binary search. Binary search is where we repeatedly look at the middle element in the Array, and determine whether the element we're looking for must be to the left, or to the right. Each time we do this, we're able to halve the number of elements we still need to search, making binary search a lot faster than linear search!

The downside of binary search though is that it only works if the data is sorted. If we only need to perform a single search, then it's faster to just do a linear search, as it takes longer to sort than to linear search. If we're going to be performing a lot of searches, it is often worth sorting the data first so that we can use binary search for the repeated searches.

In-Place Array Operations Introduction
In programming interviews, the interviewer often expects you to minimise the time and space complexity of your implementation. In-place Array operations help to reduce space complexity, and so are a class of techniques that pretty much everybody encounters regularly in interviews.

So, what are in-place array operations?

The best way of answering this question is to look at an example.

Given an Array of integers, return an Array where every element at an even-indexed position is squared.

Input: array = [9, -2, -9, 11, 56, -12, -3]
Output: [81, -2, 81, 11, 3136, -12, 9]
Explanation: The numbers at even indexes (0, 2, 4, 6) have been squared, 
whereas the numbers at odd indexes (1, 3, 5) have been left the same.
This problem is hopefully very straightforward. Have a quick think about how you would implement it as an algorithm though, possibly jotting down some code on a piece of paper.

Anyway, there are two ways we could approach it. The first is to create a new Array, of the same size as the original. Then, we should copy the odd-indexed elements and square the even-indexed elements, writing them into the new Array.

```csharp
public int[] SquareEven(int[] array, int length)
{
    // Check for edge cases
    if (array == null)
    {
        return null;
    }

    // Create a resultant array to hold the result
    int[] result = new int[length];

    // Iterate through the original array
    for (int i = 0; i < length; i++)
    {
        // Get the element from index i of the input array
        int element = array[i];

        // If the index is an even number, then square the element
        if (i % 2 == 0)
        {
            element *= element;
        }

        // Write the element into the result array
        result[i] = element;
    }

    // Return the result array
    return result;
}
```
The above approach, although correct, is an inefficient way of solving the problem. This is because it uses O(length) extra space.

Instead, we could iterate over the original input Array itself, overwriting every even-indexed element with its own square. This way, we won't need that extra space. It is this technique of working directly in the input Array, and not creating a new Array, that we call in-place. In-place Array operations are a big deal for programming interviews, where there is a big focus on minimising both time and space complexity of algorithms.

Here's the in-place implementation for our squareEven(...) function.

```csharp
public int[] SquareEven(int[] array, int length)
{
    // Check for edge cases
    if (array == null)
    {
        return array;
    }

    // Iterate through even indices of the original array
    for (int i = 0; i < length; i += 2)
    {
        // Index is even, so square the element and replace the original value
        array[i] *= array[i];
    }

    // Return the modified original array
    return array;
}
```

An important difference for in-place vs not in-place is that in-place modifies the input Array. This means that other functions can no longer access the original data, because it has been overwritten. We'll talk more about this in a bit.

A Better Repeated Deletion Algorithm - Intro
Let's look at one more example. This time, the result Array is smaller than the input Array! How's this going to work? Let's find out! Here's the problem description:

Given a sorted array, remove the duplicates such that each element appears only once.

Input: array = [1, 1, 2]
Output: [1, 2]
Input: array = [0, 0, 1, 1, 1, 2, 2, 3, 3, 4]
Output: [0, 1, 2, 3, 4]
You've hopefully already done this question, back when we were looking at deleting items from an Array. In that case, your algorithm might have looked something like this.

```csharp
public class Solution {
    public int RemoveDuplicates(int[] nums) {
        // The initial length is simply the capacity.
        int length = nums.Length;

        // Assume the last element is always unique.
        // Then for each element, delete it if it is
        // the same as the one after it.
        for (int i = length - 2; i >= 0; i--) {
            if (nums[i] == nums[i + 1]) {
                // Delete the element at index i.
                for (int j = i + 1; j < length; j++) {
                    nums[j - 1] = nums[j];
                }
                // Reduce the length by 1.
                length--;
            }
        }

        // Return the new length.
        return length;
    }
}
```
This is actually an in-place algorithm, because it doesn't require any extra space—its space complexity is O(1). However, the time complexity's not so flash, at O(N2). This is because of the nested loop.

We want to get the algorithm down to an O(N) time complexity.

If we don't try to do this in-place, then it's straightforward. We could simply iterate through the Array, adding all unique elements to a new Array. Seeing as the input Array is sorted, we can easily identify all unique elements, as they are the first element, and then any element that is different to the one before it.

One potential problem is that we actually don't know how long the result Array needs to be. Remember how that must be decided when the Array is created? The best solution for this problem is to do an initial pass, counting the number of unique elements. Then, we can create the result Array and do a second pass to add the elements into it. Here's the code for this approach.

```csharp
public int[] CopyWithRemovedDuplicates(int[] nums) {
    // Check for edge cases.
    if (nums == null || nums.Length == 0) {
        return nums;
    }

    // Count how many unique elements are in the Array.
    int uniqueNumbers = 0;
    for (int i = 0; i < nums.Length; i++) {
        // An element should be counted as unique if it's the first
        // element in the Array, or is different to the one before it.
        if (i == 0 || nums[i] != nums[i - 1]) {
            uniqueNumbers++;
        }
    }

    // Create a result Array.
    int[] result = new int[uniqueNumbers];

    // Write the unique elements into the result Array.
    int positionInResult = 0;
    for (int i = 0; i < nums.Length; i++) {
        // Same condition as in the previous loop. Except this time, we can write
        // each unique number into the result Array instead of just counting them.
        if (i == 0 || nums[i] != nums[i - 1]) {
            result[positionInResult] = nums[i];
            positionInResult++;
        }
    }

    return result;
}
```

Did you notice the fatal flaw with this approach though? It's the wrong return type! We could copy the result array back into the input array... and then return the length... but this is not what the question wants us to do. We want to instead do the deletions with a space complexity of O(1) and a time complexity of O(N).

## A Better Repeated Deletion Algorithm - Answer

Anyway, the algorithm with O(N) space is surprisingly similar to the one without. Interestingly, it's simpler though, because it doesn't need to firstly determine the size of the output.

Implementing this requires the use of the two-pointer technique. This is where we iterate over the Array in two different places at the same time.

Read all the elements like we did before, to identify the duplicates. We call this our readPointer.
Keep track of the next position in the front to write the next unique element we've found. We call this our writePointer.

```csharp
public int RemoveDuplicates(int[] nums) {
    // Check for edge cases.
    if (nums == null) {
        return 0;
    }
    
    // Use the two-pointer technique to remove the duplicates in-place.
    // The first element shouldn't be touched; it's already in its correct place.
    int writePointer = 1;
    
    // Go through each element in the array.
    for (int readPointer = 1; readPointer < nums.Length; readPointer++) {
        // If the current element we're reading is *different* from the previous
        // element...
        if (nums[readPointer] != nums[readPointer - 1]) {
            // Copy it into the next position at the front, tracked by writePointer.
            nums[writePointer] = nums[readPointer];
            // Increment writePointer, because the next element should be written one space over.
            writePointer++;
        }
    }
    
    // This turns out to be the correct length value.
    return writePointer;
}
```
You're quite possibly surprised that this even works. How are we not overwriting any elements that we haven't yet looked at?! The key thing to notice is that the condition is such that it is impossible for writePointer to ever get ahead of the readPointer. This means that we would never overwrite a value that we haven't yet read

When to Use In-Place Array Operations
It's important to know when to use in-place Array operations—they might not always be the way to go.

For example, if we'll need the original array values again later, then we shouldn't be overwriting them. In these cases, it's best to create a copy to work with, or to simply not use in-place techniques. It's important to be very careful when working with existing code that somebody else has written. If other code is depending on the original Array to work, then you might completely break the program if you modify that Array!

In-place operations are valuable when appropriate because they reduce the space complexity of an algorithm. Instead of requiring O(N) space, we can reduce it down to O(1).
## Dynamic Arrays

Unlike static arrays, **dynamic arrays** can grow and shrink during runtime. Internally, dynamic arrays are implemented as wrappers around static arrays. When the capacity of a dynamic array is exceeded:

1. A larger static array is allocated (typically twice the size).
2. Existing elements are copied to the new array.
3. New elements are added.

This resizing process enables dynamic arrays to offer flexibility at the cost of occasional resizing overhead.

### Example: Implementing a Dynamic Array in C#

Here’s a simplified implementation of a dynamic array:

```csharp
public class DynamicArray
{
    private int[] items;
    private int size;

    public DynamicArray(int initialCapacity = 4)
    {
        items = new int[initialCapacity];
        size = 0;
    }

    public void Add(int item)
    {
        if (size == items.Length)
        {
            Resize();
        }
        items[size++] = item;
    }

    public void AddAtBeginning(int item)
    {
        Insert(0, item);
    }

    public void Insert(int index, int item)
    {
        if (index < 0 || index > size)
        {
            throw new Exception("Index out of bounds.");
        }

        if (size == items.Length)
        {
            Resize();
        }

        for (int i = size - 1; i >= index; i--)
        {
            items[i + 1] = items[i];
        }

        items[index] = item;
        size++;
    }

    public int Get(int index)
    {
        if (index >= size || index < 0)
        {
            throw new Exception("Index out of bounds.");
        }
        return items[index];
    }

    public int Find(int key)
    {
        for (int i = 0; i < size; i++)
        {
            if (items[i] == key)
            {
                return i;
            }
        }
        return -1; // Not found
    }

    public void DeleteAtEnd()
    {
        if (size == 0)
        {
            throw new Exception("Array is empty.");
        }
        size--;
    }

    public void DeleteAtBeginning()
    {
        DeleteAtIndex(0);
    }

    public void DeleteAtIndex(int index)
    {
        if (index < 0 || index >= size)
        {
            throw new Exception("Index out of bounds.");
        }

        for (int i = index; i < size - 1; i++)
        {
            items[i] = items[i + 1];
        }
        size--;
    }

    private void Resize()
    {
        int newCapacity = items.Length * 2;
        if (items.Length == 0)
        {
            newCapacity = 4;
        }

        int[] newArray = new int[newCapacity];
        for (int i = 0; i < size; i++)
        {
            newArray[i] = items[i];
        }
        items = newArray;
    }

    public string Print()
    {
        string result = "";
        for (int i = 0; i < size; i++)
        {
            result += items[i] + " ";
        }
        return result;
    }
}
```
### Key Operations in Dynamic Arrays

1. **Add Element at the End**:
   ```csharp
   public void Add(int item)
   {
       if (size == items.Length)
       {
           Resize();
       }
       items[size++] = item;
   }
   ```

2. **Add Element at the Beginning**:
   ```csharp
   public void AddAtBeginning(int item)
   {
       Insert(0, item);
   }
   ```

3. **Insert Element at Index**:
   ```csharp
   public void Insert(int index, int item)
   {
       if (index < 0 || index > size)
       {
           throw new Exception("Index out of bounds.");
       }

       if (size == items.Length)
       {
           Resize();
       }

       for (int i = size - 1; i >= index; i--)
       {
           items[i + 1] = items[i];
       }

       items[index] = item;
       size++;
   }
   ```

4. **Delete Element at the End**:
   ```csharp
   public void DeleteAtEnd()
   {
       if (size == 0)
       {
           throw new Exception("Array is empty.");
       }
       size--;
   }
   ```

5. **Delete Element at the Beginning**:
   ```csharp
   public void DeleteAtBeginning()
   {
       DeleteAtIndex(0);
   }
   ```

6. **Delete Element at Index**:
   ```csharp
   public void DeleteAtIndex(int index)
   {
       if (index < 0 || index >= size)
       {
           throw new Exception("Index out of bounds.");
       }

       for (int i = index; i < size - 1; i++)
       {
           items[i] = items[i + 1];
       }
       size--;
   }
   ```

7. **Get by Index**:
   ```csharp
   public int Get(int index)
   {
       if (index >= size || index < 0)
       {
           throw new Exception("Index out of bounds.");
       }
       return items[index];
   }
   ```

8. **Find by Key**:
   ```csharp
   public int Find(int key)
   {
       for (int i = 0; i < size; i++)
       {
           if (items[i] == key)
           {
               return i;
           }
       }
       return -1; // Not found
   }
   ```

9. **Print Array**:
   ```csharp
   public string Print()
   {
       string result = "";
       for (int i = 0; i < size; i++)
       {
           result += items[i] + " ";
       }
       return result;
   }
   ```
   
## Multidimentional Array

In some languages, the multidimensional array is actually implemented internally as a one-dimensional array while in some other languages, there is actually no multidimensional array at all.

1. C++ stores the two-dimensional array as a one-dimensional array.

So actually A[i][j] equals to A[i * N + j] if we defined A as a one-dimensional array which also contains M * N elements.

2. In Java, the two-dimensional array is actually a one-dimensional array which contains M elements, each of which is an array of N integers.

Similar to a one-dimensional array, a two-dimensional array also consists of a sequence of elements. But the elements can be laid out in a rectangular grid rather than a line.

```csharp
using System;

public class MainClass
{
    private static void PrintArray(int[][] a)
    {
        // Print the arrays
        for (int i = 0; i < a.Length; ++i)
        {
            Console.WriteLine(a[i]);
        }

        // Print the elements of the arrays
        for (int i = 0; i < a.Length; ++i)
        {
            if (a[i] != null)
            {
                for (int j = 0; j < a[i].Length; ++j)
                {
                    Console.Write(a[i][j] + " ");
                }
            }
            Console.WriteLine();
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Example I:");
        int[][] a = new int[2][];
        a[0] = new int[5]; // Initialize the inner arrays
        a[1] = new int[5];
        PrintArray(a);

        Console.WriteLine("Example II:");
        int[][] b = new int[2][]; // Inner arrays are not initialized
        PrintArray(b);

        Console.WriteLine("Example III:");
        b[0] = new int[3]; // Initialize individual inner arrays
        b[1] = new int[5];
        PrintArray(b);
    }
}
```

### Comparison of Static vs. Dynamic Arrays

| Feature                | Static Array           | Dynamic Array             |
|------------------------|------------------------|---------------------------|
| **Size**               | Fixed                 | Flexible                  |
| **Memory Usage**       | Fixed allocation      | Can grow/shrink           |
| **Access Time**        | \(O(1)\)             | \(O(1)\)                 |
| **Resize Overhead**    | N/A                  | Occasional \(O(n)\)       |
| **Insertion/Deletion** | N/A                  | \(O(n)\)                  |


