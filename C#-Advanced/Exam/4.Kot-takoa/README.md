<img src="https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png" />

#### _Telerik Academy Season 2016-2017 / C# Advanced Exam - 31 May 2016_

# Task 4: Kot - Takoa

## Description
We all know that life in the Academy is hard. It's even harder when you have a C# exam. And if some of the trainers are in a bad mood and write hard tasks for the students to solve, 
it becomes even harder. But as people say - **"Kot - Takoa"**. Other people from the Academy say **"Obiknoveno fakademiyata takoata e kot"**. That's why you're given some C# **kot**, which you'll have to minify according to the rules described bellow.

## Minification rules

---

- **All unnecessary whitespaces and all new lines should be removed from the code**

- Unminified code:

```cs
var      number   =    3 + 4;
while(true   ) {


}
var koishtebiemsledizpit = "ko     ce                        to";
```

- Minified code:

```cs
var number=3+4;while(true){}var koishtebiemsledizpit="ko     ce                        to";
```

---

- **All single and multiline comments should be removed from the code**

- Unminified code:

```cs
int gosho = 8;
// gosho e poveche ot pesho
var pesho = 5;
/* multi
line
comment */
int ivan = 3;
```

- Minified code:

```cs
int gosho=8;var pesho=5;int ivan=3;
```

---

- **All variable declarations of the same type that are directly one after another should be separated by a comma, instead of being on different lines**

- Unminified code:

```cs
var koftiLiE = true;
int a = 3;
int b = 4;
int c = 5;
var willipass = false;
```

- Minified code:

```cs
var koftiLiE=true;int a=3,b=4,c=5;var willipass=false;
```

## Input
- You will receive an integer **N** on the first line - the counter of the lines of the C# **kot** that you must minify.
- On the next **N** lines each, you will receive a single line of the **kot**.

## Output
- Output a single line - the minified **kot**.

## Constraints
- There will be no code that you can't understand at your current level in C#(if you studied, that is). That means no OOP, lambda expressions, strange data structures, interfaces, LINQ and so on.
- The input **kot** will always be valid C# code that compiles.
  - _Small hint_: If your solution is correct, the output code will also compile.
- There will never be more than 1 variable declaration on a single line.
- Two adjacent variable declaration made with the **var** keyword are not considered of the same type, regardless of their types.
- The input code will never contain verbatim strings(strings starting with **@**) or string literals that contain escape sequences. There won't be any **char** literals in the code.
- The code will contain only declarations of variables of the following primitive types: **bool**, **int**, **char**, **string**, **decimal**. Any variable of other type will be declared with the **var** keyword.
- **N** will always be in the range [1, 200]
- **Some cases test only partial implementations**, you can still score points with a partial implementation, don't give up :) .
- A line of **kot** will never contain more than 500 symbols.
- Memory limit: 16MB
- Time limit: 0.1s

## Sample tests

#### Input

```cs
29
// mnogo pih kogat go pisah tozi kod
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{
    class HJKjksdfg
    {
        // entry point
        static void Main()
        {
            string input = Console.ReadLine();
            string moreInput = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                // i have no idea what this code is doing
                var list = new List<int>();
            }


            Console.WriteLine("Goshe, vzehme li go toq C reshetka?"); /* this needs to be
             deleted */
            Console.WriteLine("Oshte puskam Random.Next na 5-ta zadacha");
        }
    }
}
```

#### Output

```cs
using System;using System.Collections.Generic;using System.Text;namespace ConsoleApplication1{class HJKjksdfg{static void Main(){string input=Console.ReadLine(),moreInput=Console.ReadLine();int n=int.Parse(Console.ReadLine());for(int i=0;i<n;i++){var list=new List<int>();}Console.WriteLine("Goshe, vzehme li go toq C reshetka?");Console.WriteLine("Oshte puskam Random.Next na 5-ta zadacha");}}}
```
