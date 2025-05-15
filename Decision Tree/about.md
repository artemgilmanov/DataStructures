## Definition 

Decision tree is a popular tool that is widely applied in various domains including operations research, data mining and machine learning. The definition of decision tree varies in different domains. In this card, we focus on the form of decision tree that is applied in the domain of machine learning. More specifically, decision tree can be used to solve the problems of classification and regression in the subdomain of supervised machine learning.

In this card, we elaborate on the decision tree for classification problems. Unless otherwise specified, in the rest of the card, we refer to the decision tree as the one used for classification problems.

A decision tree for classification is a special form of binary tree, which is used as a classifier. There are two types of nodes in decision tree:

leaf node: same as the ones in binary tree, i.e. the node that does not have any child node. 
decision node: the non-leaf node.
Each leaf node contains a label that is assigned to the objects which fall into this leaf node during the inference phase.

For each decision node in the tree, it contains a branching rule that can be expressed in the following form:

```cshrp
if (condition == true) {
    object goes to the left child node;
} else {
    object goes to the right child node;
}
```
where the condition is a testing expression based on the value of certain attribute in the object.

For numerical attributes, the condition takes the form of less-or-equal-than comparison, i.e. "
object.attribute
≤
C
object.attribute≤C". For example, 
object.height
≤
1.7
object.height≤1.7.

For categorical attributes, the condition is expressed as membership to a list of categorical values, i.e. 
object.attribute
∈
{
C
1
,
C
2
,
C
3
.
.
.
}
object.attribute∈{C 
1
​
 ,C 
2
​
 ,C 
3
​
 ...}. For example, 
object.color
∈
{
red, green, yellow
}
object.color∈{red, green, yellow}. 
At each decision node, the branching would be performed according to the predictor, an object would then iteratively be attributed to the nodes along the tree, from top to bottom.

 
## Example
We will show an example of decision tree for a classification problem. First of all, let us introduce the data set called Iris, which is first published in the paper of "The use of multiple measurements in taxonomic problems" - Ronald. A. Fisher (1936) [1]. The Iris data set consists of measurement for 150 samples of iris flower. Each sample contains the measurement for the length and the width of its petal and sepal, and a 'class' attribute that indicates the category of iris flower, namely setosa, versicolor and virginica. Below we show a few samples from the Iris data set.



With the Iris data set, the classification problem that we would like to tack with is to predict the category of iris flower, given a sample with attributes of petal and sepal, i.e. labelling the sample.

Therefore, the desired decision tree model can be defined as the following function 
F
F:

 
F
(
X
)
=
y
,
X
=
[
x
1
,
x
2
,
x
3
,
x
4
]
 
,
 
y
∈
{
virginica
,
setosa
,
versicolor
}
F(X)=y,X=[x 
1
​
 ,x 
2
​
 ,x 
3
​
 ,x 
4
​
 ] , y∈{virginica,setosa,versicolor}

This decision tree takes a vector of four real values, and gives a label as output. And here is what a decision tree might look like:



In the above graph, each node in oval represents a decision node, while each node in box represents a leaf node. As we can see, each decision node in the tree contains a condition to further assign the samples that go through this node. The condition is designed to best split the samples, in a way that all the samples that are assigned to the same child node are more similar to each other, than the samples in the oppose child node. We will discuss more in detail about the criteria how the condition is chosen and calculated in the following articles.

 
## References
- (Fisher,R.A. "The use of multiple measurements in taxonomic problems" Annual Eugenics, 7, Part II, 179-188 (1936))[https://onlinelibrary.wiley.com/doi/abs/10.1111/j.1469-1809.1936.tb02137.x]

## Model Inference - Decision Tree

Now one might wonder how the decision tree works, i.e. how we can apply the decision tree to classify a sample. This step is also called model inference in machine learning. Basically, to apply the decision tree, is to traverse the tree from top to down. At each decision node, we follow the corresponding branch with regards to the result of condition testing. When we reach the leaf node of the tree, we take the label of the leaf node as the classification result for the sample. 

Let us take the first sample from the above table as an example 
X
X, as follows:



We then can break down the steps to apply the decision tree that we gave as an example in the definition article for this particular example 
X
X, in the below graph where we highlight the path in red and denote each step with number. 



 

Starting from the root node with the condition 
{
petal_length
<
=
3.0
}
{petal_length<=3.0}
, by comparing the corresponding attribute in the sample 
X
X with the value on the right hand side of the condition, the test result of the condition turns out to be false. Therefore, we move on to its right child node.

Now we are at the decision node with the condition 
{
petal_length
<
=
4.8
}
{petal_length<=4.8}, similarly by testing the condition, this time we would move on to its left child node. 

Next, at the decision node with the condition 
{
petal_width
<
=
1.7
}
{petal_width<=1.7}, we would then move on to its right child node which turns out to be a leaf node. As a result, by applying the decision tree, we obtain the classification result for the sample 
X
X as 
"virginica"
"virginica", which is indeed the actual category of the sample.
As we can see, the conjunction of conditions along the path also forms a chain of rules, which explains how the label is chosen. This chain of rules serves naturally as the interpretability of the decision tree model, i.e. the reasoning that is comprehensive for humans to understand how the prediction (i.e. decision) is made by the machine. This interpretability is one of the advantages of decision tree model, comparing to the blackbox models such as those neural network based models.

##  Algorithm - Decision Tree

In this article, we explain the algorithm to build a decision tree for classification problems. Here is the overall intuition about the algorithm:

The algorithm to construct a decision tree follows the approach of divide-and-conquer, i.e. we recursivelly splitting the input samples into two subgroups with decision node, until we no longer need to split them. At the end, each of the samples is assigned to a leaf node, and we label the leaf node with the category of the majority samples within the leaf node.

As one can see, we can implement the decision tree construction algorithm by recursion. Given a list of samples with various labels, to construct a decision tree that could assign the sample with a proper label, here are the base cases and the recurrence relation of the recursive algorithm: 

base cases: If the samples are of the same labels, then we do not need to further split the samples. This is the fundamental base case. One can define more base cases in order to regulate the complexity of the final tree.

recurrence relation: We find the most distinguishable feature of the samples and also the best value to split on, in order to obtain two subgroups of samples. We then construct subtrees out of the split subgroups. The criterion to split the samples is twofold: 1). we should reduce the samples into smaller scales in a fast manner, so that we could reduce the occurrence of recursion, i.e. reduce the cost of the algorithm. 2). we should also make sure the split subgroups are more uniform so that it becomes easier to classify the samples. We will discuss more about the criterion in the following articles.
 
Here is an example of pseudo code on how to construct a decision tree.

```cshrp
using System;
using System.Collections.Generic;

public class TreeNode
{
    public string Feature { get; set; }    // Feature to split on (null for leaf nodes)
    public object SplitValue { get; set; } // Value to split on
    public TreeNode Left { get; set; }     // Left child (values <= split value)
    public TreeNode Right { get; set; }    // Right child (values > split value)
    public object Prediction { get; set; } // Prediction for leaf nodes
}

public class DecisionTreeBuilder
{
    private int maxTreeDepth;
    private int minNodeSize;

    public DecisionTreeBuilder(int maxDepth = 10, int minSize = 5)
    {
        maxTreeDepth = maxDepth;
        minNodeSize = minSize;
    }

    public TreeNode BuildDecisionTree(List<Dictionary<string, object>> samples, 
                                    int currentDepth = 0)
    {
        // Base cases
        if (AllSamplesSameTarget(samples) 
        {
            return CreateLeafNode(samples);
        }
        
        if (currentDepth >= maxTreeDepth || samples.Count < minNodeSize)
        {
            return CreateLeafNode(samples);
        }

        // Find best split
        var (feature, value) = FindBestSplit(samples);
        if (feature == null) // No good split found
        {
            return CreateLeafNode(samples);
        }

        // Split samples
        var (leftSamples, rightSamples) = SplitSamples(samples, feature, value);

        // Create decision node
        var node = new TreeNode
        {
            Feature = feature,
            SplitValue = value,
            Left = BuildDecisionTree(leftSamples, currentDepth + 1),
            Right = BuildDecisionTree(rightSamples, currentDepth + 1)
        };

        return node;
    }

    private bool AllSamplesSameTarget(List<Dictionary<string, object>> samples)
    {
        if (samples.Count == 0) return true;
        var firstTarget = samples[0]["target"];
        foreach (var sample in samples)
        {
            if (!sample["target"].Equals(firstTarget))
                return false;
        }
        return true;
    }

    private TreeNode CreateLeafNode(List<Dictionary<string, object>> samples)
    {
        // In a real implementation, you'd calculate the most common target value
        // or average value for regression
        return new TreeNode 
        {
            Prediction = samples.Count > 0 ? samples[0]["target"] : null
        };
    }

    private (string feature, object value) FindBestSplit(List<Dictionary<string, object>> samples)
    {
        // Implementation depends on your data types and splitting criteria
        // This is a simplified placeholder
        double bestGain = -1;
        string bestFeature = null;
        object bestValue = null;

        foreach (var feature in samples[0].Keys)
        {
            if (feature == "target") continue;

            var (value, gain) = FindBestSplitForFeature(samples, feature);
            if (gain > bestGain)
            {
                bestGain = gain;
                bestFeature = feature;
                bestValue = value;
            }
        }

        return (bestFeature, bestValue);
    }

    private (object value, double gain) FindBestSplitForFeature(
        List<Dictionary<string, object>> samples, string feature)
    {
        // Simplified - in practice you'd calculate information gain or Gini impurity
        // This would handle different data types (continuous/discrete) differently
        return (samples[0][feature], 0.5); // Placeholder
    }

    private (List<Dictionary<string, object>> left, 
            List<Dictionary<string, object>> right) SplitSamples(
        List<Dictionary<string, object>> samples, string feature, object value)
    {
        var left = new List<Dictionary<string, object>>();
        var right = new List<Dictionary<string, object>>();

        foreach (var sample in samples)
        {
            if (CompareValues(sample[feature], value) <= 0)
                left.Add(sample);
            else
                right.Add(sample);
        }

        return (left, right);
    }

    private int CompareValues(object a, object b)
    {
        // Implement proper comparison for your data types
        return Comparer<object>.Default.Compare(a, b);
    }
}
```
## Stopping Conditions
A decision tree grows from top to bottom. When it stops growing, a leaf node is added. Here are a few conditions when we stop splitting samples :

All the examples that fall into the current node belong to the same category, i.e. no further classification is needed.

The tree reaches its predefined max_depth.
The number of examples that fall into the current node is less than the predefined minimal_number_of_examples.
The condition (1) is a natural and optimal case to stop adding more nodes, since we achieve our initial goal, i.e. there is no more ambiguity when the samples reach the node. While the conditions of (2) and (3) are more of an intervention to prevent the decision tree from overgrowing itself which leads to the scenario of overfitting. This intervention is also known as regularization in machine learning, which is a measure to prevent the model from overfitting.

## Further Readings
- [1]. Breiman, L. (1984). CART: Classification and Regression Trees. New York: Routledge.
- https://www.taylorfrancis.com/books/mono/10.1201/9781315139470/classification-regression-trees-leo-breiman-jerome-friedman-olshen-charles-stone

## Splitting Criterion
