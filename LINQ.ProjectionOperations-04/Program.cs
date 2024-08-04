using FunctionalProgramming;

namespace LINQ.ProjectionOperations_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * select
             * selectMany
             * zip
             */
            // selectex();

            // SelectManyEx();
 
        }

        private static void SelectManyEx()
        {
            var Employees = Repository.LoadEmployees();
            var letters = Employees.SelectMany(e => e.FirstName);
            var letters2 = from e in Employees
                           from l in e.FirstName
                           select l;
            foreach (var item in letters2)
            {
                Console.WriteLine(item);
            }
        }

        private static void selectex()
        {
            var Employees = Repository.LoadEmployees();
            var FullNames = Employees.Select(e => $"{e.FirstName} {e.LastName}");
            var FullNames2 = from e in Employees
                             select $"{e.FirstName} {e.LastName}";
            foreach (var item in FullNames2)
            {
                Console.WriteLine(item);
            }
        }
    }
}
