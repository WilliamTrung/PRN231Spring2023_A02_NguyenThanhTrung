using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using BusinessObject.DBContext;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace eBookStoreWebAPI.Controllers
{
    [Route("odata/Users")]
    [ApiController]
    public class UserController : ODataController
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        // GET: api/User
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var list = await _unitOfWork.UserRepository.Get(expression: null, "Role", "Publisher");
            return list.ToList();
        }


        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.user_id)
            {
                return BadRequest();
            }


            try
            {
                await _unitOfWork.UserRepository.Update(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            await _unitOfWork.UserRepository.Add(user);

            return CreatedAtAction("GetUser", new { id = user.user_id }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _unitOfWork.UserRepository.GetFirst(c => c.user_id== id);
            if (user == null)
            {
                return NotFound();
            }
            
            await _unitOfWork.UserRepository.Delete(user);

            return NoContent();
        }
    }
}
