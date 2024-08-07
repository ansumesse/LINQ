using LINQ.SortedData_05;

namespace LINQ.Concatenation_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Concat
             **/
            var Emps = Repository.LoadEmployees().Take(10);
            var Emps2 = Repository.LoadEmployees().Skip(10).Take(10);
            foreach (var item in Concatenation(Emps, Emps2))
            {
                Console.WriteLine(item);
            }
        }

        private static IEnumerable<string> Concatenation(IEnumerable<Employee> emps, IEnumerable<Employee> emps2)
        {
            return emps.Select(x => x.Name).Concat(emps2.Select(x => x.Name));
        }
    }
}
