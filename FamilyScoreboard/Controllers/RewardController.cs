using FamilyScoreboard.Infrastructure;
using FamilyScoreboard.Models;
using FamilyScoreboard.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FamilyScoreboard.Controllers {
    public class RewardController : Controller {

        private readonly ScoreboardContext _dbContext;

        public RewardController(ScoreboardContext dbContext) {
            _dbContext = dbContext;
        }
        public IActionResult Index() {
            var model = new Rewards {
                RewardList = _dbContext.Rewards?.ToList()
            };
            return View(model);
        }

        public IActionResult Add(Rewards model) {
            if(!ModelState.IsValid) {
                model.RewardList = _dbContext.Rewards.ToList();
                return View("Index", model);
            }

            var newReward = new Reward {
                Cost = model.newRewardCost,
                Name = model.newRewardName,
                Description = model.newRewardDescription,
                IsEnabled = true
            };

            _dbContext.Rewards.Add(newReward);
            _dbContext.SaveChanges();

            model = new Rewards {
                RewardList = _dbContext.Rewards.ToList()
            };

            return View("Index", model);
        }

        public IActionResult Remove(int id) {
            var rewardToRemove = _dbContext.Rewards.SingleOrDefault(_ => _.Id == id);
            _dbContext.Rewards.Remove(rewardToRemove);
            _dbContext.SaveChanges();
            return View("Index");
        }

        public IActionResult Deactivate(int id) {
            var rewardToDeactivate = _dbContext.Rewards.Single(_ => _.Id == id);
            rewardToDeactivate.IsEnabled = false;
            _dbContext.SaveChanges();
            return View("Index");
        }
    }
}