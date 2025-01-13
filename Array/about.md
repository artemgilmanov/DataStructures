# Static and Dynamic Arrays

Arrays are a fundamental data structure in computer science. They allow for the storage and manipulation of multiple elements under a single variable name. Despite their ubiquity in modern programming languages like C#, Python, and Java, their underlying mechanisms often remain hidden. In this post, we’ll demystify arrays by examining how they work at the memory level and explore their static and dynamic variants.

## What Is an Array?

An array is a collection of elements of the same type, stored in contiguous memory locations. This guarantees:

1. **Contiguous Memory**: Elements are stored sequentially in memory.
2. **Homogeneous Data**: All elements are of the same type, occupying equal memory.
3. **Indexed Access**: Each element can be accessed via its index.

These properties allow constant-time \(O(1)\) access to any element using the formula:

\[
\text{Address of element } q = \text{Base Address} + (	ext{Size of element} \times \text{Index})
\]

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

