namespace LINQ.CustomLINQExtenstionMethod_19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var emps = Repository.Employees;
            emps.WhereWithPaginate(x => x.HasHealthInsurance).Print("");
        }
    }
}
