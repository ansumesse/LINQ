using FunctionalProgramming;
using System.Collections.Generic;
using System.Xml.Linq;

namespace LINQ.FunctionalProgramming_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = Repository.LoadEmployees();
            list.Filter(e => e.FirstName.ToLowerInvariant().StartsWith("ma")).Print("Employees with first name starts with 'ma'");

            list.Filter(e => e.FirstName.ToLowerInvariant().EndsWith("m")).Print("Employees with last name starts with 'm'");

            list.Filter(e => e.Department.ToLowerInvariant() == "HR").Print("Employees in 'HR' department");

            list.Filter(e => e.HireDate.Year == 2018).Print("Employees hired in '2018'");

            list.Filter(e => e.Gender.ToLowerInvariant() == "female").Print("Female employees");

            list.Filter(e => e.HasHealthInsurance == false).Print("Employees without Health insurance");

            list.Filter(e => e.HasPensionPlan == true).Print("Employees with Pension Plan");

            list.Filter(e => e.Salary == 10700).Print("Employees with Salary = $10700");

            list.Filter(e => e.Salary > 10700).Print("Employees with Salary > $10700");

            list.Filter(e => e.Salary < 107000).Print("Employees with Salary < $10700");

            list.Filter(e => e.Salary < 107000 && e.Gender.ToLowerInvariant() == "female").Print("Employees with Salary < $107000 and female");

        }
    }
}
