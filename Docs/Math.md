# The Math
This project makes extensive use of statistics to predict and project results of die rolls, 
and determine the results of combat under various conditions.

# Binomial Distribution
The core mathematical concept used is the binomial distribution. binomial distribution is a probability 
distribution that summarizes the likelihood that a given number of successes will occur in a fixed number of 
trials, assuming that each trial has exactly two outcomes: success or failure. The binomial distribution also
assumes that each trial is independent, that is, that the success or failure of any single triea does not
affect the success or failure of any other trial. For example, in the context of this project, a trial would 
be the roll of a single die. Since a die roll has six possible outcomes, we have to define which outcome(s) 
are considered success, and which are failure. In Warhammer, success is typically defined as rolling a specified 
value or higher. If the success case is defined as rolling a 3+, then rolling any of the values 3, 4, 5, or 6 is 
considered a success, and rolling a 1 or 2 is considered a failure. Each die roll is independent. The result of
rolling any one die does not affect the result of any other die.

The binomial distribution of a fixed number of trials is expressed by the following equation:

$$ P(X = k) = \binom{n}{k} p^k (1-p)^{n-k} $$

where:

- $$ P(X = k) $$ is the probability of getting exactly \( k \) successes in \( n \) trials.
- $$ \binom{n}{k} $$ is the binomial coefficient, calculated as \( \frac{n!}{k!(n-k)!} \).
- $$ p^k $$ is the probability of success raised to the power of \( k \).
- $$ (1-p)^{n-k} $$ is the probability of failure raised to the power of \( n-k \).