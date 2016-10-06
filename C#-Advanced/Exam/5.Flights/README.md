<img src="https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png" />

#### _Telerik Academy Season 2016-2017 / C# Advanced Exam - 1 June 2016_

# Safe flights

## Description
You just had to know too much, did you? Apparently, you haven't mastered the power of **daInternetO** as well as you thought. Yesterday, your grandparents started to fly regularly between the Antarctic islands. The flight system of Penguin Airlines overloaded. Simultaneous flights between the same islands occurred, which led to your grandma screaming over the phone and

![Plane crash](https://www.taleas.com/static/images/comics/PlaneCrash.png)

There are **N** islands (numbered **from 0 to N-1**). You have a list of all flights that are going to take place. Each flight will be given as pair of numbers (**A** and **B**). This means that there will be a plane which constantly flies from **A** to **B** and back. The flight is safe if there isn't another flight between **A** and **B**.
Your task is to calculate the number of distinct island-to-island routes which are safe to travel.

## Input
- On the first line you will receive an integer **N**
- Each of the next lines will be consisted of two integer numbers (**A** and **B**) separated by a space
  - If both numbers are **-1** then there will be no more flights
  - Otherwise the numbers mean flight from **A** to **B** will occur
- _The input will always be valid and in the described format. There is no need to validate it explicitly._

## Output
- Print an integer number on a single line
  - The number of distinct safe island-to-island routes

## Constraints
- If there are multiple flights from **A** to **B** they are unsafe
- If there is a flight from **A** to **B** and from **B** to **A** both are unsafe
  - **A** != **B** for each flight
- 2 <= **N** <= 10000
- 0 <= **total number of existing flights** <= 15000
- **Time limit: 0.1 s**
- **Memory limit: 32 MB**

## Sample tests

### Sample Test 1

#### Input
```
5
0 4
1 2
4 1
0 1
1 0
1 2
-1 -1
```

#### Output
```
3
```

#### Explanation
```
Safe routes are:
0 <-> 4
4 <-> 1
0 <-> 1
```

Here is an overly descriptive and very colorful diagram of the above example:

<img src="imgs/islands.png" width="50%">

### Sample Test 2

#### Input
```
12
11 7
3 7
2 10
6 8
11 2
2 4
2 10
2 8
10 2
7 6
4 7
4 9
11 2
2 4
4 9
2 4
8 10
7 10
8 3
8 1
4 10
7 8
4 3
10 2
9 4
7 2
2 11
2 3
1 8
8 1
11 10
3 6
2 10
4 9
5 9
2 10
-1 -1
```

#### Output
```
29
```

### Sample Test 3

#### Input
```
14
6 13
2 13
10 1
-1 -1
```

#### Output
```
4
```

#### Explanation
```
Safe routes are:
6 <-> 13
2 <-> 13
2 <-> 6
10 <-> 1
```
