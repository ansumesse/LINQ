using FunctionalProgramming;
using LINQ.FunctionalProgramming_02;

namespace LINQ.GroupingData_08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Employees = Repository.LoadEmployees();

            GroupAndLookuptoEx(Employees);

        }

        private static void GroupAndLookuptoEx(IEnumerable<Employee> Employees)
        {
            var groupedByDepart = Employees.GroupBy(x => x.Department); // using deferd execution
            var toLookupDepart = Employees.ToLookup(x => x.Department); // using immediate execution
            var groupedByDepartQ = from emp in Employees
                                   group emp by emp.Department;


            foreach (var group in toLookupDepart)
            {
                group.Print($"'{group.Key}'");
            }
        }
    }
}
