using System;
using System.Collections.Generic;
using System.Linq;
using FamilyScoreboard.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FamilyScoreboard.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CompletedTasksController : ControllerBase {

        private readonly FamilyScoreboardContext _dbContext;

        public CompletedTasksController(FamilyScoreboardContext dbContext) {
            _dbContext = dbContext;
        }
        
        [HttpGet]
        public IEnumerable<CompletedTask> Get() {
            return _dbContext.CompletedTasks.Include(ct => ct.FamilyMember).Include(ct => ct.Task);
        }
        
        [HttpPost]
        public ActionResult Post([FromQuery(Name="familyMemberId")] int familyMemeberId, [FromQuery(Name = "taskId")] int taskId) {
            if(familyMemeberId == default || taskId == default) {
                return BadRequest("Query parameters familyMemeberId and taskId are required");
            }

            var familyMember = _dbContext.FamilyMembers.Single(_ => _.Id == familyMemeberId);
            var task = _dbContext.Tasks.Single(_ => _.Id == taskId);

            var newCompletedTask = new CompletedTask {
                FamilyMember = familyMember,
                Task = task,
                PointsEarned = task.PointValue,
                DateEarned = DateTimeOffset.Now
            };
            _dbContext.CompletedTasks.Add(newCompletedTask);
            _dbContext.SaveChanges();
            return Ok();
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id) {
            var completedTaskToDelete = _dbContext.CompletedTasks.Single(_ => _.Id == id);
            if(completedTaskToDelete != null) {
                _dbContext.CompletedTasks.Remove(completedTaskToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}
