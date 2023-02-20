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

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAuthorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookAuthorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

        // GET: api/BookAuthor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookAuthor>>> GetBookAuthors()
        {
            var result = await _unitOfWork.BookAuthorRepository.Get();
            return result.ToList();
        }

        // GET: api/BookAuthor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookAuthor>> GetBookAuthor(int id)
        {
            //var bookAuthor = await _context.BookAuthors.FindAsync(id);

            //if (bookAuthor == null)
            //{
            //    return NotFound();
            //}

            return null;
        }

        // PUT: api/BookAuthor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookAuthor(int id, BookAuthor bookAuthor)
        {
            //if (id != bookAuthor.author_id)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(bookAuthor).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!BookAuthorExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return NoContent();
        }

        // POST: api/BookAuthor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookAuthor>> PostBookAuthor(BookAuthor bookAuthor)
        {
            //_context.BookAuthors.Add(bookAuthor);
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (BookAuthorExists(bookAuthor.author_id))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return CreatedAtAction("GetBookAuthor", new { id = bookAuthor.author_id }, bookAuthor);
        }

        // DELETE: api/BookAuthor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookAuthor(int id)
        {
            //var bookAuthor = await _context.BookAuthors.FindAsync(id);
            //if (bookAuthor == null)
            //{
            //    return NotFound();
            //}

            //_context.BookAuthors.Remove(bookAuthor);
            //await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
