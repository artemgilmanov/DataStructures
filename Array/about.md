# Static and Dynamic Arrays

## Static Arrays

A **static array** has a fixed size determined at initialization. It cannot grow or shrink during program execution. For example, in C#:

```csharp
int[] numbers = new int[10];
```

All elements are initialized to their default values:
- For `int`, elements are set to `0`.
- For `string`, elements are set to `null`.

### Characteristics of Static Arrays

- **Fixed Size**: Size is defined at creation and cannot be changed.
- **Efficient Access**: Accessing any element by index is O(1).
- **Sequential Memory Allocation**: Ensures quick access but may require careful memory management.

### Operations on Static Arrays

1. **Access Elements**:
   ```csharp
   int element = numbers[2]; // Gets the third element.
   ```
2. **Modify Elements**:
   ```csharp
   numbers[2] = 5; // Sets the third element to 5.
   ```
3. **Iterate Through Array**:
   Using `for`:
   ```csharp
   for (int i = 0; i < numbers.Length; i++)
   {
       Console.WriteLine(numbers[i]);
   }
   ```
   Using `foreach`:
   ```csharp
   foreach (int item in numbers)
   {
       Console.WriteLine(item);
   }
   ```
4. **Check Array Length**:
   ```csharp
   int length = numbers.Length; // Gets the length of the array.
   ```

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

## What Is an Array?

An array is a collection of elements of the same type, stored in contiguous memory locations. This guarantees:

1. **Contiguous Memory**: Elements are stored sequentially in memory.
2. **Homogeneous Data**: All elements are of the same type, occupying equal memory.
3. **Indexed Access**: Each element can be accessed via its index.

These properties allow constant-time O(1) access to any element.

An array is a basic data structure to store a collection of elements sequentially. But elements can be accessed randomly since each element in the array can be identified by an array index.
An array can have one or more dimensions. Here we start with the one-dimensional array, which is also called the linear array. Here is an example:
 
```csharp
using System;

public class MainClass
{
    public static void Main(string[] args)
    {
        // 1. Initialize
        int[] a0 = new int[5];
        int[] a1 = { 1, 2, 3 };

        // 2. Get Length
        Console.WriteLine("The size of a1 is: " + a1.Length);

        // 3. Access Element
        Console.WriteLine("The first element is: " + a1[0]);

        // 4. Iterate all Elements
        Console.Write("[Version 1] The contents of a1 are:");
        for (int i = 0; i < a1.Length; ++i)
        {
            Console.Write(" " + a1[i]);
        }
        Console.WriteLine();

        Console.Write("[Version 2] The contents of a1 are:");
        foreach (int item in a1)
        {
            Console.Write(" " + item);
        }
        Console.WriteLine();

        // 5. Modify Element
        a1[0] = 4;

        // 6. Sort
        Array.Sort(a1);
    }
}
```
As we mentioned in the previous article, an array has a fixed capacity and we need to specify the size of the array when we initialize it. Sometimes this will be somewhat inconvenient and wasteful.

Therefore, most programming languages offer built-in dynamic array which is still a random access list data structure but with variable size. For example, we have vector in C++ and ArrayList in Java.

```csharp
using System;
using System.Collections.Generic;

public class MainClass
{
    public static void Main(string[] args)
    {
        // 1. Initialize
        List<int> v0 = new List<int>();
        List<int> v1 = null; // v1 is null

        // 2. Cast an array to a list
        int[] a = { 0, 1, 2, 3, 4 };
        v1 = new List<int>(a);

        // 3. Make a copy
        List<int> v2 = v1;                     // another reference to v1
        List<int> v3 = new List<int>(v1);      // make an actual copy of v1

        // 4. Get length
        Console.WriteLine("The size of v1 is: " + v1.Count);

        // 5. Access element
        Console.WriteLine("The first element in v1 is: " + v1[0]);

        // 6. Iterate the list
        Console.Write("[Version 1] The contents of v1 are:");
        for (int i = 0; i < v1.Count; ++i)
        {
            Console.Write(" " + v1[i]);
        }
        Console.WriteLine();

        Console.Write("[Version 2] The contents of v1 are:");
        foreach (int item in v1)
        {
            Console.Write(" " + item);
        }
        Console.WriteLine();

        // 7. Modify element
        v2[0] = 5;  // modifying v2 will also modify v1
        Console.WriteLine("The first element in v1 is: " + v1[0]);

        v3[0] = -1; // modifying v3 will not modify v1
        Console.WriteLine("The first element in v1 is: " + v1[0]);

        // 8. Sort
        v1.Sort();

        // 9. Add new element at the end of the list
        v1.Add(-1);
        v1.Insert(1, 6);

        // 10. Delete the last element
        v1.RemoveAt(v1.Count - 1);
    }
}
```
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

## Principle
In some languages, the multidimensional array is actually implemented internally as a one-dimensional array while in some other languages, there is actually no multidimensional array at all.

1. C++ stores the two-dimensional array as a one-dimensional array.

The picture below shows the actual structure of a M * N array A:

So actually A[i][j] equals to A[i * N + j] if we defined A as a one-dimensional array which also contains M * N elements.

2. In Java, the two-dimensional array is actually a one-dimensional array which contains M elements, each of which is an array of N integers.

The picture below shows the actual structure of a two-dimensional array A in Java:

Dynamic 2D Array
Similar to the one-dimensional dynamic array, we can also define a dynamic two-dimensional array. Actually, it can be just a nested dynamic array.

## Writing Items into an Array

To put a DVD into the Array, we need to decide which of the 15 places we'd like it to go in. Each of the places is identified using a number in the range of 0 to N - 1. The 1st place is 0, the 2nd place is 1, the 3rd place is 2... all the way up to the 15th place, which is 14. We call these numbers that identify each place indexes.

Let's put the DVD for The Avengers into the eighth place of the Array we created above.

```csharp
// Firstly, we need to actually create a DVD object for The Avengers.
DVD avengersDVD = new DVD("The Avengers", 2012, "Joss Whedon");

// Next, we'll put it into the 8th place of the array. Remember, because we
// started numbering from 0, the index we want is 7.
dvdCollection[7] = avengersDVD;
```
And that's it. We've put the DVD for The Avengers into our Array! Let's put a few more DVD's in.

```csharp
// Create DVD objects
DVD incrediblesDVD = new DVD("The Incredibles", 2004, "Brad Bird");
DVD findingDoryDVD = new DVD("Finding Dory", 2016, "Andrew Stanton");
DVD lionKingDVD = new DVD("The Lion King", 2019, "Jon Favreau");

// Put "The Incredibles" into the 4th place: index 3.
dvdCollection[3] = incrediblesDVD;

// Put "Finding Dory" into the 10th place: index 9.
dvdCollection[9] = findingDoryDVD;

// Put "The Lion King" into the 3rd place: index 2.
dvdCollection[2] = lionKingDVD;
```
Notice that we put The Incredibles into the Array at index 3. What happens if we now run this next piece of code?

```csharp
// Create a DVD object for "Star Wars"
DVD starWarsDVD = new DVD("Star Wars", 1977, "George Lucas");

// Replace the DVD in the 4th place (index 3) with "Star Wars"
dvdCollection[3] = starWarsDVD;
```
Because we just put Star Wars into the Array at index 3, The Incredibles is no longer in the Array. It has been overwritten! If we still have the incrediblesDVD variable in scope, then the DVD still exists in the computer's memory. If not though, it's totally gone!

## Reading Items from an Array

We can check what's at a particular Array index.

```csharp
// Print out what's in indexes 7, 10, and 3
Console.WriteLine(dvdCollection[7]);
Console.WriteLine(dvdCollection[10]); // This will throw an exception as the index is out of bounds.
Console.WriteLine(dvdCollection[3]);
```
Notice that because we haven't yet put anything at index 10, the value it contains is null. In other languages, such as C, the Array slot could contain completely random data. Java always initializes empty Array slots to null if the Array contains objects, or to default values if it contains primitive types. For example, the array int [] would contain the default value of 0 for each element, float[] would contain default values of 0.0, and bool[] would contain default values of false.

## Writing Items into an Array with a Loop

We commonly use a loop to put lots of values into an Array. To illustrate this, let's go to another example. This time, we're going to create an Array of ints and put the first 10 square numbers into it.

```csharp
int[] squareNumbers = new int[10];

// Go through each of the Array indexes, from 0 to 9.
for (int i = 0; i < 10; i++)
{
    // We need to be careful with the 0-indexing. The next square number
    // is given by (i + 1) * (i + 1).
    // Calculate it and insert it into the Array at index i.
    int square = (i + 1) * (i + 1);
    squareNumbers[i] = square;
}
```
Reading Items from an Array with a Loop
We can also use a loop to print out everything that's in the Array.

```csharp
// Go through each of the array indexes, from 0 to 9.
for (int i = 0; i < 10; i++)
{
    // Access and print what's at the i-th index.
    Console.WriteLine(squareNumbers[i]);
}

// Will print:
// 1
// 4
// 9
// 16
// 25
// 36
// 49
// 64
// 81
// 100
```
One last thing worth knowing now is that there's a more elegant way of printing out the values of an Array—a variant of the for loop, commonly referred to as a "for each" loop.

```csharp
// For each VALUE in the array.
foreach (int square in squareNumbers)
{
    // Print the current value of square.
    Console.WriteLine(square);
}

// Prints exactly the same as the previous example.
```
You'll probably agree that this code is a lot simpler to read. We can use it whenever we don't need the index values. For actually writing the squares into the Array, it wouldn't have worked because we needed to work with the actual index numbers. You don't have to use a "for each" loop when you're starting out, but we recommend you become comfortable with it before interviews. Simple, elegant code is good code!

## Array Capacity VS Length

If somebody asks you how long the DVD Array is, what would your answer be?

There are two different answers you might have given.

The number of DVDs the box could hold, if it was full, or
The number of DVDs currently in the box.
Both answers are correct, and both have very different meanings! It's important to understand the difference between them, and use them correctly. We call the first one the capacity of the Array, and the second one the length of the Array.

## Array Capacity

Let's say we've created a new Array like this.

DVD[] array = new DVD[6]
Is it a valid operation to insert an element at array[6]? What about at array[10]?

Nope, neither of these are valid. When we created the Array, we specified that it can hold up to 6 DVD's. This is the Array's capacity.

Remembering that indexing starts at 0, we can only insert items at array[0], array[1], array[2], array[3], array[4], and array[5]. Trying to put an element anywhere else, such as array[-3], array[6], or array[100] will cause your code to crash with an ArrayIndexOutOfBoundsException!

The Array's capacity must be decided when the Array is created. The capacity cannot be changed later. Going back to our DVD's-in-a-cardboard-box-analogy, changing the capacity of an Array would be akin to trying to make a cardboard box bigger. Trying to make a fixed-size cardboard box bigger is impractical, and it's the same as an Array on a computer!

So, what do we do if we get a 7th DVD and we'd like all our DVD's in the same Array? Well, unfortunately it's the same as it is with our cardboard box. We'll need to go get a larger one, and then move all the existing DVD's into it, along with the new one.

The capacity of an Array in Java can be checked by looking at the value of its length attribute. This is done using the code arr.length, where arr is the name of the Array. Different programming languages have different ways of checking the length of an Array.

int capacity = array.length;
System.out.println("The Array has a capacity of " + capacity);
Running this code will give the following output:

The Array has a capacity of 6
Yup, it's a bit confusing that you need to access the capacity of an Array by using .length. Unfortunately, this is just something you'll need to get used to.

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

Handling Array Parameters
Most Array questions on LeetCode have an Array passed in as a parameter, with no "length" or "capacity" parameter. What do we mean by this? Well, let's look at an example. Here is the description for the first problem you'll be asked to solve.

Given a binary array, find the maximum number of consecutive 1s in this array.

And here is the code template you're given.

```csharp
public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        // Implementation goes here
        return 0;
    }
}
``` 
The only parameter is nums; an Array. You couldn't possibly solve this question without knowing how long nums is. Well, luckily it's straightforward. When an Array is given as a parameter, without any additional information, you can safely assume that length == capacity. That is, the Array is the exact right size to hold all of it's data. We can, therefore, use .length.

Be careful though, Array's are 0-indexed. The capacity/ length is a number of items, not a highest index. The highest index is .length - 1. Therefore, to iterate over all items in the Array, we can do the following.

```csharp
public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        // Hint: Initialize and declare a variable here to 
        // keep track of how many 1's you've seen in a row.
        for (int i = 0; i < nums.Length; i++) {
            // Do something with element nums[i].
        }
        return 0; // Replace with actual return value after implementation.
    }
}
``` 
And that is the basics of Arrays that you'll need to get started! In the next chapter, we'll look at some of the fundamental techniques we use to work with Arrays.

Before that though, we have a few introductory Array problems for you to play around with, starting with the one we briefly looked at above. Enjoy!

# Basic Array Operations

Now that we have a fairly good understanding of what an Array actually is, and how it is stored inside the computer's physical memory, the next important thing to look at is all the operations that Arrays support. An Array is a data structure, which means that it stores data in a specific format and supports certain operations on the data it stores. Consider the DVD inventory management software from the introduction section. Let's look at some operations you might want to perform using this software:

Insert a new DVD into the collection at a specific location.
Delete a DVD from the existing collection if it doesn't make sense to keep it in the inventory anymore.
Search for a particular DVD in the collection. This is one of the most commonly executed operation on our collection, because our inventory management software would be used hundreds of times a day to look for a particular DVD asked for by the user.
In this section, we'll be looking at the three basic operations that are supported by almost every data structure; insertion, deletion, and search.

# Array Insertions

In the previous chapter, we looked at how to write elements to an Array. There is a lot more to inserting elements though, as we're about to see!

Inserting a new element into an Array can take many forms:

Inserting a new element at the end of the Array.
Inserting a new element at the beginning of the Array.
Inserting a new element at any given index inside the Array.

## Inserting at the End of an Array

At any point in time, we know the index of the last element of the Array, as we've kept track of it in our length variable. All we need to do for inserting an element at the end is to assign the new element to one index past the current last element.

This is pretty much the same as we've already seen. Here's the code to make a new Array that can hold up to 6 items, and then add items into the first 3 indexes.
Here is the equivalent code in C#:

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
Here is the equivalent code in C#:

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

Notice how indexes 3, 4, and 5 all contain 0? This is because Java fills unused int Array slots with 0s.

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
Here is the equivalent code in C#:

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
Here is the equivalent C# code:

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

Here is the equivalent C# code:

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
Here is the equivalent program in C#:

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

Here is the equivalent method in C#:

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

Here's the equivalent implementation of the given Java method in C#:

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

### Comparison of Static vs. Dynamic Arrays

| Feature                | Static Array           | Dynamic Array             |
|------------------------|------------------------|---------------------------|
| **Size**               | Fixed                 | Flexible                  |
| **Memory Usage**       | Fixed allocation      | Can grow/shrink           |
| **Access Time**        | \(O(1)\)             | \(O(1)\)                 |
| **Resize Overhead**    | N/A                  | Occasional \(O(n)\)       |
| **Insertion/Deletion** | N/A                  | \(O(n)\)                  |

### Built-in Dynamic Arrays in C#

C# provides a built-in dynamic array implementation: `List<T>`. Here’s how to use it:

```csharp
using System.Collections.Generic;

List<int> numbers = new List<int>();
numbers.Add(7);
numbers.Insert(1, 10); // Insert 10 at index 1

Console.WriteLine(numbers[1]); // Access element at index 1
numbers.RemoveAt(0); // Remove the first element
```

`List<T>` handles resizing and other operations internally, making it ideal for most scenarios.
