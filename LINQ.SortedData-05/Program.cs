
namespace LINQ.SortedData_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * order DESC & ASC
             * orderby then
             * reverse
             * costum order
             **/
            var Employees = Repository.LoadEmployees();
            CustomOrderEx(Employees);
        }

        private static void CustomOrderEx(IEnumerable<Employee> Employees)
        {
            var CustomSorted = Employees.OrderBy(e => e, new CustomOrderEmployeeNo());
            CustomSorted.Print("sorted");
        }

        private static IEnumerable<Employee> ReverseEx(IEnumerable<Employee> Employees)
        {
            var ReversedEmp = Employees.OrderBy(e => e.Name).Reverse();
            var ReversedEmpQ = (from e in Employees
                                select e).Reverse();
            return ReversedEmp;
        }

        private static IOrderedEnumerable<Employee> OrderByTHenByEx(IEnumerable<Employee> Employees)
        {
            var SortedEmp = Employees.OrderBy(e => e.Name).ThenBy(e => e.Salary);
            var SortdEmpQ = from e in Employees
                            orderby e.Name, e.Salary
                            select e;
            return SortdEmpQ;
        }

        private static IOrderedEnumerable<Employee> OrderByEx()
        {
            var Employees = Repository.LoadEmployees();
            var SortedEmp = Employees.OrderBy(e => e.Name);
            var sortedEmpQ = from e in Employees
                             orderby e.Name
                             select e;
            return sortedEmpQ;
        }
    }
}
