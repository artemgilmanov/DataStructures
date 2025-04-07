##   Queue - Implementation

In a FIFO data structure, the first element added to the queue will be processed first.
To implement a queue, we may use a dynamic array and an index pointing to the head of the queue.

As mentioned, a queue should support two operations: enqueue and dequeue. Enqueue appends a new element to the queue while dequeue removes the first element. So we need an index to indicate the starting point.

```cshrp
using System;
using System.Collections.Generic;

public class MyQueue
{
    // store elements
    private List<int> data;
    // a pointer to indicate the start position
    private int p_start;
    
    public MyQueue()
    {
        data = new List<int>();
        p_start = 0;
    }
    
    /** Insert an element into the queue. Return true if the operation is successful. */
    public bool EnQueue(int x)
    {
        data.Add(x);
        return true;
    }
    
    /** Delete an element from the queue. Return true if the operation is successful. */
    public bool DeQueue()
    {
        if (IsEmpty())
        {
            return false;
        }
        p_start++;
        return true;
    }
    
    /** Get the front item from the queue. */
    public int Front()
    {
        return data[p_start];
    }
    
    /** Checks whether the queue is empty or not. */
    public bool IsEmpty()
    {
        return p_start >= data.Count;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        MyQueue q = new MyQueue();
        q.EnQueue(5);
        q.EnQueue(3);
        
        if (!q.IsEmpty())
        {
            Console.WriteLine(q.Front());
        }
        
        q.DeQueue();
        
        if (!q.IsEmpty())
        {
            Console.WriteLine(q.Front());
        }
        
        q.DeQueue();
        
        if (!q.IsEmpty())
        {
            Console.WriteLine(q.Front());
        }
    }
}
```
## Drawback

The implementation above is straightforward but is inefficient in some cases. With the movement of the start pointer, more and more space is wasted. And it will be unacceptable when we only have a space limitation.

Let's consider a situation when we are only able to allocate an array whose maximum length is 5. Our solution works well when we have only added less than 5 elements. For example, if we only called the enqueue function four times and we want to enqueue an element 10, we will succeed.

And it is reasonable that we can not accept more enqueue request because the queue is full now. But what if we dequeue an element? 

Actually, we should be able to accept one more element in this case.

## Circular Queue

Previously, we have provided a straightforward but inefficient implementation of queue.

A more efficient way is to use a circular queue. Specifically, we may use a fixed-size array and two pointers to indicate the starting position and the ending position. And the goal is to reuse the wasted storage we mentioned previously.

Let's take a look at an example to see how a circular queue works. You should pay attention to the strategy we use to enqueue or dequeue an element.

## Circular Queue - Implementation

In a circular queue, we use an array and two pointers, head and tail. head indicates the start position of the queue while tail indicates the ending position of the queue.

```cshrp
public class MyCircularQueue 
{
    private int[] data;
    private int head;
    private int tail;
    private int size;

    /** Initialize your data structure here. Set the size of the queue to be k. */
    public MyCircularQueue(int k) 
    {
        data = new int[k];
        head = -1;
        tail = -1;
        size = k;
    }
    
    /** Insert an element into the circular queue. Return true if the operation is successful. */
    public bool EnQueue(int value) 
    {
        if (IsFull())
        {
            return false;
        }
        if (IsEmpty())
        {
            head = 0;
        }
        tail = (tail + 1) % size;
        data[tail] = value;
        return true;
    }
    
    /** Delete an element from the circular queue. Return true if the operation is successful. */
    public bool DeQueue() 
    {
        if (IsEmpty())
        {
            return false;
        }
        if (head == tail)
        {
            head = -1;
            tail = -1;
            return true;
        }
        head = (head + 1) % size;
        return true;
    }
    
    /** Get the front item from the queue. */
    public int Front() 
    {
        if (IsEmpty())
        {
            return -1;
        }
        return data[head];
    }
    
    /** Get the last item from the queue. */
    public int Rear() 
    {
        if (IsEmpty())
        {
            return -1;
        }
        return data[tail];
    }
    
    /** Checks whether the circular queue is empty or not. */
    public bool IsEmpty() 
    {
        return head == -1;
    }
    
    /** Checks whether the circular queue is full or not. */
    public bool IsFull() 
    {
        return ((tail + 1) % size) == head;
    }
}

/**
 * Your MyCircularQueue object will be instantiated and called as such:
 * MyCircularQueue obj = new MyCircularQueue(k);
 * bool param_1 = obj.EnQueue(value);
 * bool param_2 = obj.DeQueue();
 * int param_3 = obj.Front();
 * int param_4 = obj.Rear();
 * bool param_5 = obj.IsEmpty();
 * bool param_6 = obj.IsFull();
 */
```

## Queue - Usage

Most popular languages provide built-in Queue library so you don't have to reinvent the wheel.

As mentioned before, the queue has two important operations, enqueue and dequeue. Besides, we should be able to get the first element in a queue since the first element should be processed first.

Below are some examples of using the built-in Queue library and its common operations:

```cshrp
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        // 1. Initialize a queue.
        Queue<int> q = new Queue<int>();
        
        // 2. Get the first element - throws exception if queue is empty
        Console.WriteLine("The first element is: " + (q.Count > 0 ? q.Peek().ToString() : "null"));
        
        // 3. Add new elements (called Enqueue in C#)
        q.Enqueue(5);
        q.Enqueue(13);
        q.Enqueue(8);
        q.Enqueue(6);
        
        // 4. Remove an element (called Dequeue in C#)
        q.Dequeue();
        
        // 5. Get the first element
        Console.WriteLine("The first element is: " + q.Peek());
        
        // 6. Get the size of the queue
        Console.WriteLine("The size is: " + q.Count);
    }
}
```
