<img src="https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png"/>

#### _Telerik Academy Season 2016-2017 Autumn / Data Structures and Algorithms Exam - 4 September 2017_
# K<super>th</super> Frequent Number


## Description

Your task is to write a program that finds the K<super>th</super> most frequent number.

The program should support the following operations:

-   `ADD number`
    -   Adds a number
-   `REMOVE number`
    -   Removes a number
-   `GET position`
    -   Returns the K<super>th</super> most frequent number

For better explanation see the sample tests

## Input

Read the input from the standard input

-   The input reads 4 kinds of commands:
    -   `ADD number` adds `number`
    -   `REMOVE number` tries to remove an occurrence of `number`
    -   `GET position` finds the frequent number at position
        -   If the position is invalid, print error
    -   `END` stops the program
        -   i.e. read commands until `END`

## Output

Print the output on the standard output

-   Print a single line for each command, except `END`

## Constraints
- **See BGcoder for time and memory limits**
- The commands will always be less than 36046

## Sample Tests


<table>
<tr>
<th>Input</th>
<th>Outut</th>
</tr>
<tr>
<td>
<pre><code>ADD 1
ADD 2
ADD 3
ADD 4
ADD 5
GET 1
GET 2
GET 3
GET 4
GET 5
ADD 2
GET 1
GET 2
GET 3
GET 4
GET 5
REMOVE 2
GET 1
GET 2
GET 3
GET 4
GET 5
REMOVE 2
REMOVE 2
GET 1
GET 2
GET 3
GET 4
GET 5
END</code></pre>
</td>
<td>
<pre><code>Ok: 1 added
Ok: 2 added
Ok: 3 added
Ok: 4 added
Ok: 5 added
Ok: Found 1
Ok: Found 2
Ok: Found 3
Ok: Found 4
Ok: Found 5
Ok: 2 added
Ok: Found 2
Ok: Found 1
Ok: Found 3
Ok: Found 4
Ok: Found 5
Ok: Number 2 removed
Ok: Found 1
Ok: Found 2
Ok: Found 3
Ok: Found 4
Ok: Found 5
Ok: Number 2 removed
Error: Number 2 not found
Ok: Found 1
Ok: Found 3
Ok: Found 4
Ok: Found 5
Error: 5 is invalid K
 </code></pre>
</td></tr>

</table>



<table>
<tr>
<th>Input</th>
<th>Outut</th>
</tr>
<tr>
<td>
<pre><code>ADD 5
ADD 4
ADD 3
ADD 2
ADD 1
GET 1
GET 2
GET 3
GET 4
GET 5
ADD 2
GET 1
GET 2
GET 3
GET 4
GET 5
REMOVE 2
GET 1
GET 2
GET 3
GET 4
GET 5
REMOVE 2
REMOVE 2
GET 1
GET 2
GET 3
GET 4
GET 5
END</code></pre>
</td>
<td>
<pre><code>Ok: 5 added
Ok: 4 added
Ok: 3 added
Ok: 2 added
Ok: 1 added
Ok: Found 1
Ok: Found 2
Ok: Found 3
Ok: Found 4
Ok: Found 5
Ok: 2 added
Ok: Found 2
Ok: Found 1
Ok: Found 3
Ok: Found 4
Ok: Found 5
Ok: Number 2 removed
Ok: Found 1
Ok: Found 2
Ok: Found 3
Ok: Found 4
Ok: Found 5
Ok: Number 2 removed
Error: Number 2 not found
Ok: Found 1
Ok: Found 3
Ok: Found 4
Ok: Found 5
Error: 5 is invalid K
 </code></pre>
</td></tr>

</table>






















