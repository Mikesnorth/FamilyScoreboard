using FamilyScoreboard.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyScoreboard.ViewModels {
    public class Chores {
        public IList<Chore> ChoreList { get; set; } = new List<Chore>();
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [Display(Name = "Name: ")]
        public string newChoreName { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(500)]
        [Display(Name = "Description: ")]
        public string newChoreDescription { get; set; }
        [Display(Name = "Point Value: ")]
        public int newChorePointValue { get; set; }
    }
}
