using FamilyScoreboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyScoreboard.ViewModels {
    public class Dashboard {
        public IList<FamilyMember> FamilyMemebers { get; set; }

        public FamilyMember ThisMonthsLeader { get; set; }
        public FamilyMember ThisWeeksLeader { get; set; }
        public int TotalPointsThisWeek { get; set; }
        public int TotalPointsThisMonth { get; set; }

    }
}
