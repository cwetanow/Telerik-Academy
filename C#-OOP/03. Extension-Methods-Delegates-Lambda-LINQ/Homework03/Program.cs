using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework03.ExtensionMethods;
using Homework03.Students;

namespace Homework03
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task 1
            Console.WriteLine("Task 1");
            var builder = new StringBuilder();
            builder.Append("This is a test");
            Console.WriteLine(builder.Substring(10, 4).ToString());
            //Task 2
            Console.WriteLine();
            Console.WriteLine("Task 2");
            var list = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine(IEnumerableExtensionMethods.Average(list));
            Console.WriteLine(IEnumerableExtensionMethods.Sum(list));
            Console.WriteLine(IEnumerableExtensionMethods.Product(list));
            Console.WriteLine(IEnumerableExtensionMethods.Min(list));
            //Task 3
            Console.WriteLine();
            Console.WriteLine("Task 3");
            var listOfStudents = new List<Student>{
                new Student("Ivan","Petrov", "619501","0285123285","bazinga@abv.bg",new List<double>{2,3,5,6,2,4,5},new Group(2,"Physics"),20),
                 new Student("Gosho","Kirov", "120125","0885168754","iAmPesho@gmail.com",new List<double>{3,3,3,3,3,5,3},new Group(2,"Mathematics"),19),
                  new Student("Pesho","Pesheff", "748906","0257231456","tainoobichamazis123@mail.bg",new List<double>{6,6,6,6,6},new Group(2,"Philosophy"),31),
                   new Student("Tosho","Gorgiev", "365406","6553698523","t.georgiev@abv.bg",new List<double>{2,2,2},new Group(3,"Mathematics"),22),
                    new Student("Hassan","Mehmedov", "458707","0251236945","allahuakbar@isis.onion",new List<double>{3,4,2,5,6,2,3},new Group(4,"Mathematics"),19)
                     
            };
            var studentsWithFirstBeforeLast = from student in listOfStudents
                                              where student.FirstName.CompareTo(student.LastName) < 0
                                              select student;
            foreach (var student in studentsWithFirstBeforeLast)
            {
                Console.WriteLine(student);
            }
            //Task 4
            Console.WriteLine();
            Console.WriteLine("Task 4");
            var studentsWithAgeInInterval = from student in listOfStudents
                                            where student.Age > 17 && student.Age < 25
                                            select student;
            foreach (var student in studentsWithAgeInInterval)
            {
                Console.WriteLine(student);
            }
            //Task 5
            Console.WriteLine();
            Console.WriteLine("Task 5");
            var sortedStudents = listOfStudents.OrderBy(student => student.FirstName).ThenBy(student => student.LastName);
            foreach (var item in sortedStudents)
            {
                Console.WriteLine(item);
            }
            //Task 6
            Console.WriteLine();
            var numbers = new List<int> { 1, 2, 3, 7, 49, 21, 42, 53, 222, 149 };
            Console.WriteLine("With Lambda");
            DivisibleBy7And3WithLambda(numbers);
            Console.WriteLine("With LINQ");
            DivisibleBy7And3WithLINQ(numbers);
            //Task 7
            Console.WriteLine();
            Console.WriteLine("Task 8");
            var timer = new Timer(4,3);
            timer.Invoke();
            //Task 9
            Console.WriteLine();
            Console.WriteLine("Task 9");
            var studentsFrom2Group = from student in listOfStudents
                                     where student.Group.GroupNumber == 2
                                     orderby student.FirstName
                                     select student;

            PrintCollection(studentsFrom2Group.ToList());
            //Task 10
            Console.WriteLine();
            Console.WriteLine("Task 10");
            var studentsFrom2 = listOfStudents
                .Where(student => student.Group.GroupNumber == 2)
                .OrderBy(student => student.FirstName)
                .Select(student => student);
            PrintCollection(studentsFrom2.ToList());
            //Task 11
            Console.WriteLine();
            Console.WriteLine("Task 11");
            var studentsWithABV = from student in listOfStudents
                                  where student.Email.Contains("abv.bg")
                                  select student;
            PrintCollection(studentsWithABV.ToList());
            //Task 12
            Console.WriteLine();
            Console.WriteLine("Task 12");
            var sofiaMans = listOfStudents
                .Where(student => student.Tel.Substring(0, 2) == "02")
                .Select(student => student);
            PrintCollection(sofiaMans.ToList());
            //Task 13
            Console.WriteLine();
            Console.WriteLine("Task 13");
            var excellentStudents = listOfStudents
                .Where(student => student.Marks.Contains(6))
                .Select(s => new { FullName = string.Format("{0} {1}", s.FirstName, s.LastName), Marks = string.Join(" ", s.Marks.ToArray()) });
            PrintCollection(excellentStudents.ToList());
            
            //Taske 14
            Console.WriteLine();
            Console.WriteLine("Task 14");
              var badStudents = listOfStudents
                  .Where(student=>student.Marks.Where(x=>x==2).ToList().Count==2)            
                  .Select(s => new { FullName = string.Format("{0} {1}", s.FirstName, s.LastName), Marks = string.Join(", ", s.Marks.ToArray()) });
              PrintCollection(badStudents.ToList());
            
            

            //Taskt 15
            Console.WriteLine();
            Console.WriteLine("Task 15");
            var marks = listOfStudents
                .Where(student => student.FN.Substring(4,2)=="06")
                .Select(student => student.Marks);
            foreach (var item in marks)
            {
                PrintCollection(item);
                Console.WriteLine();
            }
            //Task 16
            Console.WriteLine();
            Console.WriteLine("Task 16");
            var mathematicians = listOfStudents
                .Where(student => student.Group.DepartmentName.Equals("Mathematics"))
                .Select(student => student.FirstName);
            Console.WriteLine(string.Join(", ", mathematicians));
            

            //Task 17
            Console.WriteLine();
            Console.WriteLine("Task 17");
            var strings = new List<string> { "I", "am", "a", "baaaad", "string", "array" };
            var longest = strings
                .Where(s => s.Length == (strings
                                             .Where(stringa => stringa.Length > 0)
                                                .Select(stringa => stringa.Length).Max()))
                .Select(s => s);
            PrintCollection(longest.ToList());

            //Task 18
            Console.WriteLine();
            Console.WriteLine("Task 18");
            var grouped = listOfStudents
                .GroupBy(student => student.Group.GroupNumber)
                .Select(student=>student);
            foreach (var item in grouped)
            {
                Console.WriteLine("In Group:");
                PrintCollection(item.ToList());
                Console.WriteLine();
                
            }


        }
        static void PrintCollection<T>(List<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        static void DivisibleBy7And3WithLambda(List<int> list)
        {
            var temp = list.Where(num => (num % 7 == 0 && num % 3 == 0));
            foreach (var item in temp)
            {
                Console.WriteLine(item);
            }
        }
        static void DivisibleBy7And3WithLINQ(List<int> list)
        {
            var temp = from num in list
                       where num % 7 == 0 && num % 3 == 0
                       select num;
            foreach (var item in temp)
            {
                Console.WriteLine(item);
            }
        }
    }
}
