
using FamilyScoreboard.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FamilyScoreboard.ViewModels {
    public class Rewards {
        public IList<Reward> RewardList { get; set; }
        [Required]
        [Range(1, 1000)]
        [Display(Name = "Cost: ")]
        public int newRewardCost { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        [Display(Name = "Name: ")]
        public string newRewardName { get; set; }
        [Required]
        [MinLength(20)]
        [MaxLength(256)]
        [Display(Name = "Description: ")]
        public string newRewardDescription { get; set; }
    }
}
