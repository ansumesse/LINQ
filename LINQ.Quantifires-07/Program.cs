using LINQ.DataPartitioning_06;

namespace LINQ.Quantifires_07
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var employees = Repository.LoadEmployees();
            bool Result2;
            IEnumerable<Employee> ResultQ;
            AnyEx(employees, out Result2, out ResultQ);
            bool Result3;
            AllEx(employees, out Result2, out Result3);
            Console.WriteLine(Result2);
            ResultQ.Print("dd");
        }

        private static void AllEx(IEnumerable<Employee> employees, out bool Result2, out bool Result3)
        {
            Result2 = employees.All(x => !string.IsNullOrEmpty(x.Email));
            Result3 = employees.All(x => x.Skills.Any(y => y.Equals("c#", StringComparison.OrdinalIgnoreCase)));
        }

        private static void AnyEx(IEnumerable<Employee> employees, out bool Result2, out IEnumerable<Employee> ResultQ)
        {
            var Result = employees.Any(x => x.Name.StartsWith("jac", StringComparison.OrdinalIgnoreCase));

            Result2 = employees.Any(x => x.Salary < 200_000);
            var Result3 = employees.Any(x => x.Skills.Count == 1);

            ResultQ = from emp in employees
                      where emp.Skills.Any(x => x.Length <= 3)
                      select emp;
        }
    }
}
