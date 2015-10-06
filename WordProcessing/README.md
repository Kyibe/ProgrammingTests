# WordProcessing



# Developer Test
Below are two problems for you to solve. We ask you to do what you can in 1 hour but you may take extra time if you wish. If you do not wish to take more than 1 hour then please write comments, notes or pseudo code describing how you would complete the test. We are looking for clean, reusable code that will show us your coding style and how you solve problems. Good Luck.
## Part 1
Write a console program to read in a file (see attached file “fileinput.txt”), count the occurrences of all words used in the input file and output a report to screen in alphabetical order. The report should resemble the following:

|Word     |Count|
|---------|-----|
|a        |40   |
|aardvark |1    |
|antelope |3    |
|be       |6    |
|bee      |3    |
|brown    |4    |


## Part 2
Extend the program to filter the list of words in the input file and output the result to screen. The filter should pass only six letter words that are composed of two concatenated words that are also in the input file.

For example, given the list
al, albums, aver, bar, barely, be, befoul, bums, by, cat, con, convex, ely, foul, here, hereby, jig, jigsaw, or, saw, tail, tailor, vex, we, weaver

The program should return
albums, barely, befoul, convex, hereby, jigsaw, tailor, weaver

Because these are a concatenation of two other strings:
al + bums => albums
bar + ely => barely
be + foul => befoul
con + vex => convex
here + by => hereby
jig + saw => jigsaw
tail + or => tailor
we + aver => weaver
