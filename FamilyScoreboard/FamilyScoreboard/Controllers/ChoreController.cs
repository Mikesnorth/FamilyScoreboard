using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyScoreboard.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using FamilyScoreboard.ViewModels;
using FamilyScoreboard.Models;

namespace FamilyScoreboard.Controllers {
    public class ChoreController : Controller {

        private readonly ScoreboardContext _dbContext;

        public ChoreController(ScoreboardContext dbContext) {
            _dbContext = dbContext;
        }

        public IActionResult Index() {
            var model = new Chores {
                ChoreList = _dbContext.Chores.ToList()
            };
            return View(model);
        }

        public IActionResult Add(Chores model) {
            var newChore = new Chore {
                Name = model.newChoreName,
                Description = model.newChoreDescription,
                PointValue = model.newChorePointValue
            };

            _dbContext.Chores.Add(newChore);
            _dbContext.SaveChanges();

            model = new Chores {
                ChoreList = _dbContext.Chores.ToList()
            };
            return View("Index", model);
        }

        public IActionResult Remove(int id) {
            var choreToRemove = _dbContext.Chores.SingleOrDefault(_ => _.Id == id);

            if(choreToRemove != null) {
                _dbContext.Chores.Remove(choreToRemove);
                _dbContext.SaveChanges();
            }

            var model = new Chores {
                ChoreList = _dbContext.Chores.ToList()
            };
            return View("Index", model);
        }
    }
}