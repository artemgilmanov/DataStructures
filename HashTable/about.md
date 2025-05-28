## The Principle of Hash Table

As we mentioned in the introduction,  Hash Table is a data structure which organizes data using hash functions in order to support quick insertion and search. In this article, we will take a look at the principle of the hash table.

The Principle of Hash Table
The key idea of Hash Table is to use a hash function to map keys to buckets. To be more specific,

When we insert a new key, the hash function will decide which bucket the key should be assigned and the key will be stored in the corresponding bucket;
When we want to search for a key, the hash table will use the same hash function to find the corresponding bucket and search only in the specific bucket.
 
An Example

In the example, we use y = x % 5 as our hash function. Let's go through the insertion and search strategies using this example:

Insertion: we parse the keys through the hash function to map them into the corresponding bucket.
e.g. 1987 is assigned to bucket 2 while 24 is assigned to bucket 4.
Search: we parse the keys through the same hash function and search only in the specific bucket.
e.g. if we search for 1987, we will use the same hash function to map 1987 to 2. So we search in bucket 2 and we successfully find out 1987 in that bucket.
e.g. if we search for 23, will map 23 to 3 and search in bucket 3. And We find out that 23 is not in bucket 3 which means 23 is not in the hash table.

## Keys to Design a Hash Table

There are two essential factors that you should pay attention to when you are going to design a hash table.

1. Hash Function
The hash function is the most important component of a hash table which is used to map the key to a specific bucket. In the example in the previous article, we use y = x % 5 as a hash function, where x is the key value and y is the index of the assigned bucket.

The hash function will depend on the range of key values and the number of buckets.

Here are some examples of hash functions:

It is an open problem to design a hash function. The idea is to try to assign the key to the bucket as uniformly as you can. Ideally, a perfect hash function will be a one-one mapping between the key and the bucket. However, in most cases, a hash function is not perfect and it is a tradeoff between the amount of buckets and the capacity of a bucket.

2. Collision Resolution
Ideally, if our hash function is a perfect one-one mapping, we will not need to handle collisions. Unfortunately, in most cases, collisions are almost inevitable. For instance, in our previous hash function (y = x % 5), both 1987 and 2 are assigned to bucket 2. That is a collision.

A collision resolution algorithm should solve the following questions:

How to organize the values in the same bucket?
What if too many values are assigned to the same bucket?
How to search for a target value in a specific bucket?
These questions are related to the capacity of the bucket and the number of keys which might be mapped into the same bucket according to our hash function.

Let's assume that the bucket, which holds the maximum number of keys, has N keys.

Typically, if N is constant and small, we can simply use an array to store keys in the same bucket. If N is variable or large, we might need to use height-balanced binary search tree instead.

Exercise
By now, you should be able to implement a basic hash table. We provide the exercise for you to implement a hash set and a hash map. Read the requirement, determine your hash function and solve the collision if needed. 

If you are not familiar with the concepts of hash set and hash map, you can go back to the introduction part to find out the answer.

Insertion and search are two basic operations in a hash table.

Besides, there are operations that are based on these two operations. For example, when we remove an element, we will first search the element and then remove the element from the corresponding position if the element exists.

## Design HashSet

Design a HashSet without using any built-in hash table libraries.

Implement MyHashSet class:

void add(key) Inserts the value key into the HashSet.
bool contains(key) Returns whether the value key exists in the HashSet or not.
void remove(key) Removes the value key in the HashSet. If key does not exist in the HashSet, do nothing.
 
Example 1:

Input
["MyHashSet", "add", "add", "contains", "contains", "add", "contains", "remove", "contains"]
[[], [1], [2], [1], [3], [2], [2], [2], [2]]
Output
[null, null, null, true, false, null, true, null, false]

Explanation
MyHashSet myHashSet = new MyHashSet();
myHashSet.add(1);      // set = [1]
myHashSet.add(2);      // set = [1, 2]
myHashSet.contains(1); // return True
myHashSet.contains(3); // return False, (not found)
myHashSet.add(2);      // set = [1, 2]
myHashSet.contains(2); // return True
myHashSet.remove(2);   // set = [1]
myHashSet.contains(2); // return False, (already removed)
 
Constraints:

0 <= key <= 106
At most 104 calls will be made to add, remove, and contains.

## Design HashMap

Design a HashMap without using any built-in hash table libraries.

Implement the MyHashMap class:

MyHashMap() initializes the object with an empty map.
void put(int key, int value) inserts a (key, value) pair into the HashMap. If the key already exists in the map, update the corresponding value.
int get(int key) returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key.
void remove(key) removes the key and its corresponding value if the map contains the mapping for the key.
 
Example 1:

Input
["MyHashMap", "put", "put", "get", "get", "put", "get", "remove", "get"]
[[], [1, 1], [2, 2], [1], [3], [2, 1], [2], [2], [2]]
Output
[null, null, null, 1, -1, null, 1, null, -1]

Explanation
MyHashMap myHashMap = new MyHashMap();
myHashMap.put(1, 1); // The map is now [[1,1]]
myHashMap.put(2, 2); // The map is now [[1,1], [2,2]]
myHashMap.get(1);    // return 1, The map is now [[1,1], [2,2]]
myHashMap.get(3);    // return -1 (i.e., not found), The map is now [[1,1], [2,2]]
myHashMap.put(2, 1); // The map is now [[1,1], [2,1]] (i.e., update the existing value)
myHashMap.get(2);    // return 1, The map is now [[1,1], [2,1]]
myHashMap.remove(2); // remove the mapping for 2, The map is now [[1,1]]
myHashMap.get(2);    // return -1 (i.e., not found), The map is now [[1,1]]

Constraints:

0 <= key, value <= 106
At most 104 calls will be made to put, get, and remove.

## Hash Set - Usage

The hash set is one of the implementations of a set which is a data structure to store no repeated values. 

We provide an example of using the hash set in Java, C++ and Python. If you are not familiar with the usage of the hash set, it will be helpful to go through the example.

```cshrp
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        // 1. initialize the hash set
        HashSet<int> hashSet = new HashSet<int>();

        // 2. add a new key
        hashSet.Add(3);
        hashSet.Add(2);
        hashSet.Add(1);

        // 3. remove the key
        hashSet.Remove(2);

        // 4. check if the key is in the hash set
        if (!hashSet.Contains(2))
        {
            Console.WriteLine("Key 2 is not in the hash set.");
        }

        // 5. get the size of the hash set
        Console.WriteLine("The size of hash set is: " + hashSet.Count);

        // 6. iterate the hash set
        foreach (int i in hashSet)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("are in the hash set.");

        // 7. clear the hash set
        hashSet.Clear();

        // 8. check if the hash set is empty
        if (hashSet.Count == 0)
        {
            Console.WriteLine("hash set is empty now!");
        }
    }
}

```

## Find Duplicates By Hash Set

As we know, it is easy and effective to insert a new value and check if a value is in a hash set or not.

Therefore, typically, a hash set is used to check if a value has ever appeared or not.

An Example
Let's look at an example:

Given an array of integers, find if the array contains any duplicates. 

This is a typical problem which can be solved by a hash set.

You can simply iterate each value and insert the value into the set. If a value has already been in the hash set, there is a duplicate.

Template
Here we provide a template for you to solve this kind of problems:

```cshrp
using System.Collections.Generic;

bool FindDuplicates<T>(List<T> keys)
{
    HashSet<T> hashset = new HashSet<T>();
    foreach (T key in keys)
    {
        if (hashset.Contains(key))
        {
            return true;
        }
        hashset.Add(key);
    }
    return false;
}
```

##   Hash Map - Usage

The hash map is one of the implementations of a map which is used to store (key, value) pairs.

We provide an example of using the hash map in Java, C++ and Python. If you are not familiar with the usage of the hash map, it will be helpful to go through the example.

```cshrp
using System;
using System.Collections.Generic;

public class MainClass
{
    public static void Main(string[] args)
    {
        // 1. initialize a dictionary
        Dictionary<int, int> dictionary = new Dictionary<int, int>();

        // 2. insert a new (key, value) pair if the key doesn't exist
        if (!dictionary.ContainsKey(0)) dictionary[0] = 0;
        if (!dictionary.ContainsKey(2)) dictionary[2] = 3;

        // 3. insert or update a (key, value) pair
        dictionary[1] = 1;
        dictionary[1] = 2;

        // 4. get the value of a specific key
        Console.WriteLine("The value of key 1 is: " + dictionary[1]);

        // 5. delete a key
        dictionary.Remove(2);

        // 6. check if a key is in the dictionary
        if (!dictionary.ContainsKey(2))
        {
            Console.WriteLine("Key 2 is not in the dictionary.");
        }

        // 7. get the size of the dictionary
        Console.WriteLine("The size of dictionary is: " + dictionary.Count);

        // 8. iterate the dictionary
        foreach (KeyValuePair<int, int> entry in dictionary)
        {
            Console.Write("(" + entry.Key + "," + entry.Value + ") ");
        }
        Console.WriteLine("are in the dictionary.");

        // 9. clear the dictionary
        dictionary.Clear();

        // 10. check if the dictionary is empty
        if (dictionary.Count == 0)
        {
            Console.WriteLine("Dictionary is empty now!");
        }
    }
}

```

## Scenario I - Provide More Information

The first scenario to use a hash map is that we need more information rather than only the key. Then we can build a mapping relationship between key and information by hash map.

An Example
Let's look at an example:

Given an array of integers, return indices of the two numbers such that they add up to a specific target.

In this example, if we only want to return true if there is a solution, we can use a hash set to store all the values when we iterate the array and check if target - current_value is in the hash set or not.

However, we are asked to return more information which means we not only care about the value but also care about the index. We need to store not only the number as the key but also the index as the value. Therefore, we should use a hash map rather than a hash set.

What's More
In some cases, we need more information not just to return more information but also to help us with our decisions.

In the previous examples, when we meet a duplicated key, we will return the corresponding information immediately. But sometimes, we might want to check if the value of the key is acceptable first.

##   Scenario II - Aggregate by Key

Another frequent scenario is to aggregate all the information by key. We can also use a hash map to achieve this goal.

An Example
Here is an example:

Given a string, find the first non-repeating character in it and return it's index. If it doesn't exist, return -1.

A simple way to solve this problem is to count the occurrence of each character first. And then go through the results to find out the first unique character.

Therefore, we can maintain a hashmap whose key is the character while the value is a counter for the corresponding character. Each time when we iterate a character, we just add the corresponding value by 1.

What's more
The key to solving this kind of problem is to decide your strategy when you encounter an existing key.

In the example above, our strategy is to count the occurrence. Sometimes, we might sum all the values up. And sometimes, we might replace the original value with the newest one. The strategy depends on the problem and practice will help you make a right decision.

Template
Here we provide a template for you to solve this kind of problems:

```cshrp
ReturnType aggregateByKey_hashmap(List<Type> keys) {
    Map<Type, InfoType> hashmap = new HashMap<>();

    for (Type key : keys) {
        if (hashmap.containsKey(key)) {
            // Update existing entry with your logic
            hashmap.put(key, updated_information_based_on(hashmap.get(key)));
        } else {
            // Insert new entry
            hashmap.put(key, initial_value_for(key));
        }
    }

    // Compute and return final result based on the hashmap
    return generateResultFromMap(hashmap);
}
```
## Design the Key

In the previous problems, the choice of key is comparatively straightforward. Unfortunately, sometimes you have to think it over to design a suitable key when using a hash table.

An Example
Let's look at an example:

Given an array of strings, group anagrams together.

As we know, a hash map can perform really well in grouping information by key. But we cannot use the original string as key directly. We have to design a proper key to present the type of anagrams. For instance, there are two strings "eat" and "ate" which should be in the same group. While "eat" and "act" should not be grouped together.

Solution
Actually, designing a key is to build a mapping relationship by yourself between the original information and the actual key used by hash map. When you design a key, you need to guarantee that:

1. All values belong to the same group will be mapped in the same group.

2. Values which needed to be separated into different groups will not be mapped into the same group.

This process is similar to design a hash function, but here is an essential difference. A hash function satisfies the first rule but might not satisfy the second one. But your mapping function should satisfy both of them.

In the example above, our mapping strategy can be: sort the string and use the sorted string as the key. That is to say, both "eat" and "ate" will be mapped to "aet".

The mapping strategy can be really tricky sometimes. We provide some exercise for you in this chapter and will give a summary after that.

## Design the Key - Summary

Here are some takeaways about how to design the key for you.

When the order of each element in the string/array doesn't matter, you can use the sorted string/array as the key.
If you only care about the offset of each value, usually the offset from the first value, you can use the offset as the key.
In a tree, you might want to directly use the TreeNode as key sometimes. But in most cases, the serialization of the subtree might be a better idea.
In a matrix, you might want to use the row index or the column index as key.
In a Sudoku, you can combine the row index and the column index to identify which block this element belongs to.
Sometimes, in a matrix, you might want to aggregate the values in the same diagonal line. 
