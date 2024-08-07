using FunctionalProgramming;

namespace LINQ.ElementOperations_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * ElementAt
             * First
             * Last
             * Single
             **/
            var Employees = Repository.LoadEmployees();

            // var employeeAt = ElementAtEx(100, Employees);
            var firstEmp = FirstEx(Employees);
            Console.WriteLine(firstEmp);
        }

        private static Employee FirstEx(IEnumerable<Employee> employees)
        {
            return employees.FirstOrDefault(x => x.FirstName == null, new Employee()
            {
                Department = "null",
                HasHealthInsurance = false,
                Gender = "null",
                FirstName = "null",
                HasPensionPlan = false,
                HireDate = default,
                Id = default,
                LastName = "null",
                Salary = default
            }
                );
        }

        private static Employee ElementAtEx(int index, IEnumerable<Employee> employees)
        {
            if (index < employees.Count())
                return employees.ElementAt(index);
            else
            {
                return employees.ElementAtOrDefault(index) ?? new Employee() { Department = "null", HasHealthInsurance = false, Gender = "null",
                    FirstName = "null", HasPensionPlan = false, HireDate = default, Id = default, LastName = "null", Salary = default };
            }
        }
    }
}
