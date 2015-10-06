# Kata

## Q1
Write a program that, when given a list of words separated by spaces, outputs the words in reverse order.

The input may contain multiple lines, consider each line of the input to be a separate set of words, and output each set of words on a new line.

Example input:

Welcome to William Hill 
Enjoy the test

Example output:

Hill William to Welcome
test the Enjoy

## Q2

In the UK there are coins with the following denominations:

1p, 2p, 5p, 10p, 20p, 50p, £1 (100p), £2 (200p)

We can make 3p using the following two distinct combinations:

1p + 1p + 1p
1p + 2p

Write a program that, when given an input Xp, outputs the number of distinct ways Xp can be produced using UK coins. You may expect the input to contain a single number for X on each line. Each type of coin may be used an arbitrary number of times.

Example input:

3
1

Example output:

2
1

## Q3

Write a program that, when given two months, outputs the number of months in between that contain five Sundays.

This is inclusive, for example given an input of “September 2013 December 2013”, your program should consider September, October, November and December 2013.

The dates will be provided as two pairs of months and years separated by spaces, per line, and the input may contain multiple lines.

Example input:

September 2013 December 2013

Example output:

2

## Q4

Given two integers x and y, we can calculate all combinations of x and y when given an upper and lower bound for their values. For example, using 2 and 4 as the lower and upper bounds for x and y gives us the following pairs of x and y: {2,2} {2,3} {2,4} {3,2} {3,3} {3,4} {4,2} {4,3} {4,4} .

For each of these pairs, we can calculate xy.

22 = 4, 23 = 8, 24 = 16, 32 = 9, 33 = 27, 34 = 81, 42 = 16, 43 = 64, 44 = 256

Removing duplicate values, we get:

4, 8, 9, 16, 27, 64, 81, 256

This is 8 distinct terms.

Write a program that, when given two integer bounds as input, outputs the number of distinct values of xy.

You may expect each pair of bounds on a single line, separated by a space. The input may contain multiple lines.

Example input:

2 4

Example output

8
