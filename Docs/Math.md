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
- $\binom{n}{k}$ is the binomial coefficient.
- $p^k$ is the probability of success for $k$ trials.
- $(1-p)^{n-k}$ is the probability of failure for $n-k$ trials.

Each of these pieces are explained further below.

## Probability Notation
In statistics, probability is frequently expressed as a function of $P$. In the case of binomial distributions, $P(X=k)$ is used to denote the *probability* that of seeing $k$ successes when all of the trials are run. This 
means *any* $k$ trials result in a success. It does not matter which specific trials resulted in a success, only that there were exactly $k$ successes in the trial.

## The Binomial Coefficient
The binomial coefficient is used to represent the possible number of *combinations* of $k$ elements from a set of $n$ elements without regard to the order of selection. This coefficient is expressed in shorthand as $\binom{n}{k}$, and is 
calculated using the equation:

$$\frac{n!}{k!(n-k)!}$$

where 
- $n$ is the total number of objects
- $k$ is the number of objects to select

For example, consider a group of five objects, labeled 1 through 5. The task is to select any two objects from this group of five. How many ways exist to pick two objects from the group? Since the order of picking doesn't 
matter, a fixed number of *combinations* of objects can be selected from the group, as shown below:
 
| Selection 1 | Selection 2 |
|----------|----------|
| Object 1 | Object 2 |
| Object 1 | Object 3 |
| Object 1 | Object 4 |
| Object 1 | Object 5 |
| Object 2 | Object 3 |
| Object 2 | Object 4 |
| Object 2 | Object 5 |
| Object 3 | Object 4 |
| Object 3 | Object 5 |
| Object 4 | Object 5 |

There are 10 possible combinations of two objects that can be made from a group of five. This number of combinations can be determined by using the binomial coefficient equation.

$$\frac{n!}{k!(n-k)!} = \frac{5!}{2!(5-2)!} = 10$$

## Probability of Success
The probability of success for a single trial is expressed as the equation:

$$p^k$$

where
- $p$ is the probability of success for a single trial.
- $k$ is the number of trials.

In the context of dice, there are six possible results for rolling a dice. Because each outcome is equally likely, the probability of any particular result is $\frac{1}{6}$. Each time the die is rolled, the probability of 
rolling the same result is multiplied again by $\frac{1}{6}$. For example, the probability of rolling a 6 on a single die roll is $\frac{1}{6}$, so the probability of rolling a 6 for every roll in five rolls would be 
calculated as:

$$\frac{1}{6} * \frac{1}{6} * \frac{1}{6} * \frac{1}{6} * \frac{1}{6} = \left(\frac{1}{6}\right)^5 = \frac{1}{7776}$$

What if the success case includes more than one result value? In the context of Warhammer, a success may be defined as rolling a 4+ on a dice. This means that a result of 4, 5, or 6 would be considered a success. In this case,
the probabilities of each result can be added together to determine the probability of the success case as a whole. In this case, the probability of rolling a 4, a 5, or a 6 are all 1/6. So the probability of the success case
can be calculated as:

$$p(4, \text{ }5, \text{ or } 6) = \frac{1}{6} + \frac{1}{6} + \frac{1}{6} = \frac{3}{6} = \frac{1}{2}$$

This indicates that the probability of rolling a 4, 5, or 6 is 1/2 or a 50% chance. This makes sense, as half of the results on the dice are considered a successful roll. The probability of rolling a success in all of five 
dice, then would be calculated as:

$$\frac{1}{2} * \frac{1}{2} * \frac{1}{2} * \frac{1}{2} * \frac{1}{2} = \left(\frac{1}{2}\right)^5 = (1/32)$$

This indicates that the chance of succeeding a roll on all five dice, with success being defined as rolling a 4, 5, or 6, is $1/32$ or 3.13%.

 