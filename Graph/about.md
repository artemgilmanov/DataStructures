## Introduction
The content on this card is exclusive to our premium users. If you like the content after previewing the first chapter for free, please subscribe to LeetCode premium here.
Graph is probably the data structure that has the closest resemblance to our daily life. There are many types of graphs describing the relationships in real life. For instance, our friend circle is a huge “graph”.

## Types of “graphs”
There are many types of “graphs”. In this Explore Card, we will introduce three types of graphs: undirected graphs, directed graphs, and weighted graphs.

## Undirected graphs
The edges between any two vertices in an “undirected graph” do not have a direction, indicating a two-way relationship.

## Directed graphs
The edges between any two vertices in a “directed graph” graph are directional.

## Weighted graphs
Each edge in a “weighted graph” has an associated weight. The weight can be of any metric, such as time, distance, size, etc. The most commonly seen “weighted map” in our daily life might be a city map. In Figure 3, each edge is marked with the distance, which can be regarded as the weight of that edge.

## The Definition of “graph” and Terminologies
“Graph” is a non-linear data structure consisting of vertices and edges. There are a lot of terminologies to describe a graph. If you encounter an unfamiliar term in the following Explore Card, you may look up the definition below.

Vertex: In Figure 1, nodes such as A, B, and C are called vertices of the graph.
Edge: The connection between two vertices are the edges of the graph. In Figure 1, the connection between person A and B is an edge of the graph.
Path: the sequence of vertices to go through from one vertex to another. In Figure 1, a path from A to C is [A, B, C], or [A, G, B, C], or [A, E, F, D, B, C].
**Note**: there can be multiple paths between two vertices.

Path Length: the number of edges in a path. In Figure 1, the path lengths from person A to C are 2, 3, and 5, respectively.
Cycle: a path where the starting point and endpoint are the same vertex. In Figure 1, [A, B, D, F, E] forms a cycle. Similarly, [A, G, B] forms another cycle.
Negative Weight Cycle: In a “weighted graph”, if the sum of the weights of all edges of a cycle is a negative value, it is a negative weight cycle. In Figure 4, the sum of weights is -3.
Connectivity: if there exists at least one path between two vertices, these two vertices are connected. In Figure 1, A and C are connected because there is at least one path connecting them.
Degree of a Vertex: the term “degree” applies to unweighted graphs. The degree of a vertex is the number of edges connecting the vertex. In Figure 1, the degree of vertex A is 3 because three edges are connecting it.
In-Degree: “in-degree” is a concept in directed graphs. If the in-degree of a vertex is d, there are d directional edges incident to the vertex. In Figure 2, A’s indegree is 1, i.e., the edge from F to A.
Out-Degree: “out-degree” is a concept in directed graphs. If the out-degree of a vertex is d, there are d edges incident from the vertex. In Figure 2, A’s outdegree is 3, i,e, the edges A to B, A to C, and A to G.

## Overview of Disjoint Set

Given the vertices and edges between them, how could we quickly check whether two vertices are connected? For example, Figure 5 shows the edges between vertices, so how can we efficiently check if 0 is connected to 3, 1 is connected to 5, or 7 is connected to 8? We can do so by using the “disjoint set” data structure, also known as the “union-find” data structure. Note that others might refer to it as an algorithm. In this Explore Card, the term “disjoint set” refers to a data structure.

The primary use of disjoint sets is to address the connectivity between the components of a network. The “network“ here can be a computer network or a social network. For instance, we can use a disjoint set to determine if two people share a common ancestor.

## Terminologies

Parent node: the direct parent node of a vertex. For example, in Figure 5, the parent node of vertex 3 is 1, the parent node of vertex 2 is 0, and the parent node of vertex 9 is 9.
Root node: a node without a parent node; it can be viewed as the parent node of itself. For example, in Figure 5, the root node of vertices 3 and 2 is 0. As for 0, it is its own root node and parent node. Likewise, the root node and parent node of vertex 9 is 9 itself. Sometimes the root node is referred to as the head node.

## Introduction to Disjoint Sets

The two important functions of a “disjoint set.”

In the introduction videos above, we discussed the two important functions in a “disjoint set”.

The find function finds the root node of a given vertex. For example, in Figure 5, the output of the find function for vertex 3 is 0.
The union function unions two vertices and makes their root nodes the same. In Figure 5, if we union vertex 4 and vertex 5, their root node will become the same, which means the union function will modify the root node of vertex 4 or vertex 5 to the same root node.

There are two ways to implement a “disjoint set”.

Implementation with Quick Find: in this case, the time complexity of the find function will be O(1). However, the union function will take more time with the time complexity of O(N).
Implementation with Quick Union: compared with the Quick Find implementation, the time complexity of the union function is better. Meanwhile, the find function will take more time in this case.

## Quick Find - Disjoint Set

Explanation of Quick Find
In this video, we'll talk about Quick Find implementation of a Disjoint Set and cover its two basic operations along with their complexity: find and union.

Algorithm
```cshrp
using System;

public class UnionFind
{
    private int[] root;
    private int[] rank;

    public UnionFind(int size)
    {
        root = new int[size];
        rank = new int[size];
        for (int i = 0; i < size; i++)
        {
            root[i] = i;
            rank[i] = 1; // Initially each set has rank 1
        }
    }

    // Find with path compression
    public int Find(int x)
    {
        if (x == root[x])
        {
            return x;
        }
        return root[x] = Find(root[x]); // Path compression
    }

    // Union by rank
    public void Union(int x, int y)
    {
        int rootX = Find(x);
        int rootY = Find(y);
        
        if (rootX != rootY)
        {
            if (rank[rootX] > rank[rootY])
            {
                root[rootY] = rootX;
            }
            else if (rank[rootX] < rank[rootY])
            {
                root[rootX] = rootY;
            }
            else
            {
                root[rootY] = rootX;
                rank[rootX]++;
            }
        }
    }

    public bool Connected(int x, int y)
    {
        return Find(x) == Find(y);
    }
}

public class Program
{
    public static void Main()
    {
        UnionFind uf = new UnionFind(10);
        // 1-2-5-6-7 3-8-9 4
        uf.Union(1, 2);
        uf.Union(2, 5);
        uf.Union(5, 6);
        uf.Union(6, 7);
        uf.Union(3, 8);
        uf.Union(8, 9);
        
        Console.WriteLine(uf.Connected(1, 5)); // true
        Console.WriteLine(uf.Connected(5, 7)); // true
        Console.WriteLine(uf.Connected(4, 9)); // false
        
        // 1-2-5-6-7 3-8-9-4
        uf.Union(9, 4);
        Console.WriteLine(uf.Connected(4, 9)); // true
    }
}
```

Time Complexity
Union-find Constructor-O(N)
Find-O(1)
Union-O(N)
Connected-O(1)

Note: 
N is the number of vertices in the graph.

When initializing a union-find constructor, we need to create an array of size N with the values equal to the corresponding array indices; this requires linear time.
Each call to find will require O(1) time since we are just accessing an element of the array at the given index.
Each call to union will require O(N) time because we need to traverse through the entire array and update the root vertices for all the vertices of the set that is going to be merged into another set.
The connected operation takes O(1) time since it involves the two find calls and the equality check operation.

Space Complexity
We need O(N) space to store the array of size N.

## Quick Union - Disjoint Set

Explanation of Quick Union
In the following video we'll take a look at Quick Union implementation of a Disjoint Set and show the difference between the Quick Union implementation and the Quick Find implementation we talked about earlier. As previously done for the Quick Find implementation, we'll also derive the time complexity of the Quick Union operations so you can compare them.

Why is Quick Union More Efficient than Quick Find?
Generally speaking, Quick Union is more efficient than Quick Find. We'll explain the reason in the below video.

The keen observer may notice that the Quick Union code shown here includes a soon-to-be introduced technique called path compression. While the complexity analysis in the video is sound, the correct Quick Union code (the right side of the video) is the implementation shown below.

At 00:06, in the union function in the Quick Union code, the line root[rootY] = x, should be root[rootY] = rootX, as shown in the code below.

## Algorithm
```cshrp
using System;

public class UnionFind
{
    private int[] root;

    public UnionFind(int size)
    {
        root = new int[size];
        for (int i = 0; i < size; i++)
        {
            root[i] = i;
        }
    }

    // Find with path compression
    public int Find(int x)
    {
        if (x == root[x])
        {
            return x;
        }
        return root[x] = Find(root[x]); // Path compression
    }

    public void Union(int x, int y)
    {
        int rootX = Find(x);
        int rootY = Find(y);
        if (rootX != rootY)
        {
            root[rootY] = rootX;
        }
    }

    public bool Connected(int x, int y)
    {
        return Find(x) == Find(y);
    }
}

public class Program
{
    public static void Main()
    {
        UnionFind uf = new UnionFind(10);
        // 1-2-5-6-7 3-8-9 4
        uf.Union(1, 2);
        uf.Union(2, 5);
        uf.Union(5, 6);
        uf.Union(6, 7);
        uf.Union(3, 8);
        uf.Union(8, 9);
        
        Console.WriteLine(uf.Connected(1, 5)); // true
        Console.WriteLine(uf.Connected(5, 7)); // true
        Console.WriteLine(uf.Connected(4, 9)); // false
        
        // 1-2-5-6-7 3-8-9-4
        uf.Union(9, 4);
        Console.WriteLine(uf.Connected(4, 9)); // true
    }
}
```

## Time Complexity

Union-find Constructor-O(N)
Find-O(N)
Union-O(N)
Connected-O(N)

Note: 
N is the number of vertices in the graph. In the worst-case scenario, the number of operations to get the root vertex will be 
H where H is the height of the tree. Because this implementation does not always point the root of the shorter tree to the root of the taller tree, 
H can be at most N when the tree forms a linked list.

The same as in the quick find implementation, when initializing a union-find constructor, we need to create an array of size 
N
N with the values equal to the corresponding array indices; this requires linear time.
For the find operation, in the worst-case scenario, we need to traverse every vertex to find the root for the input vertex. The maximum number of operations to get the root vertex would be no more than the tree's height, so it will take O(N) time.
The union operation consists of two find operations which (only in the worst-case) will take O(N) time, and two constant time operations, including the equality check and updating the array value at a given index. Therefore, the union operation also costs O(N) in the worst-case.
The connected operation also takes O(N) time in the worst-case since it involves two find calls.

Space Complexity
We need O(N) space to store the array of size N.

## Union by Rank - Disjoint Set

Disjoint Set - Union by Rank
We have implemented two kinds of “disjoint sets” so far, and they both have a concerning inefficiency. Specifically, the quick find implementation will always spend O(n) time on the union operation and in the quick union implementation, as shown in Figure 6, it is possible for all the vertices to form a line after connecting them using union, which results in the worst-case scenario for the find function. Is there any way to optimize these implementations?

Of course, there is; it is to union by rank. The word “rank” means ordering by specific criteria. Previously, for the union function, we always chose the root node of x and set it as the new root node for the other vertex. However, by choosing the parent node based on certain criteria (by rank), we can limit the maximum height of each vertex.

To be specific, the “rank” refers to the height of each vertex. When we union two vertices, instead of always picking the root of x (or y, it doesn't matter as long as we're consistent) as the new root node, we choose the root node of the vertex with a larger “rank”. We will merge the shorter tree under the taller tree and assign the root node of the taller tree as the root node for both vertices. In this way, we effectively avoid the possibility of connecting all vertices into a straight line. This optimization is called the “disjoint set” with union by rank.

Algorithm
```cshrp
using System;

public class UnionFind
{
    private readonly int[] root;
    private readonly int[] rank;

    public UnionFind(int size)
    {
        root = new int[size];
        rank = new int[size];
        for (int i = 0; i < size; i++)
        {
            root[i] = i;
            rank[i] = 1; // Initially each set has rank 1
        }
    }

    // Find with path compression (iterative)
    public int Find(int x)
    {
        while (x != root[x])
        {
            root[x] = root[root[x]]; // Path compression
            x = root[x];
        }
        return x;
    }

    // Union by rank
    public void Union(int x, int y)
    {
        int rootX = Find(x);
        int rootY = Find(y);
        
        if (rootX == rootY) return;
        
        // Attach smaller rank tree under root of higher rank tree
        if (rank[rootX] > rank[rootY])
        {
            root[rootY] = rootX;
        }
        else if (rank[rootX] < rank[rootY])
        {
            root[rootX] = rootY;
        }
        else
        {
            root[rootY] = rootX;
            rank[rootX]++;
        }
    }

    public bool Connected(int x, int y) => Find(x) == Find(y);
}

public class Program
{
    public static void Main()
    {
        UnionFind uf = new UnionFind(10);
        // 1-2-5-6-7 3-8-9 4
        uf.Union(1, 2);
        uf.Union(2, 5);
        uf.Union(5, 6);
        uf.Union(6, 7);
        uf.Union(3, 8);
        uf.Union(8, 9);
        
        Console.WriteLine(uf.Connected(1, 5)); // true
        Console.WriteLine(uf.Connected(5, 7)); // true
        Console.WriteLine(uf.Connected(4, 9)); // false
        
        // 1-2-5-6-7 3-8-9-4
        uf.Union(9, 4);
        Console.WriteLine(uf.Connected(4, 9)); // true
    }
}
```

Time Complexity
Union-find Constructor-O(N)
Find-O(logN)
Union-O(logN)	
Connected-O(logN)

Note: 
N is the number of vertices in the graph.

For the union-find constructor, we need to create two arrays of size N each.
For the find operation, in the worst-case scenario, when we repeatedly union components of equal rank, the tree height will be at most
log(N)+1, so the find operation requires O(logN) time.
For the union and connected operations, we also need O(logN) time since these operations are dominated by the find operation.

Space Complexity
We need O(N) space to store the array of size N.

##   Path Compression Optimization - Disjoint Set

Path Compression Optimization - Disjoint Sets
In the previous implementation of the “disjoint set”, notice that to find the root node, we need to traverse the parent nodes sequentially until we reach the root node. If we search the root node of the same element again, we repeat the same operations. Is there any way to optimize this process?

The answer is yes! After finding the root node, we can update the parent node of all traversed elements to their root node. When we search for the root node of the same element again, we only need to traverse two elements to find its root node, which is highly efficient. So, how could we efficiently update the parent nodes of all traversed elements to the root node? The answer is to use “recursion”. This optimization is called “path compression”, which optimizes the find function.

Algorithm
```cshrp
using System;

public class UnionFind
{
    private readonly int[] root;

    public UnionFind(int size)
    {
        root = new int[size];
        for (int i = 0; i < size; i++)
        {
            root[i] = i;
        }
    }

    // Find with path compression (recursive)
    public int Find(int x)
    {
        if (x == root[x])
        {
            return x;
        }
        return root[x] = Find(root[x]); // Path compression
    }

    public void Union(int x, int y)
    {
        int rootX = Find(x);
        int rootY = Find(y);
        if (rootX != rootY)
        {
            root[rootY] = rootX;
        }
    }

    public bool Connected(int x, int y)
    {
        return Find(x) == Find(y);
    }
}

public class Program
{
    public static void Main()
    {
        UnionFind uf = new UnionFind(10);
        // 1-2-5-6-7 3-8-9 4
        uf.Union(1, 2);
        uf.Union(2, 5);
        uf.Union(5, 6);
        uf.Union(6, 7);
        uf.Union(3, 8);
        uf.Union(8, 9);
        
        Console.WriteLine(uf.Connected(1, 5)); // true
        Console.WriteLine(uf.Connected(5, 7)); // true
        Console.WriteLine(uf.Connected(4, 9)); // false
        
        // 1-2-5-6-7 3-8-9-4
        uf.Union(9, 4);
        Console.WriteLine(uf.Connected(4, 9)); // true
    }
}
```

Time Complexity
Union-find Constructor-O(N)
Find-O(logN)
Union-O(logN)
Connected-O(logN)

Note: 
N is the number of vertices in the graph.

As before, we need O(N) time to create and fill the root array.
For the find, union, and connected operations (the latter two operations both depend on the find operation), we need 
O(1) time for the best case (when the parent node for some vertex is the root node itself). In the worst case, it would be 
O(N) time when the tree is skewed. However, on average, the time complexity will be O(logN). Supporting details for the average time complexity can be found in Top-Down Analysis of Path Compression where R. Seidel and M. Sharir discuss the upper bound running time when path compression is used with arbitrary linking.

Space Complexity
We need O(N) space to store the array of size N.

## Optimized “disjoint set” with Path Compression and Union by Rank

Optimized “disjoint set” with Path Compression and Union by Rank
This implementation of the “disjoint set” is optimized with both “path compression” and “union by rank”.

Implementation
```cshrp

```

Time Complexity
Union-find Constructor-O(N)
Find-O(α(N)) 
Union-O(α(N))
Connected-O(α(N))

Note: 
N is the number of vertices in the graph. 
α refers to the Inverse Ackermann function. In practice, we assume it's a constant. In other words, O(α(N)) is regarded as O(1) on average.

For the union-find constructor, we need to create two arrays of size N each.
When using the combination of union by rank and the path compression optimization, the find operation will take O(α(N)) time on average. Since union and connected both make calls to find and all other operations require constant time, union and connected functions will also take O(α(N)) time on average.

Space Complexity
We need O(N) space to store the array of size N.

## Summary of the “disjoint set” data structure

The main idea of a “disjoint set” is to have all connected vertices have the same parent node or root node, whether directly or indirectly connected. To check if two vertices are connected, we only need to check if they have the same root node.

The two most important functions for the “disjoint set” data structure are the find function and the union function. The find function locates the root node of a given vertex. The union function connects two previously unconnected vertices by giving them the same root node. There is another important function named connected, which checks the “connectivity” of two vertices. The find and union functions are essential for any question that uses the “disjoint set” data structure.

Implementation of the “disjoint set”

```cshrp
public class UnionFind {
    // Constructor of Union-find. The size is the length of the root array.
    public UnionFind(int size) {}
    public int find(int x) {}
    public void union(int x, int y) {}
    public boolean connected(int x, int y) {}
}
```
find function of the “disjoint set”
The “disjoint set” mainly uses the find function to find the root node of a given vertex.

A basic implementation of the find function:
```cshrp
public int find(int x) {
    while (x != root[x]) {
        x = root[x];
    }
    return x;
}
```
The find function – optimized with path compression:
```cshrp
public int find(int x) {
    if (x == root[x]) {
        return x;
    }
    return root[x] = find(root[x]);
}
```
union function of the “disjoint set”
The “disjoint set” mainly uses the union function to connect two vertices, x, and y, by equating their root node.

A basic implementation of the union function:
```cshrp
public void union(int x, int y) {
    int rootX = find(x);
    int rootY = find(y);
    if (rootX != rootY) {
        root[rootY] = rootX;
    }
}
```
The union function – Optimized by union by rank:
```cshrp
public void union(int x, int y) {
    int rootX = find(x);
    int rootY = find(y);
    if (rootX != rootY) {
        if (rank[rootX] > rank[rootY]) {
            root[rootY] = rootX;
        } else if (rank[rootX] < rank[rootY]) {
            root[rootX] = rootY;
        } else {
            root[rootY] = rootX;
            rank[rootX] += 1;
        }
    }
}
```
connected function of the “disjoint set”
The connected function checks if two vertices, x and y, are connected by checking if they have the same root node. If x and y have the same root node, they are connected. Otherwise, they are not connected.
```cshrp
public boolean connected(int x, int y) {
    return find(x) == find(y);
}
```
Tips for using the “disjoint sets” data structure in solving LeetCode problems
The code for the disjoint set is highly modularized. You might want to become familiar with the implementation. I would highly recommend that you understand and memorize the implementation of “disjoint set with path compression and union by rank”.

Finally, we strongly encourage you to solve the exercise problems using the abovementioned implementation of the “disjoint set” data structure. Some of these problems can be solved using other data structures and algorithms, but we highly recommend that you practice solving them using the “disjoint set” data structure.

##  Overview of Depth-First Search Algorithm

Previously, we learned how to check the connectivity between two vertices with the “disjoint set” data structure. Now, let's switch gears and consider: Given a graph, how can we find all of its vertices, and how can we find all paths between two vertices?

The depth-first search algorithm is ideal in solving these kinds of problems because it can explore all paths from the start vertex to all other vertices. Let's start by considering an example. In Figure 7, there are five vertices [A, C, D, B, E]. Given two vertices A and B, there are two paths between them. One path is [A, C, D, B], and the other is [A, E, B].

In Graph theory, the depth-first search algorithm (abbreviated as DFS) is mainly used to:

1. Traverse all vertices in a “graph”;
2. Traverse all paths between any two vertices in a “graph”.

## Traversing all Vertices – Depth-First Search Algorithm

Complexity Analysis
Time Complexity: O(V+E). Here, V represents the number of vertices, and E represents the number of edges. We need to check every vertex and traverse through every edge in the graph.

Space Complexity: O(V). The space complexity of DFS depends on the maximum depth of recursion. In the worst case, if the graph is a straight line or a long path, the DFS recursion can go as deep as the number of vertices. Therefore, the space complexity of DFS is O(V).

## Traversing all paths between two vertices – Depth-First Search Algorithm

# Complexity Analysis

## Time Complexity: 
**O((V−1)!)**  
The above example is for an undirected graph. The worst-case scenario, when trying to find all paths, is a complete graph. A complete graph is a graph where every vertex is connected to every other vertex.

In a complete graph, there will be **V−1** unique paths of length one that start at the source vertex; one of these paths will go to the target and end. Each of the remaining paths will have **V−2** unique paths that extend from it (since none of them will go back to the source vertex which was already visited). This process will continue and lead to approximately **(V−1)!** total paths. Remember, once a path reaches the target vertex, it ends, so the total number of paths will be less than **(V−1)!**.

The precise total number of paths in the worst-case scenario is equivalent to the Number of Arrangements of the subset of vertices excluding the source and target node, which equals **e⋅(V−2)!**.

While finding all paths, at each iteration, we add all valid paths from the current vertex to the stack, as shown in the video. Each time we add a path to the stack requires **O(V)** time to create a copy of the current path, append a vertex to it, and push it onto the stack. Since the path grows by one vertex each time, a path of length **V** must have been copied and pushed onto the stack **V** times before reaching its current length. Therefore, it is intuitive to think that each path should require **O(V²)** time in total. However, there is a flaw in our logic. Consider the example above; at 2:50 we add ADE to the stack. Then at 3:20, we add ADEC, ADEB, and ADEF to the stack. ADE is a subpath of ADEC, ADEB, and ADEF, but ADE was only created once. So the time required for each path to create ADE can be thought of as **O(V)** divided by the number of paths that stem from ADE. With this in mind, the time spent to create a path is **V** plus **V−1** divided by the number of paths that stem from this subpath plus **V−2** times... For a complete graph with many nodes, this averages out to **O(2⋅V) = O(V)** time per path.

Thus, the time complexity to find all paths in an undirected graph in the worst-case scenario is equal to the number of paths found **O((V−2)!)** times the average time to find a path **O(V)** which simplifies to **O((V−1)!)**.

## Space Complexity: 
**O(V³)**  
The space used is by the stack which will contain:
- **(V−1)** paths after adding first **V−1** paths to the stack.
- **(V−1)−1 + (V−2)** paths after popping one path and adding second set of paths.
- **(V−1)−1 + (V−2)−1 + (V−3)−1 + ...**

≈ **V⋅(V−1)/2 + 1** paths will be at most in the stack, and each path added to the stack will take **O(V)** space.  
Therefore, in total, this solution will require **O(V⋅(V−1)/2 + 1)⋅V = O(V³)** space. Note that the space used to store the result does not count towards the space complexity.

## LeetCode 1971 - Find if Path Exists in Graph - DFS

```cshrp
using System;
using System.Collections.Generic;

public class Solution {
    public bool ValidPath(int n, int[][] edges, int start, int end) {
        // Create adjacency list
        var adjacencyList = new List<List<int>>();
        for (int i = 0; i < n; i++) {
            adjacencyList.Add(new List<int>());
        }
        
        // Populate adjacency list (undirected graph)
        foreach (var edge in edges) {
            adjacencyList[edge[0]].Add(edge[1]);
            adjacencyList[edge[1]].Add(edge[0]);
        }
        
        // DFS using stack
        var stack = new Stack<int>();
        stack.Push(start);
        var visited = new bool[n];
        
        while (stack.Count > 0) {
            int node = stack.Pop();
            
            // Check if we've reached the target
            if (node == end) {
                return true;
            }
            
            // Skip if already visited
            if (visited[node]) {
                continue;
            }
            
            visited[node] = true;
            
            // Add all neighbors to stack
            foreach (int neighbor in adjacencyList[node]) {
                stack.Push(neighbor);
            }
        }
        
        return false;
    }
}

// Example usage
public class Program {
    public static void Main() {
        var solution = new Solution();
        
        int n = 6;
        var edges = new int[][] {
            new int[] {0, 1},
            new int[] {0, 2},
            new int[] {3, 5},
            new int[] {5, 4},
            new int[] {4, 3}
        };
        
        Console.WriteLine(solution.ValidPath(n, edges, 0, 5)); // false
        Console.WriteLine(solution.ValidPath(n, edges, 0, 1)); // true
    }
}
```
## Complexity Analysis

## Time Complexity:  
**O(V + E)**  

Here, **V** represents the number of vertices, and **E** represents the number of edges.  

- To create the adjacency list, we must iterate over each of the **E** edges.  
- In the while loop, at most, we will visit each vertex once.  
- The for loop inside the while loop will have a cumulative sum of at most **E** iterations since it will iterate over all of the node's neighbors for each node.  

## Space Complexity:  
**O(V + E)**  

- The adjacency list will contain **O(V + E)** elements.  
- The stack will also contain **O(E)** elements. However, this can be reduced to **O(V)** by checking whether a neighbor node has been seen before adding it to the stack.  
- The `seen` set will use **O(V)** space to store the visited nodes.

## LeetCode 797 - All Paths From Source to Target - DFS

```cshrp
using System;
using System.Collections.Generic;

public class Solution
{
    // DFS
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        List<IList<int>> paths = new List<IList<int>>();
        if (graph == null || graph.Length == 0)
        {
            return paths;
        }

        DFS(graph, 0, new List<int>(), paths);
        return paths;
    }

    private void DFS(int[][] graph, int node, List<int> path, List<IList<int>> paths)
    {
        path.Add(node);
        if (node == graph.Length - 1)
        {
            paths.Add(new List<int>(path));
            return;
        }

        foreach (int nextNode in graph[node])
        {
            DFS(graph, nextNode, path, paths);
            path.RemoveAt(path.Count - 1); // Backtrack
        }
    }
}

```

## Complexity Analysis

### Time Complexity:  
**O(2ᴠ · V)**  

Here, **V** represents the number of vertices.

- For a directed acyclic graph (DAG) with **V** vertices, there could be at most **2^(V-1) - 1** possible paths from the starting vertex to the target vertex.
- We need **O(V)** time to build each such path.
- Therefore, a loose upper bound would be **(2^(V-1) - 1) · O(V) = O(2ᴠ · V)**.
- Due to path overlaps during traversal, the actual time spent will be somewhat lower.

### Space Complexity:  
**O(V)**  

- The recursion depth cannot exceed **V** levels.
- We need **O(V)** space to store visited vertices during recursive traversal.
- Note: Space required for storing the output paths is not included in this complexity.

##  Overview of Breadth-First Search Algorithm

Previously, we discussed the “depth-first search” algorithm. This section will talk about a closely related and equally popular algorithm called “breadth-first search”. Similarly, the “breadth-first search” algorithm can traverse all vertices of a “graph” and traverse all paths between two vertices. However, the most advantageous use case of “breadth-first search” is to efficiently find the shortest path between two vertices in a “graph” where all edges have equal and positive weights.

Although the “depth-first search” algorithm can find the shortest path between two vertices in a “graph” with equal and positive weights, it must traverse all paths between two vertices before finding the shortest one. The “breadth-first search” algorithm, in most cases, can find the shortest path without traversing all paths. This is because when using "breadth-first search", as soon as a path between the source vertex and target vertex is found, it is guaranteed to be the shortest path between the two nodes.

In Figure 8, the vertices are [A, C, D, B, E]. Given vertices A and B, there are two paths between them. One path is [A, C, D, B], and the other is [A, E, B]. Obviously, [A, E, B] is the shortest path between A and B.

In Graph theory, the primary use cases of the “breadth-first search” (“BFS”) algorithm are:
1. Traversing all vertices in the “graph”;
2.Finding the shortest path between two vertices in a graph where all edges have equal and positive weights.

## Traversing all Vertices - Breadth-First Search

## Complexity Analysis

### Time Complexity:  
**O(V + E)**  

Where:
- **V** = number of vertices
- **E** = number of edges

We need to:
1. Check every vertex exactly once
2. Traverse through every edge exactly once

This matches the time complexity of the standard DFS approach.

### Space Complexity:  
**O(V)**  

Space usage consists of:
1. Queue storage: At most **O(V)** vertices (since we check visited status before enqueueing)
2. Visited tracking: **O(V)** space to store visited status for all vertices

## Shortest Path Between Two Vertices - Breadth-First Search

## Complexity Analysis

### Time Complexity
**O(V + E)**  
where:  
- **V** = number of vertices  
- **E** = number of edges  

In the worst case (maximum distance between start and target vertices), we must:  
- Visit each vertex exactly once  
- Traverse each edge exactly once  

### Space Complexity 
**O(V)** due to:  
- Queue storage: up to V vertices  
- Visited tracking: V boolean flags  

*Note: This analysis assumes an adjacency list representation.*

## LeetCode 1971 - Find if Path Exists in Graph - BFS

```cshrp
using System;
using System.Collections.Generic;

public class Solution
{
    public bool ValidPath(int n, int[][] edges, int start, int end)
    {
        List<List<int>> adjacencyList = new List<List<int>>();
        for (int i = 0; i < n; i++)
        {
            adjacencyList.Add(new List<int>());
        }

        foreach (int[] edge in edges)
        {
            adjacencyList[edge[0]].Add(edge[1]);
            adjacencyList[edge[1]].Add(edge[0]);
        }

        Queue<int> queue = new Queue<int>();
        bool[] seen = new bool[n];
        queue.Enqueue(start);
        seen[start] = true;

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();

            if (node == end)
            {
                return true;
            }

            foreach (int neighbor in adjacencyList[node])
            {
                if (!seen[neighbor])
                {
                    seen[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }

        return false;
    }
}
```

## Complexity Analysis

### Time Complexity: O(V + E)
- **V** = Number of vertices
- **E** = Number of edges

Breakdown:
1. **Adjacency list construction**: O(E) (iterate through all edges)
2. **Vertex processing**: O(V) (visit each vertex once)
3. **Edge traversal**: O(E) (process all neighbors through adjacency lists)

### Space Complexity: O(V + E)
Components:
1. **Adjacency list**: O(V + E) storage
2. **Queue**: O(V) in worst case
3. **Visited set**: O(V) for tracking

*Note: This analysis applies to standard BFS/DFS implementations using adjacency lists.*

## LeetCode 797 - All Paths From Source to Target - BFS

## Complexity Analysis

```cshrp
using System;
using System.Collections.Generic;

public class Solution
{
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        List<IList<int>> paths = new List<IList<int>>();
        if (graph == null || graph.Length == 0)
        {
            return paths;
        }

        Queue<List<int>> queue = new Queue<List<int>>();
        List<int> path = new List<int> { 0 };
        queue.Enqueue(path);

        while (queue.Count > 0)
        {
            List<int> currentPath = queue.Dequeue();
            int node = currentPath[currentPath.Count - 1];

            foreach (int nextNode in graph[node])
            {
                List<int> tmpPath = new List<int>(currentPath) { nextNode };

                if (nextNode == graph.Length - 1)
                {
                    paths.Add(new List<int>(tmpPath));
                }
                else
                {
                    queue.Enqueue(new List<int>(tmpPath));
                }
            }
        }

        return paths;
    }
}

```

### Time Complexity: O(2ᴠ·V)
- **V** = Number of vertices

**Explanation:**
1. Maximum possible paths: 2^(V-1) - 1 (exponential in V)
2. Each path construction: O(V) time
3. Upper bound: (2^(V-1) - 1) × O(V) = O(2ᴠ·V)
4. Actual time may be lower due to path overlap

### Space Complexity: O(2ᴠ·V)
**Components:**
1. Queue storage: O(2ᴠ) paths in worst case
2. Each path: O(V) space
3. Total: O(2ᴠ·V) space

*Note: This exponential complexity occurs in worst-case scenarios for certain graph traversal problems.*

## Overview of Minimum Spanning Tree
