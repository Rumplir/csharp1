using S09EP03.Entities;
using S09EP03.Entities.Enums;
using System.Globalization;

namespace S09EP03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter Worker data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("How many contracts to this worker? ");
            int qntContracts = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            for (int i = 1; i <= qntContracts; i++)
            {
                Console.WriteLine($"Enter #{i} contract data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);

            }
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string MAndY = Console.ReadLine();
            int month = int.Parse(MAndY.Substring(0,2));
            int year = int.Parse(MAndY.Substring(3));
            Console.WriteLine($"Name: {worker.Name}");
            Console.WriteLine($"Department: {worker.Department.Name}");
            Console.WriteLine($"Income for {MAndY}: {worker.Income(month, year):C2}");
        }
    }
}