<img src="https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png" />

#### _Telerik Academy Season 2016-2017 / C# Advanced Exam - 01 June 2016_


# Task 1: CryptoCS

## Description

John and Jane are a simple couple. They want nothing more than to rule the galaxy. To achieve their goal, they need a way to communicate without being understood by anybody else. So they developed a encryption system for transferring important messages between one another.

The encryption system consists of **adding** or **subtracting** numbers from **two different numeral systems**, and print the result in a **third numeral system**.

The **first number is always in 26-based snumeral system**, consisting of the digits `a`, `b`, ..., `y`, `z`:

| Digit | Value |
| ----- | ----- |
| a     | 0     |
| b     | 1     |
| c     | 2     |
| d     | 3     |
| ...   | ....  |
| y     | 24    |
| z     | 25    |

The **second number is always in 7-based numeral system**, consisting of the digits `0`, `1`,`2`,`3`,`4`,`5` and `6`. Each digit in this numeral system has its corresponding value, i.e. the digit `0` has value `0` (you don't say...)

The **result number is always in 9-based numeral system**, consisting of the digits `0`, `1`,`2`,`3`,`4`,`5`, `6`, `7` and `8`. Each digit in this numeral system has its corresponding value, i.e. the digit `2` has value `2` (...)

Your task is to calculate the result of the operation, `+` or `-`

## Example

-   Input:

```cmd
bac (678 in dec)
+
10  (7 in dec)
=
841 (685 in dec)
```

## Input
- On the first line you will receive the first number in **26-based** numeral system
- On the second line you will receive the operation **(subtraction (-) or addition (+))**
- On the third line you will receive the second number in **7-based** numeral system

## Output
-   Print the result of the operation with the provided numbers in **9-based** numeral system

## Constraints

- The input will always be valid and in the described format. There is no need to validate it explicitly.
- The number of digits in any number will always be less or equal to 8192 (2^13)
- The second number will always be smaller or equal than the first
- **Time limit**: **0.5**s
- **Memory limit**: **24** MB

## Sample tests

### Input

```bash
bac
+
10
```

### Output

```bash
841
```

### Input

```bash
xzywvcas
+
66666
```

### Output

```bash
612462321742
```
