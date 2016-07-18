using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem1.People;
using Problem1.Disciplines;
using Problem3;
using Problem3.Cats;

namespace Homework04
{
    class Program
    {
        public static List<Problem2.Student> InitialiseStudents(){
            List<Problem2.Student> students = new List<Problem2.Student>() { 
            new Problem2.Student("Ivan", "Petrov", 4),
            new Problem2.Student("Pesho", "Pesheff", 5),
            new Problem2.Student("Gorgi", "Kirov", 2),
            new Problem2.Student("Tosho", "Toshev", 2),
            new Problem2.Student("Ivan", "Karachanakov", 3),
            new Problem2.Student("Versachko", "Petrov", 3),
            new Problem2.Student("Dolcho", "Kandev", 4),
            new Problem2.Student("Gabancho", "Kandev", 6),
            new Problem2.Student("Valeri", "Bojinov", 3),
            new Problem2.Student("Georgi", "Georgiev", 5)
        };
            return students;
        }
        public static List<Problem2.Worker> InitialiseWorkers()
        {
            List<Problem2.Worker> workers = new List<Problem2.Worker>()
        {
            new Problem2.Worker("Georgi","Gesheff",100,12),
            new Problem2.Worker("Ivan","Vesheff",1500,2),
            new Problem2.Worker("Georgi","Gesheff",111,8),
            new Problem2.Worker("Petur","Georgiev",333,8),
            new Problem2.Worker("Kiro","Petrov",444,4),
            new Problem2.Worker("Gancho","Ivanov",555,4),
            new Problem2.Worker("Ivan","Kirov",123,8),
            new Problem2.Worker("Gesh","Ahmedov",123,8),
            new Problem2.Worker("Tosho","Kirov",333,8),
            new Problem2.Worker("Pepi","Cvetevv",44,16)
        };
            return workers;
        }
        static void Main(string[] args)
        {
            //Task 1
            var teach = new Teacher("Kiro", new List<Discipline> { new Discipline("Math",20, 200)});
            Console.WriteLine(teach.Name);
            var stud = new Student("Pesho", 1234);
            Console.WriteLine(stud.ClassNumber);
            Console.WriteLine();
            //Task 2
            var students = InitialiseStudents().OrderBy(x=>x.Grade).ToList();
            foreach (var item in students)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            var workers = InitialiseWorkers().OrderBy(x=>x.MoneyPerHour()).ToList();
            foreach (var item in workers)
            {
                Console.WriteLine(item);
            }
            List<Problem2.Human> merged=new List<Problem2.Human>();
            foreach (var item in students)
            {
                merged.Add(item);
            }
            foreach (var item in workers)
            {
                merged.Add(item);
            }
            merged = merged.OrderBy(x => x.FirstName).ThenBy(x=>x.LastName).ToList();
            Console.WriteLine();
            foreach (var item in merged)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            
            //Task 3
            var dogs = new List<Dog>(){
                new Dog("Old Sharo","Male",12),
                new Dog("Sharo","Male",4),
                new Dog("Jony","Male",5),
                new Dog("Atilla","Female",2),
                new Dog("Rex","Male",6)
            };
            Console.WriteLine("Dogs avg: {0}",dogs.Average(x=>x.Age));
            var cats = new List<Cat>(){
                new Tomcat("Persi",2),
                new Kitten("Leila",4),
                new Kitten("Baba mara",5),
                new Cat("Ginka","Female",2),
                new Tomcat("Anfibya",6)
            };
            Console.WriteLine("Cats avg: {0}", cats.Average(x => x.Age));
            var frogs = new List<Frog>(){
                new Frog  ("Car Jaba","Male" ,2),
                new Frog("Carica jaba","Female",4),
                new Frog("Grand mayster","Male",432),
                new Frog("Ginka","Female",2),
                new Frog("John Frog","Male",6)
            };
            Console.WriteLine("Frogs avg: {0}", frogs.Average(x => x.Age));
        }
    }
}
