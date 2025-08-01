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

When we discussed selection sort, the basic principle involved finding the minimum element and moving it to the front. We repeated this continuously until we sorted the entire list. But as we saw, selection sort has a running time of O(n2), since for every iteration, we need to find the minimum element in the list which takes O(n) time. We can improve upon this by using a special data structure called a heap.

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
The key aspect that makes heapsort better than selection sort is the running time of the algorithm is now O(NlogN). This is a result of the fact that removing the max element from the heap, which is the central operation in the sort is a O(logN) operation, which has to be performed in the worst case N−1 times. Note that in-place heapification is an O(N) operation, so it has no impact on the worst-case time complexity of heapsort.

In terms of space complexity, since we are treating the input array as a heap and creating no extra space (all operations are in-place), heapsort is O(1).

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
The main advantage of heapsort is it's generally much faster than the other comparison based sorts on sufficiently large inputs as a consequence of the running time. However, there are a few undesirable qualities in the algorithm. For one, it is not a stable sort. It also turns out that in practice, this algorithm performs worse than other O(NlogN) sorts as a result of bad cache locality properties. Heapsort swaps elements based on locations in heaps, which can cause many read operations to access indices in a seemingly random order, causing many cache misses, which will result in practical performance hits.

# Non-Comparison Based Sorts

## Counting Sort

In the world of non-comparison based sorts, one of the simplest building blocks is counting sort.

Let’s start with a simple example and build up to the full counting sort algorithm. Let’s define an array A=[1,5,0,3,6,4,2]

Could you come up with a clever approach to sort this special array in a single pass?

A special property of this array is that the maximum element is 6, the minimum element is 0, and each value in between shows up exactly once in the array. So, for this specific array, a rather simple algorithm can sort it in one pass:

Initialize an array 
output of size 7
For every element A[i]
output[A[i]]=A[i]
All we have to do is map each element A[i] to index A[i] in the output array. This algorithm runs in O(N) time and O(N) extra space. It is guaranteed to work for any array with the following properties: 1. Each element in the array A is between 0 and N−1 inclusive (0≤A[i]≤N−1) 2. No element is repeated 3. The array is size N (all elements from 0 to N - 1 show up exactly once)

The above algorithm in a sense is the simplest version of counting sort. Counting sort is all about using a predefined range of “keys” (in the above example, the keys map one-to-one to an index) to construct a sorted input. The above example is the basic idea, but there are some natural extensions to it. 1. Counting sort can handle non-unique keys (input array can have duplicate elements) 2. Counting sort can handle non-consecutive keys (input array can have elements that don’t exist within the predefined range of values) 3. Counting sort can handle non-numerical keys as long as they are constrained within an alphabet of constrained size (e.g characters, objects with a predefined set of values)

Suppose now that the minimum possible value of the array is set to 0 and the maximum possible value in the array is K. The main idea required to handle steps (1) and (2) is to track the frequency of each value in the range 0 to K.

Suppose the input array was A=[5,4,5,5,1,1,3]

As we did earlier, we can initialize a new array counts of size equal to the max(A)+1. Then, the core concept involves mapping each index i of the counts array to the number of occurrences of 
i in the original array A.

In this example, the counts array would be [0, 2, 0, 1, 1, 3, 0]

From this counts array, we can determine the starting index for each element in the original array. The starting indices can be found by calculating the cumulative sum of our previous counts array (index i is the sum of all preceding indices). startingIndices=[0,0,2,2,3,4,7]

An easy interpretation of this array is to take any element in the original input A and find its index in startingIndices. That index is where the first instance of that element should be placed. Couple of examples below:

The first instance of element 1 should be placed at index 0 (which makes sense because it is the minimum element).
The first instance of element 5 should be placed at index 4. This must be true since, when sorted, there are three total instances of 5's, so the starting index of the first instance of 5 should be at index 4. On every iteration, we will increment the index as we process elements. So the second and third instances of element 5 will be placed at indices 5 and 6, respectively.
Below is an animation of counting sort:

In the actual implementation of this algorithm, we will overwrite the original counts array with the startingIndices array to reduce the amount of additional space used.

With this intuition in hand, below is the algorithm for counting sort on a set of integers from 0 to K (not all values have to be present and some values can be duplicated).

```csharp
using System;
using System.Linq;

public class Solution
{
    public void CountingSort(int[] arr)
    {
        // Sorts an array of integers where minimum value is 0 and maximum value is K
        int K = arr.Max();
        int[] counts = new int[K + 1];
        foreach (int elem in arr)
        {
            counts[elem] += 1;
        }
        
        // Overwrite counts with the starting index of each element in the final sorted array
        int startingIndex = 0;
        for (int i = 0; i < K + 1; i++)
        {
            int count = counts[i];
            counts[i] = startingIndex;
            startingIndex += count;
        }

        int[] sortedArray = new int[arr.Length];
        foreach (int elem in arr)
        {
            sortedArray[counts[elem]] = elem;
            // Increment counts[elem] index by 1 so the next duplicate element
            // is placed in the appropriate index
            counts[elem] += 1;
        }

        // Copy over sorted list into original arr
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = sortedArray[i];
        }
    }
}
```
The time complexity of counting sort is O(N+K) where N is the size of the input array and K is the maximum value in the array. Again, a key assumption in the above version of counting sort is that the minimum possible value in the array is 0 (no negative numbers) and the maximum value is some positive integer K. If this is not the case, it's possible to perform a mapping step at the beginning and then remap the values to the original array at the end. For example, an array with values between -5 and 10 can be mapped to values between 0 and 15, perform counting sort, and then remap to the original -5 to 10 range.

Below is a slight modification to counting sort to handle shifting of values when values are between a range of two general integers.

```csharp
using System;
using System.Linq;

public class Solution
{
    public void CountingSort(int[] arr)
    {
        // Sorts an array of integers (handles shifting of integers to range 0 to K)
        int shift = arr.Min();
        int K = arr.Max() - shift;
        int[] counts = new int[K + 1];
        foreach (int elem in arr)
        {
            counts[elem - shift] += 1;
        }
        
        // Overwrite counts with the starting index of each element in the final sorted array
        int startingIndex = 0;
        for (int i = 0; i < K + 1; i++)
        {
            int count = counts[i];
            counts[i] = startingIndex;
            startingIndex += count;
        }

        int[] sortedArray = new int[arr.Length];
        foreach (int elem in arr)
        {
            sortedArray[counts[elem - shift]] = elem;
            // Increment counts[elem] index by 1 so the next duplicate element
            // is placed in the appropriate index
            counts[elem - shift] += 1;
        }

        // Copy over sorted list into original arr
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = sortedArray[i];
        }
    }
}
```
The space complexity of counting sort is also O(N+K) since we have to initialize a new array of size N and a counts array of size K+1.

Another important constraint is that counting sort is only viable on inputs that have a fixed size (integers in a range, characters, etc.). If the possible set of inputs is an array of strings, counting sort is not a viable option.

Advantages of using counting sort: 1. It is a stable sort. 2. It can be significantly faster than other comparison based sorts on larger collections of integers with a relatively small range of values.

Disadvantages of using counting sort: 1. It requires extra memory, while many comparison sorts can be implemented without requiring any extra memory. 2. When the range of possible values K is large compared to N, counting sort may actually perform worse than a theoretically slower O(NlogN) sort as a result of the extra memory overhead and additional K operations that need to be performed.

## Radix Sort

A problem we encounter with counting sort is that it can’t easily handle strings where the alphabet size could be unconstrained. Additionally, when the maximum value of the array is extraordinarily large, counting sort will lose its appeal since the additional memory overhead can cause things to slow down quite a bit.

Radix sort is an extension of counting sort that handles these problems. It works well with collections of strings and collections of integers (especially when the maximum value is large).
There are a couple of variations of radix sort, but let’s focus on Least Significant Digit (LSD) Radix Sort.

Let’s use the example array 
A=[256,336,736,443,831,907]

LSD Radix Sort
The basic principle of LSD radix sort is to start with the rightmost, least significant, digit (in the case of strings, the rightmost character) of each integer and perform a counting sort on just that digit. Since counting sort is a stable sort, it will keep elements in their relative order in the case of ties.

After the first step of sorting we get the following array (focus on the last digit here):

[831, 443, 256, 336, 736, 907]

We repeat the process on the second digit to get the following array:

[907, 831, 336, 736, 443, 256]

And finally, the last step involves the leftmost digit, which then gives us our sorted array:

[256, 336, 443, 736, 831, 907]

In the case where Radix sort has to deal with integers that have a different number of digits, the leftmost digits in smaller numbers will be treated as 0 anyways, so the sorting algorithm will still work. In the case of strings, a common practice is to pad the smaller length strings with special characters that are treated as the minimum values in an alphabet until the smaller length strings match the length of the longest string.

Here is the full LSD radix sort algorithm for integers. 1. Find the number of digits in the maximum integer. Let that be W. 2. For each integer, loop through digits from 1 to W in right to left order (least significant to most significant digit). On each group of digits, perform counting sort.

Below is the implementation of LSD Radix Sort (note that it uses a modified implementation of counting sort):

```csharp
using System;

public class Solution
{
    private const int NUM_DIGITS = 10;

    public void CountingSort(int[] arr, int placeVal)
    {
        // Sorts an array of integers where minimum value is 0 and maximum value is NUM_DIGITS
        int[] counts = new int[NUM_DIGITS];

        foreach (int elem in arr)
        {
            int current = elem / placeVal;
            counts[current % NUM_DIGITS] += 1;
        }

        // Overwrite counts with the starting index of each digit in our group of digits
        int startingIndex = 0;
        for (int i = 0; i < counts.Length; i++)
        {
            int count = counts[i];
            counts[i] = startingIndex;
            startingIndex += count;
        }

        int[] sortedArray = new int[arr.Length];
        foreach (int elem in arr)
        {
            int current = elem / placeVal;
            sortedArray[counts[current % NUM_DIGITS]] = elem;
            // Increment counts[current % NUM_DIGITS] index by 1 so the
            // next duplicate digit is placed in the appropriate index
            counts[current % NUM_DIGITS] += 1;
        }

        // Copy over sorted list into original arr
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = sortedArray[i];
        }
    }

    public void RadixSort(int[] arr)
    {
        int maxElem = int.MinValue;
        foreach (int elem in arr)
        {
            if (elem > maxElem)
            {
                maxElem = elem;
            }
        }

        int placeVal = 1;
        while (maxElem / placeVal > 0)
        {
            CountingSort(arr, placeVal);
            placeVal *= 10;
        }
    }
}
```
The running time of LSD Radix sort requires a few parameters. Let W be the maximum digit length within the list of integers. Let N be the size of the original input integer array. And lastly, since we are using counting sort, we must also be aware of the alphabet size K. In the case of digits, it’s a constant 10, but when applied to other inputs, this alphabet size may change.

With these parameters defined, the running time of LSD radix sort is O(W(N+K)) as a result of at most W calls to counting sort. The amount of extra space needed is the same as counting sort – O(N+K).

The advantage of LSD Radix sort is that for a set of integers and strings with a reasonable W and K. It can be extraordinarily fast, sorting in close to linear time (when W is small). It is also a stable sort.

The disadvantages are that LSD radix sort does require some overhead memory, which when N and/or K is large, can cause major performance hits when compared to other sorts. Additionally, it does require looking at all digits due to the fact that more significant digits later down the line have more impact on the final sorted result. Another type of radix sort that’s commonly used that uses similar ideas looks at the most significant digit (MSD) first and is called MSD radix sort. This approach has a better average case and best case performance than LSD radix sort, though the implementation is significantly trickier.

## Bucket Sort
Bucket sort is another non-comparison sorting method similar to counting sort and radix sort. The overarching idea in bucket sort is to place every element of the input into a bucket, where each bucket accepts a range of values. Each bucket is then sorted using a traditional sorting algorithm and then the outputs of the buckets are put together to create one sorted list.

Let's consider a simple example using the array A=[22,50,32,28,41,12].

Suppose we used K=5 buckets. Since the max value of the array is 50, what bucket sort will do is place elements in the array into the following 5 buckets:
[0, 9] -> elements: []
[10, 19] -> elements: [12]
[20, 29] -> elements: [22, 28]
[30, 39] -> elements: [32]
[40, 50] -> elements: [50, 41]

The next step involves sorting each bucket using a traditional sort such as insertion sort. Finally, bucket sort will go through each of the sorted buckets in proper order and put together the buckets into the final sorted list.

The steps of bucket sort can be broken down into four distinct parts.
Given an array A:
1. Create an initial array of k empty buckets.
2. Distribute each element of the array into its respective bucket. A common way to map values to buckets is via the following function: floor(K∗A[i]/max(A)).
3. Sort each bucket using insertion sort or some other sorting algorithm.
4. Concatenate the sorted buckets in order to create the sorted list.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public void BucketSort(int[] arr, int K)
    {
        List<List<int>> buckets = new List<List<int>>(K);
        for (int i = 0; i < K; i++)
        {
            buckets.Add(new List<int>());
        }

        int shift = arr.Min();
        int maxValue = arr.Max() - shift;

        // Place elements into buckets
        double bucketSize = (double)maxValue / K;
        if (bucketSize < 1)
        {
            bucketSize = 1.0;
        }

        foreach (int elem in arr)
        {
            int index = (int)((elem - shift) / bucketSize);
            if (index == K)
            {
                // Put the max value in the last bucket
                buckets[K - 1].Add(elem);
            }
            else
            {
                buckets[index].Add(elem);
            }
        }

        // Sort individual buckets
        foreach (var bucket in buckets)
        {
            bucket.Sort();
        }

        // Convert sorted buckets into final output
        List<int> sortedList = new List<int>();
        foreach (var bucket in buckets)
        {
            sortedList.AddRange(bucket);
        }

        // Copy sorted elements back to original array
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = sortedList[i];
        }
    }
}
```
The worst-case time complexity of bucket sort is O(N2) if the sorting algorithm used on the bucket is insertion sort, which is the most common use case since the expectation is that buckets will not have too many elements relative to the entire list. 
In the worst case, all elements are placed in one bucket, causing the running time to reduce to the worst-case complexity of insertion sort (all elements are in reverse order). If the worst-case running time of the intermediate sort used is O(NlogN), then the worst-case running time of bucket sort will also be O(NlogN)

On average, when the distribution of elements across buckets is reasonably uniform, it can be shown that bucket sort runs on average O(N+K) for K buckets.

The space complexity is O(N+K) since we have to initialize an array of size K.
The total number of elements stored in this additional array is N, since all N elements have to go inside a bucket.
