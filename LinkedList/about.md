## Introduction - Singly Linked List

ach node in a singly-linked list contains not only the value but also a reference field to link to the next node. By this way, the singly-linked list organizes all the nodes in a sequence.

The blue arrows show how nodes in a singly linked list are combined together.

### Node Structure
Here is the typical definition of a node in a singly-linked list:

```cshrp
public class SinglyListNode
{
    public int val;
    public SinglyListNode next;

    public SinglyListNode(int x)
    {
        val = x;
        next = null;
    }
}
```
In most cases, we will use the head node (the first node) to represent the whole list.

### Operations
Unlike the array, we are not able to access a random element in a singly-linked list in constant time. If we want to get the ith element, we have to traverse from the head node one by one. It takes us O(N) time on average to visit an element by index, where N is the length of the linked list.

For instance, in the example above, the head is the node 23. The only way to visit the 3rd node is to use the "next" field of the head node to get to the 2nd node (node 6); Then with the "next" field of node 6, we are able to visit the 3rd node.

You might wonder why the linked list is useful though it has such a bad performance (compared to the array) in accessing data by index. We will introduce the insert and delete operations in next two articles and you will realize the benefit of the linked list.

After that, we provide an exercise for you to design your own singly linked list.

### Add Operation - Singly Linked List

If we want to add a new value after a given node prev, we should: 

Initialize a new node cur with the given value;
Link the "next" field of cur to prev's next node next;
Link the "next" field in prev to cur.
Unlike an array, we don’t need to move all elements past the inserted element. Therefore, you can insert a new node into a linked list in O(1) time complexity if you have a reference to prev, which is very efficient.

An Example

Let's insert a new value 9 after the second node 6.

We will first initialize a new node with value 9. Then link node 9 to node 15. Finally, link node 6 to node 9.

Add a Node at the Beginning
As we know, we use the head node head to represent the whole list.

So it is essential to update head when adding a new node at the beginning of the list.

Initialize a new node cur;
Link the new node to our original head node head.
Assign cur to head.
For example, let's add a new node 9 at the beginning of the list.

We initialize a new node 9 and link node 9 to current head node 23.
Assign node 9 to be our new head.
What about adding a new node at the end of the list? Can we still use similar strategy?

### Delete Operation - Singly Linked List

If we want to delete an existing node cur from the singly linked list, we can do it in two steps:

Find cur's previous node prev and its next node next;
Link prev to cur's next node next.
In our first step, we need to find out prev and next. It is easy to find out next using the reference field of cur. However, we have to traverse the linked list from the head node to find out prev which will take O(N) time on average, where N is the length of the linked list. So the time complexity of deleting a node will be O(N).

The space complexity is O(1) because we only need constant space to store our pointers.

An Example

Let's try to delete node 6 from the singly linked list above.

1. Traverse the linked list from the head until we find the previous node prev which is node 23

2. Link prev (node 23) with next (node 15)

Node 6 is not in our singly linked list now.

Delete the First Node
If we want to delete the first node, the strategy will be a little different.

As we mentioned before, we use the head node head to represent a linked list. Our head is the black node 23 in the example below.

If we want to delete the first node, we can simply assign the next node to head. That is to say, our head will be node 6 after deletion.

The linked list begins at the head node, so node 23 is no longer in our linked list.

What about deleting the last node? Can we still use similar strategy?

### Design Singly Linked List - Solution

Let's briefly review the structure definition of a node in the singly linked list.

```cshrp
public class SinglyListNode
{
    public int val;
    public SinglyListNode next;
    public SinglyListNode(int x)
    {
        val = x;
        next = null;
    }
}
```

### 1. Initiate a new linked list: represent a linked list using the head node.

```cshrp
public class MyLinkedList {
    private SinglyListNode head;

    /** Initialize your data structure here. */
    public MyLinkedList() {
        head = null;
    }
```

### 2. Traverse the linked list to get element by index.

```cshrp
    private SinglyListNode GetNode(int index) {
        SinglyListNode cur = head;
        for (int i = 0; i < index && cur != null; ++i) {
            cur = cur.next;
        }
        return cur;
    }

    private SinglyListNode GetTail() {
        SinglyListNode cur = head;
        while (cur != null && cur.next != null) {
            cur = cur.next;
        }
        return cur;
    }

   public int Get(int index) {
        SinglyListNode cur = GetNode(index);
        return cur == null ? -1 : cur.val;
    }
```

### 3. Add a new node.

```cshrp
  public void AddAtHead(int val) {
        SinglyListNode cur = new SinglyListNode(val);
        cur.next = head;
        head = cur;
    }

   public void AddAtTail(int val) {
        if (head == null) {
            AddAtHead(val);
            return;
        }
        SinglyListNode prev = GetTail();
        SinglyListNode cur = new SinglyListNode(val);
        prev.next = cur;
    }

    public void AddAtIndex(int index, int val) {
        if (index == 0) {
            AddAtHead(val);
            return;
        }
        SinglyListNode prev = GetNode(index - 1);
        if (prev == null) {
            return;
        }
        SinglyListNode cur = new SinglyListNode(val);
        cur.next = prev.next;
        prev.next = cur;
    }
```

It is worth noting that we have to get the (index - 1)th node or the last node before we add the new node (except adding at the head) and it takes O(N) time to get a node by index, where N is the length of the linked list. It is different from adding a new node after a given node.

### 4. Delete a node.


```cshrp
    public void DeleteAtIndex(int index) {
        if (index == 0) {
            if (head != null)
                head = head.next;
            return;
        }

        SinglyListNode prev = GetNode(index - 1);
        if (prev == null || prev.next == null) {
            return;
        }
        prev.next = prev.next.next;
    }
}
```

Similar to the add operation, it takes O(N) time to get the node by the index which is different from deleting a given node. However, even if we already get the node we want to delete, we still have to traverse to get its previous node.

##  Two-Pointer in Linked List

Let's start with a classic problem:

Given a linked list, determine if it has a cycle in it.

You might have come up with the solution using the hash table. But there is a more efficient solution using the two-pointer technique. Try to think it over by yourself before reading the remaining content.

Imagine there are two runners with different speed. If they are running on a straight path, the fast runner will first arrive at the destination. However, if they are running on a circular track, the fast runner will catch up with the slow runner if they keep running.

That's exactly what we will come across using two pointers with different speed in a linked list:

If there is no cycle, the fast pointer will stop at the end of the linked list.
If there is a cycle, the fast pointer will eventually meet with the slow pointer.
So the only remaining problem is:

What should be the proper speed for the two pointers?

It is a safe choice to move the slow pointer one step at a time while moving the fast pointer two steps at a time. For each iteration, the fast pointer will move one extra step. If the length of the cycle is M, after M iterations, the fast pointer will definitely move one more cycle and catch up with the slow pointer.

What about other choices? Do they work? Would they be more efficient?

### Summary - Two-Pointer in Linked List

```cshrp
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public class Solution {
    public bool HasCycle(ListNode head) {
        ListNode slow = head;
        ListNode fast = head;

        while (slow != null && fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast) {
                return true;
            }
        }

        return false;
    }
}
```

#### Tips
It is similar to what we have learned in an array. But it can be trickier and error-prone. There are several things you should pay attention:

1. Always examine if the node is null before you call the next field.

Getting the next node of a null node will cause the null-pointer error. For example, before we run fast = fast.next.next, we need to examine both fast and fast.next is not null.

2. Carefully define the end conditions of your loop.

Run several examples to make sure your end conditions will not result in an endless loop. And you have to take our first tip into consideration when you define your end conditions.

#### Complexity Analysis
It is easy to analyze the space complexity. If you only use pointers without any other extra space, the space complexity will be O(1). However, it is more difficult to analyze the time complexity. In order to get the answer, we need to analyze how many times we will run our loop .

In our previous finding cycle example, let's assume that we move the faster pointer 2 steps each time and move the slower pointer 1 step each time.

If there is no cycle, the fast pointer takes N/2 times to reach the end of the linked list, where N is the length of the linked list.
If there is a cycle, the fast pointer needs M times to catch up the slower pointer, where M is the length of the cycle in the list.
Obviously, M <= N. So we will run the loop up to N times. And for each loop, we only need constant time. So, the time complexity of this algorithm is O(N) in total.

Analyze other problems by yourself to improve your analysis skill. Don't forget to take different conditions into consideration. If it is hard to analyze for all situations, consider the worst one.

## Reverse Linked List

Let's start with a classic problem:

Reverse a singly linked list.

One solution is to iterate the nodes in original order and move them to the head of the list one by one. It seems hard to understand. We will first use an example to go through our algorithm. 

Algorithm Overview
Let's look at an example:

Keep in mind that the black node 23 is our original head node.

1. First, we move the next node of the black node, which is node 6, to the head of the list:

2. Then we move the next node of the black node, which is node 15, to the head of the list:

3. The next node of the black node now is null. So we stop and return our new head node 15.

More
In this algorithm, each node will be moved exactly once.

Therefore, the time complexity is O(N), where N is the length of the linked list. We only use constant extra space so the space complexity is O(1).

This problem is the foundation of many linked-list problems you might come across in your interview. If you are still stuck, our next article will talk more about the implementation details.

There are also many other solutions. You should be familiar with at least one solution and be able to implement it.

### Reverse Linked List - Solution

```cshrp
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public class Solution {
    public ListNode ReverseList(ListNode head) {
        if (head == null) {
            return head;
        }

        ListNode currentHead = head;

        while (head.next != null) {
            ListNode p = head.next;
            head.next = p.next;
            p.next = currentHead;
            currentHead = p;
        }

        return currentHead;
    }
}
```

In this article, we will talk more about details of our algorithm to reverse the linked list.

In the solution we mentioned previously, there are two nodes which we should keep track of: the original head node and the new head node.

Therefore, we need to use two pointers in one linked list at the same time. One pointer head always points at our original head node while another pointer curHead always points at our newest head node.

Let's focus on a single step (the 2nd step in the previous article). Our goal is to move the next node of head, which is 15, to the head of the list.

1. First, we use a temporary pointer p to indicate the next node of the head node. And link the "next" field of head to the "next" field of p.
2. Then, we link the "next" field of p to the curHead.
3. Now our linked list actually looks like the picture below. And we set curHead to be p.

By this way, we successfully move node 15 to the head of the list. And we can repeat this process until the next node of head is null.

## Introduction - Doubly Linked List

We have introduced the singly linked list in previous chapters.

A node in a singly linked list has the value field, and a "next" reference field to link nodes sequentially.

In this article, we will introduce another type of linked list: Doubly Linked List.

Definition
The doubly linked list works in a similar way but has one more reference field which is known as the "prev" field. With this extra field, you are able to know the previous node of the current node.

Let's take a look at an example:
The green arrows indicate how our "prev" field works.
 
Node Structure
Here is a typical definition of the node structure in a doubly linked list:

```cshrp
// Definition for doubly-linked list.
public class DoublyListNode {
    public int val;
    public DoublyListNode next;
    public DoublyListNode prev;

    public DoublyListNode(int x) {
        val = x;
    }
}
```

Similar to the singly linked list, we will use the head node to represent the whole list.

Operations
Similar to a singly linked list, we will introduce how to access data, insert a new node or delete an existing node in a doubly linked list.

We can access data in the same exact way as in a singly linked list:

We are not able to access a random position in constant time.
We have to traverse from the head to get the i-th node we want.
The time complexity in the worse case will be O(N), where N is the length of the linked list.
For addition and deletion, it will be a little more complicated since we need to take care of the "prev" field as well. We will go through these two operations in next two articles.

After that, we provide an exercise for you to redesign the linked list using doubly linked list.

### Add Operation - Doubly Linked List

If we want to insert a new node cur after an existing node prev, we can divide this process into two steps:

link cur with prev and next, where next is the original next node of prev;
re-link the prev and next with cur. 
Similar to the singly linked list, both the time and the space complexity of the add operation are O(1).

An Example

Let's add a new node 9 after the existing node 6:

link cur (node 9) with prev (node 6) and next (node 15)
re-link prev (node 6) and next (node 15) with cur (node 9)
What if we want to insert a new node at the beginning or at the end?

### Delete Operation - Doubly Linked List

If we want to delete an existing node cur from the doubly linked list, we can simply link its previous node prev with its next node next.

Unlike the singly linked list, it is easy to get the previous node in constant time with the "prev" field.

Since we no longer need to traverse the linked list to get the previous node, both the time and space complexity are O(1).

An Example
Our goal is to delete the node 6 from the doubly linked list.
So we link its previous node 23 and its next node 15:
Node 6 is not in our doubly linked list now.
What if we want to delete the first node or the last node?

### Design Doubly Linked List - Solution

Let's briefly review the structure definition of a node in the doubly linked list.

```cshrp
public class DoublyListNode
{
    public int val;
    public DoublyListNode next, prev;

    public DoublyListNode(int x)
    {
        val = x;
    }
}
```

Based on this definition, we are going to give you the solution step by step. The solution for the doubly linked list is similar to the one using singly linked list.

#### 1. Initiate a new linked list: represent a linked list using the head node.
```cshrp
public class MyLinkedList
{
    private DoublyListNode head;

    // Initialize your data structure here
    public MyLinkedList()
    {
        head = null;
    }
}

```

#### 2. Traverse the linked list to get element by index.
```cshrp
public class MyLinkedList
{
    private DoublyListNode head;

    // Initialize your data structure here
    public MyLinkedList()
    {
        head = null;
    }

    // Helper function to return the index-th node
    private DoublyListNode GetNode(int index)
    {
        DoublyListNode cur = head;
        for (int i = 0; i < index && cur != null; ++i)
        {
            cur = cur.next;
        }
        return cur;
    }

    // Helper function to return the last node
    private DoublyListNode GetTail()
    {
        DoublyListNode cur = head;
        while (cur != null && cur.next != null)
        {
            cur = cur.next;
        }
        return cur;
    }

    // Get the value of the index-th node
    public int Get(int index)
    {
        DoublyListNode cur = GetNode(index);
        return cur == null ? -1 : cur.val;
    }
}

```
#### 3. Add a new node.
```cshrp
public class MyLinkedList
{
    private DoublyListNode head;

    // Initialize your data structure here
    public MyLinkedList()
    {
        head = null;
    }

    // Add a node at the head
    public void AddAtHead(int val)
    {
        DoublyListNode cur = new DoublyListNode(val);
        cur.next = head;
        if (head != null)
        {
            head.prev = cur;
        }
        head = cur;
    }

    // Add a node at the tail
    public void AddAtTail(int val)
    {
        if (head == null)
        {
            AddAtHead(val);
            return;
        }
        DoublyListNode prev = GetTail();
        DoublyListNode cur = new DoublyListNode(val);
        prev.next = cur;
        cur.prev = prev;
    }

    // Add a node at index
    public void AddAtIndex(int index, int val)
    {
        if (index == 0)
        {
            AddAtHead(val);
            return;
        }

        DoublyListNode prev = GetNode(index - 1);
        if (prev == null) return;

        DoublyListNode cur = new DoublyListNode(val);
        DoublyListNode next = prev.next;

        cur.prev = prev;
        cur.next = next;
        prev.next = cur;

        if (next != null)
        {
            next.prev = cur;
        }
    }
}

```
Similar to the singly linked list, it takes O(N) time to get a node by index, where N is the length of the linked list. It is different from adding a new node after a given node.

#### 4. Delete a node.
```cshrp
public class MyLinkedList
{
    private DoublyListNode head;

    // Initialize your data structure here
    public MyLinkedList()
    {
        head = null;
    }

    // Delete node at index
    public void DeleteAtIndex(int index)
    {
        DoublyListNode cur = GetNode(index);
        if (cur == null) return;

        DoublyListNode prev = cur.prev;
        DoublyListNode next = cur.next;

        if (prev != null)
        {
            prev.next = next;
        }
        else
        {
            head = next; // deleting the head
        }

        if (next != null)
        {
            next.prev = prev;
        }
    }
}

```

Similar to the add operation, it takes O(N) time to get the node by the index which is different from deleting a given node. However, it is different to the singly linked list. When we get the node we want to delete, we don't need to traverse to get its previous node but using the "prev" field instead.

## Summary - Linked List

Review
Let's briefly review the performance of the singly linked list and doubly linked list.

They are similar in many operations:

Both of them are not able to access the data at a random position in constant time.
Both of them can add a new node after given node or at the beginning of the list in O(1) time.
Both of them can delete the first node in O(1) time.
But it is a little different to delete a given node (including the last node).

In a singly linked list, it is not able to get the previous node of a given node so we have to spend O(N) time to find out the previous node before deleting the given node.
In a doubly-linked list, it will be much easier because we can get the previous node with the "prev" reference field. So we can delete a given node in O(1) time.
 

Comparison
Here we provide a comparison of time complexity between the linked list and the array.

| Access         | by index            | Array | Singly-Linked List | Doubly-Linked List |
|----------------|---------------------|-------|--------------------|--------------------|
|                |                     | O(1)  | O(N)               | O(N)               |
| Add            | before first node   | O(N)  | O(1)               | O(1)               |
|                | after given node    | O(N)  | O(1)               | O(1)               |
|                | after last node     | O(1)  | O(N)               | O(1)               |
| Delete         | the first node      | O(N)  | O(1)               | O(1)               |
|                | a given node        | O(N)  | O(N)               | O(1)               |
|                | the last node       | O(1)  | O(N)               | O(1)               |
| Search         | a given node        | O(N)  | O(N)               | O(N)               |

Note: The given time complexities for the Doubly-Linked List assume that the Doubly-Linked List implementation keeps a reference to the tail node. If a reference to the tail node is not kept, then adding a node after the last node or deleting the last node would also require O(N) time.

After this comparison, it is not difficult to come up with our conclusion:

If you need to add or delete a node frequently, a linked list could be a good choice.

If you need to access an element by index often, an array might be a better choice than a linked list.
