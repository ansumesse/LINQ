using LINQ.FunctionalProgramming_02;
using System.Collections;
namespace LINQ.CoreOfLINQ_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 8, 9 };
            // Extension Where (fluent syntax)
            var EvenNum1 = Numbers.Where(n => n % 2 == 0);
            // Enumerable Where method
            var EvenNum2 = Enumerable.Where(Numbers, n => n % 2 == 0);
            // using Query Syntax
            var EvenNum3 =
                from n in Numbers
                where n % 2 == 0
                select n;
            Numbers.Add(10);

            EvenNum1.Print("even numbers");
            EvenNum2.Print("even numbers");
            EvenNum3.Print("even numbers");
        }
    }
}
