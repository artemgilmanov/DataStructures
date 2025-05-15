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
