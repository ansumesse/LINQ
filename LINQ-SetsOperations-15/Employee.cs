namespace Shared
{
    public class Employee
    {
        public string EmployeeNo {get;set;}
        public string Name {get;set;}
         
        public override string ToString()
        {
            return $"[{EmployeeNo}] {Name}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || this.GetType() != obj.GetType()) return false;

            var temp = (Employee)obj;

            return this.EmployeeNo == temp.EmployeeNo;
        }
        public override int GetHashCode()
        {
            int hash = 37;
            hash *= 23 + this.EmployeeNo.GetHashCode();
            hash *= 23 + this.Name.GetHashCode();
            return hash;
        }
    }
}
