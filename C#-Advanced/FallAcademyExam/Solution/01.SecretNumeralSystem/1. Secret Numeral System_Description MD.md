<img src="https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png" />

#### _Telerik Academy Season 2016-2017 / C# Advanced Exam - 07 Dec 2016_

# Task 1: Secret Numeral System

## Description
**Ocek** and **Ikuc** like functional programming. 
One day they decided to invent a secret numeral system, so they can send encoded messages to each other without anyone else understanding them. They're using names of famous functional programmers to represent the digits.
However, the **FBI** caught wind of it and since they know that you know a little bit of programming, your task is to decode the numbers that **Ocek** and **Ikuc** send to each other. 
Thankfully, the **FBI** also provided you with some additional information about their numeral system - below are all the numbers of their numeral system and their values in the decimal numeral system:

| Digit      | Decimal value   |
| ---------- |:---------------:|
| hristo     | 0               |    
| tosho      | 1               |    
| pesho      | 2               |    
| hristofor  | 3               |
| vlad       | 4               |     
| haralampi  | 5               |
| zoro       | 6               |     
| vladimir   | 7               |

### Decoding the messages
- **Ocek** will send **4** numbers in the functional numeral system to **Ikuc**. The **FBI** have deduced that you must find **the product** of the **4** numbers and print it's value in decimal numeral system.

## Input
- On the only input line you will receive the four numbers in the functional numeral system separated by a comma and a space - **`", "`**

## Output
- Output a single line containing a single value - **the product** of the **4** input numbers in the decimal numeral system.

## Constraints
- The input numbers' value will always be between 0 and 2^40, inclusive.

## Sample tests
| Input                                                          | Output           |
|:-------------------------------------------------------------- |:---------------- |
| vladtosho, peshovlad, toshoharalampi, pesho                    | 17160            |
| haralampi, toshohristofor, peshopesho, toshovladimir           | 14850            |
| toshopesho, peshozoro, toshovladvlad, vlad                     | 88000            |
| hristoforzoro, hristoforhristofor, pesho, toshovladharalampi   | 163620           |

## Hints
- **Use only if you're stuck :)**
- The **FBI** figured that their task is a bit hard, so they left you a hint - an array of ASCII character codes in the **base 7** numeral system. If you turn the numbers from **base 7** to **base 10**, take the corresponding ASCII symbols and concatanate them, you get to see the hint :)

```csharp
var hint = new string[]{
    "132", "216", "230", "44", "214", "166", "215", "232", "44", "202", "210",
    "205", "210", "224", "223", "44", "202", "216", "203", "223", "44", "224",
    "206", "210", "223", "44", "215", "225", "214", "203", "222", "166", "213",
    "44", "223", "232", "223", "224", "203", "214", "44", "206", "166", "226",
    "203", "120", "44", "133", "223", "44", "224", "206", "203", "222", "203",
    "44", "166", "215", "44", "166", "220", "220", "222", "216", "220", "222",
    "210", "166", "224", "203", "44", "200", "225", "210", "213", "224", "63",
    "210", "215", "44", "204", "225", "215", "201", "224", "210", "216", "215",
    "166", "213", "210", "224", "232", "120", "16", "13", "146", "224", "222",
    "210", "215", "205", "64", "145", "203", "220", "213", "166", "201", "203",
    "44", "201", "166", "215", "44", "223", "210", "214", "220", "213", "210",
    "204", "232", "44", "224", "206", "210", "215", "205", "223", "44", "166",
    "44", "213", "216", "224", "62", "44", "211", "225", "223", "224", "44",
    "200", "203", "44", "201", "166", "222", "203", "204", "225", "213", "44",
    "210", "215", "44", "230", "206", "166", "224", "44", "216", "222", "202",
    "203", "222", "44", "232", "216", "225", "44", "222", "203", "220", "213",
    "166", "201", "203", "16", "13", "150", "206", "210", "215", "212", "44",
    "166", "200", "216", "225", "224", "44", "224", "206", "203", "44", "202",
    "166", "224", "166", "44", "224", "232", "220", "203", "223", "44", "216",
    "204", "44", "224", "206", "203", "44", "224", "206", "222", "203", "203",
    "44", "215", "225", "214", "200", "203", "222", "223", "44", "166", "215",
    "202", "44", "224", "206", "203", "44", "222", "203", "223", "225", "213",
    "224", "44", "63", "44", "206", "216", "230", "44", "214", "225", "201",
    "206", "44", "210", "223", "44", "101", "163", "103", "66", "44", "60",
    "44", "101", "163", "103", "66", "44", "60", "44", "101", "163", "103",
    "66", "44", "60", "44", "101", "163", "103", "66", "120"
};
```