using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework05.Shapes;
using Homework05.Banking;

namespace Homework05
{
    class Program
    {
        static void Main(string[] args)
        {
            TestShapes();
            Console.WriteLine();
            TestBank();
            Console.WriteLine();
            

            TestException();
            
            Console.WriteLine();
            TestExceptionWithDate();
        }
        static void TestException()
        {
            var rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                var b = rand.Next(-500, 500);
                try
                {
                    var start = 0;
                    var end = 100;
                    if (b < start || b > end)
                    {
                        throw new InvalidRangeException<int>("Invalid range",start.ToString(),end.ToString());
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Exception caught, number is: {0}", b);
                    Console.WriteLine();
                }

            }
        }
        public static void TestExceptionWithDate()
        {
            Random gen = new Random();
            for (int i = 0; i < 10; i++)
            {
                var b = RandomDay(gen);
                try
                {
                    
                    var start = new DateTime(1980, 1, 1);
                    var end = new DateTime(2013, 12, 31);
                    if (b < start || b > end)
                    {
                        throw new InvalidRangeException<DateTime>("Invalid range", start.ToString(), end.ToString());
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Exception caught, number is: {0}", b);
                    Console.WriteLine();
                }
                Console.WriteLine(RandomDay(gen));
            }
            

        }
         
       public static DateTime RandomDay(Random gen)
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
        static void TestBank()
        {
            var bank = new Bank(new List<Account> { 
                new DepositAccount(Customer.company, 1000, 2),
                new LoanAccount(Customer.company, 2222, 2.7),
                new MortgageAccount(Customer.company, 1234, 1.7),
                new DepositAccount(Customer.company, 200, 2),
                new DepositAccount(Customer.individual, 11000, 3),
                new MortgageAccount(Customer.individual, 1200, 2),
                new LoanAccount(Customer.individual, 14236, 3)
                
            });
            bank.PrintAccounts();
        }
        static void TestShapes()
        {
            var shapes = new List<Shape>()
            {
                new Triangle(5,3),
                new Square(5),
                new Square(2),
                new Triangle(3,6),
                new Rectangle(40,2),
                new Triangle(5,11),
                new Rectangle(5,22),
                new Triangle(7,12),
                new Square(14),
                new Rectangle(2,1),
                new Triangle(3,3),
                new Square(11),
                new Square(9),
                new Rectangle(4.2,3.7),
                new Square(40)
            };
            foreach (var item in shapes)
            {
                Console.WriteLine("{0} surface: {1}", item, item.CalculateSurface());
            }
        }
    }
}
