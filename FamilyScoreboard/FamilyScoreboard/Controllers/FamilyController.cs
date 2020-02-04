using System;
using System.Collections.Generic;
using System.Linq;
using FamilyScoreboard.Infrastructure;
using FamilyScoreboard.Models;
using FamilyScoreboard.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FamilyScoreboard.Controllers {
    public class FamilyController : Controller {

        private readonly ScoreboardContext _dbContext;

        public FamilyController(ScoreboardContext dbContext) {
            _dbContext = dbContext;
        }


        public ActionResult<Family> Index() {
            var model = new Family {
                FamilyMembers = _dbContext.FamilyMemebers.ToList()
            };
            return View(model);
        }

        public ActionResult<Family> Add(Family model) {
            var newFamilyMember = new FamilyMember {
                FirstName = model.newMemberFirstName,
                LastName = model.newMemberLastName,
                PreferredName = model.newMemberPreferredName,
                DateOfBirth = model.newMemberDateOfBirth,
                CompletedChores = new List<CompletedChore>()
            };

            _dbContext.FamilyMemebers.Add(newFamilyMember);
            _dbContext.SaveChanges();

            model = new Family {
                FamilyMembers = _dbContext.FamilyMemebers.ToList()
            };
            return View("Index", model);
        }

        [Route("{id}")]
        public ActionResult<Family> Remove(int id) {
            var memberToRemove = _dbContext.FamilyMemebers.SingleOrDefault(_ => _.Id == id);
            if(memberToRemove != null) {
                _dbContext.FamilyMemebers.Remove(memberToRemove);
                _dbContext.SaveChanges();
            }

            var model = new Family {
                FamilyMembers = _dbContext.FamilyMemebers.Include(fm => fm.CompletedChores).ToList()
            };
            return View("Index", model);
        }

        public ActionResult Details(int id) {
            var model = new FamilyMemberDetails {
                FamilyMember = _dbContext.FamilyMemebers.Include(fm => fm.CompletedChores).Single(_ => _.Id == id),
                Chores = _dbContext.Chores.ToList()
            };
            return View(model);
        }

        public ActionResult MarkChoreComplete(FamilyMemberDetails memberDetails) {
            var familyMemeber = _dbContext.FamilyMemebers.Include(fm => fm.CompletedChores).Single(_ => _.Id == memberDetails.FamilyMember.Id);
            var choreToMark = _dbContext.Chores.Single(_ => _.Id == memberDetails.SelectedChoreId);

            if(familyMemeber.CompletedChores == null) {
                familyMemeber.CompletedChores = new List<CompletedChore>();
            }
            familyMemeber.CompletedChores.Add(new CompletedChore {
                DateEntered = DateTimeOffset.Now,
                PointsEarned = choreToMark.PointValue,
                Chore = choreToMark
            });

            _dbContext.SaveChanges();

            var model = new FamilyMemberDetails{
                FamilyMember = _dbContext.FamilyMemebers.Single(_ => _.Id == memberDetails.FamilyMember.Id),
                Chores = _dbContext.Chores.ToList()
            };
            return View("Details", model);
        }
    }
}
