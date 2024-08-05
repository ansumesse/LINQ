
namespace LINQ.DataPartitioning_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = Repository.LoadEmployees();
            //SkipEX(employees);
            //TakeEx(employees);
            //Chunks(employees);
           
            while (true)
            {
                Console.WriteLine("Enter # of records per page: ");
                int.TryParse(Console.ReadLine(), out int size);

                Console.WriteLine("Enter # of page: ");
                int.TryParse(Console.ReadLine(), out int page);

                var Result = employees.Paginate(size, page);
                int StartFrom = (page - 1) * size + 1;
                int EndTo = Result.Count() < size ? (page - 1) * size + Result.Count() : page * size;
                Result.Print($"starts from {StartFrom} to {EndTo}");
            }
           


        }

        private static void Chunks(IEnumerable<Employee> employees)
        {
            var empChunks = employees.Chunk(5).ToList();
            for (int i = 0; i < empChunks.Count(); i++)
            {
                empChunks[i].Print($"chunk NO {i + 1}");

            }
        }

        private static void TakeEx(IEnumerable<Employee> employees)
        {
            var TakeEx1 = employees.Take(10);
            TakeEx1.Print("Take first 10 emps");

            var TakeEx2 = employees.TakeWhile(e => e.Index != 25);
            TakeEx2.Print("Take until indes of emps = 25");

            var TakeEx3 = employees.TakeLast(10);
            TakeEx3.Print("Take last 10 emps");
        }

        private static void SkipEX(IEnumerable<Employee> employees)
        {
            var skipEx1 = employees.Skip(10);
            skipEx1.Print("Skip first 10 emps");

            var skipEx2 = employees.SkipWhile(e => e.Index != 25);
            skipEx2.Print("Skip until indes of emps = 25");

            var skipEx3 = employees.SkipLast(10);
            skipEx3.Print("Skip last 10 emps");
        }
    }
}
