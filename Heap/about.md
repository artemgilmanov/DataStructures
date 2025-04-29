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
