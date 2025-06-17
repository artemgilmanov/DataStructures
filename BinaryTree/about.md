## Traverse a Tree - Introduction

### Pre-order Traversal
Pre-order traversal is to visit the root first. Then traverse the left subtree. Finally, traverse the right subtree. Here is an example:

Note: in the following animation, the highlighting in red indicates that we return from the visit of the node. The order of the visit is indicated on the array right below the binary tree.

### In-order Traversal
In-order traversal is to traverse the left subtree first. Then visit the root. Finally, traverse the right subtree.

Typically, for binary search tree, we can retrieve all the data in sorted order using in-order traversal. We will mention that again in another card(Introduction to Data Structure - Binary Search Tree).

Post-order Traversal
Post-order traversal is to traverse the left subtree first. Then traverse the right subtree. Finally, visit the root.

It is worth noting that when you delete nodes in a tree, deletion process will be in post-order. That is to say, when you delete a node, you will delete its left child and its right child before you delete the node itself.

Also, post-order is widely used in mathematical expressions. It is easier to write a program to parse a post-order expression.

You can easily figure out the original expression using the inorder traversal. However, it is not easy for a program to handle this expression since you have to check the priorities of operations.

If you handle this tree in postorder, you can easily handle the expression using a stack. Each time when you meet a operator, you can just pop 2 elements from the stack, calculate the result and push the result back into the stack.

Recursive or Iterative
Try to practice the three different traversal methods in our after-article exercise. You might want to implement the methods recursively or iteratively. Implement both recursion and iteration solutions and compare the differences between them.

## Binary Tree Traversal - Solution

In this article, we will provide the recursive solution for the three traversal methods we have mentioned. And talk about the implementation of the iterative solution. Finally, we will discuss the difference between them.

### Pre-order Traversal - Recursive Solution

```cshrp
using System;
using System.Collections.Generic;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution 
{
    private void PreorderTraversal(TreeNode root, List<int> answer) 
    {
        if (root == null) 
        {
            return;
        }
        answer.Add(root.val);                   // visit the root
        PreorderTraversal(root.left, answer);   // traverse left subtree
        PreorderTraversal(root.right, answer);  // traverse right subtree
    }
    
    public IList<int> PreorderTraversal(TreeNode root) 
    {
        List<int> answer = new List<int>();
        PreorderTraversal(root, answer);
        return answer;
    }
}

// Usage Example
public class Program
{
    public static void Main()
    {
        // Create a sample binary tree
        //       1
        //      / \
        //     2   3
        //    / \
        //   4   5
        TreeNode root = new TreeNode(1)
        {
            left = new TreeNode(2)
            {
                left = new TreeNode(4),
                right = new TreeNode(5)
            },
            right = new TreeNode(3)
        };
        
        Solution solution = new Solution();
        IList<int> result = solution.PreorderTraversal(root);
        
        Console.WriteLine("Preorder Traversal:");
        Console.WriteLine(string.Join(", ", result)); // Output: 1, 2, 4, 5, 3
    }
}
```
### In-order Traversal - Recursive Solution

```cshrp
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    private void InorderTraversal(TreeNode root, IList<int> answer) {
        if (root == null) {
            return;
        }
        InorderTraversal(root.left, answer);   // traverse left subtree
        answer.Add(root.val);                  // visit the root
        InorderTraversal(root.right, answer); // traverse right subtree
    }
    
    public IList<int> InorderTraversal(TreeNode root) {
        IList<int> answer = new List<int>();
        InorderTraversal(root, answer);
        return answer;
    }
}
```

### Post-order Traversal - Recursive Solution

```cshrp
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    private void PostorderTraversal(TreeNode root, IList<int> answer) {
        if (root == null) {
            return;
        }
        PostorderTraversal(root.left, answer);   // traverse left subtree
        PostorderTraversal(root.right, answer);  // traverse right subtree
        answer.Add(root.val);                     // visit the root
    }
    
    public IList<int> PostorderTraversal(TreeNode root) {
        IList<int> answer = new List<int>();
        PostorderTraversal(root, answer);
        return answer;
    }
}
```

### Iterative Solution
There are several iterative solutions for tree traversal. One of the solutions is to use a stack to simulate the recursion process.

Taking pre-order traversal as an example, in each iteration, we pop one node from the stack and visit this node. Then if this node has a right child, push its right child into the stack. If this node has a left child, push its left child into the stack. It is noteworthy that we push the right child first so that we can visit the left child first since the nature of the stack is LIFO(last in first out). After that, we can continue to the next iteration until the stack is empty.

```cshrp
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public IList<int> PreorderTraversal(TreeNode root) {
        IList<int> answer = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        
        if (root != null) {
            stack.Push(root);
        }
        
        while (stack.Count > 0) {
            TreeNode current = stack.Pop();
            answer.Add(current.val);            // visit the root
            
            // Push right child first so that left is processed first (LIFO)
            if (current.right != null) {
                stack.Push(current.right);     // push right child to stack if not null
            }
            if (current.left != null) {
                stack.Push(current.left);       // push left child to stack if not null
            }
        }
        
        return answer;
    }
}
```
### Complexity Analysis
As we mentioned before, we can traverse a tree recursively to retrieve all the data in pre-order, in-order or post-order. The time complexity is O(N) because we visit each node exactly once. And the depth of the tree might be N in the worst case. That is to say, the level of recursion might be at most N in the worst case. Therefore, taking system stack into consideration, the space complexity is O(N) as well.

To be cautious, the complexity might be different due to a different implementation. It is comparatively easy to do traversal recursively but when the depth of the tree is too large, we might suffer from stack overflow problem. That's one of the main reasons why we want to solve this problem iteratively sometimes. 

For the iterative solution, the time complexity is apparently the same with recursion solution which is O(N). The space complexity is also O(N) since in the worst case, we will have all the nodes in the stack. There are some other solutions for iterative traversal which can reduce the space complexity to O(1).

## Level-order Traversal - Introduction
