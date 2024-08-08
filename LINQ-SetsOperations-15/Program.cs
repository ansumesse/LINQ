using Shared;

namespace LINQ_SetsOperations_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Distinct & DistinctBy
             * Except & ExceptBy
             * Intersect & IntersectBy
             * Union & UnionBy
             **/

            var ParticipentIn12 = Repository.Meeting1.Participants.Concat(Repository.Meeting2.Participants);
            ParticipentIn12.Print("pariticepent in meeting 1, 2");

            DistinctEx(ParticipentIn12).Print("Distinct Emps in meeting 1 ,2");
            DistinctbyEx(ParticipentIn12).Print("Distinct Emps in meeting 1 ,2");

            var participent1 = Repository.Meeting1.Participants;
            var participent2 = Repository.Meeting2.Participants;

            ExceptEx(participent1, participent2).Print("particiepent 1 except paticipent 2");
            ExceptByEx(participent1, participent2).Print("particiepent 1 except paticipent 2");

        }
        public static IEnumerable<Employee> DistinctEx(IEnumerable<Employee> emps)
        {
            var DistinctEmps = emps.Distinct();
            return DistinctEmps;
        }
        public static IEnumerable<Employee> DistinctbyEx(IEnumerable<Employee> emps)
        {
            var DistinctEmps = emps.DistinctBy(x => x.EmployeeNo);
            return DistinctEmps;
        }
        public static IEnumerable<Employee> ExceptEx(IEnumerable<Employee> emps1, IEnumerable<Employee> emps2)
        {
            var ExceptEmps = emps1.Except(emps2);
            return ExceptEmps;
            
        }
        public static IEnumerable<Employee> ExceptByEx(IEnumerable<Employee> emps1, IEnumerable<Employee> emps2)
        {
            var ExceptEmps = emps1.ExceptBy(emps2.Select(x => x.EmployeeNo), x => x.EmployeeNo);
            return ExceptEmps;
            
        }

    }
}
