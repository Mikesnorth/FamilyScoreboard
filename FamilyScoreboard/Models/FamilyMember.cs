using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyScoreboard.Models {
    public class FamilyMember {
        public int Id { get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PreferredName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public ICollection<CompletedChore> CompletedChores { get; set; }
    }
}
