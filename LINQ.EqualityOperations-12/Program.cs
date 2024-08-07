using LINQ.SortedData_05;

namespace LINQ.EqualityOperations_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // SequanceEqual

            var Employees = Repository.LoadEmployees();

            var first5Emps = Employees.Take(5);
            var sec5Emps = Employees.Take(5);
            Console.WriteLine(AreEqual(first5Emps, sec5Emps));

        }
        public static bool AreEqual(IEnumerable<Employee> employees1, IEnumerable<Employee> employees2)
        {
            return employees1.SequenceEqual(employees2);
        }
    }
}
