namespace LINQ.JoinOperation_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Employees = Repository.LoadEmployees();
            var Departments = Repository.LoadDepartment();
            //JoinEx(Employees, Departments);
            IEnumerable<IEnumerable<Employee>> ResultQ = GroupJoinEx(Employees, Departments);
            //foreach (var item in Result)
            //{
            //    item.Employees.Print(item.DepartmentN);
            //}
            foreach (var item in ResultQ)
            {
                item.Print("");
            }
        }

        private static IEnumerable<IEnumerable<Employee>> GroupJoinEx(IEnumerable<Employee> Employees, IEnumerable<Department> Departments)
        {
            var Result = Departments.GroupJoin(
                Employees,
                d => d.Id,
                e => e.DepartmentId,
                (d, e) => new GroupDto()
                {
                    DepartmentN = d.Name,
                    Employees = e.ToList()
                }

                );
            var ResultQ = from dep in Departments
                          join emp in Employees
                          on dep.Id equals emp.DepartmentId into empgroup
                          select empgroup;
            return ResultQ;
        }

        private static void JoinEx(IEnumerable<Employee> Employees, IEnumerable<Department> Departments)
        {
            var Result = Employees.Join(
                Departments,
                e => e.DepartmentId,
                d => d.Id,
                (e, d) =>
                    new EmployeeDto()
                    {
                        Name = e.FullName,
                        DeptName = d.Name
                    });
            var ResultQ = from emp in Employees
                          join dep in Departments on emp.DepartmentId equals dep.Id
                          select new EmployeeDto()
                          {
                              Name = emp.FullName,
                              DeptName = dep.Name
                          };
            foreach (var item in ResultQ)
            {
                Console.WriteLine($"{item.Name}   {item.DeptName}");
            }
        }
    }
}
