# High-Quality-Code
## Any fool can write code that a computer can understand. Good programmers write code that humans can understand.  
# Keys to being an effective programmer:
  - Maximizing the portion of a program that you can **safely ignore**
    - While working on any one section of code
  - Most practices discussed later propose ways to achieve this important goal
  
Best conventions for writing high quality code

# What is High-Quality Programming Code?
- **High-quality programming code:**
  - Easy to read and understand
    - Easy to modify and maintain
  - Correct behavior in all cases
    - Well tested
  - Well architectured and designed
  - Well documented
    - Self-documenting code
  - Well formatted   

# Software Quality
- **External quality**
  - Does the software behave correctly?
  - Are the produced results correct?
  - Does the software run fast?
  - Is the software UI easy-to-use?v
  - Is the code secure enough?
- **Internal quality**
  - Is the code easy to read and understand?
  - Is the code well structured?
  - Is the code easy to modify?  

- **High-quality programming code**:
  - Strong cohesion at all levels: modules, classes, methods, etc.
    - Single unit is responsible for single task
  - Loose coupling between modules, classes, methods, etc.
    - Units are independent one of another
  - Good formatting
  - Good names for classes, methods, variables, etc.
  - Self-documenting code style
   
# Code Conventions
- **Code conventions** are formal guidelines about the style of the source code:
  - Code formatting conventions
    - Indentation, whitespace, etc.
  - Naming conventions
    - **PascalCase** or **camelCase**, prefixes, suffixes, etc.
  - Best practices
    - Classes, interfaces, enumerations, structures, inheritance, exceptions, properties, events, constructors, fields, operators, etc.  

- Microsoft has official **C#** code conventions
  - Design Guidelines for Developing Class Libraries: http://msdn.microsoft.com/en-us/library/ms229042.aspx
- Semi-official **JavaScript** code conventions
  - http://javascript.crockford.com/code.html, http://google-styleguide.googlecode.com/svn/trunk/javascriptguide.xml
- Large organization follow strict conventions
  - Code conventions can vary in different teams
- High-quality code goes **beyond code conventions**
  - Software quality is a way of thinking!

# Managing Complexity
- **Managing complexity** has central role in software development
  - Minimize the amount of complexity that anyone’s brain has to deal with at a certain time
- Architecture and design challenges
  - Design modules and classes to reduce complexity
- Code construction challenges
  - Apply good software construction practices: classes, methods, variables, naming, statements, error handling, formatting, comments, etc.
   
# Key Characteristics of HQC
- **Correct behavior**
  - Conforming to the requirements
  - Stable, no hangs, no crashes
  - Bug free – works as expected
  - Correct response to incorrect usage
- **Readable** – easy to read
- **Understandable** – self-documenting
- **Maintainable** – easy to modify when required  
- Good **identifiers' names**

  - Good names for variables, constants, methods, parameters, classes, structures, fields, properties, interfaces, structures, enumerations, namespaces,
- High-quality **classes**, interfaces and class hierarchies
  - Good abstraction and encapsulation
  - Simplicity, reusability, minimal complexity
  - Strong cohesion, loose coupling

- High-quality **methods**
  - Reduced complexity, improved readability
  - Good method names and parameter names
  - Strong cohesion, loose coupling
- **Variables**, **data**, **expressions** and **constants**
  - Minimal variable scope, span, live time
  - Simple expressions
  - Correctly used constants
  - Correctly organized data  

- Correctly used **control structures**
  - Simple statements
  - Simple conditional statements and simple conditions
  - Well organized loops without deep nesting
- Good code **formatting**
  - Reflecting the logical structure of the program
  - Good formatting of classes, methods, blocks, whitespace, long lines, alignment, etc.  

- High-quality **documentation** and comments
  - Effective comments
  - Self-documenting code
- **Defensive programming** and exceptions
  - Ubiquitous use of defensive programming
  - Well organized exception handling
- Code tuning and **optimization**
  - Quality code instead of good performance
  - Code performance when required  

- Following the corporate **code conventions**
  - Formatting and style, naming, etc.
  - Domain-specific best practices
- Well **tested** and **reviewed**
  - Testable code
  - Well designed **unit tests**
    - Tests for all scenarios
    - High code coverage
  - Passed code reviews and inspections  

# Code Formatting
## Why do we need it? How can white spaces and parenthesis help us?

```cs
	public   const    string                    FILE_NAME
	="example.bin"  ;  static void Main   (             ){
	FileStream   fs=     new FileStream(FILE_NAME,FileMode
	.   CreateNew)   // Create the writer      for data  .
	;BinaryWriter w=new BinaryWriter     (    fs      );// Write data to                               Test.data.
	for(  int i=0;i<11;i++){w.Write((int)i);}w   .Close();
	fs   .   Close  (  ) // Create the reader    for data.
	;fs=new FileStream(FILE_NAME,FileMode.            Open
	,  FileAccess.Read)     ;BinaryReader                r
	= new BinaryReader(fs);  // Read data from  Test.data.
	 for (int i = 0; i < 11; i++){ Console      .WriteLine
	(r.ReadInt32                                       ())
	;}r       .    Close   (   );  fs .  Close  (  )  ;  }

```

- Good formatting goals
  - To improve code readability
  - To improve code maintainability
- Fundamental principle of code formatting:
  - Any (consistent) formatting style that follows the above principle is good
  - Good formatting don’t affect speed, memory use or other aspects of the program 
  
## Formatting Blocks in C#
- Put **{** and **}** alone on a line under the corresponding parent block
- Indent the block contents by a single [Tab]
  - Visual Studio will replace the [Tab] with 4 spaces
- _Example_:

```cs
if (some condition)
{
    // Block contents indented by a single [Tab]
    // VS will replace the [Tab] with 4 spaces
}
```

## Formatting Blocks in JS
- Put **{** at the end of the block and **}** alone on a line under the corresponding parent block
- Indent the block contents by a single [Tab]
  - [tab] or spaces depends on the team style
- _Example_:

```cs
if (some condition) {
    // Block contents indented by a single [Tab]
    // Choosing between [tab] and spaces depends
    //  on project formatting style
}
```

## Why are Brackets <br /> Obligatory?
```cs
x = 3+4 * 2+7;
```
```cs
x = (3 + 4) * (2 + 7);
```

# Methods
## Empty Lines between Methods
- Use empty line for separation between methods:

```cs
public class Factorial
{
  private static ulong CalcFactorial(uint num)
  {
    	if (num == 0) return 1;
    	else return num * CalcFactorial(num - 1);
  }

  static void Main()
  {
    	ulong factorial = CalcFactorial(5);
			Console.WriteLine(factorial);
  }
}
```

## Methods Indentation
- Methods should be indented with a single [Tab] from the class body
- Methods body should be indented with a single [Tab] as well

```cs
public class Indentation_Example_
{
    private int Zero()
    {
        return 0;
    }
}
```

## Brackets in Methods Declaration
- Brackets in the method declaration should be formatted as follows:

```cs
private static ulong CalcFactorial(uint num)
```

- Don't  use spaces between the brackets:

```cs
private static ulong CalcFactorial ( uint num )
private static ulong CalcFactorial (uint num)
```

- The same applies for **if**-conditions and **for**-loops:

```cs
if (condition) { … }

for (int i = 0; i < 10; i++) { … }
```

## Separating Parameters
- Separate method parameters by comma followed by a space
  - Don't put space before the comma
  - Correct examples:
```cs
private void RegisterUser(string username, string password);
RegisterUser("academy", "s3cr3t!p@ssw0rd");
```

  - Incorrect examples:
```cs
private void RegisterUser(string username,string password)
private void RegisterUser(string username ,string password)
private void RegisterUser(string username , string password)
```


<!-- attr: { showInPresentation:true, hasScriptWrapper:true } -->
## Empty Lines
- Use an empty line to separate logically related sequences of lines:

```cs
private List<Report> PrepareReports()
{
    List<Report> reports = new List<Report>();

    // Create incomes reports
    Report incomesSalesReport = PrepareIncomesSalesReport();
    Report incomesSupportReport = PrepareIncomesSupportReport();
    reports.Add(incomesSalesReport, incomesSupportReport);

    // Create expenses reports
    Report expensesPayrollReport = PrepareExpensesPayrollReport();
    Report expensesMarketingReport = PrepareExpensesMarketingReport();
    reports.Add(expensesPayrollReport, expensesMarketingReport);

    return reports;
}
```
# Formatting Types
- Formatting classes / structures / interfaces / enumerations
  - Indent the class body with a single [Tab]
  - Use the following order of definitions:
    - Constants, delegates, inner types, fields, constructors, properties, methods
    - Static members, public members, protected members,  internal members, private members
  - The above order of definitions is not the only possible correct one

# Formatting Types  <br /> – _Example in C#_

```cs
public class Dog
{
    // Static variables
    public const string SPECIES = "Canis Lupus Familiaris";

		// Instance variables
    private int age;

		// Constructors
    public Dog(string name, int age)
    {
        this.Name = name;
        this.Аge = age;
    }
    
		// Properties
    public string Name { get; set; }

    // Methods
    public void Breath()
    {
        // TODO: breathing process
    }

    public void Bark()
    {
        Console.WriteLine("wow-wow");
    }
}
```

# Formatting Conditional Statements and Loops
- Formatting conditional statements and loops
  - Always use **{ }** block after **if** / **for** / **while**, even when a single operator follows
  - Indent the block body after **if** / **for** / **while**
  - Always put a new line after a **if** / **for** / **while** block!
  - Always put the **{** on the next line (in C#)
  - Always put the **{** on the same line (in JavaScript)
  - Never indent with more than one [Tab]

## Conditional Statements and Loops Formatting <br/> – _Examples in C#_

- Correct examples:
```cs
for (int i = 0; i < 10; i++)
{
    Console.WriteLine("i={0}", i);
}
```

- Incorrect examples:

```cs
for (int i = 0; i < 10; i++)
  Console.WriteLine("i={0}", i);

for (int i = 0; i < 10; i++) Console.WriteLine("i={0}", i);

for (int i = 0; i < 10;) {
    Console.WriteLine("i={0}", i);  i++; Console.WriteLine();
}
```

## Using Empty Lines
- Empty lines are used to separate logically unrelated parts of the source code
  - Don't put empty lines when not needed!

```cs
public static void PrintList(List<int> ints)
{
    Console.Write("{ ");
    foreach (int item in ints)
    {
        Console.Write(item);
        Console.Write(" ");
    }

    Console.WriteLine("}");
}

static void Main()
{
    // …
```   

# Misplaced Empty Lines – _Example_

```cs
for (int i = 0; i < 10;)
{
    Console.WriteLine("i={0}", i);  





		i++;


		Console.WriteLine();
}
```

## Breaking Long Lines
- Break long lines after punctuation
- Indent the second line by single [Tab]
- Do not additionally indent the third line
- _Examples_:

```cs
if (matrix[x, y] == 0 || matrix[x-1, y] == 0 ||
    matrix[x+1, y] == 0 || matrix[x, y-1] == 0 ||
    matrix[x, y+1] == 0)
{ …

public void GetAllAbstractPaintings()
{
	   var paintings = this.Database.Paintings.All()
		 .Where(x => x.PaintingStyle == PaintingStyleType.Abstract)
		 .OrderBy(x => x.Price)
		 .ThenBy(x => x.DateCreated)
		 .Select(x => x.OriginalPaintingPath)
		 .ToList();
}
```  

## Incorrect ways to break long lines (in C#_)

```cs
if (matrix[x, y] == 0 || matrix[x-1, y] ==
  0 || matrix[x+1, y] == 0 || matrix[x,
  y-1] == 0 || matrix[x, y+1] == 0)
{ …
```

```cs
if (matrix[x, y] == 0 || matrix[x-1, y] == 0 ||
      matrix[x+1, y] == 0 || matrix[x, y-1] == 0 ||
      matrix[x, y+1] == 0)
{ …
```

```cs
DictionaryEntry<K, V> newEntry
  = new DictionaryEntry<K, V>(oldEntry
  .Key, oldEntry.Value);
```

## Breaking Long Lines <br/> in C# and JavaScript
- In C# use single [Tab] after breaking a long line:

```cs
if (matrix[x, y] == 0 || matrix[x-1, y] == 0 ||
    matrix[x+1, y] == 0 || matrix[x, y-1] == 0 ||
    matrix[x, y+1] == 0)
{
    matrix[x, y] == 1;
}
```

- In JavaScript use double [Tab] in the carried long lines:

```cs
if (matrix[x, y] == 0 || matrix[x-1, y] == 0 ||
       matrix[x+1, y] == 0 || matrix[x, y-1] == 0 ||
       matrix[x, y+1] == 0) {
    matrix[x, y] == 1;
}
```

# Alignments
- All types of alignments are considered harmful
  - Alignments are hard-to-maintain!
  - Modifying one line of code shouldn’t require modifying several others
- Incorrect examples:  

```cs
public void NotCool()
{
	var student          = new Student("Ivan", "Kolev", 21);
	var studentGrades    = new List<int>() { 2, 3, 4, 5, 6 };
	var school           = new SMG("Kopernik");
	var studenstInSchool = new List<Student>();
}

```

# Naming Identifiers
## Naming Variables, Methods, Classes, Etc.

## General Naming Guidelines
- Always use **English**
  - How will you feel if you read Vietnamese code with variables named in Vietnamese?
  - English is the only language that all software developers speak
- Avoid abbreviations except accepted ones
  - _Example_: **scrpCnt** vs. `scriptsCount`
- Avoid hard-to-pronounce names
  - _Example_: **dtbgRegExPtrn** vs. `dateTimeBulgarianRegExPattern`

## Use Meaningful Names
- Always prefer **meaningful names**
  - Names should answer these questions:
    - **What does this class do? What is the intent of this variable? What is this variable / class used for?**
  - Correct examples:
    - **FactorialCalculator**, **studentsCount**, **Math.PI**, **configFileName**, **CreateReport**
  - Incorrect examples:
    - **k, k2, k3, junk, f33, KJJ, button1, variable, temp, tmp, temp_var, something, someValue**

## Names Should Be Meaningful in Their Context
- Whether a name is meaningful or not depends on its **context** (its enclosing type)
- _Examples_ of meaningful names:
  - **Generate()** in the class **LabyrinthGenerator**
  - **Find(string** **fileName)** in the class **FileFinder**
  - **Deposit(decimal** **amount)** in the class **Account**
- _Examples_ of meaningless names:
  - **Generate()** in the class **Program**
  - **Find(string name)** in the class **Program**
   
## Fake Meaningful Names
- Junior developers often use “**fake**” meaningful names that are in fact meaningless
  - Bad naming examples:
    - **Topic6Exercise12, LoopsExercise12, Problem7, OOPLecture_LastExercise**
  - Yes, **Topic6Exercise12** indicates that this is solution to exercise 12, but what is it about?
    - Sum of numbers or Tetris game?
  - Better naming:
    - **MaximalNumbersSubsequence**

## Naming Classes and Types
- Naming types (classes, structures, etc.)
  - Use **PascalCase** character casing
    - In C#, JavaScript, Java, PHP
  - Correct examples:
    - **RecursiveFactorialCalculator**, **TreeSet**, **XmlDocument**, **IEnumerable**, **Color**, **TreeNode**, **InvalidTransactionException**, **MainForm**
  - Incorrect examples:
    - **recursiveFactorialCalculator, recursive_factorial_calculator,  RECURSIVE_FACTORIAL_CALCULATOR**

## Naming Classes and Structures in C#, JavaScript, C++ and Java
- Use the following formats:
  - [Noun]
  - [Adjective] + [Noun]
- Correct examples:
  - **Student**, **FileSystem**, **BinaryTreeNode**, **Constants**, **MathUtils**, **CheckBox**, **Calendar**
- Incorrect examples:
  - **Move, FindUsers, Fast, ExtremlyFast, Optimize, Check,  FastFindInDatabase**
   
## Naming Interfaces in C&num;
- Following formats are acceptable:
  - '**I**' + [Verb] + '**able**'
  - '**I**' + [Noun], '**I**' + [Adjective] + [Noun]
- Correct examples:
  - **IEnumerable**, **IFormattable**, **IDataReader**,**IList**, **IHttpModule**,**ICommandExecutor**
- Incorrect examples:
  - **List, iFindUsers, IFast, IMemoryOptimize, Optimizer, FastFindInDatabase, CheckBox**

## Naming Interfaces in Java
- Following formats are acceptable:
  - [Verb] + '**able**'
  - [Noun], [Adjective] + [Noun]
- Correct examples:
  - **Serializable** , **Enumerable**, **Comparable**, **Runnable**, **CharSequence**, **OutputStream**
- Incorrect examples:
  - **list, FindUsers, Run, Inumber, OPTIMIZER, IMemoryOptimize, FastFindInDatabase**

## Naming Enumerations in C&num;
- Several formats are acceptable:
  - [Noun] or [Verb] or [Adjective]
- Use the same style for all members
- Correct examples:
  - **enum Day {Monday,** **Tuesday,** **Wednesday,** **…}**, **enum AppState {Running,** **Finished,** **…}**, 	 **enum WindowState {Normal,** **Maximized,** **…}**
- Incorrect examples:
  - **enum Color {red, green, blue, white},enum PAGE_FORMAT {A4, A5, A3, LEGAL, …}**
   
## Naming Enumerations in Java
- Several formats are acceptable:
  - [Noun] or [Verb] or [Adjective]
- Use **PascalCase** for the enumeration		 and  **CAPITALS** for its members
- Correct examples:
  - **enum Suit** **{CLUBS,** **DIAMONDS,** **HEARTS, SPADES}**, **enum Color** **{RED,** **GREEN,** **BLUE,** **…}**
- Incorrect examples:
  - **enum Color {red, green, blue, white},enum PAGE_FORMAT {A4, A5, A3, LEGAL, …}**

## Naming Special Classes
- Attributes
  - Add '**Attribute**' as suffix
  - Correct example: **WebServiceAttribute**
  - Incorrect example: **WebService**
  
- Collection Classes
  - Add '**Collection**' as suffix
  - Correct example: **StringsCollection**
  - Incorrect example: **ListOfStrings**

- Exceptions
  - Add '**Exception**' as suffix
  - Use informative name
  - Correct example: **FileNotFoundException**
  - Incorrect example: **FileNotFoundError**
  
- Delegate Classes
  - Add '**Delegate**' or '**EventHandler**' as suffix
  - Correct example: **DownloadFinishedDelegate**
  - Incorrect example: **akeUpNotification**

## The Length of Class Names
- How **long** could be the name of a class / struct / interface / enum / delegate?
  - The name should be **as long as required**
  - Don't abbreviate the names if this could make them unclear
  - Your IDE has autocomplete, right?
- Correct examples: **FileNotFoundException**, **CustomerSupportNotificationService**
- Incorrect examples: **FNFException, CustSuppNotifSrvc**

## Naming Namespaces in C&num;
- Namespaces naming guidelines
  - Use **PascalCase**
- Following formats are acceptable:
  - **Company** **.** **Product** **.** **Component** **.****…**
  - **Product** **.** **Component** **.****…**
- Correct example:
  - **Telerik.WinControls.GridView**
- Incorrect examples:
  -  **Telerik_WinControlsGridView, Classes**

## Naming Java Packages /JS Namespaces
- Packages naming guidelines
  - Use **camelCase**
- Following formats are acceptable:
  - **com** **.** **company** **.** **product** **.** **component** **.** **…**
  - **product** **.** **component** **.** **…**
- Correct examples:
  - **com.apple.quicktime**, **hibernate.core**
- Incorrect examples:
  - **IBM.DB2.Data, ibm.db2_data, Tetris.UI**

## Naming Project Folders
- Project folders' names should follow the project namespaces / packages
- Correct examples:
  - **com**
    - **apple**
      - **quicktime**
  - **Telerik.WinControls.GridView**
- Incorrect examples:
  - **com_apple_quicktime, quicktime.src**

## Naming Files in C# / Java
- Files with source code should have names matching their content
  - File containing a class **Student** should be named **Student.cs** / **student.java**
-  Correct examples:
  - **StudentDAO.cs**, **Constants.java**, **CryptographyAlgorithms.cs**
- Incorrect examples:
  - **Program.cs, SourceCode.java, _d2.cs, WebApplication1.jsp, Page1.aspx**

## Naming Files in JavaScript
- Use **small letters and hyphens**for JavaScript file names (+ optionally **.min** + version)
  - Put a single library / component in a single file
-  Correct examples:
  - **jquery-1.8.2.min.js**, **widgets.js**, **kendo.common.min.js**, **scriptaculous.js**
- Incorrect examples:
  - **KendoUI.js, jQuery_classes.js, MyAjax.Library.js, jQuery-1.8.2.js**

## Naming .NET Assemblies
- .NET assembly names should follow the root namespace in its class hierarchy
- Correct examples:
  - **Oracle.DataAccess.dll**
  - **Interop.CAPICOM.dll**
  - **Telerik.WinControls.GridView.dll**
- Incorrect examples:
  - **OracleDataAccess.dll**
  - **Telerik_WinControlsGridView.dll**

## Naming JAR Files in Java
- JAR files names should consist of single word or several words separated by hyphen
  - Can contain version information
- Correct examples:
  - **xalan25.jar**
  - **ant-apache-log4j.jar**
- Incorrect examples:
  - **Ant.Apache.Log4J.jar**
  - **Oracle.JDBC.Drivers.jar**

## Naming Applications
- Applications should be named **meaningfully**
  - Use [Noun] or [Adjective] + [Noun]
  - Use **PascalCase**
- Correct examples:
  - **BlogEngine**
  - **NewsAggregatorSerivice**
- Incorrect examples:
  - **ConsoleApplication4, WebSite2**
  - **zadacha_14, online_shop_temp2**

## Naming Methods
- Methods naming guidelines
  - Use meaningful method names
  - Method names should answer the question:
    - **What does this method do?**
  - If you cannot find a good name for a method, think about whether it has a **clear intent**
- Correct examples: **FindStudent**, **LoadReport**, **Sinus**
- Incorrect examples: **Method1, DoSomething, HandleStuff, SampleMethod, DirtyHack**

- Use **PascalCase**  for C# and **camelCase** for JavaScript, PHP and Java
  - _Example_ (C#): **LoadSettings**
  - _Example_ (JS/PHP/Java): **loadSettings**
- Prefer the following formats:
  - [Verb], [Verb] + [Noun],[Verb] + [Adjective] + [Noun]
- Correct examples: **Show**, **LoadSettingsFile**, **FindNodeByPattern**, **ToString**, **PrintList**
- Incorrect examples: **Student, Generator, Counter, White, Approximation, MathUtils**

## Methods Returning a Value
- Methods returning values should **describe the returned value**
- _Examples_:
    - **ConvertMetersToInches**, not MetersInches or Convert or ConvertUnit
    - **Meters2Inches** is still acceptable
    - **CalculateSinus** is good but **Sinus** is still acceptable
  - Ensure that the unit of measure is obvious
    - Prefer **MeasureFontInPixels** to **MeasureFont**

# Single Purpose of All Methods
- Methods should have a **single purpose**!
  - Otherwise they cannot be named well
  - How to name a method that creates annual incomes report, downloads updates from internet and scans the system for viruses?
  - CreateAnnualIncomesReportDownloadUpdatesAndScanForViruses is a nice name, right?
  - `You don't do this! No really! Never!`
- Methods that have multiple purposes (weak cohesion) are hard to be named
  - Need to be refactored instead of named

## Consistency in Methods Naming
- Use **consistent** naming in the entire project
  - **LoadFile**, **LoadImageFromFile**, **LoadSettings**, **LoadFont**, **LoadLibrary**, but not ReadTextFile
- Use consistently the opposites at the same level of abstraction:
  - **LoadLibrary** vs. **UnloadLibrary**, but NOT  FreeHandle
  - **OpenFile** vs. **CloseFile**, but NOT  DeallocateResource
  - **GetName** vs. **SetName**, but NOT  AssignName
   
## The Length of Method Names
- How long could be the name of a method?
  - The name should be **as long as required**
  - Don't abbreviate
  - Your IDE has autocomplete
- Correct examples (C#):
  - **LoadCustomerSupportNotificationService**, **CreateMonthlyAndAnnualIncomesReport**
- Incorrect examples:
  - **LoadCustSuppSrvc, CreateMonthIncReport**

## Naming Method Parameters
- Method parameters names
  - Preferred form: [Noun] or [Adjective] + [Noun]
  - Should be in **camelCase**
  - Should be meaningful
  - Unit of measure should be obvious
- Correct examples: **firstName**, **report**, **speedKmH**, **usersList**, **fontSizeInPixels**, **font**
- Incorrect examples: **p, p1, p2, populate, LastName, last_name, convertImage**

## Naming Variables
- Variable names
  - Should be in **camelCase**
  - Preferred form: **[Noun]** or **[Adjective] + [Noun]**
  - Should explain the purpose of the variable
    - If you can't find good name for a variable check if it has a single purpose
    - `Exception:` variables with very small scope, e.g. the index variable in a 3-lines long for-loop
  - Names should be consistent in the project

## Naming Variables – _Example_
- Correct examples:
  - **firstName**, **report**, **config**, **usersList** , **fontSize**, **maxSpeed**, **font**, **startIndex**, **endIndex**, **charsCount**, **configSettingsXml**, **dbConnection**, **createUserSqlCommand**
- Incorrect examples:
  - **foo, bar, p, p1, p2, populate, LastName, last_name, LAST_NAME, convertImage, moveMargin, MAXSpeed, _firtName, __temp, firstNameMiddleNameAndLastName**

## More about Naming Variables
- The name should address the problem we solve, not to the means used to solve it
  - Prefer nouns from the business domain to computer science terms
- Correct examples:
  - **accounts**, **customers**, **customerAddress**, **accountHolder**, **paymentPlan**, **vipPlayer**
- Incorrect examples:
  - **paymentsPriorityQueue, playersArray, accountsLinkedList, customersHashtable**

## Naming Boolean Variables
- Give to boolean variables names that imply `true` or `false`
- Use positive boolean variable names
  - Incorrect example:
-  Correct examples:
  - **hasPendingPayment**, **customerFound**, **validAddress**, **positiveBalance**, **isPrime**
- Incorrect examples:
  - **notFound, findCustomerById, player, programStop, run, list, isUnsuccessfull**

## Naming Special Variables
- Naming counters
  - Establish a convention, e.g. [Noun] + '**Count**'
  - _Examples_: **ticketsCount**, **customersCount**
- State
  - Establish a convention, e.g. [Noun] + '**State**'
  - _Examples_: **blogParseState**, **threadState**
- Variables with small scope and span
  - E.g. loop counters
  - Short names can be used, e.g. **index**, **i**, **u**

## Temporary Variables
- Do you really think **temporary** variables exist?
  - All variables in the program are temporary because are used temporary only during the program execution, right?
- Temporary variables can always be named better than **temp** or **tmp**:

```cs
// Swap a[i] and a[j]
int temp = a[i]; (why not? int oldValue = a[i];)
a[i] = a[j];
a[j] = temp; (a[j] = oldValue;)
```

## The Length of Variable Names
- How long could be the name of a variable?
  - Depends on the variable scope and live time
  - More "famous" variables should have longer and more descriptive name

## Naming Constants in C&num;
- Use **PascalCase** for **const** fields and **PascalCase** for **readonly**
- Use meaningful names that describe their value
- Correct examples:

```cs
private const int ReadBufferSize = 8192;
public static readonly PageSize DefaultPageSize = PageSize.A4;
private const int FontSizeInPoints = 16;
```

- Incorrect examples:

```cs
public const int MAX = 512; // Max what? Apples or Oranges?
public const int BUF256 = 256; // What about BUF256 = 1024?
public const string GREATER = "&gt;"; // GREATER_HTML_ENTITY
public const int FONT_SIZE = 16; // 16pt or 16px?
public const PageSize PAGE = PageSize.A4; // Maybe PAGE_SIZE?
```

## Naming Constants
- Use **CAPITAL_LETTERS** for JavaScript /Java / PHP / C++ constants
- Use meaningful names
  - Constants should describe their value
- Correct examples:

```cs
public static final int READ_BUFFER_SIZE = 8192;
public static final PageSize DEFAULT_PAGE_SIZE = PageSize.A4;
public static final int FONT_SIZE_IN_POINTS = 16;
```

- Incorrect examples:

```cs
public static final int NAME = "BMW"; // What name? Car name?
public static final int BufSize = 256; // Use CAPITALS
public static final int font_size_pixels = 16; // CAPITALS
```

## Names to Avoid
- Don't use **numbers** in the identifiers names
  - _Example_:
    - **PrintReport** and **PrintReport2**
    - What is the difference?
  - Exceptions:
    - When the number is part of the name itself,e.g. **RS232Port**, **COM3**, **Win32APIFunctions**
- Don't use Cyrillic or letters from other alphabet
  - FindСтудентByName, DisplayΩ2Protein
   
## Never Give Misleading Name!
- Giving a misleading name is even worse than giving a totally unclear name
- _Example_:
  - Consider a method that calculates the sum of all elements in an array
  - Its should be named **Sum** or **CalculateSum**
  - What about naming it **CalculateAverage** or **Max** or **CheckForNegativeNumber**?
  - It's crazy, but be careful with "copy-paste"

## What's Wrong with This Code?

```cs
FileStream fs = new FileStream(FILE_NAME, FileMode.CreateNew);
// Create the writer for data.
BinaryWriter w = new BinaryWriter(fs);
// Write data to Test.data.
for (int i = 0; i < 11; i++)
{
  w.Write( (int) i);
}
w.Close();
fs.Close();
// Create the reader for data.
fs = new FileStream(FILE_NAME, FileMode.Open, FileAccess.Read);
BinaryReader r = new BinaryReader(fs);
// Read data from Test.data.
for (int i = 0; i < 11; i++)
{
  Console.WriteLine(r.ReadInt32());
}
r.Close();
fs.Close();
```

# Code Documentation and Comments in the Program
## Revealing the Secrets of Self-Documenting Code

## What is Project Documentation?
- Consists of documents and information
  - Both inside the source-code and outside
- **External documentation**
  - At a higher level compared to the code
  - Problem definition, requirements, architecture, design, project plans, test plans. etc.
- **Internal documentation**
  - Lower-level – explains a class,method or a piece of code
  
## Programming Style
- Main contributor to code-level documentation
  - The program structure
  - Straight-forward, easy-to-read and easily understandable code
  - Good naming approach
  - Clear layout and formatting
  - Clear abstractions
  - Minimized complexity
  - Loose coupling and strong cohesion

## Bad Comments – _Example_
```cs
public static List<int> FindPrimes(int start, int end)
{
    // Create new list of integers
    List<int> primesList = new List<int>();
    // Perform a loop from start to end
    for (int num = start; num <= end; num++)
    {
        // Declare boolean variable, initially true
        bool prime = true;
        // Perform loop from 2 to sqrt(num)
        for (int div = 2; div <= Math.Sqrt(num); div++)
        {
            // Check if div divides num with no remainder
            if (num % div == 0)
            {
                // We found a divider -> the number is not prime
                prime = false;
                // Exit from the loop
                break;
            }
            // Continue with the next loop value
  }

  // Check if the number is prime
  if (prime)
  {
      // Add the number to the list of primes
      primesList.Add(num);
  }
}

// Return the list of primes
return primesList;
}


```

## Self-Documenting Code – _Example_

```cs
public static List<int> FindPrimes(int start, int end)
{
  List<int> primesList = new List<int>();
  for (int num = start; num <= end; num++)
  {
    bool isPrime = IsPrime(num);
    if (isPrime)
    {
      primesList.Add(num);
    }
  }
  return primesList;
}
```

Good code does not need comments. It is self-explaining.

```cs
private static bool IsPrime(int num)
{
  bool isPrime = true;
  int maxDivider = Math.Sqrt(num);
  for (int div = 2; div <= maxDivider; div++)
  {
    if (num % div == 0)
    {
      // We found a divider -> the number is not prime
      isPrime = false;
      break;
    }
  }
  return isPrime;
}
```
Good methods have good name and are easy to read and understand.
This comment explain non-obvious details. It does not repeat the code.

## Bad Programming Style – _Example_
```cs
for (i = 1; i <= num; i++)
{
    meetsCriteria[i] = true;
}
for (i = 2; i <= num / 2; i++)
{
    j = i + i;
while (j <= num)
{
        meetsCriteria[j] = false;
        j = j + i;
    }
}
for (i = 1; i <= num; i++)
{
    if (meetsCriteria[i])
    {
        Console.WriteLine(i + " meets criteria.");
    }
}
```

Uninformative variable names. Crude layout.

## Good Programming Style – _Example_

```cs
for (primeCandidate = 1; primeCandidate <= num; primeCandidate++)
{
    isPrime[primeCandidate] = true;
}

for (int factor = 2; factor < (num / 2); factor++)
{
    int factorableNumber = factor + factor;
    while (factorableNumber <= num)
    {
        isPrime[factorableNumber] = false;
        factorableNumber = factorableNumber + factor;
    }
}

for (primeCandidate = 1; primeCandidate <= num; primeCandidate++)
{
    if (isPrime[primeCandidate])
    {
        Console.WriteLine(primeCandidate + " is prime.");
    }
}
```

## Self-Documenting Code
- Code that relies on **good programming style**
  - To carry major part of the information intended for the documentation
- Self-documenting code fundamental principles

```
The best documentation is the code itself.
```

```
Make the code self-explainable
and self-documenting, easy to read and understand.
```

```
Do not document bad code, rewrite it!
```

## Self-Documenting Code Checklist
- **Classes**
  - Does the class’s interface present a consistent abstraction?
  - Does the class’s interface make obvious how you should use the class?
  - Is the class well named, and does its name describe its purpose?
  - Can you treat the class as a black box?
  - Do you reuse instead of repeating code?

- **Methods**
  - Does each routine’s name describe exactly what the method does?
  - Does each method perform one well-defined task with minimal dependencies?
  - 
- **Data Names**
  - Are type names descriptive enough to help document data declarations?
  - Are variables used only for the purpose for which they’re named?
  - Does naming conventions distinguish among type names, enumerated types,  named constants, local variables, class variables, and global variables?
  
- **Others**
  - Are data types simple so that they minimize complexity?
  - Are related statements grouped together?
   
# "Everything the Compiler Needs to Know is in the Code!"

## Effective Comments
- Effective comments **do not repeat the code**
  - They explain it at a higher level and reveal non-obvious details
- The best software documentation is the source code itself – keep it clean and readable!
- **Self-documenting code** is self-explainable and does not need comments
  - Simple design, small well named methods, strong cohesion and loose coupling, simple logic, good variable names, good formatting, …

# Effective Comments – Mistakes
- Misleading comments

```cs
// write out the sums 1..n for all n from 1 to num   
current = 1;
previous = 0;
sum = 1;   
for (int i = 0; i < num; i++)
{   
   Console.WriteLine( "Sum = " + sum );   
   sum = current + previous;   
   previous = current;   
   current = sum;
}

```

Can you guess that sum is equal to the ith Fibonacci number?

- Comments repeating the code:

```cs
// set product to "base"
product = base;

// loop from 2 to "num"
for ( int i = 2; i <= num; i++ )
{
   // multiply "base" by "product"  
   product = product * base;
}
Console.WriteLine( "Product = " + product );
```

- Poor coding style:

```cs
// compute the square root of Num using
// the Newton-Raphson approximation
r = num / 2;
while (abs(r - (num/r)) > TOLERANCE)
{
   r = 0.5 * (r + (num/r) );
}
Console.WriteLine( "r = " + r );
```

- Do not comment bad code, rewrite it 
 
# Key Points for Effective Comments
- Use commenting styles that don’t break down or discourage modification

```cs
//  Variable            Meaning
//  --------            -------
//  xPos .............. X coordinate position (in meters)
//  yPos .............. Y coordinate position (in meters)
//  zPos .............. Z coordinate position (in meters)
//  radius ............ The radius of the sphere where the
                        battle ship is located (in meters)
//  distance .......... The distance from the start position
                        (in meters)
```

- The above comments are **unmaintainable**

- Comment the code intent, not implementation details

```cs
// Scan char by char to find the command-word terminator ($)
done = false;
maxLen = inputString.Length;
i = 0;
while (!done && (i < maxLen))
{
  if (inputString[i] == '$')
  {
    done = true;
  }
  else
  {
    i++;
  }
}
```

- Focus your documentation efforts on the code

```cs
// Find the command-word terminator
foundTheTerminator = false;
maxCommandLength = inputString.Length();
testCharPosition = 0;
while (!foundTheTerminator &&
    (testCharPosition < maxCommandLength))
{
  if (inputString[testCharPosition] == COMMAND_WORD_TERMINATOR)
  {
    foundTheTerminator = true;
    terminatorPosition = testCharPosition;
  }
  else
  {
    testCharPosition = testCharPosition + 1;
  }
}
```

Better code &rarr; less comments

- Focus paragraph comments on the **why** rather than the **how**

```cs
// Establish a new account
if (accountType == AccountType.NewAccount)
{
   …
}
```

- Use comments to prepare the reader for what is to follow
- Avoid abbreviations

- Comment anything that gets around an error or an undocumented feature
  - E.g. **//** **This** **is** **workaround** **for** **bug** **#3712**
- Justify violations of good programming style
- Don’t comment tricky code – rewrite it
- Use built-in features for commenting
  - XML comments in C#
  - JavaDoc in Java, …

## General Guidelines for Higher Level Documentation
- Describe the design approach to the class
- Describe limitations, usage assumptions, and so on
- Comment the class interface (public methods / properties / events / constructors)
- Don’t document implementation details in the class interface
- Describe the purpose and contents of each file
- Give the file a name related to its contents

## <a id="xml-docs"></a>C# XML Documentation
- In C# you can document the code by XML tags in special comments
  - Directly in the source code
- For example:

```cs
/// <summary>
/// This class performs an important function.
/// </summary>
public class MyClass { }
```

- The XML doc comments are not **metadata**
  - Not included in the compiled assembly and not accessible through reflection

## XML Documentation Tags
- **&lt;summary>**
  - A summary of the class / method / object
- **&lt;param>**

    `<param name="name">description</param>`
  - Describes one of the parameters for a method
- **&lt;returns>**
  - A description of the returned value
- **&lt;remarks>**
  - Additional information (remarks)

- **&lt;c>** and **&lt;code>**
  - Gives you a way to indicate code
- **&lt;see>** and **&lt;seealso>** and cref
  - Code reference `<seealso cref="TestClass.Main"/>`
- **&lt;exception>**

    `<exception cref="type">description</exception>`
  - Lets you specify which exceptions can be thrown
- All tags: http://msdn.microsoft.com/en-us/library/5ast78ax.aspx

## XML Documentation Example

```cs
/// <summary>
/// The GetZero method. Always returns zero.
/// </summary>
/// <example>  
/// This sample shows how to call the <see cref="GetZero"/> method.
/// <code>
/// class TestClass  
/// {
///     static int Main()  
///     {
///         return GetZero();
///     }
/// }
/// </code>
/// </example>
public static int GetZero()
{
    return 0;
}
```

## C# XML Documentation
- Visual Studio will use the XML documentation for autocomplete
  - Automatically, just use XML docs
- Compiling the XML documentation:
  - Compile with **/doc** the to extract the XML doc into an external XML file
  - Use Sandcastle or other tool to generate CHM / PDF / HTML / other MSDN-style documentation
    - _Example_: http://www.ewoodruff.us/shfbdocs/

# Correct Use of Variables, Data, Expressions and Constants
## Correctly Organizing Data and Expressions

## Initially Assigned <br/> Variables in C&num;
- Static variables
- Instance variables of class instances
- Instance variables of initially assigned struct variables
- Array elements
- Value parameters
- Reference parameters
- Variables declared in a `catch` clause or a `foreach` statement

## Initially Unassigned <br/> Variables in C&num;
- Instance variables of initially unassigned struct variables
- Output parameters
  - Including the `this` variable of struct instance constructors
- Local variables
  - Except those declared in a `catch` clause or a `foreach` statement

## Guidelines for Initializing Variables
- When the problems can happen?
  - The variable has never been assigned a value
  - The value in the variable is outdated
  - Part of the variable has been assigned a value and a part has not
    - E.g. **Student** class has initialized name, but faculty number is left unassigned
- Developing effective techniques for avoiding initialization problems can save a lot of time

## Variable Initialization
- Initialize all variables before their first usage
  - Local variables should be manually initialized
  - Declare and define each variable close to where it is used
  - This C# code will result in compiler error:

```cs
int value;
Console.WriteLine(value);
```
  - We can initialize the variable at its declaration:

```cs
int value = 0;
Console.WriteLine(value);
```

- Pay special attention to **counters** and **accumulators**
  - A common error is forgetting to reset a counter or an accumulator

```cs
int sum = 0;
for (int i = 0; i < array.GetLength(0); i++)
{
  for (int j = 0; j < array.GetLength(1); j++)
  {
    sum = sum + array[i, j];
  }
  Console.WriteLine(
    "The sum of the elements in row {0} is {1}", sum);
}
```

- Check the need for reinitialization
  - Make sure that the initialization statement is inside the part of the code that’s repeated
- Check input parameters for validity
  - Before you assign input values to anything, make sure the values are reasonable

```cs
int input;
bool validInput =
  int.TryParse(Console.ReadLine(), out input);
if (validInput)
{
  …
}
```

## Partially Initialized Objects
- Ensure objects cannot get into partially initialized state
  - Make all fields private and require valid values for all mandatory fields in all constructors
  - _Example_: **Student** object is invalid unless it has **Name** and **FacultyNumber**

```cs
class Student
{
  private string name, facultyNumber;
  public Student(string name, string facultyNumber)
  { … }
}
```

## Variables – Other Suggestions
- Don't define **unused variables**
  - Compilers usually issues warnings
- Don't use variables with **hidden purpose**
  - Incorrect example:

```cs
int mode = 1;
…
if (mode == 1) …; // Read
if (mode == 2) …; // Write
if (mode == 3) …; // Read and write
```

  - Use enumeration instead:

```cs
enum ResourceAccessMode { Read, Write, ReadWrite }
```

## Returning Result from a Method
- Always assign the result of a method in some variable before returning it. Benefits:
  - Improved code **readability**
    - The returned value has self-documenting name
  - Simplified debugging
  - Example:

```cs
int salary = days * hoursPerDay * ratePerHour;
return salary;
```

  - Incorrect example:

```cs
return days * hoursPerDay * ratePerHour;
```

The intent of the formula is obvious
We can put a breakpoint at this line and check if the result is correct

# Scope, Lifetime, Span

## Scope of Variables
- **Scope** – a way of thinking about a variable’s celebrity status
  - How **famous** is the variable?
  - Global (static), member variable, local
  - Most famous variables can be used anywhere, less famous variables are much more restricted
  - The scope is often combined with **visibility**
- In C# and Java, a variable can also be visible to a package or a namespace

## Visibility of Variables
- Variables' **visibility** is explicitly set restriction regarding the access to the variable
  - `public, protected, internal, private`
- Always try to reduce maximally the variables scope and visibility
  - This reduces potential coupling
  - Avoid public fields (exception: `readonly` / `const` in C# / `static` `final` in Java)
  - Access all fields through `properties / methods`

## Exceeded Scope – _Example_

```cs
public class Globals
{
   public static int state = 0;
}
public class ConsolePrinter
{
   public static void PrintSomething()
   {
      if (Globals.state == 0)
      {
         Console.WriteLine("Hello.");
       }
      else
      {
         Console.WriteLine("Good bye.");
      }
   }
}
```

## Span of Variables
- Variable **span**
  - The of lines of code (LOC) between variable usages
  - **Average span** can be calculated for all usages
  - Variable span should be kept as low as possible
  - Define variables at their first usage, not earlier
  - Initialize variables as late as possible
  - Try to keep together lines using the same variable

`Always define and initialize variables just before their first use!`

## Variable Live Time
- Variable **live time**
  - The number of lines of code (LOC) between the first and the last variable usage in a block
  - Live time should be kept as low as possible
- The same rules apply as for minimizing span:
  - Define variables at their first usage
  - Initialize variables just before their first use
  - Try to keep together lines using the same variable

## Unneeded Large Variable Span and Live Time
## Keep Variables LiveAs Short a Time

- Advantages of short time and short span
  - Gives you an accurate picture of your code
  - Reduces the chance of initialization errors
  - Makes your code more readable

## Best Practices
- Initialize variables used in a loop immediately before the loop
- Don’t assign a value to a variable until just before the value is used
  - Never follow the old C / Pascal style of declaring variables in the beginning of each method
- Begin with the most restricted visibility
  - Expand the visibility only when necessary
- Group related statements together

## Group RelatedStatements – _Example_

```cs
void SummarizeData(…)
{
  …
  GetOldData(oldData, numOldData);
  GetNewData(newData, numNewData);
  totalOldData = Sum(oldData, numOldData);
  totalNewData = Sum(newData, numNewData);
  PrintOldDataSummary(oldData, totalOldData);
  PrintNewDataSummary(newData, totalNewData);
  SaveOldDataSummary(totalOldData, numOldData);
  SaveNewDataSummary(totalNewData, numNewData);
  …
}
```
- Six variables for just this short fragment
You have to keep track of **oldData**, **newData**, **numOldData**, **numNewData**, **totalOldData** and **totalNewData**

## Better Grouping– _Example_
- Easier to understand, right?

```cs
void SummarizeDaily( … )
{
  GetOldData(oldData, numOldData);
  totalOldData = Sum(oldData, numOldData);
  PrintOldDataSummary(oldData, totalOldData);
  SaveOldDataSummary(totalOldData, numOldData);
  …
  GetNewData(newData, numNewData);
  totalNewData = Sum(newData, numNewData);
  PrintNewDataSummary(newData, totalNewData);
  SaveNewDataSummary(totalNewData, numNewData);
  …
}
```

The two blocks are each shorter and  individually contain fewer variables

## Single Purpose
- Variables should have **single purpose**
  - Never use a single variable for multiple purposes!
  - Economizing memory is not an excuse
- Can you choose a good name for variable that is used for several purposes?
  - _Example_: variable used to count students or to keep the average of their grades
  - Proposed name: `studentsCountOrAvgGrade`
 
## Variables Naming
- The name should describe the object clearly and accurately, which the variable represents
  - Bad names: **r18pq, __hip, rcfd, val1, val2**
  - Good names: **account**, **blockSize**, **customerDiscount**
- Address the problem, which the variable solves – "what" instead of "how"
  - Good names: **employeeSalary**, **employees**
  - Bad names: **myArray, customerFile, customerHashTable**
  - 
## Poor and Good Variable Names
```cs
x = x - xx;
xxx = aretha + SalesTax(aretha);
x = x + LateFee(x1, x) + xxx;
x = x + Interest(x1, x);
```

- What do x1, xx, and xxx mean?
- What does aretha mean ?

```cs
balance = balance - lastPayment;
monthlyTotal = NewPurchases + SalesTax(newPurchases);
balance = balance + LateFee(customerID, balance) +
  monthlyTotal;
balance = balance + Interest(customerID, balance);
```

## Naming Considerations
- Naming depends on the scope and visibility
  - Bigger scope, visibility, longer lifetime &rarr;longer and more descriptive name:

```cs
protected Account[] mCustomerAccounts;
```

  - Variables with smaller scope and shorter lifetime can be shorter:

```cs
for (int i=0; i<customers.Length; i++) { … }
```

- The enclosing type gives a context for naming:

```cs
class Account { Name: string { get; set; } }
// not AccountName
```

## Optimum Name Length
- Somewhere between the lengths of x and maximumNumberOfPointsInModernOlympics
- Optimal length – 10 to 16 symbols     
  - Too long

```cs
numberOfPeopleOfTheBulgarianOlympicTeamFor2012
```
  - Too short

```cs
а, n, z
```

  - Just right

```cs
numTeamMembers, teamMembersCount
```

## Naming Specific Data Types
- Naming counters

```cs
UsersCount, RolesCount, FilesCount
```

- Naming variables for state

```cs
ThreadState, TransactionState
```

- Naming temporary variables
  - Bad examples:

```cs
a, aa, tmpvar1, tmpvar2
```

  - Good examples:

```cs
index, value, count
```

- Name Boolean variables with names implying "Yes / No" answers

```cs
canRead, available, isOpen, valid
```

- Booleans variables should bring "truth" in their name
  - Bad examples:

```cs
notReady, cannotRead, noMoreData
```
  - Good examples:

```cs
isReady, canRead, hasMoreData
```

- Naming enumeration types
  - Use build in enumeration types (**Enum**)

```cs
Color.Red, Color.Yellow, Color.Blue
```

  - Or use appropriate prefixes (e.g. in JS / PHP)

```cs
colorRed, colorBlue, colorYellow
```

- Naming constants – use capital letters

```cs
MAX_FORM_WIDTH, BUFFER_SIZE
```

- C# constants should be in PascalCase:

```cs
Int32.MaxValue, String.Empty, InvariantCulture
```

## Naming Convention
- Some programmers resist to followstandards and conventions
  - But why?
- Conventions benefits
  - Transfer knowledge across projects
  - Helps to learn code more quickly on a new project
  - Avoid calling the same thing by two different names

- When should we use a naming convention?
  - Multiple developers are working on the same project
  - The source code is reviewed by other programmers
  - The project is large
  - The project will be long-lived
- You always benefit from having some kind of naming convention!

## Language-Specific Conventions
- C# and Java / JavaScript conventions
  - **i** and **j** are integer indexes
  - Constants are in **ALL_CAPS** separated by underscores (sometimes **PascalCase** in C#)
  - Method names use uppercase in C# and lowercase in JS for the first word
  - The underscore **_** is not used within names
    - Except for names in all caps

## Standard Prefixes
- Hungarian notation – not used
- Semantic prefixes (ex. **btnSave**)
  - Better use **buttonSave**
- Do not miss letters to make name shorter
- Abbreviate names in consistent way throughout the code
- Create names, which can be pronounced(not like btnDfltSvRzlts)
- Avoid combinations, which form another word or different meaning (ex. preFixStore)

## Kinds of Names to Avoid
- Document short names in the code
- Remember, names are designed for the people, who will read the code
  - Not for those who write it
- Avoid variables with similar names, but different purpose

```cs
UserStatus / UserCurrentStatus
```

- Avoid names, that sounds similar

```cs
decree / degree / digRee
```

- Avoid digits in names

- Avoid words, which can be easily mistaken
  - E.g. adsl, adcl, adctl, atcl
- Avoid using non-English words
- Avoid using standard types and keywords in the variable names
  - E.g. int, class, void, return
- Do not use names, which has nothing common with variables content
- Avoid names, that contains hard-readable symbols / syllables, e.g. Csikszentmihalyi

## Avoid Complex Expressions
- Never use complex expressions in the code!
  - Incorrect example:

```cs
for (int i=0; i<xCoords.length; i++) {
  for (int j=0; j<yCoords.length; j++) {
    matrix[i][j] =
      matrix[xCoords[findMax(i)+1]][yCoords[findMin(j)-1]] *
      matrix[yCoords[findMax(j)+1]][xCoords[findMin(i)-1]];
  }
}
```  
- Complex expressions are evil because:
  - Make code hard to read and understand, hard to debug, hard to modify and hard to maintain
What shall we do if we get at this line **IndexOutOfRangeException**?
There are 10 potential sources of **IndexOutOfRangeException** in this expre

## Simplifying Complex Expressions

```cs
for (int i = 0; i < xCoords.length; i++)
{
  for (int j = 0; j < yCoords.length; j++)
  {
    int maxStartIndex = findMax(i) + 1;
    int minStartIndex = findMin(i) - 1;
    int minXcoord = xCoords[minStartIndex];
    int maxXcoord = xCoords[maxStartIndex];
    int minYcoord = yCoords[minStartIndex];
    int maxYcoord = yCoords[maxStartIndex];
    int newValue =
      matrix[maxXcoord][minYcoord] *
      matrix[maxYcoord][minXcoord];
    matrix[i][j] = newValue;
  }
}
```

## Avoid Magic Numbers and Strings
- What is **magic number** or **value**?
  - Magic numbers / values are all literals different than `0, 1, -1, null` and `""` (empty string)
- Avoid using magic numbers / values
  - They are **hard to maintain**
    - In case of change, you need to modify all occurrences of the magic number / constant
  - Their meaning is not obvious
    - _Example_: what the number 1024 means?

## The Evil Magic Numbers

```cs
public class GeometryUtils
{
  public static double CalcCircleArea(double radius)
  {
    double area = 3.14159265 * radius * radius;
    return area;
  }
  public static double CalcCirclePerimeter(double radius)
  {
    double perimeter = 6.28318531 * radius;
    return perimeter;
  }
  public static double CalcElipseArea(double axis1, double axis2)
  {
    double area = 3.14159265 * axis1 * axis2;
    return area;
  }
}
```

## Turning MagicNumbers into Constants

```cs
public class GeometryUtils
{
   public const double PI = 3.14159265;
   public static double CalcCircleArea(double radius)
   {
      double area = PI * radius * radius;
      return area;
   }
   public static double CalcCirclePerimeter(double radius)
   {
      double perimeter = 2 * PI * radius;
      return perimeter;
   }
   public static double CalcElipseArea(
    double axis1, double axis2)
   {
      double area = PI * axis1 * axis2;
      return area;
   }
}
```

## Constants in C#
- There are two types of constants in C#
  - Compile-time constants:

```cs
public const double PI = 3.14159206;
```

- Replaced with their value during compilation
- No field stands behind them
  - Run-time constants:

```cs
public static readonly string ConfigFile = "app.xml";
```

- Special fields initialized in the static constructor
- Compiled into the assembly like any other class member

## Constants in JavaScript
- JS does not support constants
  - Simulated by variables / fields in **ALL_CAPS**:

```cs
var PI = 3.14159206;

var CONFIG =
{
  COLOR : "#AF77EE",
  DEFAULT_WIDTH : 200,
  DEFAULT_HEIGHT : 300
};

document.getElementById("gameField").style.width =
  CONFIG.DEFAULT_WIDTH;
document.getElementById("gameField").style.
  backgroundColor = CONFIG.COLOR;
```

## When to Use Constants?
- Constants should be used in the following cases:
  - When we need to use numbers or other values and their logical meaning and value are not obvious
  - File names

```cs
public static readonly string SettingsFileName =
"ApplicationSettings.xml";
```

  - Mathematical constants

```cs
public const double E = 2.7182818284;
```

  - Bounds and ranges

```cs
public const int READ_BUFFER_SIZE = 5 * 1024 *1024;
```

## When to Avoid Constants?
- Sometime it is better to keep the magic values instead of using a constant
  - **Error messages** and **exception descriptions**
  - **SQL commands** for database operations
  - Titles of **GUI elements**(labels, buttons, menus, dialogs, etc.)
- For internationalization purposes use **resources**, not constants
  - Resources are special files embedded in the assembly / JAR file, accessible at runtime

# Control Flow, Conditional Statements and Loops
## Correctly Organizing the Control Flow Logic

## Straight-Line Code
- When statements’ order matters

```cs
GetData();
GroupData();
Print();
```

  - **Make dependencies obvious**
  - Name methods according to dependencies
  - Use method parameters

```cs
data = GetData();
groupedData = GroupData(data);
PrintGroupedData(groupedData);
```
  - Document the control flow if needed

- When statements’ order does not matter
  - Make code read from top to bottom like a newspaper
  - **Group related statements together**
  - Make clear boundaries for dependencies
    - Use blank lines to separate dependencies
    - User separate method

## Straight-Line Code – Examples

```cs
ReportFooter CreateReportFooter(Report report)
{
  // …
}
ReportHeader CreateReportHeader(Report report)
{
  // …
}
Report CreateReport()
{
  var report = new Report();
  report.Footer = CreateReportFooter(report);
  report.Content = CreateReportContent(report);
  report.Header = CraeteReportHeader(report);
  return report;
}
ReportContent CreateReportContent(Report report)
{
  // …
}
```

```cs
Report CreateReport()
{
  var report = new Report();  
  report.Header = CreateReportHeader(report);
  report.Content = CreateReportContent(report);
  report.Footer = CreateReportFooter(report);
  return report;
}

ReportHeader CraeteReportHeader(Report report)
{
  // …
}

ReportContent CreateReportContent(Report report)
{
  // …
}

ReportFooter CreateReportFooter(Report report)
{
  // …
}
```

## Straight-Line Code Summary
- The most important thing to consider when organizing straight-line code is
  - **Ordering dependencies**
- Dependencies should be made **obvious**
  - Through the use of good routine names, parameter lists and comments
- If code doesn’t have order dependencies
  - Keep related statements together

## Using Conditional Statements
- Always use `{` and `}` for the conditional statements body, even when it is a single line:

```cs
if (condition)
{
  DoSometing();
}
```

- Why omitting the brackets could be harmful?

```cs
if (condition)
  DoSomething();
  DoAnotherThing();
DoDifferentThing();
```

- This is misleading code + misleading formatting

- Always put the normal (expected) condition first after the `if` clause

- Start from most common cases first, then go to the unusual ones

- Avoid comparing to **true** or **false**:

- Always consider the else case
  - If needed, document why the else isn’t necessary

```cs
if (parserState != States.Finished)
{
  // …
}
else
{
  // Ignore all content once the pareser has finished
}
```

- Avoid double negation

- Write `if` clause with a meaningful statement

- Use meaningful boolean expressions, which read like a sentence

- Be aware of copy/paste problems in **if-else** bodies

## Use Simple Conditions
- Do not use complex `if` conditions
  - You can always simplify them by introducing boolean variables or boolean methods
  - Incorrect example:

```cs
if (x > 0 && y > 0 && x < Width-1 && y < Height-1 &&
  matrix[x, y] == 0 && matrix[x-1, y] == 0 &&
  matrix[x+1, y] == 0 && matrix[x, y-1] == 0 &&
  matrix[x, y+1] == 0 && !visited[x, y]) …
```

  - Complex boolean expressions can be harmful
  - How you will find the problem if you get `IndexOutOfRangeException`?

## Simplifying Boolean Conditions
- The last example can be easily refactored into self-documenting code:

```cs
bool inRange = x > 0 && y > 0 && x < Width-1 && y < Height-1;
if (inRange)
{
  bool emptyCellAndNeighbours =
    matrix[x, y] == 0 && matrix[x-1, y] == 0 &&
    matrix[x+1, y] == 0 && matrix[x, y-1] == 0 &&
    matrix[x, y+1] == 0;
  if (emptyCellAndNeighbours && !visited[x, y]) …
}
```

- Now the code is:
    - Easy to read – the logic of the condition is clear
    - Easy to debug – breakpoint can be put at the if

- Use object-oriented approach

```cs
class Maze
{
  Cell CurrentCell { get; set; }
  IList<Cell> VisitedCells { get; }
  IList<Cell> NeighbourCells { get; }
  Size Size { get; }

  bool IsCurrentCellInRange()
  {
    return Size.Contains(CurrentCell);
  }

  bool IsCurrentCellVisited()
  {
    return VisitedCells.Contains(CurrentCell);
  }


```  

```cs
  bool AreNeighbourCellsEmpty()
  {
    …
  }
  bool ShouldVisitCurrentCell()
  {
    return
      IsCurrentCellInRange() &&
      CurrentCell.IsEmpty() &&
      AreNeighbourCellsEmpty() &&
      !IsCurrentCellVisited()
  }
}
```

- Now the code:
  - Models the real scenario
  - Stays close to the problem domain
   
## Use Decision Tables
- Sometimes a **decision table** can be used for simplicity

```cs
var table = new Hashtable();
table.Add("A", new AWorker());
table.Add("B", new BWorker());
table.Add("C", new CWorker());

string key = GetWorkerKey();

var worker = table[key];
if (worker != null)
{
  ...
  worker.Work();
  ...
}
```

## Positive Boolean Expressions
- Starting with a **positive expression** improves the readability

- Use De Morgan’s laws for negative checks
 
## Use Parentheses
- Avoid complex boolean conditions without parenthesis

```cs
if (a < b && b < c || c == d)
```

- Using parenthesis helps readability as well as ensure correctness

```cs
if (( a < b && b < c ) || c == d)
```
- Too many parenthesis have to be avoided as well
  - Consider separate Boolean methods or variables in those cases

## Boolean Expression Evaluation
- Most languages evaluate from left to right
  - Stop evaluation as soon as some of the boolean operands is satisfied
  
- Useful when checking for **null**

```cs
if (list != null && list.Count > 0) …
```

- There are languages that does not follow this “short-circuit” rule

## Numeric Expressions as Operands
- Write numeric boolean expressions as they are presented on a number line
  - Contained in an interval
  - Outside of an interval

## Avoid Deep Nesting of Blocks
- **Deep nesting** of conditional statements and loops makes the code unclear
  - More than 2-3 levels is too deep
  - Deeply nested code is complex and hard to read and understand
  - Usually you can extract portions of the code in separate methods
    - This simplifies the logic of the code
    - Using good method name makes the code self-documenting

## Deep Nesting – _Example_

```cs
if (maxElem != Int32.MaxValue)
{
    if (arr[i] < arr[i + 1])
    {
        if (arr[i + 1] < arr[i + 2])
        {
            if (arr[i + 2] < arr[i + 3])
            {
                maxElem = arr[i + 3];
            }
            else
            {
                maxElem = arr[i + 2];
            }
        }
        else
        {
            if (arr[i + 1] < arr[i + 3])
            {
                maxElem = arr[i + 3];
            }
            else
            {
                maxElem = arr[i + 1];
            }
        }
    } else {
        if (arr[i] < arr[i + 2])
        {
            if (arr[i + 2] < arr[i + 3])
            {
                maxElem = arr[i + 3];
            }
            else
            {
                maxElem = arr[i + 2];
            }
        }
        else
        {
            if (arr[i] < arr[i + 3])
            {
                maxElem = arr[i + 3];
            }
            else
            {
                maxElem = arr[i];
            }
        }
    }
}
```

## Avoiding Deep Nesting – _Example_

```cs
private static int Max(int i, int j)
{
    if (i < j)
    {
        return j;
    }
    else
    {
       return i;
    }
}

private static int Max(int i, int j, int k)
{
    if (i < j)
    {
        int maxElem = Max(j, k);
        return maxElem;
    }
    else
    {
        int maxElem = Max(i, k);
        return maxElem;
    }
}
```

```cs
private static int FindMax(int[] arr, int i)
{
  if (arr[i] < arr[i + 1])
  {
    int maxElem = Max(arr[i + 1], arr[i + 2], arr[i + 3]);
    return maxElem;
  }
  else
  {
    int maxElem = Max(arr[i], arr[i + 2], arr[i + 3]);
    return maxElem;
  }
}

if (maxElem != Int32.MaxValue) {
  maxElem = FindMax(arr, i);
}


```

## Using Case Statement
- Choose the most effective ordering of cases
  - Put the normal (usual) case first
  - Order cases by frequency
  - Put the most unusual (exceptional) case last
  - Order cases alphabetically or numerically
- Keep the actions of each case simple
  - Extract complex logic in separate methods
- Use the default clause in a `case` statement or the last `else` in a chain of `if-else` to trap errors

## Incorrect Case Statement

```cs
void ProcessNextChar(char ch)
{
  switch (parseState)
  {
    case InTag:
      if (ch == ">")
      {
        Console.WriteLine("Found tag: {0}", tag);
        text = "";
        parseState = ParseState.OutOfTag;
      }
      else
      {
        tag = tag + ch;
      }
      break;
    case OutOfTag:
      …
  }
}
```

## Improved Case Statement

```cs
void ProcessNextChar(char ch)
{
  switch (parseState)
  {
    case InTag:
      ProcessCharacterInTag(ch);
      break;
    case OutOfTag:
      ProcessCharacterOutOfTag(ch);
      break;
    default:
      throw new InvalidOperationException(
        "Invalid parse state: " + parseState);
  }
}
```

## Case – Best Practices
- Avoid using fallthroughs
- When you do use them, document them well

```cs
switch (c)
{
  case 1:
  case 2:
    DoSomething();
    // FALLTHROUGH  
  case 17:
    DoSomethingElse();
    break;
  case 5:
  case 43:
    DoOtherThings();
    break;
}
```

- Overlapping control structures is evil:

```cs
switch (inputVar)
{
  case 'A': if (test)
            {
              // statement 1
              // statement 2
  case 'B':   // statement 3
              // statement 4
              ...
            }
            ...
            break;
}
```

- This code will not compile in C# but may compile in other languages

## Control Statements – Summary
- For simple `if-else`-s, pay attention to the order of the `if` and `else` clauses
  - Make sure the nominal case is clear
- For `if-then-else` chains and `case` statements, choose the most readable order
- Optimize boolean statements to improve readability
- Use the `default` clause in a `case` statement or the last `else` in a chain of `if`-s to trap errors

# Using Loops
- Choosing the correct type of loop:
  - Use `for` loop to repeat some block of code a certain number of times
  - Use `foreach` loop to process each element of an array or a collection
  - Use `while` / `do-while` loop when you don't know how many times a block should be repeated
- Avoid deep nesting of loops
  - You can extract the loop body in a new method

## Loops: Best Practices
- Keep loops simple
  - This helps readers of your code
- Treat the inside of the loop as it were a routine
  - Don’t make the reader look inside the loop to understand the loop control
- Think of a loop as a black box
- Keep loop’s housekeeping at the start or at the end of the loop block

- Use meaningful variable names to make loops readable

- Avoid empty loops

```cs
while ((inputChar = Console.Read()) != '\n')
{
}
```

```cs
do
{
   inputChar = Console.Read();
}
while (inputChar != '\n');
```

- Be aware of your language (loop) semantics
  - C# – access to modified closure

## Loops: Tips on for-Loop
- Don’t explicitly change the index value to force the loop to stop
  - Use `while`-loop with `break` instead
- Put only the controlling statements in the loop header

- Avoid code that depends on the loop index’s final value

## Loops: break and continue
- Use `continue` for tests at the top of a loop to avoid nested `if`-s
- Avoid loops with lots of `break`-s scattered trough it
- Use `break` and `continue` only with caution
 
## How Long Should a Loop Be?
- Try to make the loops **short enough** to view it all at once (one screen)
- Use methods to shorten the loop body
- Make long loops especially clear
- Avoid deep nestingin loops

## The return Statement
- Use `return` when it enhances readability
- Use `return` to avoid deep nesting
- Avoid multiple `return`-s in long methods

## Recursion
- Useful when you want to walk a tree / graph-like structures
- Be aware of infinite recursion or indirect recursion
- Recursion example:

```cs
void PrintWindowsRecursive(Window w)
{
  w.Print()
  foreach(childWindow in w.ChildWindows)
  {
     PrintWindowsRecursive(childWindow);
  }}
```

## Recursion Tips
- Ensure that recursion has end (bottom)
- Verify that recursion is not very high-cost
  - Check the occupied system resources
  - You can always use stack classes and iteration
- Don’t use recursion when there is better **linear** (iteration based) solution, e.g.
  - Factorials
  - Fibonacci numbers
- Some languages optimize tail-call recursions

## GOTO
- Avoid `goto`-s, because they have a tendency to introduce spaghetti code
- [“A Case Against the GO TO Statement” by Edsger Dijkstra](http://www.cs.utexas.edu/users/EWD/transcriptions/EWD02xx/EWD215.html)
- Use `goto`-s as a last resort
  - If they make the code more maintainable
- C# supports `goto` with labels, but avoid it!
 
# High-Quality Methods
## How to Design and Implement High-Quality Methods? Understanding Cohesion and Coupling

## Why Do We Need Methods?
- **Methods** (functions, routines) are important in software development
  - **Reduce complexity**
    - Divide and conquer: complex problems are split into composition of several simple
  - **Improve code readability**
    - Small methods with good method names make the code self-documenting
  - **Avoid duplicating code**
    - Duplicating code is hard to maintain

- **Methods** simplify software development
  - **Hide implementation details**
    - Complex logic is encapsulated and hidden behind a simple interface
    - Algorithms and data structures are hidden and can be transparently replaced later
  - **Increase the level of abstraction**
    - Methods address the business problem, not the technical implementation:

## Using Methods: <br> Fundamentals
- Fundamental principle of correct method usage

```md
A method should do what its name says or should indicate an
error (throw an exception). Any other behavior is incorrect!
```

- Methods should do exactly **what their names say**
  - Nothing less (work in all possible scenarios)
  - Nothing more (no side effects)
- In case of incorrect input or incorrect preconditions, an **error** should be indicated

## Bad Methods – Examples
```cs
int Sum(int[] elements)
{
  int sum = 0;
  foreach (int element in elements)
  {
      sum = sum + element;
  }
  return sum;
}
```
- What will happen if we sum `2,000,000,000` + `2,000,000,000`?
  - **Result**: `-294,967,296`

```cs
double CalcTriangleArea(double a, double b, double c)
{
  double s = (a + b + c) / 2;
  double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
  return area;
}
```
- What will happen if `a = b = c = -1`?
- What will happen if `a = b = c = 1`?
  - Both triangles will have the **same size**.

## Good Methods – Examples

```cs
double CalcTriangleArea(double a, double b, double c)
{
  if (a <= 0 || b <= 0 || c <= 0)
  {
    throw new ArgumentException(
      "Sides should be positive.");
  }
  double s = (a + b + c) / 2;
  double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
  return area;
}
```

## Indicating an Error
- Some methods do not correctly indicate errors
```cs
internal object GetValue(string propertyName)
{
    PropertyDescriptor descriptor =
        this.propertyDescriptors[propertyName];

    return descriptor.GetDataBoundValue();
}
```
- If the property name **does not exist**
  - A null reference exception will be <br>thrown **implicitly** &rarr; it is not meaningful

- Use the correct exception handling instead:
```cs
internal object GetValue(string propertyName)
{
    PropertyDescriptor descriptor =
        this.propertyDescriptors[propertyName];

    if (descriptor == null)
    {
        throw new ArgumentException("Property name "
         + propertyName + " does not exists!");
    }		

    return descriptor.GetDataBoundValue();
}
```

## Symptoms of Wrong Methods
- Method that does something different than its name is wrong for at least one of these reasons:
  - The method sometimes returns incorrect result &rarr; **bug**
  - The method returns incorrect output when its input is incorrect or unusual &rarr; **low** **quality**
    - Could be acceptable for `private` methods only

- The method does too many things &rarr; **bad** **cohesion**
- The method has side effects &rarr; **spaghetti** **code**
- Method returns strange value when an error condition happens &rarr; **it should indicate the error**

## Wrong Methods – Examples
```cs
long Sum(int[] elements)
{
  long sum = 0;

  for (int i = 0; i < elements.Length; i++)
  {
    sum = sum + elements[i];
    elements[i] = 0; // Hidden side effect
  }

  return sum;
}
```

```cs
double CalcTriangleArea(double a, double b, double c)
{
  if (a <= 0 || b <= 0 || c <= 0)
  {
    return 0; // Incorrect result
  }

  double s = (a + b + c) / 2;
  double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

  return area;
}
```

## Strong Cohesion
- Methods should have **strong cohesion**
  - Should address single task and address it well
  - Should have clear intent
- Methods that  address several tasks in the same time are hard to be named
- Strong cohesion is used in engineering
  - In computer hardware any PC component solves a single task
  - E.g. hard disk performs a single task – storage

## Acceptable Types of Cohesion
- **Functional cohesion** (independent function)
  - Method performs certain well-defined calculation and returns a single result
  - The entire input is passed through parameters and the entire output is returned as result
  - No external dependencies or side effects
	- _Examples_

```cs
Math.Sqrt(value), Char.IsLetterOrDigit(ch), ...
```

- **Sequential cohesion** (algorithm)
  - Method performs certain sequence of operations to perform a single task and achieve certain result
    - It encapsulates an algorithm
  - _Example_:
    - Connect to mail server
    - Send message headers
    - Send message body
    - Disconnect from the server

- **Communicational cohesion** (common data)
  - A set of operations used to process certain data and produce a result
  - _Example_:
    - Retrieve input data from database
    - Perform internal calculations over retrieved data
    - Build the report
    - Format the report as Excel worksheet
    - Display the Excel worksheet on the screen

- **Temporal cohesion**(time related activities)
  - Operations that are generally not related but need to happen in a certain moment
  - _Examples_:
    - Load user settings
    - Check for updates
    - Load all invoices from the database
    - Sequence of actions to handle the event

## Unacceptable Cohesion
- **Logical cohesion**
  - Performs a different operation depending on an input parameter
  - Incorrect example:
	```cs
	object ReadAll(int operationCode)
	{
	  if (operationCode == 1) … // Read person name
	  else if (operationCode == 2) … // Read address
	  else if (operationCode == 3) … // Read date
	  …
	}
	```
  - Can be acceptable in event handlers (e.g. the **KeyDown** event in Windows Forms)

- **Coincidental cohesion** (spaghetti)
  - Not related (random) operations are grouped in a method for unclear reason
  - Incorrect example:
	```cs
	Wtf HandleStuff(customerId, int[], ref sqrtValue,
    mp3FileName, emailAddress)
	```
    - Prepares annual incomes report for given customer
    - Sorts an array of integers in increasing order
    - Calculates the square root of given number
    - Converts given MP3 file into WMA format
    - Sends email to given customer

## Loose Coupling

- What is **loose coupling**?
  - Minimal dependences of the method on the other parts of the source code
  - Minimal dependences on the class members or external classes and their members
  - No side effects
  - If the coupling is loose, we can easily reuse a method or group of methods in a new project
- Tight coupling &rarr; **spaghetti code**

- **The ideal coupling**
  - A methods depends only on its parameters
  - Does not have any other input or output
  - _Example_: `Math.Sqrt()`
- **Real world**
  - Complex software cannot avoid coupling but could make it as loose as possible
  - _Example_: complex encryption algorithm performs initialization, encryption, finalization

## Coupling – _Example_
- Intentionally increased coupling for more flexibility (.NET cryptography API):

```cs
byte[] EncryptAES(byte[] inputData, byte[] secretKey)
{
  Rijndael cryptoAlg = new RijndaelManaged();
  cryptoAlg.Key = secretKey;
  cryptoAlg.GenerateIV();
  MemoryStream destStream = new MemoryStream();
  CryptoStream csEncryptor = new CryptoStream(
    destStream, cryptoAlg.CreateEncryptor(),
    CryptoStreamMode.Write);
  csEncryptor.Write(inputData, 0, inputData.Length);
  csEncryptor.FlushFinalBlock();
  byte[] encryptedData = destStream.ToArray();
  return encryptedData;
}
```

# Loose Coupling – _Example_
- To reduce coupling we can make **utility classes**
  - Hide the complex logic and provide simple straightforward interface (a.k.a. **façade**):

```cs
byte[] EncryptAES(byte[] inputData, byte[] secretKey)
{
  MemoryStream inputStream = MemoryStream(inputData);
  MemoryStream outputStream = new MemoryStream();

  EncryptionUtils.EncryptAES(, outputStream, secretKey);
  byte[] encryptedData = outputStream.ToArray();

  return encryptedData;
}
```

## Tight Coupling – _Example_
- Passing parameters through class fields
  - Typical example of tight coupling
  - Don't do this unless you have a good reason!

```cs
class Sumator
{
  public int a, b;
  int Sum()
  {
    return a + b;
  }
  static void Main()
  {
    Sumator sumator = new Sumator() { a = 3, b = 5 };
    Console.WriteLine(sumator.Sum());
  }
}
```

## Tight Coupling in Real Code
- Say, we have a large piece of software
  - We need to update subsystems and the subsystems are not really independent
  - E.g. a change in filtering affects sorting, etc:

```cs
class GlobalManager
{
    public void UpdateSorting() {…}
    public void UpdateFiltering() {…}
    public void UpdateData() {…}
    public void UpdateAll () {…}
}
```

## Loose Coupling and OOP
- Reducing coupling with OOP techniques
  - **Abstraction**
    - Define a `public` interface and hide the implementation details
  - **Encapsulation**
    - Make methods and fields `private` unless they are definitely needed
    - Define new members as `private`
    - Increase visibility as soon as this is needed

## Acceptable Coupling
- Method is coupled to its **parameters**
  - This is the best type of coupling

```cs
static int Sum(int[] elements) { … }
```

- Method in a class is coupled to some **class fields**
  - This coupling is usual, do not worry too much

```cs
static int CalcArea()
{
	return this.Width * this.Height;
}
```

- Method in a class is coupled to **static** methods, properties or constants in **external class**
  - This is normal, usually is not a problem

```cs
static double CalcCircleArea(double radius)
{
	return Math.PI * radius * radius;
}
```

## Non-Acceptable Coupling
- Method in a class is coupled to **static fields** in external class
  - Use `private` fields and `public` properties
- Methods take as input data some fields that could be passed as parameters
  - Check the intent of the method
  - Is it designed to process `internal` class data or is utility method?
- Method is defined `public` without being part of the `public` class's interface &rarr; **possible coupling**

## Methods Parameters
- Put most important parameters first
  - Put the main input parameters first
  - Put non-important optional parameters last
  - _Example_:

```cs
void RegisterUser(string username, string password,
	Date accountExpirationDate, Role[] roles)
```

- _Incorrect example_:

```cs
void RegisterUser(Role[] roles, string password,
	string username, Date accountExpirationDate)
```

- Do not modify the input parameters
- _Incorrect example_:

```cs
bool CheckLogin(string username, string password)
{
  username = username.ToLower();
  // Check the username / password here …
}
```

  - _Correct example_:

```cs
bool CheckLogin(string username, string password)
{
  string usernameLowercase = username.ToLower();
  // Check the username / password here …
}
```

- Use parameters consistently
- Use the same names and the same order in all methods
  - _Incorrect example_:

```cs
void EncryptFile(Stream input, Stream output, string key);
void DecryptFile(string key, Stream output, Stream input);
```

  - Output parameters should be put last

```cs
FindCustomersAndIncomes(Region region,
	out Customer[] customers, out decimal[] incomes)
```

## Pass Entire Object or <br> Its Fields?
- When should we pass an object containing few values and when these values separately?
  - Sometime we pass an object and use only a single field of it. **Is this a good practice?**

## Pass Entire Object or Its Fields? - Examples

```cs
decimal CalculateSalary(Employee employee, int months);
```

```cs
decimal CalculateSalary(double rate, int months);
```

- Look at the method's level of abstraction
  - Is it intended to operate with employees or with rates and months? &rarr; **the first is incorrect**

## How Much Parameters Methods Should Have?
- Limit the number of parameters to `7 (+/-2)`
  - `7` is a "magic" number in psychology
  - Human brain cannot process more than `7 (+/-2)` things in the same time
- If the parameters need to be too many, reconsider the method's intent
  - Does it have a **clear intent**?
  - Consider extracting few of the parameters in a new method

## Methods Length
- How long should a method be?
  - There is no specific restriction
  - Avoid methods longer than **one screen** (`30` lines)
  - Long methods are not always bad
    - Be sure you have a good reason for their length
  - **Cohesion** and **coupling** are more important than the method length!
  - Long methods often contain portions that could be extracted as separate methods with good name and clear intent

## Pseudocode
- **Pseudocode** can be helpful in:
  - Routines design
  - Routines coding
  - Code verification
  - Cleaning up unreachable <br> branches in a routine

## Designing in Pseudocode
- What the routine will abstract  i.e. the information a routine will **hide**?
- Routine input parameters
- Routine output
- Preconditions
  - Conditions that have to be true before a routine is called
- Postconditions
  - Conditions that have to be true after routine execution

## Design Before Coding
- Why it is better to spend time on design before you start coding?
  - The functionality may be already available in a library, **so you do not need to code at all!**
  - You need to think of the best way to implement the task considering your project requirements
  - If you fail on writing the code right the first time, you need to know that **programmers get emotional to their code**

## Pseudocode _Example_

```md
Routine that evaluates an aggregate expression for a
database column (e.g. Sum, Avg, Min)

Parameters: Column Name, Expression

Preconditions:
- Check whether the column exists and throw an argument
exception if not
- If  the expression parser cannot parse the expression
 throw an ExpressionParsingException

Routine code: Call the evaluate method on the DataView class
and return the resulting value as string
```

## Public Routines in Libraries
- `Public` routines in libraries and system software is hard to change
  - Because customers want **no breaking changes**
- Two reasons why you need to change a `public` routine:
  - New functionality has to be added conflicting with the old features
  - The name is confusing and makes the usage of the library unintuitive
- Design better upfront, or refactor carefully

## Method Deprecation
- **Deprecated** method
  - About to be removed in future versions
- When deprecating an old method
  - Include that in the documentation
  - **Specify the new routine that has to be used**
- Use the **[Obsolete]** attribute in .NET

```cs
[Obsolete("CreateXml() method is deprecated.
	Use CreateXmlReader instead.")]
public void CreateXml (…)
{
  …
}
```

## Inline Routines
- **Inline** routines provide two benefits:
  - Abstraction
  - Performance benefit of not creating a new routine on the stack
- Some applications (e.g. **games**) need that optimization
  - Used for the most frequently used routines
  - _Example_: a short routine called 100,000 times
- Not all languages support Inline routines

# Conclusion
- Designing and coding routines is engineering activity
  - **There is no perfect solution**
- Competing solutions usually demonstrate different trade-offs
  - The challenge of the programmer is to
    - Evaluate the **requirements**
    - Choose the **most appropriate** solution from the available options
    - Ensure **loose coupling** / **strong cohesion**

# High-Quality Classes and Class Hierarchies
## Best Practices in the Object-Oriented Design

# Basic Principles
## Cohesion, Coupling,Inheritance and Polymorphism

## Cohesion
- **Cohesion** measures how closely are all the routines in a class/module
  - Cohesion must be **strong**
  - Classes must contain strongly related functionality and aim for **single purpose**
- **Strong cohesion** is a useful tool for managing complexity
  - Well-defined abstractions keep cohesion strong
  - Bad abstractions have weak cohesion

## Good and Bad Cohesion
- Good: hard disk, CD-ROM, floppy
- Bad: spaghetti code

## Strong Cohesion
- Strong cohesion example
  - Class `System.Math`
    - Sin(), Cos(), Asin()
    - Sqrt(), Pow(), Exp()
    - Math.PI, Math.E

```cs
float sideA = 40f, sideB = 69f;
float angleAB = Math.PI / 3;
float sideC =
	Math.Pow(sideA, 2) + Math.Pow(sideB, 2) -
	2 * sideA * sideB * Math.Cos(angleAB);

float sidesSqrtSum =
	Math.Sqrt(sideA) +
	Math.Sqrt(sideB) +
	Math.Sqrt(sideC);
```

## Coupling
- **Coupling** describes how tightly a class or routine is related to other classes or routines
- **Coupling** must be kept **loose**
  - Modules must depend little on each other
  - All classes and routines must have
    - Small, direct, visible, and flexible relationships to other classes and routines
  - One module must be easily used by other modules, without complex dependencies

## Loose and Tight Coupling
- **Loose Coupling**
  - Easily replace old HDD
  - Easily place this HDD to <br> another motherboard
- **Tight Coupling**
  - Where is the video adapter?
  - Can you change the video <br> controller on this MB?

## Loose Coupling – _Example_

```cs
class Report
{
  public bool LoadFromFile(string fileName) {…}
  public bool SaveToFile(string fileName) {…}
}
class Printer
{
  public static void Print(Report report) {…}
}
class Program
{    
  static void Main()
  {
    Report myReport = new Report();          
    myReport.LoadFromFile("C:\\DailyReport.rep");
    Printer.Print(myReport);
  }
}
```

## Tight Coupling – _Example_

```cs
class MathParams
{
  public static double operand;
  public static double result;
}
class MathUtil
{
  public static void Sqrt()
  {
    MathParams.result = CalcSqrt(MathParams.operand);
  }
}
…
MathParams.operand = 64;
MathUtil.Sqrt();
Console.WriteLine(MathParams.result);
```

## Inheritance
- **Inheritance** is the ability of a class to implicitly gain all members from another class
  - Inheritance is principal concept in OOP
  - The class whose methods are inherited is called **base** (parent) class
  - The class that gains new functionality is called **derived** (child) class
- Use inheritance to:
  - **Reuse repeating code**: data and program logic
  - Simplify code maintenance

## Inheritance in C# and JS
- In **C#** all class members are inherited
  - Fields, methods, properties, etc.
  - Structures cannot be inherited, only classes
  - No multiple inheritance is supported
  - Only multiple interface implementations
- In **JS** inheritance is supported indirectly
  - Several ways to implement inheritance
  - Multiple inheritance is not supported
  - There are no interfaces (JS is typeless language)

## Polymorphism
- **Polymorphism** is a principal concept in OOP
- The ability to handle the objects of a specific class as instances of its parent class
  - To call abstract functionality
- Polymorphism allows to create hierarchies with more valuable logical structure
- Polymorphism is a tool to enable **code reuse**
  - Common logic is taken to the base class
  - Specific logic is implemented in the derived class in a overridden method

## Polymorphism in C# and JS
- In C# polymorphism is implemented through:
  - Virtual methods (`virtual`)
  - Abstract methods (`abstract`)
  - Interfaces methods (`interface`)
- In C# **override** overrides a virtual method
- In JavaScript **all methods are virtual**
  - The child class can just "override" any method from any object
  - There are no interfaces (JS is typeless language)

## Polymorphism – _Example_

```cs
public class Person
{
  public virtual void PrintName() {
    Console.Write("I am a person.");
  }
}
public class Student : Person
{
  public override void PrintName() {
    Console.Write("I am a student. " + base.PrintName());
  }
}
public class Trainer : Person
{
  public override void PrintName() {
    Console.Write("I am a trainer.");
  }
}
```

## How to Design High-Quality Classes? Abstraction, Cohesion and Coupling

## High-Quality Classes: Abstraction
- Present a consistent level of **abstraction** in the class contract (publicly visible members)
  - What abstraction the class is implementing?
  - Does it represent only one thing?
  - Does the class name well describe its purpose?
  - Does the class define clear and easy to understand public interface?
  - Does the class hide all its implementation details?

## Good Abstraction – _Example_

```cs
public class Font
{
   public string Name { get; set; }
   public float SizeInPoints { get; set; }
   public FontStyle Style { get; set; }
   public Font(
      string name, float sizeInPoints, FontStyle style)
   {
      this.Name = name;
      this.SizeInPoints = sizeInPoints;
      this.Style = style;
   }
   public void DrawString(DrawingSurface surface,
      string str, int x, int y) { … }
   public Size MeasureString(string str) { … }
}
```

## Bad Abstraction – _Example_

```cs
public class Program
{
  public string title;
  public int size;
  public Color color;
  public void InitializeCommandStack();
  public void PushCommand(Command command);
  public Command PopCommand();
  public void ShutdownCommandStack();
  public void InitializeReportFormatting();
  public void FormatReport(Report report);
  public void PrintReport(Report report);
  public void InitializeGlobalData();
  public void ShutdownGlobalData();
}
```
Does this class really represent a "program"? Is this name good?
Does this class really have a single purpose?

## Establishing Good Abstraction
- Define operations along with their opposites
  - _Example:_ `Open()` and `Close()`
- Move unrelated methods in another class
  - _Example:_ In class `Employee` if you need to calculate **Age** by given **DateOfBirth**, create а static method `CalcAgeByBirthDate(…)` in a separate class
- Group related methods intro a single class
- Does the class name correspond to the class content?

- Beware of breaking the interface abstraction due to evolution
  - Don't add public members inconsistent with abstraction
  - _Example_: in class called **Employee** at some time we add method for accessing the DB with SQL

```cs
{
  public string FirstName { get; set; }
  public string LastName; { get; set; }
  …
  public SqlCommand FindByPrimaryKeySqlCommand(int id);
}
```

## Encapsulation
- Minimize visibility of classes and members
  - In C# start from `private` and move to `internal`, `protected` and `public` if required
- Classes should hide their implementation details
  - A principle called **encapsulation** in OOP
  - Anything which is not part of the class interface should be declared `private`
  - Classes with good encapsulated classes are: less complex, easier to maintain, more loosely coupled
- Classes should keep their state **clean**

- Never declare fields `public` (except constants)
  - Use properties / methods to access the fields
- Don't put private implementation details in the `public` interface
  - All `public` members should be consistent with the abstraction represented by the class
- Don't make a method `public` just because it calls only `public` methods
- Don't make assumptions about how the class will be used or will not be used

- Don't violate encapsulation semantically!
  - Don't rely on non-documented internal behavior or side effects
  - Wrong example:
    - Skip calling `ConnectToDB()` because you just called `FindEmployeeById()` which should open connection
  - Another wrong example:
    - Use `String.Empty` instead of `Titles.NoTitle` because you know both values are the same

## Inheritance or Containment?
- Containment is "**has a**" relationship
  - _Example_: **Keyboard** has a set of **Key**s
- Inheritance is "**is a**" relationship
  - Design for inheritance: make the class **abstract**
  - Disallow inheritance: make the class **sealed**
  - Subclasses must be usable through the base class interface
    - Without the need for the user to know the difference

## Inheritance
- Don't hide methods in a subclass
  - _Example_: if the class `Timer` has private method `Start()`, don't define `Start()` in `AtomTimer`
- Move common interfaces, data, and behavior as high as possible in the inheritance tree
  - This maximizes the code reuse
- Be suspicious of base classes of which there is only one derived class
  - Do you really need this additional level of inheritance?

- Be suspicious of classes that override a routine and **do nothing** inside
  - Is the overridden routine used correctly?
- Avoid **deep inheritance** trees
  - Don't create more than 6 levels of inheritance
- Avoid using a base class’s protected data fields in a derived class
  - Provide protected accessor methods or properties instead

- Prefer inheritance to extensive type checking:
- Consider inheriting `Circle` and `Square` from `Shape` and override the abstract action `Draw()`

```cs
switch (shape.Type)
{
  case Shape.Circle:
    shape.DrawCircle();
    break;
  case Shape.Square:
    shape.DrawSquare();
    break;
  ...
}
```

## Class Methods and Data
- Keep the number of methods in a class as small as possible &rarr; reduce complexity
- Minimize direct methods calls to other classes
  - Minimize indirect methods calls to other classes
  - Less external method calls == less coupling
  - Also known as "**fan-out**"
- Minimize the extent to which a class collaborates with other classes
  - Reduce the **coupling** between classes

## Class Constructors
- Initialize all member data in all constructors, if possible
  - Uninitialized data is error prone
  - Partially initialized data is even more evil
  - Incorrect example: assign **FirstName** in class **Person** but leave **LastName** empty
- Initialize data members in the same order in which they are declared
- Prefer deep copies to shallow copies (**ICloneable** should make deep copy)

## Use Design Patterns
- Use private constructor to prohibit direct class instantiation
- Use design patterns for common design situations
  - **Creational patterns** like Singleton, Factory Method, Abstract Factory
  - **Structural patterns** like Adapter, Bridge, Composite, Decorator, Façade
  - **Behavioral patterns** like Command, Iterator, Observer, Strategy, Template Method

## Top Reasons to Create Class
- Model real-world objects with OOP classes
- Model abstract objects, processes, etc.
- Reduce complexity
  - Work at higher level
- Isolate complexity
  - Hide it in a class
- Hide implementation details &rarr; encapsulation
- Limit effects of changes
  - Changes affect only their class

- Hide global data
  - Work through methods
- Group variables that are used together
- Make central points of control
  - Single task should be done at single place
  - Avoid duplicating code
- Facilitate code reuse
  - Use class hierarchies and virtual methods
- Package related operations together

## Namespaces
- Group related classes together in namespaces
- Follow consistent naming convention

```cs
namespace Utils
{
  class MathUtils { … }
  class StringUtils { … }
}

namespace DataAccessLayer
{
  class GenericDAO<Key, Entity> { … }
  class EmployeeDAO<int, Employee> { … }
  class AddressDAO<int, Address> { … }
}
```

# Typical Mistakes to Avoid

## Plural Used for a Class Name
- **Never use plural in class names** unless they hold some kind of collection!

```cs
public class Teachers : ITeacher
{
  public string Name { get; set; }
  public List<ICourse> Courses { get; set; }
}
```

```cs
public class GameFieldConstants
{
  public const int MIN_X = 100;
  public const int MAX_X = 700;
}
```

# Throwing an Exception Without Parameters
- Don't throw exception without parameters:

```cs
public ICourse CreateCourse(string name, string town)
{
  if (name == null)
  {
    throw new ArgumentNullException();
  }
  if (town == null)
  {
    throw new ArgumentNullException();
  }
  return new Course(name, town);
}
```
Which parameter is **null** here?

## Parameters Checked in the Getter
- Check for invalid data in the **setters** and **constructors**, not in the getter!

```cs
public string Town
{
   get
   {
      if (string.IsNullOrWhiteSpace(this.town))
         throw new ArgumentNullException();

      return this.town;
   }
   set { this.town = value; }
}
```
Put this check in the setter!

## Missing this for Local Members
- Always use **this.XXX** instead of **XXX** to access members within the class:

```cs
public class Course
{
  public string Name { get; set; }

  public Course(string name)
  {
    Name = name;
  }
}
```
Use **this.Name**

## Empty String for Missing Values
- Use **null** when a value is missing, not **0** or **""**
  - Make a field / property nullable to access **null** values or just disallow missing values
- Bad example:
```cs
Teacher teacher = new Teacher("");
```
- Correct alternatives:
```cs
Teacher teacher = new Teacher();
```
```cs
Teacher teacher = new Teacher(null);
```

## Magic Numbers in the Classes
- Don't use "**magic**" numbers
  - Especially when the class has members related to those numbers:

```cs
public class Wolf : Animal
{
  …
  bool TryEatAnimal(Animal animal)
  {
     if (animal.Size <= 4)
     {
       return true;
     }
  }
}
```
This if statement is very wrong. **4** is the size of the **Wolf**, which has a **Size** property inherited from **Animal**. Why not use **this.Size** instead of **4**?

## Base Constructor Not Called
- Call the base constructor to **reuse** the object's state initialization code:

```cs
public class Course
{
  public string Name { get; set; }
  public Course(string name)
  { this.Name = name; }
}
public class LocalCourse : Course
{
  public string Lab { get; set; }
  public Course(string name, string lab)
  {
    this.Name = name;
    this.Lab = lab;
  }
}
```
**: base (name)**
Call the base constructor instead!

## Repeating Code in the Base and Child Classes
- Never **copy-paste** the code of the base in the inherited class

```cs
public class Course
{
  public string Name { get; set; }
  public ITeacher Teacher { get; set; }
}
public class LocalCourse
{
  public string Name { get; set; }
  public ITeacher Teacher { get; set; }
  public string Lab { get; set; }
}
```

## Broken Encapsulation through a Parameterless Constructor
- Be careful to keep fields well encapsulated

```cs
public class Course
{
  public string Name { get; private set; }
  public ITeacher Teacher { get; private set; }

  public Course(string name, ITeacher teacher)
  {
    if (name == null) ArgumentNullException("name");
    if (teacher == null) ArgumentNullException("teacher");
    this.Name = name;
    this.Teacher = teacher;
  }

  public Course() { }
}
```

## Coupling the Base Class <br> With Its Child Classes
- A class should **never** know about its children!

```cs
public class Course
{
  public override string ToString()
  {
    if (this is ILocalCourse)
    {
      return "Lab = " + ((ILocalCourse)this).Lab;
    }
    if (this is IOffsiteCourse)
    {
      return "Town = " + ((IOffsiteCourse)this).Town;
    }
    ...
  }
}
```

## Hidden Interpretation of Base Class as Its Specific Child Class
- Don't define **IEnumerable<T>** fields and use them as **List<T>** (broken abstraction)

```cs
public class Container<T>
{
  public IEnumerable<T> Items { get; }
  public Container()
  {
    this.Items = new List<T>();
  }
  public void AddItem (T item)
  {
    (this.Items as List<T>).Add(item);
  }
}
```
