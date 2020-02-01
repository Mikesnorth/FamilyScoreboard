using System.Collections.Generic;
using System.Linq;
using FamilyScoreboard.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace FamilyScoreboard.Controllers
{
    [Route("api/FamilyMembers")]
    [ApiController]
    public class FamilyMemberController : ControllerBase {

        private readonly FamilyScoreboardContext _dbContext;

        public FamilyMemberController(FamilyScoreboardContext dbContext) {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult Get() {
            return Ok(_dbContext.FamilyMembers);
        }

        [HttpGet("{id}", Name = "GetFamilyMember")]
        public ActionResult Get(int id) {
            var familyMemeber = _dbContext.FamilyMembers.SingleOrDefault(_ => _.Id == id);

            if(familyMemeber == null) {
                return NotFound();
            }
            return Ok(familyMemeber);
        }

        [HttpPost("{id}")]
        public ActionResult Post(int id, [FromBody] FamilyMember updatedFamilyMember) {
            var existingFamilyMember = _dbContext.FamilyMembers.SingleOrDefault(_ => _.Id == id);

            if (existingFamilyMember == null)  {
                return BadRequest($"No member exists with id: {updatedFamilyMember.Id}");
            }

            existingFamilyMember.FirstName = updatedFamilyMember.FirstName;
            existingFamilyMember.LastName = updatedFamilyMember.LastName;
            existingFamilyMember.PreferredName = updatedFamilyMember.PreferredName;
            existingFamilyMember.DateOfBirth = updatedFamilyMember.DateOfBirth;
            
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public ActionResult Put(int id, [FromBody] FamilyMember newFamilyMember) {
           
            if(newFamilyMember.Id != default) {
                return BadRequest("Id cannot be specified");
            }

            _dbContext.FamilyMembers.Add(newFamilyMember);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public void Delete(int id) {
            var familyMemeberToDelete = _dbContext.FamilyMembers.SingleOrDefault(_ => _.Id == id);
            if(familyMemeberToDelete != null) {
                _dbContext.FamilyMembers.Remove(familyMemeberToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}
