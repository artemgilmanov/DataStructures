# Fundamentals of Sorting

The fundamental problem of sorting is all about ordering a collection of items. How you order these items is entirely based on the method of comparison. Suppose you needed to sort a pile of books. If you are working on a home library, you might organize it by the author’s last name. But if you need to quickly transport the books, it might make sense to initially organize them based on the size of the book. Both of these problems are sorting problems, but a key takeaway is that sorting problems are necessarily tied to a method of comparison. Different methods of comparison may lead to different results. At the most basic level, sorting algorithms are all about rearranging elements in a collection based on a common characteristic of those elements.

In computer science, we have formal definitions of sorting with respect to ordering relations.

An ordering relation has two key properties:
1. Given two elements a and b, exactly one of the following must be true: a<b, a=b, or a>b ( Law of Trichotomy ) 
2. If a<b and b<c, then a<c ( Law of Transitivity )

A sort is formally defined as a rearrangement of a sequence of elements that puts all elements into a non-decreasing order based on the ordering relation.

Suppose you were given a list of strings [“hello”, “world”, “we”, “are”, “learning, “sorting”]. One way to define an ordering relation might be based on the length of the string. One valid sort based on this ordering relation is [“we”, “are”, “hello”, “world”, “sorting”, “learning”]. For every pair of adjacent elements in the list, the length of the preceding string is always less than or equal to the length of the following string. Another ordering relation we could define is the number of vowels in the string. That would lead to the following sort: [“we”, “world”, “are”, “hello”, “sorting”, “learning”].

The ordering relation practically is defined as a method of comparison in programming languages. Most programming languages allow you to pass in custom functions for comparison whenever you want to sort a sequence of elements. In Java, for example, these are comparators. In Python, you can pass a comparison function as the key to the sort method.

```csharp
using System;
using System.Collections.Generic;

public class Solution
{
    public void SortByLength(string[] arr)
    {
        // Sorts an array of strings by length of each string
        Array.Sort(arr, new StringCompare());
    }
}

public class StringCompare : IComparer<string>
{
    public int Compare(string s1, string s2)
    {
        return s1.Length.CompareTo(s2.Length);
    }
}
```

An important concept in sorting is inversions. An inversion in a sequence is defined as a pair of elements that are out of order with respect to the ordering relation. To understand this idea better, let's consider our earlier string example, where the ordering relation was defined by the length of the string:

[“are”, “we”, “sorting”, “hello”, “world”, “learning”]

Clearly, the above list is not sorted according to the lengths of strings, but what if you had to define a metric for how “out of sort” it was? Inversions provide a way to define that. In the above unsorted list, we have the following inversions:

(“are”, “we”), (“sorting”, “hello”), and (“sorting”, “world”)

The more inversions present, the more out of order the list is. In fact, the concept of inversions introduces an alternative definition of sorting: Given a sequence of elements with n inversions, a sorting algorithm is a sequence of operations that reduces inversions to 0.

The next important concept in sorting that we will refer back to is the stability of sorting algorithms. The key feature of a stable sorting algorithm is that it will preserve the order of equal elements. In our earlier string example with the string length ordering comparison, our original sequence was 

[“hello”, “world”, “we”, “are”, “learning, “sorting”]

There are two valid sorts for this sequence:

[“we”, “are”, “hello”, “world”, “sorting”, “learning”]
[“we”, “are”, “world”, “hello”, “sorting”, “learning”]

We consider (1) to be a stable sort since the equal elements “hello” and “world” are kept in the same relative order as the original sequence.

# Selection Sort

Suppose you had to sort a pile of books by their weight, with the heaviest book on the bottom and the lightest book on the top. One reasonable method of sorting is to go through your books, find the heaviest book, and then place that at the bottom. After that, you can then find the next heaviest book in the remaining pile of books and place that on top of the heaviest book. You can continue this approach until you have a sorted pile of books. This concept is exactly what the selection sort does.

Suppose we had a collection of elements where every element is an integer. Selection sort will build up the sorted list by repeatedly finding the minimum element in that list and moving it to the front of the list through a swap. It will proceed to swap elements appropriately until the entire list is sorted.

In terms of simplicity, it is a highly intuitive algorithm and not too difficult to write. Unfortunately, it is pretty slow, requiring O(n2) time to sort the list in the worst case. In the worst case, we have to search the entire array to find the minimum element, meaning we can have up to n+(n−1)+(n−2)+…+1 total operations, which is O(n2). The space complexity of selection sort is O(1) since we do not use any additional space during the algorithm (all operations are in-place).

It also is not a stable sorting algorithm. For example consider the collection [4, 2, 3, 4, 1]. After the first round of selection sort, we get the array [1, 2, 3, 4, 4]. This array is sorted, but it does not preserve the ordering of equal elements.

```csharp

using System;

public class Solution
{
    public void SelectionSort(int[] arr)
    {
        // Mutates arr so that it is sorted via selecting the minimum element and
        // swapping it with the corresponding index
        int minIndex;
        for (int i = 0; i < arr.Length; i++)
        {
            minIndex = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }
            // Swap current index with minimum element in rest of list
            int temp = arr[minIndex];
            arr[minIndex] = arr[i];
            arr[i] = temp;
        }
    }
}
```
# Bubble Sort

Conceptually, bubble sort is an implementation of a rather simple idea. Suppose we have a collection of integers that we want to sort in ascending order. Bubble sort proceeds to consider two adjacent elements at a time. If these two adjacent elements are out of order (in this case, the left element is strictly greater than the right element), bubble sort will swap them. It then proceeds to the next pair of adjacent elements. In the first pass of bubble sort, it will process every set of adjacent elements in the collection once, making swaps as necessary. The core idea of bubble sort is it will repeat this process until no more swaps are made in a single pass, which means the list is sorted.

In terms of the running time of the algorithm, bubble sort’s runtime is entirely based on the number of passes it must make in the array until it’s sorted. If the array has n elements, each pass will consider (n−1) pairs. In the worst case, when the minimum element is at the end of the list, it will take (n−1) passes to get it to the proper place at the front of the list, and then one more additional pass to determine that no more swaps are needed. Bubble sort, as a result, has worst case runtime of O(n2). The space complexity of bubble sort is O(1). All sorting operations involve swapping adjacent elements in the original input array, so no additional space is required.

Bubble sort is also a stable sorting algorithm since equal elements will never have swapped places, so their relative ordering will be preserved.

Overall, bubble sort is fairly simple to implement, and it’s stable, but outside of that, this algorithm does not have many desirable features. It’s fairly slow for most inputs and, as a result, it is rarely used in practice.

Below is the implementation of bubble sort:

```csharp
using System;

public class Solution
{
    public void BubbleSort(int[] arr)
    {
        // Mutates arr so that it is sorted via swapping adjacent elements until
        // the arr is sorted.
        bool hasSwapped = true;
        while (hasSwapped)
        {
            hasSwapped = false;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    // Swap adjacent elements
                    int temp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = temp;
                    hasSwapped = true;
                }
            }
        }
    }
}
```

#   Insertion Sort
Going back to our pile of books analogy, where we attempted to sort by weight, let's explore another approach to sorting the pile of books. We'll start at the top of the pile and iterate over the books one by one. Every time we encounter a book that is lighter than the book above it, we'll move the book up until it is in its appropriate place. Repeating this for the entire pile of books, we will get the books in sorted order.

This is the core intuition behind insertion sort. Given a collection of integers, you can sort the list by proceeding from the start of the list, and every time you encounter an element that is out of order, you can continuously swap places with previous elements until it is inserted in its correct relative location based on what you’ve processed thus far. This process is best understood with a visual example.

n terms of efficiency of this approach, the worst possible input is a reversed list, where every element has to be inserted at the very beginning of the list, which leads to a total of 1+2+…+(n−1) or O(n2) swaps. The space complexity of insertion sort is O(1). All operations are performed in-place.

Despite the O(n2) time complexity, in practice, there are a couple of advantages to insertion sort.

For one, it is a stable sort. By design of its implementation, we will never swap an element later in the list with an equal element earlier in the list. But more importantly, there are cases where insertion sort may actually be the best sort.

Generally, on almost sorted arrays where the number of inversions is relatively small compared to the size of the array, insertion sort will be quite fast since the number of swaps required will be low on almost sorted arrays.

Next, insertion sort can also be the best choice on small arrays. This is more of an empirical observation based on experiments, but it is one that you should be aware of. Many sorting functions have a quick check for the size of the collection and if that value is below a threshold, the program will default to insertion sort. Java's official implementation of Arrays.sort() performs such a check before performing more theoretically optimal sorts.

In terms of disadvantages, on larger collections with many inversions, other sorts will generally outperform insertion sort. However, of all the sorts we have covered thus far, insertion sort is the first that is practically used, depending on the context.

Below is the implementation of insertion sort:

```csharp
using System;

public class Solution
{
    public void InsertionSort(int[] arr)
    {
        // Mutates elements in arr by inserting out of place elements into appropriate
        // index repeatedly until arr is sorted
        for (int i = 1; i < arr.Length; i++)
        {
            int currentIndex = i;
            while (currentIndex > 0 && arr[currentIndex - 1] > arr[currentIndex])
            {
                // Swap elements that are out of order
                int temp = arr[currentIndex];
                arr[currentIndex] = arr[currentIndex - 1];
                arr[currentIndex - 1] = temp;
                currentIndex -= 1;
            }
        }
    }
}
```
# Heap Sort

When we discussed selection sort, the basic principle involved finding the minimum element and moving it to the front. We repeated this continuously until we sorted the entire list. But as we saw, selection sort has a running time of 
O
(
n
2
)
O(n 
2
 ), since for every iteration, we need to find the minimum element in the list which takes 
O
(
n
)
O(n) time. We can improve upon this by using a special data structure called a heap.

To review the basics of the heap data structure, you can visit the Heap Explore Card. The core concept of the heap sort involves constructing a heap from our input and repeatedly removing the minimum/maximum element to sort the array. A naive approach to heapsort would start with creating a new array and adding elements one by one into the new array. As with previous sorting algorithms, this sorting algorithm can also be performed in place, so no extra memory is used in terms of space complexity.

The key idea for in-place heapsort involves a balance of two central ideas:
(a) Building a heap from an unsorted array through a “bottom-up heapification” process, and
(b) Using the heap to sort the input array.

Heapsort traditionally uses a max-heap to sort the array, although a min-heap also works, but its implementation is a little less elegant.

Algorithm for “bottom-up heapification” of input into max-heap. Given an input array, we can represent it as a binary tree. If the parent node is stored at index i, the left child will be stored at index 2i + 1 and the right child at index 2i + 2 (assuming the indexing starts at 0).
To convert it to a max-heap, we proceed with the following steps:

Start from the end of the array (bottom of the binary tree).
There are two cases for a node
It is greater than its left child and right child (if any).
In this case, proceed to next node (one index before current array index)
There exists a child node that is greater than the current node
In this case, swap the current node with the child node. This fixes a violation of the max-heap property
Repeat the process with the node until the max-heap property is no longer violated
Repeat step 2 on every node in the binary tree from bottom-up.
A key property of this method is that by processing the nodes from the bottom-up, once we are at a specific node in our heap, it is guaranteed that all child nodes are also heaps. Once we have “heapified” the input, we can begin using the max-heap to sort the list. To do so, we will:

Take the maximum element at index 0 (we know this is the maximum element because of the max-heap property) and swap it with the last element in the array (this element's proper place).
We now have sorted an element (the last element). We can now ignore this element and decrease heap size by 1, thereby omitting the max element from the heap while keeping it in the array.
Treat the remaining elements as a new heap. There are two cases:
The root element violates the max-heap property
Sink this node into the heap until it no longer violates the max-heap property. Here the concept of "sinking" a node refers to swapping the node with one of its children until the heap property is no longer violated.
The root element does not violate the max-heap property
Proceed to step (4)
Repeat step 1 on the remaining unsorted elements. Continue until all elements are sorted.
The key aspect that makes heapsort better than selection sort is the running time of the algorithm is now 
O
(
N
log
⁡
N
)
O(NlogN). This is a result of the fact that removing the max element from the heap, which is the central operation in the sort is a 
O
(
log
⁡
N
)
O(logN) operation, which has to be performed in the worst case 
N
−
1
N−1 times. Note that in-place heapification is an 
O
(
N
)
O(N) operation, so it has no impact on the worst-case time complexity of heapsort.

In terms of space complexity, since we are treating the input array as a heap and creating no extra space (all operations are in-place), heapsort is 
O
(
1
)
O(1).

Implementation of heapsort
```csharp
using System;

public class Solution
{
    public void HeapSort(int[] arr)
    {
        // Mutates elements in arr by utilizing the heap data structure
        for (int i = arr.Length / 2 - 1; i >= 0; i--)
        {
            MaxHeapify(arr, arr.Length, i);
        }

        for (int i = arr.Length - 1; i > 0; i--)
        {
            // Swap last element with first element
            int temp = arr[i];
            arr[i] = arr[0];
            arr[0] = temp;
            // Note that we reduce the heap size by 1 every iteration
            MaxHeapify(arr, i, 0);
        }
    }

    private void MaxHeapify(int[] arr, int heapSize, int index)
    {
        int left = 2 * index + 1;
        int right = 2 * index + 2;
        int largest = index;
        if (left < heapSize && arr[left] > arr[largest])
        {
            largest = left;
        }
        if (right < heapSize && arr[right] > arr[largest])
        {
            largest = right;
        }  
        if (largest != index)
        {
            int temp = arr[index];
            arr[index] = arr[largest];
            arr[largest] = temp;
            MaxHeapify(arr, heapSize, largest);
        }
    }
}

```
The main advantage of heapsort is it's generally much faster than the other comparison based sorts on sufficiently large inputs as a consequence of the running time. However, there are a few undesirable qualities in the algorithm. For one, it is not a stable sort. It also turns out that in practice, this algorithm performs worse than other 
O
(
N
log
⁡
N
)
O(NlogN) sorts as a result of bad cache locality properties. Heapsort swaps elements based on locations in heaps, which can cause many read operations to access indices in a seemingly random order, causing many cache misses, which will result in practical performance hits.
