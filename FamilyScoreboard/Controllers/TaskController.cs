using System.Linq;
using FamilyScoreboard.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace FamilyScoreboard.Controllers
{
    [Route("api/Tasks")]
    [ApiController]
    public class TaskController : ControllerBase {

        private readonly FamilyScoreboardContext _dbContext;

        public TaskController(FamilyScoreboardContext dbContext) {
            _dbContext = dbContext;
        }
        
        [HttpGet]
        public ActionResult Get() {
            return Ok(_dbContext.Tasks);
        }

        
        [HttpGet("{id}", Name = "GetTask")]
        public ActionResult Get(int id) {
            var task = _dbContext.Tasks.SingleOrDefault(_ => _.Id == id);
            if(task == null) {
                return NotFound();
            }
            return Ok(task);
        }

        
        [HttpPost("{id}")]
        public ActionResult Post(int id, [FromBody] Task updatedTask) {
            var existingTask = _dbContext.Tasks.SingleOrDefault(_ => _.Id == id);

            if (existingTask == null) {
                return BadRequest($"No task exists with id: {id}");
            }

            existingTask.Name = updatedTask.Name;
            existingTask.Description = updatedTask.Description;
            existingTask.PointValue = updatedTask.PointValue;

            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Task newTask) {

            if(newTask.Id != default) {
                return BadRequest("Id cannot be specified");
            }

            _dbContext.Tasks.Add(newTask);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public void Delete(int id) {
            var taskToDelete = _dbContext.Tasks.SingleOrDefault(_ => _.Id == id);
            if(taskToDelete != null) {
                _dbContext.Remove(taskToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}
