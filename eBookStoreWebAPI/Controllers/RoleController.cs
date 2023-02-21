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

namespace eBookStoreWebAPI.Controllers
{
    [Route("odata/Roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Roles
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            var list = await _unitOfWork.RoleRepository.Get();
            return list.ToList();
        }
        // PUT: api/Roles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, Role role)
        {
            if (id != role.role_id)
            {
                return BadRequest();
            }


            try
            {
                await _unitOfWork.RoleRepository.Update(role);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Roles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Role>> PostRole(Role role)
        {
            await _unitOfWork.RoleRepository.Add(role);

            return CreatedAtAction("GetRole", new { id = role.role_id }, role);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _unitOfWork.RoleRepository.GetFirst(c => c.role_id == id);
            if (role == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
