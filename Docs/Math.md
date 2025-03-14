# Probability Statistics and Warhammer
This project aims to determine the probability success of combat using the rules of combat in Warhammer 40k. This project will make use of concepts from the probability theory of statistics to perform these evaluations. Combat 
in Warhammer 40k has many influencing parameters that must be input by the user and included in the combat calculation. At it's core, combat is determined using six sided dice to determine outcomes. Each die roll has a discrete 
success/failure case, and is evaluated independently. All calculations in this project will be based on these discrete die rolls, which in the context of statistics are called a *Bernoulli trial* or *Bernoulli experiment*, and 
a sequence of such outcomes is called a *Bernoulli process*.

## Probability of Success in a Single Trial
Statistics is based on probability, expressed as a decimal value, with the highest probability being 1. A probability of 1 represents an event that is guaranteed to occur. In statistics, probability of success in a 
trial is denoted by $p$. Probability can also be expressed as a percent value, with 1 being 100% probability, and all other $p$ values being some probability below 100.

In the context of a single trial, the probability of success can be calculated as:

$$p = \frac{n}{k}$$

where
- $n$ is the total number of possible results
- $k$ is the number of results that are considered a success

In the context of dice, there are 6 possible results for rolling a six-sided dice. Because each outcome is equally likely, the probability of any particular result is:

$$\frac{1}{6} = 0.1666$$

or 16.66%.

What if the success case includes more than one result value? In the context of Warhammer, a success may be defined as rolling a 4+ on a dice. This means that a result of 4, 5, or 6 would be considered a success. In this case,
the probabilities of each possible successful result can be added together to determine the probability of the success case as a whole. In this case, the probability of rolling a 4, a 5, or a 6 are all 1/6. So the probability 
of the entire success case can be calculated as:

$$p(4, \text{ }5, \text{ or } 6) = \frac{1}{6} + \frac{1}{6} + \frac{1}{6} = \frac{3}{6} = \frac{1}{2} = 0.5$$

This indicates that the probability of rolling a 4, 5, or 6 is a 50% chance. This makes sense, as half of the results on the dice are considered a successful roll.

## Probability of Failure in a Single Trial
Probability of failure is defined as the probability that success will *not* occur, and is denoted by $q$.

$$q = 1 - p$$

In the context of dice, if the probability of any one result is $\frac{1}{6}$, then the probability of *failing* to roll any one result is: 

$$q = 1 - p = \left(1 - \frac{1}{6}\right) = \frac{5}{6} = 0.8333$$

or 83.33%.

If the success case includes multiple values, such as rolling a 3+, then the probability of failure can be calculated as:

$$q = 1-p = \left(1- \left(\frac{1}{6} + \frac{1}{6} + \frac{1}{6} + \frac{1}{6}\right)\right) = \left(1- \left(\frac{4}{6}\right)\right) = \frac{2}{6} = 0.3333$$

or 33.33%

## Probability of Success in Multiple Trials
The probability of success in multiple trials is expressed as the equation:

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

## Probability of Failure
The probability of failure for a single trial is calculated the same way as the probability of success, but with some simple arithmetic included to represent all results that are *not* the success result(s).

$$p(\text{failure}) = q^k = (1-p)^k$$

where
- $p$ is the probability of success for a single trial.
- $k$ is the number of trials.
 
Since 1 is the value used to denote 100% probability, the probability of failure can be easily calculated by subtracting the probility of success from 1. From there, the result is multiplied by itself for each trial. For 
example, the probability of rolling a 5+ on all of five dice is calculated as:

$$p(\text{success}) = p^k = \left(\frac{1}{6} + \frac{1}{6}\right)^5 = \left(\frac{2}{6}\right)^5 = \left(\frac{1}{3}\right)^5 = \frac{1}{243}$$

where $p = \frac{1}{3}$ and the chance of succeeding all five die rolls is 0.41%.

Then the $p$ value of success for a single trial can be used to calculate the probability of *not* rolling a 5+ on *any* of the five dice:

$$p(\text{failure}) = (1-p)^k = \left(1-\frac{1}{3}\right)^5 = \left(\frac{2}{3}\right)^5 = \frac{32}{243}$$

So the chance of failure to roll a 5+ on any of the five dice is 13.17%.

Incidentally, since the probablity of *not* rolling a 5+ on five dice is the same as the probability for succeeding to roll a 1, 2, 3, or 4 on all five dice, and can alternatively be calculated as:

$$p(\text{1, 2, 3, 4}) = \left(\frac{1}{6} + \frac{1}{6} + \frac{1}{6} + \frac{1}{6}\right)^5 = \left(\frac{4}{6}\right)^5 = \left(\frac{2}{3}\right)^5 = \frac{}{} = \frac{32}{243}$$

or 0.41%

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

## Probability Mass Function
Remember that the binomial distribution equation is used to determine the probability of getting a specified number of successful results when executing a given number of trials. For example, when rolling five dice, what is the probability of 

- The total number of trials, denoted by $n$.
- The probability of $k$ trials being successful.
- The probability of the remaining trials (denoted by $n-k$) being unsuccessful.
- The binomial coefficient $\binom{n}{k}$, which accounts for all of the different combinations of 

## Binomial Distribution
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

