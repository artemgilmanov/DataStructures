## Machine Learning Model

The term, Machine Learning, often mystifies its nature of computer science, as its name might suggest that the machine is learning as human does, or even better. 

Despite the hope that one day we could have machines that think and learn the way that humans do, machine learning nowadays does not go beyond a computer program that performs the predefined procedures. What distinguishes a machine learning algorithm from a non-machine-learning algorithm, such as a program that controls traffic lights, is its ability to adapt its behaviors to new input. And this adaptation, which seems to have no human intervention, occasionally leads to the impression that the machine is actually learning. However, underneath the machine learning model, this adaptation of behaviors is as rigid as every bit of machine instructions that are programmed by humans. 

So what is a machine learning model ? 

A machine learning algorithm is the process that uncovers the underlying relationship within the data. 

The outcome of a machine learning algorithm is called machine learning model, which can be considered as a function
F, which outputs certain results, when given the input.

Rather than a predefined and fixed function, a machine learning model is derived from historical data. 
Therefore, when fed with different data, the output of machine learning algorithm changes, i.e. the machine learning model changes.

For example, in the scenario of image recognition, one might train a machine learning model to recognize the object in the photos.
In one case, one might feed thousands of images with and without cats to a machine learning algorithm, in order to obtain a model that is capable to tell whether there is a cat in a photo. As a result, the input of the generated model would be a digital photo, and the output is a boolean value indicating the existence of a cat on the photo.

The machine learning model in the above case is a function that maps multiple dimensional pixel values to a binary value. 
Assume that we have a photo of 3 pixels, and the value of each pixel range from 0 to 255. 
Then the mapping space between the input and the output would be (256×256×256)×2, which is around 33 million.
We can convince ourselves that it must be a daunting task to learn this mapping (machine learning model) in a real-world case where a normal photo accounts for millions of pixels and each pixel is composed of three colors (RGB) instead of a single grey color.

The task of machine learning, is to learn the function, from the vast mapping space.

## Supervised VS. Unsupervised

Given a machine learning problem, first of all, one can determine whether it is a supervised or unsupervised problem.

For any machine learning problem, we start from a data set, which consists of a group of samples. Each sample can be represented as a tuple of attributes. 

For example, there is a famous classic data set called Iris, which is first published in the paper of "The use of multiple measurements in taxonomic problems" - Ronald. A. Fisher (1936) [1]. The Iris data set consists of measurement for 150 samples of iris flower. Each sample contains the measurement for the length and the width of its petal and sepal, and a class attribute that indicates the category of iris flower, namely setosa, versicolor and virginica. Here are a few samples of the Iris data set.

### Supervised Learning
In a supervised learning task, the data sample would contain a target attribute y, also known as ground truth.
And the task is to learn a function F, that takes the non-target attributes X and output a value that approximates the target attribute, i.e. F(X)≈y.
The target attribute y serves as a teacher to guide the learning task, since it provides a benchmark on the results of learning.
Hence, the task is called supervised learning. 

In the Iris data set, the class attribute (category of iris flower) can serve as a target attribute. 
The data with a target attribute is often called "labeled" data.
Based on the above definition, for the task of predicting the category of iris flower with the labeled data, one can tell that it is a supervised learning task. 

Unsupervised Learning
In contrary to the supervised learning task, we do not have the ground truth in an unsupervised learning task. 
One is expected to learn the underlying patterns or rules from the data, without having the predefined ground truth as the benchmark.

One might wonder, without the supervision of the ground truth, can we still learn anything?
The answer is yes. Here are a few examples of the unsupervised learning tasks:

Clustering: given a data set, one can cluster the samples into groups, based on the similarities among the samples within the data set. 
For instance, a sample could be a customer profile, with attributes such as the number of items that the customer bought, the time that the customer spent on the shopping site etc. 
One can cluster the customer profiles into groups, based on the similarities of the attributes. 
With the clustered groups, one could devise specific commercial campaigns targeting each group, which might help attract and retain customers. 
Association:  given a data set, the association task is to uncover the hidden association patterns among the attributes of a sample. For instance,  a sample could be a shopping cart of a customer, where each attribute of the sample is a merchandise. 
By looking into the shopping carts, one might discover that customers who bought beers often bought diapers as well, i.e. there is a strong association between the beer and the diaper in the shopping cart.
With this learned insight, the supermarket could rearrange those strongly associated merchandise into the nearby corners, in order to promote the sales of one or another.
 
Semi-supervised Learning
In a scenario where the data set is massive but the labeled sample are few, one might find the application of both supervised and unsupervised learning. 
We can call this task as semi-supervised learning.

In many scenarios, it is prohibitively time-consuming and expensive to collect a large amount of labeled data, which often involves manual efforts. 
It takes two and a half years for a research team from Stanford to curate the famous ImageNet which contains millions of images with thousands of manually labeled categories. 
As a result, it is often the case that one has a large amount of data, yet few of them are accurately "labeled", e.g. videos without category or even a title.

By combining both the supervised and unsupervised learning in a data set with few labels, one could exploit the data set to a better extent and obtain a better result than just applying each of them individually. 

For example, one would like to predict the label of images, but only 10% of the images are labeled.
By applying supervised learning, we train a model with the labeled data, then we apply the model to predict the unlabeled data. It would be hard to convince ourselves that the model would be general enough, after all we learned from only the minority of data set. A better strategy could be to first cluster the images into groups (unsupervised learning), and then apply the supervised learning algorithm on each of the groups individually. 
The unsupervised learning in the first stage could help us to narrow down the scope of learning so that the supervised learning in the second stage could obtain better accuracy.
The process of discovering the latent mapping relationship between millions of pixels and a Yes/No answer, is what we call machine learning, in this case.
Most of the time, what we learn at the end, is an approximation to this underlying relationship. 
Due to its nature of approximation, one should not be disappointed to find that the results of a machine learning model is often not 100% accurate.
Before the wide application of deep learning in 2012, the best machine learning model can only achieve around 75% accuracy in the ImageNet visual recognition challenge.
Till nowadays, still, no machine learning model can claim 100% accuracy, although there are models that make fewer errors (<5%) than humans in this task. 

## Classification VS. Regression

n the previous section, we define a machine learning model as a function F, that takes certain input and generates an output.
Often we further distinguish the machine learning models as classification and regression, based on the type of output values.

If the output of a machine learning model is discrete values, e.g. a boolean value, we then call it a classification model. 
While we call the model that outputs continuous values as regression model.

Classification Model
For example, the model that tells whether a photo contains a cat or not can be considered as a classification model, since we can represent the output with a boolean value.

To be more specific, the input can be represented as a matrix M with dimensions of H×W where H is the height of the photo in pixels and W is the width of the photo.
Each element within the matrix is the grayscale value of each pixel in the photo, i.e. an integer value between [0,255] that indicates the intensity of color.
The expected output of the model would be a binary value [1∣0], indicating whether the photo shows a cat or not. 
To summarize, our cat-photo-recognition model F can be formulated as follows: 
F(M)∈{0,1},whereM[i][j]∈[0,255],0≤i<H,0≤j<W
And the goal of machine learning is to discover a function that is as general as possible, which has a high probability to give the right answer for unseen data.

Regression Model
As for the examples of regression model, one can consider a model that estimates the price of a real estate, given the characteristics such as the surface, the type of real estate (e.g. house, apartment), and of course the location.
In this case, we can consider the expected output as a real value p∈R, therefore it is a regression model. Note, in this example, the raw data that we have is not all numeric, but certain of them are categorical, such as the type of real estate. This is often the case in real-world problems. 

For each real estate that is under consideration, we can represent its characteristics as a tuple T, where each element within the tuple is either a numeric value, or a categorical value that represents one of its attributes. 
The elements are also called features in many cases. To summarize, we can formulate our real-estate-price-estimation model as follows: F(T)=p,where p∈R

To be more specific, let's consider a real estate with the following features:
surface = 120 m2,  type = ' apartment', location = ' NY downtown', year_of_construction = 2000

Now given the above features, if our model F gives a value like 10,000$, then most likely that our model is not a good fit for the problem. 

As an example, in the following graph, we show a regression model with the surface of the estate as the only variable, and the price of the estate as the output.   

Speaking of features, we would also like to mention that some of the machine learning models (e.g. decision tree) can handle directly the non-numeric feature as it is, while more often one has to transform those non-numeric features into numeric one way or another.
 
Problem Conversion
Given a real-world problem, sometimes one can easily formulate it and quickly attribute it to either a classification or regression problem. However, sometimes the boundary between these two models is not clear, and one can transform a classification problem into a regression problem, and vice versa. 

In the above example of real estate price estimation, it seems difficult to predict the exact price of a real estate. 
However, if we reformulate the problem as predicting the price range of real estate instead of a single price tag, then we could expect to obtain a more robust model.
As a result, we transform the problem into a classification problem, instead of regression.

As to our cat-photo-recognition model, we can also transform it from classification to regression.
Instead of giving a binary value as the output, we could define a model to give a probability value [0,100%] on whether the photo shows a cat.
In this way, one can compare the nuance between models and further tune the models.
For instance, for a photo with a cat, a model A gives the probability 1%, while model B gives the probability 49% for the same photo.
Although both models fail to give the right answer, one can tell that model B is closer to the truth. In this scenario, one often applies one of the machine learning models called Logistic Regression, which gives continuous probability values as output, but it is served to solve the classification problem.

## Data, Data, Data !

The ultimate goal of the machine learning workflow is to build a machine learning model.
We obtain the model from the data. As a result, it is the data that determines the upper bound of performance that the model can achieve. 
There are numerous models that can fit a specific data. 
The best that we can do, is to find a model that can approach the most to the upper bound set by the data. 
We cannot really expect that a model can learn something else out of the scope of data.

Rule of thumb: garbage in, garbage out.

It might be appropriate to illustrate the above point with the parable of the blind men and an elephant.
The story goes like this, a group of blind men, who have never come across an elephant before, would like to learn and conceptualize what an elephant is like by touching it. 
Each man touches a part of the body, such as leg, tusk or tail etc. While each of them got a part of the reality, none of them has the whole picture of an elephant.
Therefore, none of them actually learned the true image of an elephant.



Now, back to our machine learning task, the training data we got could be those images of legs or tusks from an elephant, while during the test processing, the testing data we got are the full portraits of elephants. 
It would not be surprising to find out that our trained model does not perform well in this case, since we do not have the high-quality training data that is closer to the reality in the first place. 

One might wonder that if the data is really important, then why not feeding the "high-quality" data such as full portraits of elephants into the algorithm, instead of snapshots on parts of the elephant body. Because, facing a problem, we or the machine, like the "blind-men", often struggle to gather the data that captures the essential characteristics of the problem, either due to the technical issues (e.g. data privacy) or simply because we do not perceive the problem in the right way. 

In the real world, the data we got reflects a part of reality in a favorable case, or it could be some noise in a less favorable case, or in the worst case, even a contradiction to the reality. Regardless of the machine learning algorithms, one would not be able to learn anything from data that contains too much noise or is too inconsistent with the reality.

## Machine Learning Workflow

