using System;
using System.Collections.Generic;
using System.Text;

class ExceptionsHomework
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }
        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (count > str.Length)
        {
            return "Invalid count!";
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }
        return result.ToString();
    }

    public static void CheckPrime(int number)
    {
        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                throw new InvalidOperationException("The number is not prime!");
            }
        }
    }

    static void Main()
    {
        var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(String.Join(" ", subarr));

        var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(String.Join(" ", allarr));

        var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(String.Join(" ", emptyarr));

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));
        Console.WriteLine(ExtractEnding("Hi", 100));

        try
        {
            CheckPrime(23);
            Console.WriteLine("23 is prime.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            CheckPrime(33);
            Console.WriteLine("33 is prime.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }

        List<Exam> peterExams = new List<Exam>();

        try
        {
            peterExams.Add(new SimpleMathExam(2));
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            peterExams.Add(new CSharpExam(55));
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            peterExams.Add(new CSharpExam(100));
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            peterExams.Add(new SimpleMathExam(1));
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            peterExams.Add(new CSharpExam(0));
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Student peter;
        try
        {
            peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
