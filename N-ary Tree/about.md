## Traversal of N-ary Tree

Tree Traversal
A binary tree can be traversed in preorder, inorder, postorder or level-order.
Among these traversal methods, preorder, postorder and level-order traversal are suitable to be extended to an N-ary tree.

Retrospect - Traverse a Binary Tree

Preorder Traversal: Visit the root node, then traverse the left subtree and finally traverse the right subtree.
Inorder Traversal: Traverse the left subtree, then visit the root node and finally traverse the right subtree.
Postorder Traversal: Traverse the left subtree, then traverse the right subtree and finally visit the root node.
Level-order Traversal: Traverse the tree level by level.
Note that here is no standard definition for in-order traversal in n-ary trees. It probably only makes sense for binary trees.
While there are several different possible ways that one could define in-order traversal for n-ary trees, each of those feels a bit odd and unnatural and probably not terribly useful in practice.

To generalize the above to n-ary trees, you simply replace the steps:

Traverse the left subtree.... Traverse the right subtree....

in the above by:

For each child:
      Traverse the subtree rooted at that child by recursively calling the traversal function

We assume that the for-loop will iterate through the children in the order they are found in the data-structure: typically, in left-to-right order, for a diagram such as below.

N-ary Tree Traversal Examples
We will use the following 3-ary tree as example:

1. Preorder Traversal
In an N-ary tree, preorder means visit the root node first and then traverse the subtree rooted at its children one by one.
For instance, the preorder of the 3-ary tree above is: A->B->C->E->F->D->G.

3. Postorder Traversal
In an N-ary tree, postorder means traverse the subtree rooted at its children first and then visit the root node itself.
For instance, the postorder of the 3-ary tree above is: B->E->F->C->G->D->A.

5. Level-order Traversal
Level-order traversal in an N-ary tree is the same with a binary tree.
Typically, when we do breadth-first search in a tree, we will traverse the tree in level order. For instance, the level-order of the 3-ary tree above is: A->B->C->D->E->F->G.

## N-ary Tree Preorder Traversal

Approach 1: Iterations
Algorithm

First of all, here is the definition of the tree Node which we would use in the following implementation.

```cshrp
// Definition for a Node.
public class Node
{
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val, IList<Node> _children)
    {
        val = _val;
        children = _children;
    }
}
```

Let's start from the root and then at each iteration pop the current node out of the stack and push its child nodes. 
In the implemented strategy we push nodes into the output list following the order Top->Bottom and Left->Right, which naturally reproduces preorder traversal.

```cshrp
public class Solution {
    public IList<int> Preorder(Node root) {
        var output = new List<int>();
        if (root == null) return output;

        var stack = new Stack<Node>();
        stack.Push(root);

        while (stack.Count > 0) {
            Node node = stack.Pop();
            output.Add(node.val);

            // Add children in reverse order
            if (node.children != null) {
                for (int i = node.children.Count - 1; i >= 0; i--) {
                    stack.Push(node.children[i]);
                }
            }
        }

        return output;
    }
}

```

### Complexity Analysis

Time complexity: we visit each node exactly once, and for each visit, the complexity of the operation (i.e. appending the child nodes) is proportional to the number of child nodes n (n-ary tree). 
Therefore the overall time complexity is O(N), where N is the number of nodes, i.e. the size of the tree.

Space complexity: depending on the tree structure, we could keep up to the entire tree, therefore, the space complexity is O(N).

## Classical Recursion Solution of N-ary Tree

Classical Recursion Solution

In that article, we focused on binary trees but the idea can also be extended to a N-ary tree.

1. "Top-down" Solution

"Top-down" means that in each recursion level, we will visit the node first to come up with some values, and pass these values to its children when calling the function recursively.

A typical "top-down" recursion function top_down(root, params) works like this:

```cshrp
1. return specific value for null node
2. update the answer if needed                              // answer <-- params
3. for each child node root.children[k]:
4.      ans[k] = top_down(root.children[k], new_params[k])  // new_params <-- root.val, params
5. return the answer if needed                              // answer <-- all ans[k]
```
"Bottom-up" Solution

"Bottom-up" means that in each recursion level, we will firstly call the functions recursively for all the children nodes and then come up with the answer according to the return values and the value of the root node itself.
A typical "bottom-up" recursion function bottom_up(root) works like this:

```cshrp
1. return specific value for null node
2. for each child node root.children[k]:
3.      ans[k] = bottom_up(root.children[k])    // call function recursively for all children
4. return answer                                // answer <- root.val, all ans[k]
```
## Solution: Encode N-ary Tree to Binary Tree

There are a lot of solutions to convert a N-ary tree to a binary tree. We only introduce one classical solution.

The strategy follows two rules:

The left child of each node in the binary tree is the next sibling of the node in the N-ary tree.
The right child of each node in the binary tree is the first child of the node in the N-ary tree.

Using this strategy, you can simply convert a N-ary tree to a binary tree recursively. Also, you can easily recover the N-ary tree from the binary tree you converted.

The recursion recovery strategy for each node is:

Deal with its children recursively.
Add its left child as the next child of its parent if it has a left child.
Add its right child as the first child of the node itself if it has a right child.

Note that there are a lot of different solutions for this problem. Try experimenting in your own way!
