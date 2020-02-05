using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FamilyScoreboard.Models;
using FamilyScoreboard.ViewModels;
using FamilyScoreboard.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FamilyScoreboard.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly ScoreboardContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ScoreboardContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }

        public ActionResult Index() {
            var model = new Dashboard {
                FamilyMemebers = _dbContext.FamilyMemebers.Include(_ => _.CompletedChores).ToList()
            };
            model.TotalPointsThisWeek = model.FamilyMemebers.Sum(CalculatePointsThisWeek);
            model.TotalPointsThisMonth = model.FamilyMemebers.Sum(CalculatePointsThisMonth);
            model.ThisWeeksLeader = model.FamilyMemebers.OrderByDescending(CalculatePointsThisWeek).First();
            model.ThisMonthsLeader = model.FamilyMemebers.OrderByDescending(CalculatePointsThisMonth).First();
            return View(model);
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private int CalculatePointsThisWeek(FamilyMember familyMember) {
            var completedChoresThisWeek = familyMember.CompletedChores.Where(_ => _.DateEntered > DateTimeOffset.Now.AddDays(-7));
            return completedChoresThisWeek.Sum(_ => _.PointsEarned);
        }

        private int CalculatePointsThisMonth(FamilyMember familyMember) {
            var completedChoresThisWeek = familyMember.CompletedChores.Where(_ => _.DateEntered.Month == DateTimeOffset.Now.Month && _.DateEntered.Year == DateTimeOffset.Now.Year);
            return completedChoresThisWeek.Sum(_ => _.PointsEarned);
        }
    }
}
