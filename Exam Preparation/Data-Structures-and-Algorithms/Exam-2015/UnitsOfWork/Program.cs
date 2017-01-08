using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitsOfWork
{
    class Program
    {
        private static SortedSet<Unit> units;
        private static Dictionary<string, Unit> unitsByName;

        static void Main()
        {
            units = new SortedSet<Unit>();
            unitsByName = new Dictionary<string, Unit>();

            string command = Console.ReadLine();
            while (command != "end")
            {
                HandleCommand(command);
                command = Console.ReadLine();
            }
        }

        static void HandleCommand(string command)
        {
            string[] commandInfo = command.Split();

            string commandName = commandInfo[0];
            switch (commandName)
            {
                case "add":
                    Add(commandInfo[1], commandInfo[2], int.Parse(commandInfo[3]));
                    break;

                case "remove":
                    Remove(commandInfo[1]);
                    break;

                case "find":
                    Find(commandInfo[1]);
                    break;

                case "power":
                    Find(int.Parse(commandInfo[1]));
                    break;

                default: return;
            }
        }

        static void Add(string unitName, string unitType, int unitAttack)
        {
            if (unitsByName.ContainsKey(unitName))
            {
                Console.WriteLine("FAIL: {0} already exists!", unitName);
            }
            else
            {
                var unit = new Unit(unitName, unitType, unitAttack);

                units.Add(unit);
                unitsByName.Add(unitName, unit);

                Console.WriteLine("SUCCESS: {0} added!", unitName);
            }
        }

        static void Remove(string unitName)
        {
            if (!unitsByName.ContainsKey(unitName))
            {
                Console.WriteLine("FAIL: {0} could not be found!", unitName);
            }
            else
            {
                var unit = unitsByName[unitName];

                units.Remove(unit);
                unitsByName.Remove(unitName);

                Console.WriteLine("SUCCESS: {0} removed!", unitName);
            }
        }

        static void Find(int numberOfUnits)
        {
            string result = "RESULT: " + string.Join(", ", units.Take(numberOfUnits));
            Console.WriteLine(result);
        }

        static void Find(string unitType)
        {
            string result = "RESULT: " + string.Join(", ", units.Where(x => x.Type == unitType).Take(10));
            Console.WriteLine(result);
        }
    }

    class Unit : IComparable<Unit>
    {
        public Unit(string name, string type, int attack)
        {
            this.Name = name;
            this.Type = type;
            this.Attack = attack;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Attack { get; set; }

        public int CompareTo(Unit other)
        {
            int attackCompareResults = this.Attack.CompareTo(other.Attack);
            if (attackCompareResults > 0)
            {
                return -1;
            }
            else if (attackCompareResults < 0)
            {
                return 1;
            }
            else
            {
                return this.Name.CompareTo(other.Name);
            }
        }

        public override int GetHashCode()
        {
            return 23 + this.Name.GetHashCode() >> 17 ^
                   (23 + this.Attack.GetHashCode() >> 17 ^
                    (23 + this.Type.GetHashCode() >> 17));
        }

        public override string ToString()
        {
            return string.Format("{0}[{1}]({2})", this.Name, this.Type, this.Attack);
        }
    }
}
