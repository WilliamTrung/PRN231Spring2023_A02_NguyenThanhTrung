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
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;

namespace eBookStoreWebAPI.Controllers
{
    [Route("odata/BookAuthors")]
    [ApiController]
    public class BookAuthorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookAuthorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<BookAuthor>>> GetBookAuthors()
        {
            var result = await _unitOfWork.BookAuthorRepository.Get(expression: null, "Book", "Author");
            //var result = await _unitOfWork.BookAuthorRepository.Get();
            return result.ToList();
        }

        // GET: api/BookAuthor
        //[HttpGet("{id}")]
        //public async Task<ActionResult<IEnumerable<BookAuthor>>> GetBookAuthors(int id)
        //{
        //    var result = await _unitOfWork.BookAuthorRepository.Get(expression: ba => ba.book_id == id);
        //    return result.ToList();
        //}

        //// GET: api/BookAuthor/5
        //[HttpGet("book-{book_id}/author-{author-id}")]
        //public async Task<ActionResult<BookAuthor>> GetBookAuthor(int book_id, int author_id)
        //{
        //    var find = await _unitOfWork.BookAuthorRepository.GetFirst(expression: ba => ba.book_id == book_id && ba.author_id == author_id);
        //    if(find == null)
        //    {
        //        return NotFound();
        //    }
        //    return find;
        //}

        // PUT: api/BookAuthor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookAuthor(int book_id, int author_id, BookAuthor bookAuthor)
        {
            if (book_id != bookAuthor.book_id && author_id != bookAuthor.author_id)
            {
                return BadRequest();
            }
            try
            {
                await _unitOfWork.BookAuthorRepository.Update(bookAuthor);
            }
            catch
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/BookAuthor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookAuthor>> PostBookAuthor(BookAuthor bookAuthor)
        {
            await _unitOfWork.BookAuthorRepository.Add(bookAuthor);
            return CreatedAtAction("GetBookAuthor", new { id = bookAuthor.author_id }, bookAuthor);
        }

        // DELETE: api/BookAuthor/5
        [HttpDelete("book-{book_id}/author-{author-id}")]
        public async Task<IActionResult> DeleteBookAuthor(int book_id, int author_id)
        {
            var find = await _unitOfWork.BookAuthorRepository.GetFirst(expression: e => e.book_id == book_id && e.author_id == author_id);
            if (find == null)
            {
                return NotFound();
            }
            await _unitOfWork.BookAuthorRepository.Delete(find);

            return NoContent();
        }
    }
}
