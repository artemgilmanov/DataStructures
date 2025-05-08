## Definition and Classification of Heap

Priority Queues
Before introducing a Heap, let's first talk about a Priority Queue.

Wikipedia: a priority queue is an abstract data type similar to a regular queue or stack data structure in which each element additionally has a "priority" associated with it. In a priority queue, an element with high priority is served before an element with low priority.

In daily life, we would assign different priorities to tasks, start working on the task with the highest priority and then proceed to the task with the second highest priority. This is an example of a Priority Queue.

A common misconception is that a Heap is the same as a Priority Queue, which is not true. A priority queue is an abstract data type, while a Heap is a data structure. Therefore, a Heap is not a Priority Queue, but a way to implement a Priority Queue.

There are multiple ways to implement a Priority Queue, such as array and linked list. However, these implementations only guarantee O(1) time complexity for either insertion or deletion, while the other operation will have a time complexity of O(N). On the other hand, implementing the priority queue with Heap will allow both insertion and deletion to have a time complexity of O(logN). So, what is a Heap?

In this chapter, we will learn to:

Understand the Heap data structure.
Understand Max Heap and Min Heap.
Understand the insertion and deletion of a Heap.
Implement a Heap.


Definition of Heap
According to Wikipedia, a Heap is a special type of binary tree. A heap is a binary tree that meets the following criteria:

Is a complete binary tree;
The value of each node must be no greater than (or no less than) the value of its child nodes.
A Heap has the following properties:

Insertion of an element into the Heap has a time complexity of O(logN);
Deletion of an element from the Heap has a time complexity of O(logN);
The maximum/minimum value in the Heap can be obtained with O(1) time complexity.

Classification of Heap
There are two kinds of heaps: Max Heap and Min Heap.

## Priority Queues

Before introducing a Heap, let's first talk about a Priority Queue.

Wikipedia: a priority queue is an abstract data type similar to a regular queue or stack data structure in which each element additionally has a "priority" associated with it. In a priority queue, an element with high priority is served before an element with low priority.

In daily life, we would assign different priorities to tasks, start working on the task with the highest priority and then proceed to the task with the second highest priority. This is an example of a Priority Queue.

A common misconception is that a Heap is the same as a Priority Queue, which is not true. A priority queue is an abstract data type, while a Heap is a data structure. Therefore, a Heap is not a Priority Queue, but a way to implement a Priority Queue.

There are multiple ways to implement a Priority Queue, such as array and linked list. However, these implementations only guarantee 
O
(
1
)
O(1) time complexity for either insertion or deletion, while the other operation will have a time complexity of 
O
(
N
)
O(N). On the other hand, implementing the priority queue with Heap will allow both insertion and deletion to have a time complexity of 
O
(
log
⁡
N
)
O(logN). So, what is a Heap?

In this chapter, we will learn to:

Understand the Heap data structure.
Understand Max Heap and Min Heap.
Understand the insertion and deletion of a Heap.
Implement a Heap.

## Definition of Heap

According to Wikipedia, a Heap is a special type of binary tree. A heap is a binary tree that meets the following criteria:

Is a complete binary tree;
The value of each node must be no greater than (or no less than) the value of its child nodes.
A Heap has the following properties:

Insertion of an element into the Heap has a time complexity of 
O
(
log
⁡
N
)
O(logN);
Deletion of an element from the Heap has a time complexity of 
O
(
log
⁡
N
)
O(logN);
The maximum/minimum value in the Heap can be obtained with 
O
(
1
)
O(1) time complexity.

## Classification of Heap

There are two kinds of heaps: Max Heap and Min Heap.

Max Heap: Each node in the Heap has a value no less than its child nodes. Therefore, the top element (root node) has the largest value in the Heap.

Min Heap: Each node in the Heap has a value no larger than its child nodes. Therefore, the top element (root node) has the smallest value in the Heap.

Max Heap: Each node in the Heap has a value no less than its child nodes. Therefore, the top element (root node) has the largest value in the Heap.
Min Heap: Each node in the Heap has a value no larger than its child nodes. Therefore, the top element (root node) has the smallest value in the Heap.

##   Heap Insertion

Insertion means adding an element to the Heap. After inserting the element, the properties of the Heap should remain unchanged.

##  Heap Deletion

Deletion means removing the “top” element from the Heap. After deleting the element, the property of Heap should remain unchanged.

##  Implementation of a Heap

We often perform insertion, deletion, and getting the top element with a Heap data structure.

We can implement a Heap using an array. Elements in the Heap can be stored in the array in the form of a binary tree. The code below will implement “Max Heap” and “Min Heap” for integers (In LeetCode problems or daily work, we often will use existing libraries instead of manually implementing Heap).

### Min Heap:

```cshrp
using System;
using System.Text;

public class MinHeap 
{
    private int[] minHeap;
    private int heapSize;
    private int realSize = 0;

    public MinHeap(int heapSize) 
    {
        this.heapSize = heapSize;
        minHeap = new int[heapSize + 1];
        minHeap[0] = 0; // Not used
    }

    public void Add(int element) 
    {
        realSize++;
        
        if (realSize > heapSize) 
        {
            Console.WriteLine("Added too many elements!");
            realSize--;
            return;
        }
        
        minHeap[realSize] = element;
        int index = realSize;
        int parent = index / 2;
        
        while (minHeap[index] < minHeap[parent] && index > 1) 
        {
            (minHeap[index], minHeap[parent]) = (minHeap[parent], minHeap[index]);
            index = parent;
            parent = index / 2;
        }
    }

    public int Peek() 
    {
        return minHeap[1];
    }

    public int Pop() 
    {
        if (realSize < 1) 
        {
            Console.WriteLine("Don't have any element!");
            return int.MaxValue;
        }
        
        int removeElement = minHeap[1];
        minHeap[1] = minHeap[realSize];
        realSize--;
        int index = 1;
        
        while (index <= realSize / 2) 
        {
            int left = index * 2;
            int right = index * 2 + 1;
            
            if (minHeap[index] > minHeap[left] || 
                (right <= realSize && minHeap[index] > minHeap[right])) 
            {
                if (right > realSize || minHeap[left] < minHeap[right]) 
                {
                    (minHeap[index], minHeap[left]) = (minHeap[left], minHeap[index]);
                    index = left;
                }
                else 
                {
                    (minHeap[index], minHeap[right]) = (minHeap[right], minHeap[index]);
                    index = right;
                }
            }
            else 
            {
                break;
            }
        }
        
        return removeElement;
    }

    public int Size() 
    {
        return realSize;
    }

    public override string ToString() 
    {
        if (realSize == 0) 
        {
            return "No element!";
        }
        
        StringBuilder sb = new StringBuilder();
        sb.Append('[');
        for (int i = 1; i <= realSize; i++) 
        {
            sb.Append(minHeap[i]);
            if (i < realSize) sb.Append(',');
        }
        sb.Append(']');
        return sb.ToString();
    }
}

public class Program 
{
    public static void Main(string[] args) 
    {
        MinHeap minHeap = new MinHeap(3);
        minHeap.Add(3);
        minHeap.Add(1);
        minHeap.Add(2);
        Console.WriteLine(minHeap.ToString());  // [1,3,2]
        Console.WriteLine(minHeap.Peek());     // 1
        Console.WriteLine(minHeap.Pop());      // 1
        Console.WriteLine(minHeap.ToString()); // [2,3]
        minHeap.Add(4);
        minHeap.Add(5); // "Added too many elements!"
        Console.WriteLine(minHeap.ToString()); // [2,3,4]
    }
}
```
### Max Heap:

```cshrp
using System;
using System.Text;

public class MaxHeap 
{
    private int[] heap;
    private int capacity;
    private int size;

    public MaxHeap(int heapSize) 
    {
        capacity = heapSize;
        heap = new int[heapSize + 1]; // Using 1-based indexing
        heap[0] = int.MinValue; // Dummy value at index 0
        size = 0;
    }

    public void Add(int element) 
    {
        if (size >= capacity) 
        {
            Console.WriteLine("Added too many elements!");
            return;
        }

        size++;
        heap[size] = element;
        HeapifyUp(size);
    }

    private void HeapifyUp(int index) 
    {
        while (index > 1 && heap[index] > heap[Parent(index)]) 
        {
            Swap(index, Parent(index));
            index = Parent(index);
        }
    }

    public int Peek() 
    {
        if (size < 1) 
        {
            Console.WriteLine("Heap is empty!");
            return int.MinValue;
        }
        return heap[1];
    }

    public int Pop() 
    {
        if (size < 1) 
        {
            Console.WriteLine("Heap is empty!");
            return int.MinValue;
        }

        int max = heap[1];
        heap[1] = heap[size];
        size--;
        HeapifyDown(1);
        return max;
    }

    private void HeapifyDown(int index) 
    {
        int maxIndex = index;
        int left = LeftChild(index);
        int right = RightChild(index);

        if (left <= size && heap[left] > heap[maxIndex])
            maxIndex = left;

        if (right <= size && heap[right] > heap[maxIndex])
            maxIndex = right;

        if (index != maxIndex) 
        {
            Swap(index, maxIndex);
            HeapifyDown(maxIndex);
        }
    }

    private int Parent(int index) => index / 2;
    private int LeftChild(int index) => index * 2;
    private int RightChild(int index) => index * 2 + 1;

    private void Swap(int i, int j) 
    {
        (heap[i], heap[j]) = (heap[j], heap[i]);
    }

    public int Size() => size;

    public override string ToString() 
    {
        if (size == 0) return "Heap is empty";

        var sb = new StringBuilder("[");
        for (int i = 1; i <= size; i++) 
        {
            sb.Append(heap[i]);
            if (i < size) sb.Append(", ");
        }
        sb.Append("]");
        return sb.ToString();
    }
}

public class Program 
{
    public static void Main() 
    {
        MaxHeap heap = new MaxHeap(5);
        heap.Add(1);
        heap.Add(2);
        heap.Add(3);
        Console.WriteLine(heap); // [3, 1, 2]
        Console.WriteLine(heap.Peek()); // 3
        Console.WriteLine(heap.Pop()); // 3
        Console.WriteLine(heap.Pop()); // 2
        Console.WriteLine(heap.Pop()); // 1
        Console.WriteLine(heap); // Heap is empty
        
        heap.Add(4);
        heap.Add(5);
        Console.WriteLine(heap); // [5, 4]
    }
}
```
## Common applications of Heap

In most programming languages, Heaps are already built-in. Therefore, we usually do not need to implement a Heap from scratch. However, to use Heap adequately, we need to understand how Heap is commonly used.

In this chapter, we will learn how to:

Construct a Max Heap and a Min Heap.
Insert elements into a Heap.
Get the top element of a Heap.
Delete the top element from a Heap.
Get the length of a Heap.
Perform time and space complexity analysis for common applications that use a Heap.

## Construct a Heap

Constructing a Heap means initializing an instance of a Heap. All methods of Heap need to be performed on an instance. Therefore, we need to initialize an instance before applying the methods. When creating a Heap, we can simultaneously perform the heapify operation. Heapify means converting a group of data into a Heap.

Time complexity: 
O
(
N
)
O(N).

Space complexity: 
O
(
N
)
O(N).

```cshrp
using System;
using System.Collections.Generic;

// In C#, a Heap is represented by PriorityQueue<TElement, TPriority>
// Note: Unlike Java, C#'s PriorityQueue is a min-heap by default

public class HeapExamples
{
    public static void Main()
    {
        // Construct an empty Min Heap (default)
        var minHeap = new PriorityQueue<int, int>();
        
        // Construct an empty Max Heap using custom comparer
        var maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        
        // Construct a Heap with initial elements ("Heapify")
        // Note: C#'s PriorityQueue doesn't have built-in heapify from collection
        // So we need to add elements manually
        var heapWithValues = new PriorityQueue<int, int>();
        foreach (int num in new[] { 3, 1, 2 })
        {
            heapWithValues.Enqueue(num, num);
        }
        
        // Usage examples
        Console.WriteLine("Min Heap Examples:");
        minHeap.Enqueue(3, 3); // Enqueue(element, priority)
        minHeap.Enqueue(1, 1);
        minHeap.Enqueue(2, 2);
        
        Console.WriteLine(minHeap.Peek()); // 1 (min element)
        Console.WriteLine(minHeap.Dequeue()); // 1
        Console.WriteLine(minHeap.Dequeue()); // 2
        Console.WriteLine(minHeap.Dequeue()); // 3
        
        Console.WriteLine("\nMax Heap Examples:");
        maxHeap.Enqueue(3, 3);
        maxHeap.Enqueue(1, 1);
        maxHeap.Enqueue(2, 2);
        
        Console.WriteLine(maxHeap.Peek()); // 3 (max element)
        Console.WriteLine(maxHeap.Dequeue()); // 3
        Console.WriteLine(maxHeap.Dequeue()); // 2
        Console.WriteLine(maxHeap.Dequeue()); // 1
    }
}
```

## Python Max Heap

Python's built-in heap module, heapq, differs from the standard implementation of a heap in two ways. Firstly, it uses zero-based indexing, and this means that it stores the root node at index zero instead of the size of the heap. As a result, the relationship between the index of the children and parent nodes is slightly different. Secondly, the built-in heapq module does not offer a direct way to create a max heap. Instead, we must modify the value(s) of each element when inserting it into the heap and when removing it from the heap. In the following video, we will learn more about this process. There are several benefits from implementing a heap in this way (you can read about them in the previous link).

##  Inserting an Element

Insertion means inserting a new element into the Heap. Note that, after the new element is inserted, properties of the Heap are still maintained.

Time complexity: 
O
(
log
⁡
N
)
O(logN)

Space complexity: 
O
(
1
)
O(1)

```cshrp
// For .NET 6 and later
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // 1. Min Heap (default PriorityQueue behavior)
        var minHeap = new PriorityQueue<int, int>();
        
        // Insert element to Min Heap
        minHeap.Enqueue(element: 5, priority: 5); // Both element and priority are the same
        
        // 2. Max Heap (using custom comparer)
        var maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        
        // Insert element to Max Heap
        maxHeap.Enqueue(element: 5, priority: 5);
        
        // 3. Alternative for older .NET versions (using SortedSet for Max Heap)
        var maxHeapAlt = new SortedSet<int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        maxHeapAlt.Add(5); // Simple insertion
    }
}
```

## Getting the Top Element of the Heap

The top element of a Max heap is the maximum value in the Heap, while the top element of a Min Heap is the smallest value in the Heap. The top element of the Heap is the most important element in the Heap.

Time complexity: 
O
(
1
)
O(1).

Space complexity: 
O
(
1
)
O(1).

```cshrp
// For .NET 6 and later
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // 1. Min Heap (default PriorityQueue)
        var minHeap = new PriorityQueue<int, int>();
        minHeap.Enqueue(3, 3);
        minHeap.Enqueue(1, 1);
        minHeap.Enqueue(2, 2);
        
        // Get top element (smallest) from Min Heap
        int minTop = minHeap.Peek();
        Console.WriteLine($"Top of Min Heap: {minTop}"); // Output: 1

        // 2. Max Heap (with custom comparer)
        var maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        maxHeap.Enqueue(3, 3);
        maxHeap.Enqueue(1, 1);
        maxHeap.Enqueue(2, 2);
        
        // Get top element (largest) from Max Heap
        int maxTop = maxHeap.Peek();
        Console.WriteLine($"Top of Max Heap: {maxTop}"); // Output: 3
    }
}
```

## Deleting the top element

Note that, after deleting the top element, the properties of the Heap will still hold. Therefore, the new top element in the Heap will be the maximum (for Max Heap) or minimum (for Min Heap) of the current Heap.

Time complexity: 
O
(
log
⁡
N
)
O(logN).

Space complexity: 
O
(
1
)
O(1).

```cshrp
// For .NET 6 and later
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // 1. Min Heap (default PriorityQueue)
        var minHeap = new PriorityQueue<int, int>();
        minHeap.Enqueue(3, 3);
        minHeap.Enqueue(1, 1);
        minHeap.Enqueue(2, 2);
        
        // Delete and return top element (smallest) from Min Heap
        if (minHeap.TryDequeue(out int minElement, out _))
        {
            Console.WriteLine($"Removed from Min Heap: {minElement}"); // Output: 1
        }

        // 2. Max Heap (with custom comparer)
        var maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        maxHeap.Enqueue(3, 3);
        maxHeap.Enqueue(1, 1);
        maxHeap.Enqueue(2, 2);
        
        // Delete and return top element (largest) from Max Heap
        if (maxHeap.TryDequeue(out int maxElement, out _))
        {
            Console.WriteLine($"Removed from Max Heap: {maxElement}"); // Output: 3
        }
    }
}
```

## Getting the Length of a Heap

The length of the Heap can be used to determine the size of the current heap, and it can also be used to determine if the current Heap is empty. If there are no elements in the current Heap, the length of the Heap is zero.

Time complexity: 
O
(
1
)
O(1)

Space complexity: 
O
(
1
)
O(1)

```cshrp
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // 1. Min Heap
        var minHeap = new PriorityQueue<int, int>();
        minHeap.Enqueue(3, 3);
        minHeap.Enqueue(1, 1);
        
        // Get length (size) of Min Heap
        int minHeapSize = minHeap.Count;
        Console.WriteLine($"Min Heap size: {minHeapSize}"); // Output: 2
        
        // Check if Min Heap is empty
        bool isMinHeapEmpty = minHeap.Count == 0;
        Console.WriteLine($"Min Heap empty? {isMinHeapEmpty}"); // Output: False

        // 2. Max Heap
        var maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        
        // Get length (size) of Max Heap
        int maxHeapSize = maxHeap.Count;
        Console.WriteLine($"Max Heap size: {maxHeapSize}"); // Output: 0
        
        // Check if Max Heap is empty
        bool isMaxHeapEmpty = maxHeap.Count == 0;
        Console.WriteLine($"Max Heap empty? {isMaxHeapEmpty}"); // Output: True
    }
}
```

## Space and Time Complexity

| **Heap method**           | **Time complexity** | **Space complexity** |
|---------------------------|---------------------|-----------------------|
| Construct a Heap          | \( O(N) \)          | \( O(N) \)            |
| Insert an element         | \( O(\log N) \)     | \( O(1) \)            |
| Get the top element       | \( O(1) \)          | \( O(1) \)            |
| Delete the top element    | \( O(\log N) \)     | \( O(1) \)            |
| Get the size of a Heap    | \( O(1) \)          | \( O(1) \)            |

N is the number of elements in the heap.

## Complete Code

Min Heap:

```cshrp
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // Construct an instance of Min Heap
        var minHeap = new PriorityQueue<int, int>();
        
        // Add 3, 1, 2 respectively to the Min Heap
        minHeap.Enqueue(3, 3);
        minHeap.Enqueue(1, 1);
        minHeap.Enqueue(2, 2);
        
        // Check all elements in the Min Heap
        Console.WriteLine("minHeap: " + string.Join(", ", GetHeapElements(minHeap)));
        
        // Get the top element of the Min Heap
        int peekNum = minHeap.Peek();
        Console.WriteLine("peek number: " + peekNum); // Output: 1
        
        // Delete the top element in the Min Heap
        minHeap.TryDequeue(out int pollNum, out _);
        Console.WriteLine("poll number: " + pollNum); // Output: 1
        
        // Check the top element after deleting 1
        Console.WriteLine("peek number: " + minHeap.Peek()); // Output: 2
        
        // Check all elements in the Min Heap
        Console.WriteLine("minHeap: " + string.Join(", ", GetHeapElements(minHeap))); // Output: 2, 3
        
        // Check the number of elements in the Min Heap
        int heapSize = minHeap.Count;
        Console.WriteLine("minHeap size: " + heapSize); // Output: 2
        
        // Check if the Min Heap is empty
        bool isEmpty = minHeap.Count == 0;
        Console.WriteLine("isEmpty: " + isEmpty); // Output: False
    }
    
    // Helper method to get all elements from the heap (for display purposes)
    private static IEnumerable<int> GetHeapElements(PriorityQueue<int, int> heap)
    {
        // Note: This is just for demonstration - dequeuing all elements modifies the heap
        var elements = new List<int>();
        while (heap.Count > 0)
        {
            heap.TryDequeue(out int element, out _);
            elements.Add(element);
        }
        // Re-add elements back to heap (since we removed them)
        foreach (var element in elements)
        {
            heap.Enqueue(element, element);
        }
        return elements;
    }
}
```

Max Heap:

```cshrp
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // Construct an instance of Max Heap using custom comparer
        var maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        
        // Add 1, 3, 2 respectively to the Max Heap
        maxHeap.Enqueue(1, 1);
        maxHeap.Enqueue(3, 3);
        maxHeap.Enqueue(2, 2);
        
        // Check all elements in the Max Heap
        Console.WriteLine("maxHeap: " + string.Join(", ", GetHeapElements(maxHeap))); // Output: 3, 1, 2
        
        // Get the top element of the Max Heap
        int peekNum = maxHeap.Peek();
        Console.WriteLine("peek number: " + peekNum); // Output: 3
        
        // Delete the top element in the Max Heap
        maxHeap.TryDequeue(out int pollNum, out _);
        Console.WriteLine("poll number: " + pollNum); // Output: 3
        
        // Check the top element after deleting 3
        Console.WriteLine("peek number: " + maxHeap.Peek()); // Output: 2
        
        // Check all elements in the Max Heap
        Console.WriteLine("maxHeap: " + string.Join(", ", GetHeapElements(maxHeap))); // Output: 2, 1
        
        // Check the number of elements in the Max Heap
        int heapSize = maxHeap.Count;
        Console.WriteLine("maxHeap size: " + heapSize); // Output: 2
        
        // Check if the Max Heap is empty
        bool isEmpty = maxHeap.Count == 0;
        Console.WriteLine("isEmpty: " + isEmpty); // Output: False
    }
    
    // Helper method to get all elements from the heap (for display purposes)
    private static IEnumerable<int> GetHeapElements(PriorityQueue<int, int> heap)
    {
        var elements = new List<int>();
        var tempHeap = new PriorityQueue<int, int>(heap.Comparer);
        
        // Copy elements to list and temporary heap
        while (heap.Count > 0)
        {
            heap.TryDequeue(out int element, out int priority);
            elements.Add(element);
            tempHeap.Enqueue(element, priority);
        }
        
        // Restore original heap
        while (tempHeap.Count > 0)
        {
            tempHeap.TryDequeue(out int element, out int priority);
            heap.Enqueue(element, priority);
        }
        
        return elements;
    }
}
```

##  Application of Heap
Heap is a commonly used data structure in computer science. In this chapter, we will cover several applications of Heap.

Heap Sort
The Top-K problem
The K-th element
