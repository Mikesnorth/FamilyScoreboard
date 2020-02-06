using System;

namespace FamilyScoreboard.Models {
    public class Redemption {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTimeOffset RedeptionDate { get; set; }
        public Reward Reward { get; set; }
        public FamilyMember FamilyMember { get; set; }
    }
}
