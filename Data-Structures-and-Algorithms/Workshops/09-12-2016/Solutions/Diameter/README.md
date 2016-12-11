# Diameter

## Description

A tree structure consisted of **N** nodes is given. Nodes are numbered **from 0 to N-1**.
The length of a path between two edges is the sum of the lengths of all the edges between them. Find the length of the longest path in the tree.

## Input
- **N** is read from the first line
- From each of the next **N - 1** lines an edge is given as 3 numbers separated by spaces
  - The first two numbers are the numbers of the nodes that the edge connects
  - The third number is the length of the edge

## Output
- Output a number on a single line - the length of the longest path between nodes in the tree

## Constraints
- **1** <= **N** < **50 000**
- Time limit: **0.2 seconds**
- Memory limit: **32 MB**

## Sample test

### Sample test 1

#### Input
```
5
3 4 3
0 3 4
0 2 6
1 4 9
```

#### Output
```
22
```

### Sample test 2

#### Input
```
11
2 7 2
1 7 6
5 1 8
2 8 6
8 6 9
10 5 5
9 1 9
0 10 15
3 1 21
6 4 3
```

#### Output
```
54
```

### Sample test 3

#### Input
```
16
2 3 92
5 2 10
14 3 42
2 4 26
14 12 50
4 6 93
9 6 24
15 14 9
0 2 95
8 0 90
0 13 60
9 10 59
1 0 66
11 12 7
7 10 35
```

#### Output
```
428
```
