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
