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
