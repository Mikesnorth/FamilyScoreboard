using FamilyScoreboard.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyScoreboard.ViewModels {
    public class Family {
        public IList<FamilyMember> FamilyMembers { get; set; }
        [Display(Name = "First Name")]
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string newMemberFirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string newMemberLastName { get; set; }
        [Display(Name = "Preferred Name")]
        public string newMemberPreferredName { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTimeOffset newMemberDateOfBirth { get; set; }
    }
}
