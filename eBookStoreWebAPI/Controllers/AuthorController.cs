using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using BusinessObject.DBContext;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using DataAccess.UnitOfWork;

namespace eBookStoreWebAPI.Controllers
{
    [Route("odata/Authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

        // GET: api/Author
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            var list = await _unitOfWork.AuthorRepository.Get();
            return list.ToList();
        }

        // GET: api/Author/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await _unitOfWork.AuthorRepository.GetFirst(expression: a => a.author_id == id, "Book", "Author");

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        // PUT: api/Author/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, Author author)
        {
            if (id != author.author_id)
            {
                return BadRequest();
            }

            try
            {
                await _unitOfWork.AuthorRepository.Update(author);
            } catch
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Author
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]        
        public async Task<ActionResult<Author>> PostAuthor([FromBody]Author author)
        {
            await _unitOfWork.AuthorRepository.Add(author);            
            return CreatedAtAction("GetAuthor", new { id = author.author_id }, author);
        }

        // DELETE: api/Author/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _unitOfWork.AuthorRepository.GetFirst(expression: a => a.author_id == id);
            if (author == null)
            {
                return NotFound();
            }

            await _unitOfWork.AuthorRepository.Delete(author);
            return NoContent();
        }
    }
}
