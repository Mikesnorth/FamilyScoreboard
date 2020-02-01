using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyScoreboard.DataModels;
using Microsoft.AspNetCore.Http;
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
        public IEnumerable<FamilyMember> Get() {
            return _dbContext.FamilyMembers;
        }

        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id) {
            var familyMemeber = _dbContext.FamilyMembers.SingleOrDefault(_ => _.Id == id);

            if(familyMemeber == null) {
                return NotFound();
            }
            return Ok(familyMemeber);
        }

        [HttpPost]
        public void Post([FromBody] FamilyMember newFamilyMember) {
            // TODO: run validation on received data
            _dbContext.FamilyMembers.Add(newFamilyMember);
            _dbContext.SaveChanges();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] FamilyMember updatedFamilyMember) {
            // TODO: run validation on received data
            var existingFamilyMember = _dbContext.FamilyMembers.SingleOrDefault(_ => _.Id == id);

            if(existingFamilyMember == null) {
                return BadRequest($"No member exists with id: {id}");
            }

            existingFamilyMember = updatedFamilyMember;
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
