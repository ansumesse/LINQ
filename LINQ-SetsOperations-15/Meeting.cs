using System;
using System.Collections.Generic;
using System.Linq;

namespace Shared
{
    public class Meeting
    {
        public string Title { get; set; }

        public DateOnly Date { get; set; } // yyyy-MM-dd
       
        public TimeOnly StartAt { get; set; } // hh:mm:ss PM/AM

        public TimeOnly EndAt { get; set; }

        public List<Employee> Participants { get; set; } = new ();
 
         
        public override string ToString()
        {
            var participentsList = "";

            var length = Participants.Count;
            for (var i = 0; i < length; i++)
            {
                var branchSymbol = i < length - 1 ? "├" : "└";
                participentsList += $"\n\t\t{branchSymbol}─── {Participants[i]}";
            }
            return $"\n\t┌ {Date.ToString("D")}  [{StartAt.ToString("hh:mm")} - {EndAt.ToString("hh:mm")}] '{Title}' ({length}) participants" +
                   $"\n\t└───────┐" +
                   $"{participentsList}";
        }
        public override bool Equals(object? obj)
        {
            if (obj is null | this.GetType() != obj.GetType())
                return false;

            var temp = (Meeting)obj;
            return this.Title == temp.Title
                && this.StartAt == temp.StartAt
                && this.EndAt == temp.EndAt
                && this.Date == temp.Date;
        }
        public override int GetHashCode()
        {
            int hash = 23;
            hash *= 17 + this.Title.GetHashCode();
            hash *= 17 + this.StartAt.GetHashCode();
            hash *= 17 + this.EndAt.GetHashCode();
            hash *= 17 + this.Date.GetHashCode();
            return hash;
        }
    } 
}
