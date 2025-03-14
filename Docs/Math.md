# The Math
This project makes extensive use of statistics to predict and project results of die rolls, and determine the results of combat under various conditions.

# Binomial Distribution
The core mathematical concept used is the binomial distribution. binomial distribution is a probability distribution that summarizes the likelihood that a given number of successes will occur in a fixed number of trials, 
assuming that each trial has exactly two outcomes: success or failure. The binomial distribution also assumes that each trial is independent, that is, that the success or failure of any single triea does not affect the success 
or failure of any other trial. For example, in the context of this project, a trial would be the roll of a single die. Since a die roll has six possible outcomes, we have to define which outcome(s) are considered success, and 
which are failure. In Warhammer, success is typically defined as rolling a specified value or higher. If the success case is defined as rolling a 3+, then rolling any of the values 3, 4, 5, or 6 is considered a success, and 
rolling a 1 or 2 is considered a failure. Each die roll is independent. The result of rolling any one die does not affect the result of any other die.

The binomial distribution of a fixed number of trials is expressed by the following equation:

$$P(X = k) = \binom{n}{k} p^k (1-p)^{n-k}$$

where:

- $P(X = k)$ is the probability of getting exactly $k$ successes.
- $\binom{n}{k}$ is the binomial coefficient, calculated as $\frac{n!}{k!(n-k)!}$.
- $p^k$ is the probability of success raised to the power of $k$.
- $(1-p)^{n-k}$ is the probability of failure raised to the power of $n-k$.

Each of these pieces are explained further below.

# Probability Notation
In statistics, probability is frequently expressed as a function of $P$. In the case of binomial distributions, $P(X=k)$ is used to denote the *probability* that of seeing $k$ successes when all of the trials are run. This 
means *any* $k$ trials result in a success. It does not matter which specific trials resulted in a success, only that there were exactly $k$ successes in the trial.

# The Binomial coefficient
The binomial coefficient represents the number of different ways to choose $k$ elements from a set of $n$ elements without regard to the order of selection. For example, let's say we have a group of five objects, these objects are labeled 1 through 5.
We need to select any two objects from this group of five. How many ways are there to pick two objects from the group? Since the order of picking doesn't matter, there are a fixed number of *combinations* of objects that can be
selected from the group, as shown below:
 
| Selection 1 | Selection 2 |
|----------|----------|
| Object 1 | Object 3 |
| Object 1 | Object 4 |
| Object 1 | Object 5 |
| Object 2 | Object 3 |
| Object 2 | Object 4 |
| Object 2 | Object 5 |
| Object 3 | Object 4 |
| Object 3 | Object 5 |
| Object 4 | Object 5 |

There are ten possible combinations of two objects to be made from a group of five. This number of combinations can be determined by using the binomial coefficient equation.

$$\frac{n!}{k!(n-k)!}$$

where 
- $n$ is the total number of objects
- $k$ is the number of objects to select

so

$$\frac{n!}{k!(n-k)!} = \frac{5!}{2!(5-2)!} = 10$$
 