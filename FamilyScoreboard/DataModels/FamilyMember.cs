using System;

namespace FamilyScoreboard.DataModels {
    public class FamilyMember {
        public int Id { get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string PreferredName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }

    }
}
