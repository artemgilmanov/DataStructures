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
##   Queue and BFS
One common application of Breadth-first Search (BFS) is to find the shortest path from the root node to the target node. In this article, we provide an example to explain how queue is applied in a BFS algorithm step by step.



An Example
Here we provide an example to show how BFS is used to find the shortest path between the root node A and the target node G.

Current
1 / 16


Insights
After watching the animation above, let's answer the following questions:

1. What is the processing order of the nodes?

In the first round, we process the root node. In the second round, we process the nodes next to the root node; in the third round, we process the nodes which are two steps from the root node; so on and so forth.

Similar to tree's level-order traversal, the nodes closer to the root node will be traversed earlier.

If a node X is added to the queue in the kth round, the length of the shortest path between the root node and X is exactly k. That is to say, you are already in the shortest path the first time you find the target node.

2. What is the enqueue and dequeue order of the queue?

As shown in the animation above, we first enqueue the root node. Then in each round, we process the nodes which are already in the queue one by one and add all their neighbors to the queue. It is worth noting that the newly-added nodes will not be traversed immediately but will be processed in the next round.

The processing order of the nodes is the exact same order as how they were added to the queue, which is First-in-First-out (FIFO). That's why we use a queue in BFS.

## BFS - Template

Previously, we have already introduced two main scenarios of using BFS: do traversal or find the shortest path. Typically, it happens in a tree or a graph. As we mentioned in the chapter description, BFS can also be used in more abstract scenarios.

In this article, we will provide you with a template. Then, we provide some exercises after this article for practice.

It will be important to determine the nodes and the edges before doing BFS in a specific question. Typically, the node will be an actual node or a status while the edge will be an actual edge or a possible transition.

Template I
Here we provide a pseudocode for you as a template:
```cshrp
using System;
using System.Collections.Generic;

public class Node
{
    public List<Node> Neighbors { get; set; } = new List<Node>();
    // Add any other node properties you need
}

public class BFSAlgorithm
{
    /// <summary>
    /// Return the length of the shortest path between root and target node.
    /// Returns -1 if no path exists.
    /// </summary>
    public int BFS(Node root, Node target)
    {
        if (root == null) return -1;
        if (root == target) return 0;

        Queue<Node> queue = new Queue<Node>(); // Store nodes to be processed
        HashSet<Node> visited = new HashSet<Node>(); // Track visited nodes
        int step = 0; // Number of steps from root to current level
        
        // Initialize
        queue.Enqueue(root);
        visited.Add(root);
        
        // BFS
        while (queue.Count > 0)
        {
            int size = queue.Count;
            // Process all nodes at current level
            for (int i = 0; i < size; i++)
            {
                Node current = queue.Dequeue();
                
                // Early return if target found
                if (current == target)
                    return step;
                
                // Add unvisited neighbors to queue
                foreach (Node neighbor in current.Neighbors)
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                        visited.Add(neighbor);
                    }
                }
            }
            step++; // Move to next level
        }
        
        return -1; // No path exists
    }
}
```

As shown in the code, in each round, the nodes in the queue are the nodes which are waiting to be processed.
After each outer while loop, we are one step farther from the root node. The variable step indicates the distance from the root node and the current node we are visiting.

Template II
Sometimes, it is important to make sure that we never visit a node twice. Otherwise, we might get stuck in an infinite loop, e.g. in graph with cycle. If so, we can add a hash set to the code above to solve this problem. Here is the pseudocode after modification:
```cshrp
using System;
using System.Collections.Generic;

public class Node
{
    // Unique identifier for the node (optional but useful)
    public int Id { get; set; }
    
    // List of neighboring nodes
    public List<Node> Neighbors { get; set; } = new List<Node>();
    
    // Constructor
    public Node(int id)
    {
        Id = id;
    }
}

public class GraphBFS
{
    /// <summary>
    /// Returns the length of the shortest path between root and target node.
    /// Returns -1 if no path exists.
    /// </summary>
    public int BFS(Node root, Node target)
    {
        // Edge case handling
        if (root == null || target == null) return -1;
        if (root == target) return 0;

        // Initialize data structures
        Queue<Node> queue = new Queue<Node>();
        HashSet<Node> visited = new HashSet<Node>();
        
        // Start with root node
        queue.Enqueue(root);
        visited.Add(root);
        int step = 0;

        // BFS loop
        while (queue.Count > 0)
        {
            // Process all nodes at current level
            int levelSize = queue.Count;
            for (int i = 0; i < levelSize; i++)
            {
                Node current = queue.Dequeue();
                
                // Check if target found
                if (current == target)
                    return step;
                
                // Add unvisited neighbors
                foreach (Node neighbor in current.Neighbors)
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                        visited.Add(neighbor);
                    }
                }
            }
            step++; // Increment level counter
        }
        
        // Target not found
        return -1;
    }
}

// Usage Example
public class Program
{
    public static void Main()
    {
        // Create nodes
        Node node0 = new Node(0);
        Node node1 = new Node(1);
        Node node2 = new Node(2);
        Node node3 = new Node(3);
        
        // Build graph connections (undirected)
        node0.Neighbors.Add(node1);
        node1.Neighbors.Add(node0);
        node1.Neighbors.Add(node2);
        node2.Neighbors.Add(node1);
        node2.Neighbors.Add(node3);
        node3.Neighbors.Add(node2);
        
        // Perform BFS
        GraphBFS bfs = new GraphBFS();
        int shortestPath = bfs.BFS(node0, node3);
        
        Console.WriteLine($"Shortest path length: {shortestPath}"); // Output: 3
    }
}
```
There are some cases where one does not need keep the visited hash set:

You are absolutely sure there is no cycle, for example, in tree traversal;
You do want to add the node to the queue multiple times.

## Last-in-first-out Data Structure

In a LIFO data structure, the newest element added to the queue will be processed first.

Different from the queue, the stack is a LIFO data structure. Typically, the insert operation is called push in a stack. Similar to the queue, a new element is always added at the end of the stack. However, the delete operation, pop, will always remove the last element which is opposite from the queue.

 

Example - Stack
1. Push: you can click Push button below to see how a new element 6 is added to the stack.

2. Pop: you can click Pop button below to see which element will be removed when you pop an element from the stack.

    Push                      Pop
   
Implementation - Stack
The implementation of a Stack is easier than a Queue. A dynamic array is sufficient to implement a stack structure. Here we provide a simple implementation for your reference:

```cshrp
using System;
using System.Collections.Generic;

public class MyStack
{
    private List<int> data; // store elements

    public MyStack()
    {
        data = new List<int>();
    }

    /// <summary>Insert an element into the stack.</summary>
    public void Push(int x)
    {
        data.Add(x);
    }

    /// <summary>Checks whether the stack is empty or not.</summary>
    public bool IsEmpty()
    {
        return data.Count == 0;
    }

    /// <summary>Get the top item from the stack.</summary>
    public int Top()
    {
        return data[data.Count - 1];
    }

    /// <summary>Delete an element from the stack. Returns true if the operation is successful.</summary>
    public bool Pop()
    {
        if (IsEmpty())
        {
            return false;
        }
        data.RemoveAt(data.Count - 1);
        return true;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        MyStack s = new MyStack();
        s.Push(1);
        s.Push(2);
        s.Push(3);
        
        for (int i = 0; i < 4; ++i)
        {
            if (!s.IsEmpty())
            {
                Console.WriteLine(s.Top());
            }
            Console.WriteLine(s.Pop());
        }
    }
}
```
## Stack - Usage
Most popular languages provide built-in stack library so you don't have to reinvent the wheel. Besides initialization, we need to know how to use the two most important operations, pop and push. Also, you should be able to get the top element from the stack. Below are some code examples for your reference:

```cshrp
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        // 1. Initialize a stack
        Stack<int> s = new Stack<int>();
        
        // 2. Push new elements
        s.Push(5);
        s.Push(13);
        s.Push(8);
        s.Push(6);
        
        // 3. Check if stack is empty
        if (s.Count == 0)
        {
            Console.WriteLine("Stack is empty!");
            return;
        }
        
        // 4. Pop an element
        s.Pop();
        
        // 5. Get the top element
        Console.WriteLine($"The top element is: {s.Peek()}");
        
        // 6. Get the size of the stack
        Console.WriteLine($"The size is: {s.Count}");
    }
}
```
From now on, we are able to use the built-in stack library to solve problems more conveniently. Let's start with an interesting problem (Min Stack) to help you review the useful operations. Then we will take a look at some classic Stack problems. When you want to process the last element first, the stack will be the most appropriate data structure.

##  Stack and DFS
Similar to BFS, Depth-First Search (DFS) can also be used to find the path from the root node to the target node. In this article, we provide an example to explain how DFS works and how a stack helps with DFS step by step.



An Example
Let's take a look at an example. We want to find a path from the root node A to the target node G by DFS.

Current
1 / 16


Insights
After watching the animation above, let's answer the following questions:

1. What is the processing order of the nodes?

In the example above, we start from the root node A. Firstly, we choose the path to the node B and trace-back till we reach the node E where we have no way to go deeper. Then we backtrack to A and choose the second path to the node C. From C, We try the first path to E but E has been visited. So we go back to C and try another path to F. Finally, we find G.

Overall, we only trace-back and try another path after we reach the deepest node.

As a result, the first path you found in DFS is not always the shortest path. For instance, in the example above, we successfully found a path A->C->F->G and stop the DFS. But this is not the shortest path from A to G.

2. What is the push and pop order of the stack?

As shown in the animation above, we first push the root node to the stack; then we try the first neighbor B and push node B to the stack; so on and so forth. When we reach the deepest node E, we need to trace back. And when we trace back, we will pop the deepest node from the stack which is actually the last node pushed to the stack.

The processing order of the nodes is the exact opposite order as how they were added to the stack, which is Last-in-First-out (LIFO). That's why we use a stack in DFS.

## DFS - Template I

As we mentioned in the chapter's description, in most cases, we can also use DFS when using BFS. But there is an important difference: the traversal order.

Different from BFS, the nodes you visit earlier might not be the nodes which are closer to the root node. As a result, the first path you found in DFS might not be the shortest path.

In this article, we will provide you a recursion template of DFS and show you how the stack helps with this process. And then we provide some exercise after this article for you to practice.

Template - Recursion
There are two ways to implement DFS. The first one is to do recursion which you might already be familiar with. Here we provide a template as reference:
```cshrp
using System;
using System.Collections.Generic;

public class Node
{
    public int Id { get; set; }
    public List<Node> Neighbors { get; set; } = new List<Node>();
    
    public Node(int id)
    {
        Id = id;
    }
}

public class GraphDFS
{
    /// <summary>
    /// Returns true if there is a path from current node to target node.
    /// </summary>
    public bool DFS(Node current, Node target, HashSet<Node> visited)
    {
        // Base case: target found
        if (current == target)
            return true;
        
        // Explore all neighbors
        foreach (Node neighbor in current.Neighbors)
        {
            if (!visited.Contains(neighbor))
            {
                visited.Add(neighbor); // Mark as visited
                if (DFS(neighbor, target, visited))
                    return true; // Path found through this neighbor
            }
        }
        
        // No path found
        return false;
    }

    // Helper method for easier initial call
    public bool HasPath(Node start, Node target)
    {
        if (start == null || target == null)
            return false;
            
        var visited = new HashSet<Node> { start };
        return DFS(start, target, visited);
    }
}

// Usage Example
public class Program
{
    public static void Main()
    {
        // Create nodes
        Node nodeA = new Node(1);
        Node nodeB = new Node(2);
        Node nodeC = new Node(3);
        Node nodeD = new Node(4);
        
        // Build graph connections
        nodeA.Neighbors.Add(nodeB);
        nodeB.Neighbors.Add(nodeC);
        nodeC.Neighbors.Add(nodeA); // Creates a cycle
        
        // Check for path
        GraphDFS dfs = new GraphDFS();
        bool pathExists = dfs.HasPath(nodeA, nodeD);
        
        Console.WriteLine($"Path exists: {pathExists}");
    }
}
```
It seems like we don't have to use any stacks when we implement DFS recursively. But actually, we are using the implicit stack provided by the system, also known as the Call Stack.
n Example
Let's take a look at an example. We want to find a path between node 0 and node 3 in the graph below. We also show you the stack's status during each call.



In each stack element, there is an integer cur, an integer target, a reference to array visited and a reference to array edges, which are exactly the parameters we have in the DFS function. We only show cur in the stack above.

Each element costs constant space. And the size of the stack is exactly the depth of DFS. So in the worst case, it costs O(h) to maintain the system stack, where h is the maximum depth of DFS. You should never forget to take the system stack into consideration when calculating the space complexity.

In the template above, we stop when we find the first path.

What if you want to find the shortest path?

Hint: Add one more parameter to indicate the shortest path you have already found.

## DFS - Template II

The advantage of the recursion solution is that it is easier to implement. However, there is a huge disadvantage: if the depth of recursion is too high, you will suffer from stack overflow. In that case, you might want to use BFS instead or implement DFS using an explicit stack.

Here we provide a template using an explicit stack:
```cshrp
using System;
using System.Collections.Generic;

public class Node
{
    public int Id { get; set; }
    public List<Node> Neighbors { get; set; } = new List<Node>();
    
    public Node(int id)
    {
        Id = id;
    }
}

public class GraphDFS
{
    /// <summary>
    /// Returns true if there is a path from root node to target node (iterative DFS)
    /// </summary>
    public bool DFS(Node root, Node target)
    {
        if (root == null || target == null)
            return false;
        
        HashSet<Node> visited = new HashSet<Node>();
        Stack<Node> stack = new Stack<Node>();
        
        visited.Add(root);
        stack.Push(root);
        
        while (stack.Count > 0)
        {
            Node current = stack.Pop();
            
            // Early return if target found
            if (current == target)
                return true;
            
            // Push unvisited neighbors to stack
            foreach (Node neighbor in current.Neighbors)
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    stack.Push(neighbor);
                }
            }
        }
        
        return false;
    }
}

// Usage Example
public class Program
{
    public static void Main()
    {
        // Create nodes
        Node node1 = new Node(1);
        Node node2 = new Node(2);
        Node node3 = new Node(3);
        Node node4 = new Node(4);
        
        // Build graph connections
        node1.Neighbors.Add(node2);
        node2.Neighbors.Add(node3);
        node3.Neighbors.Add(node1); // Creates a cycle
        node3.Neighbors.Add(node4);
        
        // Check for path
        GraphDFS dfs = new GraphDFS();
        bool pathExists = dfs.DFS(node1, node4);
        
        Console.WriteLine($"Path from node1 to node4 exists: {pathExists}");
    }
}
```
The logic is exactly the same with the recursion solution. But we use while loop and stack to simulate the system call stack during recursion. Running through several examples manually will definitely help you understand it better.
