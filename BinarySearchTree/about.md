## Introduction
A Binary Search Tree is a special form of a binary tree. The value in each node must be greater than (or equal to) any values in its left subtree but less than (or equal to) any values in its right subtree.

We'll go through this definition more specifically in this chapter and provide you some exercise related to the binary search tree.

The goal of this card is to:

Understand the properties of a binary tree;
Be able to do basic operations in a binary search tree;
Understand the concept of a height-balanced binary search tree.

## Definition of the Binary Search Tree

A binary search tree (BST), a special form of a binary tree, satisfies the binary search property:

The value in each node must be greater than (or equal to) any values stored in its left subtree.
The value in each node must be less than (or equal to) any values stored in its right subtree.
 
Here is an example of a BST.

We have exercises for you to validate a BST after this article. You can use the property we mentioned above to determine whether a binary tree is a BST or not.
The recursive thinking we have introduced in the previous chapter might help you with this problem.

Like a normal binary tree, we can traverse a BST in preorder, inorder, postorder or level-order.
However, it is noteworthy that inorder traversal in BST will be in ascending order. Therefore, the inorder traversal is the most frequent used traversal method of a BST.

We also have exercises for you to find the inorder successor in a BST after this article.
Obviously, you can do the inorder traversal to find the inorder successor in a BST.
But please try to apply the property of the BST we have learned to find out a better way to solve this problem.

## Search in a BST - Introduction

BSTs support three main operations: search, insertion and deletion. In this section, we are going to talk about how to search for a specific value in a BST.

According to the property of BST, for each node:

return the node if the target value is equal to the value of the node;
continue searching in the left subtree if the target value is less than the value of the node;
continue searching in the right subtree if the target value is larger than the value of the node.
Let's go through an example: we search for target = 4 in the BST above.

Please implement the search operation by yourself in our following exercise. You can do it recursively or iteratively. 
Try to analyze the time complexity and space complexity as well. We will provide a solution after that.

## Search in a BST - Solution

We provide the recursive and iterative solution for your reference.

Here is a recursive solution:
```cshrp
/**
 * Definition for a binary tree node.
 */
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Solution {
    public TreeNode SearchBST(TreeNode root, int target) {
        if (root == null || root.val == target) {
            return root;
        }

        if (target < root.val) {
            return SearchBST(root.left, target);
        }

        return SearchBST(root.right, target);
    }
}
```

We can also solve this problem iteratively:

```cshrp
/**
 * Definition for a binary tree node.
 */
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Solution {
    public TreeNode SearchBST(TreeNode root, int target) {
        TreeNode cur = root;
        while (cur != null && cur.val != target) {
            if (target < cur.val) {
                cur = cur.left;
            } else {
                cur = cur.right;
            }
        }
        return cur;
    }
}
```

Let's discuss the time complexity and space complexity of the search operation in a BST whose height is h. 
Focus on the recursion solution first. In the worse case, the depth of our recursion is equal to the height of the tree. 
Therefore, the time complexity of the recursion solution is O(h). And taking system stack into consideration, the space complexity should be O(h) in the worst case as well.

What about the iterative solution? The time complexity will be equal to the loop time which is also O(h) while the space complexity is O(1) since we do not need system stack anymore in an iterative solution.

Question: 
If you do not know the height of the BST h but you are given the total number of nodes N of the BST, can you express the time complexity and space complexity using N instead of h?

Hint:
What's the difference of the relationship between N and h in the best case and the relationship in the worst case?

## Insertion in a Binary Search Tree - Introduction

Another common operation in BST is to insert a new node. There are many different strategies for insertion.
We only talk about a typical insertion strategy which minimizes the changes.
The main idea is to find out a proper leaf position for the target node and then insert the node as a leaf.
Therefore, insertion will begin as a search.

Similar to our search strategy, for each node, we will:

search the left or right subtrees according to the relation of the value of the node and the value of our target node;
repeat STEP 1 until reaching an external node;
add the new node as its left or right child depending on the relation of the value of the node and the value of our target node.
In this way, we add a new node and maintain the property of BST.

Let's go through an example:

Current
1 / 20
Similar to search, we can do insertion recursively or iteratively. 
The solution is so similar with search that you should be able to implement it by yourself and analyze the time complexity and space complexity in the same way.

## Insertion in a BST - Solution

Insertion in a BST is quite similar with search in a BST. Here we only provide recursive solution in Java and C++ for your reference.

```cshrp
/**
 * Definition for a binary tree node.
 */
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Solution {
    public TreeNode InsertIntoBST(TreeNode root, int val) {
        if (root == null) {
            return new TreeNode(val); // return a new node if root is null
        }
        if (root.val < val) {         // insert to the right subtree if val > root.val
            root.right = InsertIntoBST(root.right, val);
        } else {                      // insert to the left subtree if val <= root.val
            root.left = InsertIntoBST(root.left, val);
        }
        return root;
    }
}
```
The time complexity of the insertion operation is the same with search operation which is O(h). Or O(N) in the worst case and O(logN) ideally if the tree is well organized.

The space complexity of the recursion soultion is O(h) as well. 
In other word, O(N) in the worst case and O(logN) ideally. If you implement the algorithm iteratively, the space complexity can be O(1).

## Deletion in a BST - Introduction

Deletion is more complicated than the two operations we mentioned before.
There are also many different strategies for deletion. We are going to introduce one of them which minimizes the changes. 
Our solution is to replace the target node with a proper child. According to the number of its children, we should consider three different cases:

1. If the target node has no child, we can simply remove the node.
2. If the target node has one child, we can use its child to replace itself.
3. If the target node has two children, replace the node with its in-order successor or predecessor node and delete that node.
 

Here are examples of different cases to help you understand this strategy.

By understanding the strategy above, you should be able to implement deletion function on your own. 
We have done an exercise about finding the inorder successor in a BST in the previous section.
The solution for that question might help you implement the deletion function.

## Deletion operation is a little more complicated. we also provide c++ and java codes for your reference.

For the implementation above, similar to the recursion solution of the search operation, the time complexity is O(h) in the worst case. 
And according to the depth of recursion, the space complexity is also O(h) in the worst case.

We can also represent the complexity using the total number of nodes N. 
The time complexity and space complexity will be O(logN) in the best case but O(N) in the worse case.

If you can try to implement the strategy iteratively, you will reduce the space complexity to O(1).

## Introduction to Binary Search Tree - Conclusion

We have introduced the properties of a BST and how to perform the basic operations, including search, insertion and deletion, in a BST. 
Being familiar with these basic ideas, you will be able to apply a BST to solve a real problem.

The strength of a BST is that you can perform all search, insertion and deletion operations in O(h) time complexity even in the worst case.

Usually, if you want to store data in order and need several operations, such as search, insertion or deletion, at the same time, a BST might be a good choice.

An Example
Problem: Design a class to find the kth largest element in a stream.

A most obvious way to solve this problem is to sort the array in descending order first and then return the kth element in the array.

But we have to sort for the new element everytime when we insert a new value in order to perform the search operation in O(1) time complexity. 
But the time complexity of the insertion operation will be O(N) in average. Therefore, time complexity will be O(N^2) in total.

Since we need insertion and search operations at the same time, what about using a BST to store the values?

As we know, for each node in a BST, all the values in the right subtree are larger than the value of the node itself while all the values in the left subtree are smaller than the value of the node.

In other words, for each node in a BST, if m nodes in the right subtree, the node itself is the m + 1 largest element in the existed array.

Think about the problem by yourself first. 
Feel free to store more than one value in a tree node. You might also want a counter in each node to indicate how many nodes there are in the subtree rooted at this node.

## Kth Largest Element in a Stream - Solution

Problem: Design a class to find the kth largest element in a stream.

We have mentioned the basic idea of the algorithm using the BST in the previous article. Here we provide java and C++ codes for your reference.

```cshrp
public class Node
{
    public Node left;
    public Node right;
    public int val;
    public int cnt;

    public Node(int v, int c)
    {
        left = null;
        right = null;
        val = v;
        cnt = c;
    }
}

public class KthLargest
{
    private Node root;
    private int m_k;

    public KthLargest(int k, int[] nums)
    {
        root = null;
        foreach (int num in nums)
        {
            root = InsertNode(root, num);
        }
        m_k = k;
    }

    public int Add(int val)
    {
        root = InsertNode(root, val);
        return SearchKth(root, m_k);
    }

    private Node InsertNode(Node root, int num)
    {
        if (root == null)
        {
            return new Node(num, 1);
        }

        if (root.val < num)
        {
            root.right = InsertNode(root.right, num);
        }
        else
        {
            root.left = InsertNode(root.left, num);
        }

        root.cnt++;
        return root;
    }

    private int SearchKth(Node root, int k)
    {
        int m = root.right != null ? root.right.cnt : 0;

        if (k == m + 1)
        {
            return root.val;
        }

        if (k <= m)
        {
            return SearchKth(root.right, k);
        }
        else
        {
            return SearchKth(root.left, k - m - 1);
        }
    }
}

```

y using a BST, the time complexity for insertion and search are both O(h). The time complexity of performing all the operations will be O(N*h).
That is, O(N^2) in the worst case and O(NlogN) ideally. 

If the BST is well organized, you can always keep h = logN, where h is the height of the tree and N is the total number of nodes. 
In that case, you can reduce the time complexity of search, insertion and deletion to O(logN) which is really a considerable solution in many cases. 
That's the idea of the height-balanced BST. We will introduce height-balanced BST in later chapters.

As we mentioned before, this algorithm is suitable if we have to handle both insertion and search operations.

##  Introduction to the Height-Balanced BST

In this article, we are going to help you understand the general concept of a balanced BST.

 

What is a Height-Balanced BST?
Terminology used in trees:

Depth of node - the number of edges from the tree's root node to the node
Height of node - the number of edges on the longest path between that node and a leaf
Height of Tree - the height of its root node
A height-balanced (or self-balancing) binary search tree is a binary search tree that automatically keeps its height small in the face of arbitrary item insertions and deletions. That is, the height of a balanced BST with N nodes is always logN. Also, the height of the two subtrees of every node never differs by more than 1.

Why logN?

A binary tree with height h contains at most .
In other word, a binary tree with N nodes and height h: .
That is: .
Here is an example of a normal BST and a height-balanced BST:



Using the definition, we can determine if a BST is height-balanced (Balanced Binary Tree).

As we mentioned before, the height of a balanced BST with N nodes is always logN. We can calculate the total number of nodes and the height of the tree to determine if this BST is a height-balanced BST.

Also, in the definition, we mentioned a property of height-balanced BST: the depth of the two subtrees of every node never differ by more than 1. We can also validate the tree recursively according to this rule.

 

Why Using a Height-Balanced BST?
We have introduced binary search tree and related operations, including search, insertion and deletion in the previous article. When we analyze the time complexity of these operations, it is worth noting that the height of the tree is the most important factor. Taking search operation as an example, if the height of the BST is h, the time complexity will be O(h). The height of the BST really matters.

So let's discuss the relationship between the number of nodes N and the height of the tree h. For a height-balanced BST, as we discussed in the previous section,  . But for a normal BST, in the worst case, it can degenerate into a chain. 

Therefore, the height of a BST with N nodes can vary from logN to N. That is, the time complexity of search operation can vary from logN to N. It is a huge difference in the performance.

Therefore, a height-balanced BST play an important role in improving the performance.

 

How to Implement a Height-Balanced BST?
There are several different implementations for height-balanced BSTs. The details of these implementations are different but they have similar goals:

The data structure should satisfy the binary search property and the height-balanced property.
The data structure should support the basic operations of BST, including search, insertion and deletion within O(logN) time even in worst case.
We provide a list of popular height-balanced BSTs for your reference:

Red-black tree
AVL tree
Splay tree
Treap
We are not going to talk about the details of these implementations in this article series.

 

Practical Application of the Height-balanced BST
The height-balanced BST is widely used in practice since it can provide search, insertion and deletion operations all in O(logN) time complexity.

The most profound use is in set/map. The principle of set and map are similar. We will focus on the set in the following discussion.

Set is another data structure which can store a lot of keys without any particular order or any duplicate elements. 
The basic operations it should support are to insert new elements into the set and to check if an element is in the set or not.

Typically, there are two kinds of sets which are widely used: hash set and tree set.

The tree set, TreeSet in Java or set in C++, is implemented by the height-balanced BST. Therefore, the time complexity of search, insertion and deletion are all O(logN).

The hash set, HashSet in Java or unordered_set in C++, is implemented by hash, but the height-balanced BST also plays an important role in hash set. 
When there are too many elements with the same hash key, it will cost O(N) time complexity to look up for a specific element, where N is the number of elements with the same hash key. 
Typically, the height-balanced BST will be used here to improve the performance from O(N) to O(logN).

The essential difference between the hash set and the tree set is that keys in the tree set are ordered.

Conclusion
A height-balanced BST is a special form of BST which aims at improving the performance. 
The details of implementations are outside the scope of this article series and are not required in most interviews. 
But it is useful to understand the general idea of a height-balanced BST and how height-balanced BSTs can help you in your algorithm designs.

