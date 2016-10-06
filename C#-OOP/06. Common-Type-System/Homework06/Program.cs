using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework06.Classes;
namespace Homework06
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student("Ivan", "Petrov", "Ivanov",9605123452,"ul. Tech Support",Enumerations.Faculty.Computer,
                Enumerations.Specialty.Computers,Enumerations.University.SU,"0885123476","kiro.vanev@abv.bg");
            var b = student.Clone();
            Console.WriteLine(b);
            Console.WriteLine();
            var person = new Person();
            person.Age = null;
            Console.WriteLine(person);
            Console.WriteLine();
            var bits = new _64BitArray(5);
            var bitsSecond = new _64BitArray(14);
            Console.WriteLine(bits==bitsSecond);
            Console.WriteLine(bits!=bitsSecond);
            foreach (var item in bitsSecond)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine(bits.Equals(bitsSecond));
            Console.WriteLine(bits[2]);
            Console.WriteLine(bits);
        }
    }
}
