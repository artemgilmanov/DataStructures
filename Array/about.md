# Static and Dynamic Arrays

Arrays are a fundamental data structure in computer science. They allow for the storage and manipulation of multiple elements under a single variable name. Despite their ubiquity in modern programming languages like C#, Python, and Java, their underlying mechanisms often remain hidden. In this document, arrays are demystified by examining how they work at the memory level and explore their static and dynamic variants.

## What Is an Array?

An array is a collection of elements of the same type, stored in contiguous memory locations. This guarantees:

1. **Contiguous Memory**: Elements are stored sequentially in memory.
2. **Homogeneous Data**: All elements are of the same type, occupying equal memory.
3. **Indexed Access**: Each element can be accessed via its index.

These properties allow constant-time \(O(1)\) access to any element using the formula: n+k⋅q

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
- **Efficient Access**: Accessing any element by index is \(O(1)\).
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

## Conclusion

Static arrays are simple and efficient but lack flexibility. Dynamic arrays, while more versatile, come with additional overhead for resizing. Understanding how these structures work under the hood allows developers to write more efficient and optimized code.

For scenarios where the size is known in advance, static arrays are a better choice. When flexibility is required, dynamic arrays or built-in structures like `List<T>` in C# offer the best of both worlds.

## 2

An array is a basic data structure to store a collection of elements sequentially. But elements can be accessed randomly since each element in the array can be identified by an array index.
An array can have one or more dimensions. Here we start with the one-dimensional array, which is also called the linear array. Here is an example:
 
In the above example, there are 6 elements in array A. That is to say, the length of A is 6. We can use A[0] to represent the first element in the array. Therefore, A[0] = 6. Similarly, A[1] = 3, A[2] = 8 and so on.


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
Principle
In some languages, the multidimensional array is actually implemented internally as a one-dimensional array while in some other languages, there is actually no multidimensional array at all.

1. C++ stores the two-dimensional array as a one-dimensional array.

The picture below shows the actual structure of a M * N array A:

So actually A[i][j] equals to A[i * N + j] if we defined A as a one-dimensional array which also contains M * N elements.

2. In Java, the two-dimensional array is actually a one-dimensional array which contains M elements, each of which is an array of N integers.

The picture below shows the actual structure of a two-dimensional array A in Java:

Dynamic 2D Array
Similar to the one-dimensional dynamic array, we can also define a dynamic two-dimensional array. Actually, it can be just a nested dynamic array. You can try it out by yourself.

Writing Items into an Array
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

Reading Items from an Array
We can check what's at a particular Array index.

```csharp
// Print out what's in indexes 7, 10, and 3
Console.WriteLine(dvdCollection[7]);
Console.WriteLine(dvdCollection[10]); // This will throw an exception as the index is out of bounds.
Console.WriteLine(dvdCollection[3]);
```
Notice that because we haven't yet put anything at index 10, the value it contains is null. In other languages, such as C, the Array slot could contain completely random data. Java always initializes empty Array slots to null if the Array contains objects, or to default values if it contains primitive types. For example, the array int [] would contain the default value of 0 for each element, float[] would contain default values of 0.0, and bool[] would contain default values of false.

Writing Items into an Array with a Loop
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

Array Capacity VS Length
Report Issue
If somebody asks you how long the DVD Array is, what would your answer be?

There are two different answers you might have given.

The number of DVDs the box could hold, if it was full, or
The number of DVDs currently in the box.
Both answers are correct, and both have very different meanings! It's important to understand the difference between them, and use them correctly. We call the first one the capacity of the Array, and the second one the length of the Array.

Array Capacity
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

Array Length
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

Here's the equivalent class definition in C# without the implementation:

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

Basic Array Operations

Now that we have a fairly good understanding of what an Array actually is, and how it is stored inside the computer's physical memory, the next important thing to look at is all the operations that Arrays support. An Array is a data structure, which means that it stores data in a specific format and supports certain operations on the data it stores. Consider the DVD inventory management software from the introduction section. Let's look at some operations you might want to perform using this software:

Insert a new DVD into the collection at a specific location.
Delete a DVD from the existing collection if it doesn't make sense to keep it in the inventory anymore.
Search for a particular DVD in the collection. This is one of the most commonly executed operation on our collection, because our inventory management software would be used hundreds of times a day to look for a particular DVD asked for by the user.
In this section, we'll be looking at the three basic operations that are supported by almost every data structure; insertion, deletion, and search.

Array Insertions

In the previous chapter, we looked at how to write elements to an Array. There is a lot more to inserting elements though, as we're about to see!

Inserting a new element into an Array can take many forms:

Inserting a new element at the end of the Array.
Inserting a new element at the beginning of the Array.
Inserting a new element at any given index inside the Array.

Inserting at the End of an Array
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

Inserting at the Start of an Array
To insert an element at the start of an Array, we'll need to shift all other elements in the Array to the right by one index to create space for the new element. This is a very costly operation, since each of the existing elements has to be shifted one step to the right. The need to shift everything implies that this is not a constant time operation. In fact, the time taken for insertion at the beginning of an Array will be proportional to the length of the Array. In terms of time complexity analysis, this is a linear time complexity: 
O
(
N
)
O(N), where 
N
N is the length of the Array.

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

Inserting Anywhere in the Array
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

We now have a fun problem for you to test your understanding on. Enjoy!
