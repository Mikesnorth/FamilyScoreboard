using FamilyScoreboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyScoreboard.ViewModels {
    public class Chores {
        public IEnumerable<Chore> ChoreList { get; set; }
    }
}
