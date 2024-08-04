using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.SortedData_05
{
    internal class CustomOrderEmployeeNo : IComparer<Employee>
    {
        // 2017-FI-1343 we want to order by year then by series n
        public int Compare(Employee e1, Employee e2)
        {
            var year1 = Convert.ToInt32(e1.EmployeeNo.Split("-")[0]);
            var year2 = Convert.ToInt32(e2.EmployeeNo.Split("-")[0]);
            var seq1 = Convert.ToInt32(e1.EmployeeNo.Split("-")[2]);
            var seq2 = Convert.ToInt32(e2.EmployeeNo.Split("-")[2]);

            if (year1 == year2)
                return seq1.CompareTo(seq2);
            return year1.CompareTo(year2);
        }
    }
}
