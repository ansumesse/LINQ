using LINQ.DataPartitioning_06;

namespace LINQ.AggregateOperations_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Aggregate
             * Sum
             * Average
             * Max & Min
             * MaxBy &MinBy
             **/
            var Employees = Repository.LoadEmployees();
            Console.WriteLine(MinByEx(Employees));
        }
        public static decimal AggregateEx(IEnumerable<Employee> emps)
        {
            var TotalSalsry = emps.Select(x => x.Salary).Aggregate((x, y) => x + y);
            return TotalSalsry;
        }
        public static decimal AggregateEx2(IEnumerable<Employee> emps)
        {
            var MaxSalary = emps.Select(x => x.Salary).Aggregate((x, y) => x < y ? y : x);
            return MaxSalary;
        }
        public static decimal SumEx(IEnumerable<Employee> emps)
        {
            return emps.Sum(x => x.Salary);
        }
        public static decimal AvgEx(IEnumerable<Employee> emps) => emps.Average(x => x.Salary);
        public static decimal MinEx(IEnumerable<Employee> emps)
        {
            return emps.Min(x => x.Salary);
        }
        public static decimal MaxEx(IEnumerable<Employee> emps) => emps.Max(x => x.Salary);
        public static Employee MaxByEx(IEnumerable<Employee> emps) => emps.MaxBy(x => x.Salary);
        public static Employee MinByEx(IEnumerable<Employee> emps) => emps.MinBy(x => x.Salary);
    }
}
