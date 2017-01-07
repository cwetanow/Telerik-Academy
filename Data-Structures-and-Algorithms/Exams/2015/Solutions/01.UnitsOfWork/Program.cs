using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.UnitsOfWork
{
    class Program
    {
        private static IDictionary<string, Unit> unitsByName = new Dictionary<string, Unit>();
        private static IDictionary<string, SortedSet<Unit>> unitsByType = new Dictionary<string, SortedSet<Unit>>();
        private static SortedSet<Unit> unitsByPower = new SortedSet<Unit>();

        private static IList<Unit> units = new List<Unit>();

        private const string SuccessAdd = "SUCCESS: {0} added!";
        private const string FailAdd = "FAIL: {0} already exists!";
        private const string SuccessRemove = "SUCCESS: {0} removed!";
        private const string FailRemove = "FAIL: {0} could not be found!";
        private const string Result = "RESULT: {0}";

        static void Main(string[] args)
        {
            Start();
        }

        private static void Start()
        {
            var command = Console.ReadLine();
            while (!command.StartsWith("end"))
            {
                var splittedCommand = command.Split(' ');

                var commandType = splittedCommand[0];

                if (commandType == "add")
                {
                    Add(splittedCommand);
                }
                else if (commandType == "remove")
                {
                    Remove(splittedCommand);
                }
                else if (commandType == "find")
                {
                    Find(splittedCommand);
                }
                else
                {
                    Power(splittedCommand);
                }

                command = Console.ReadLine();
            }
        }

        private static void Add(string[] parameters)
        {
            var unitName = parameters[1];
            if (unitsByName.ContainsKey(unitName))
            {
                Console.WriteLine(FailAdd, unitName);
            }
            else
            {
                var unitType = parameters[2];
                var attack = int.Parse(parameters[3]);

                var unit = new Unit
                {
                    Name = unitName,
                    Power = attack,
                    UnitType = unitType
                };

                if (unitsByType.ContainsKey(unitType))
                {
                    unitsByType[unitType].Add(unit);
                }
                else
                {
                    unitsByType[unitType] = new SortedSet<Unit> { unit };
                }

                unitsByPower.Add(unit);
                unitsByName.Add(unitName, unit);

                Console.WriteLine(SuccessAdd, unitName);
            }
        }

        private static void Remove(string[] parameters)
        {
            var unitName = parameters[1];
            if (unitsByName.ContainsKey(unitName))
            {
                var unit = unitsByName[unitName];
                unitsByName.Remove(unitName);

                unitsByPower.Remove(unit);
                unitsByType[unit.UnitType].Remove(unit);

                Console.WriteLine(SuccessRemove, unitName);
            }
            else
            {
                Console.WriteLine(FailRemove, unitName);
            }
        }

        private static void Find(string[] parameters)
        {
            var type = parameters[1];
            var topUnits = Enumerable.Empty<Unit>();

            if (unitsByType.ContainsKey(type))
            {
                topUnits = unitsByType[type]
                    .Take(10);
            }

            Console.WriteLine(Result, string.Join(", ", topUnits));
        }

        private static void Power(string[] parameters)
        {
            var count = int.Parse(parameters[1]);
            var topUnits = unitsByPower
                .Take(count);

            Console.WriteLine(Result, string.Join(", ", topUnits));
        }
    }

    public class Unit : IComparable<Unit>
    {
        // Add validations

        public string Name { get; set; }

        public string UnitType { get; set; }

        public int Power { get; set; }

        public int CompareTo(Unit other)
        {
            var result = this.Power.CompareTo(other.Power) * -1;
            if (result == 0)
            {
                result = this.Name.CompareTo(other.Name);
            }

            return result;
        }

        public override string ToString()
        {
            return string.Format("{0}[{1}]({2})", this.Name, this.UnitType, this.Power);
        }
    }
}
