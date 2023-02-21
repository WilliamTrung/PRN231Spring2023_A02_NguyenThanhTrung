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
    [Route("odata/Publishers")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PublisherController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Publishers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publisher>>> GetPublishers()
        {
            var list = await _unitOfWork.PublisherRepository.Get();
            return list.ToList();
        }


        // PUT: api/Publishers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublisher(int id, Publisher publisher)
        {
            if (id != publisher.pub_id)
            {
                return BadRequest();
            }


            try
            {
                await _unitOfWork.PublisherRepository.Update(publisher);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Publishers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Publisher>> PostPublisher(Publisher publisher)
        {
            await _unitOfWork.PublisherRepository.Add(publisher);

            return CreatedAtAction("GetPublisher", new { id = publisher.pub_id }, publisher);
        }

        // DELETE: api/Publishers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            var publisher = await _unitOfWork.PublisherRepository.GetFirst(c => c.pub_id == id);
            if (publisher == null)
            {
                return NotFound();
            }

            await _unitOfWork.PublisherRepository.Delete(publisher);

            return NoContent();
        }
    }
}
