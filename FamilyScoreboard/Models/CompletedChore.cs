using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyScoreboard.Models {
    public class CompletedChore {
        public int Id { get; set; }
        public DateTimeOffset DateEntered { get; set; }
        public int PointsEarned { get; set; }
        public Chore Chore { get; set; }
        public FamilyMember FamilyMember { get; set; }
    }
}
