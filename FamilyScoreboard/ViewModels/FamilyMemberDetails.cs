using FamilyScoreboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyScoreboard.ViewModels {
    public class FamilyMemberDetails {
        public FamilyMember FamilyMember { get; set; }
        public IEnumerable<Chore> Chores { get; set; }
        public int SelectedChoreId { get; set; }
    }
}
