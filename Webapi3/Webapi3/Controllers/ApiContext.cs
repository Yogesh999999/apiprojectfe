using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi3.Models;  // Assuming the 'Detail' model and 'ApiContext' are in this namespace

namespace Webapi3.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // This makes it an API controller
    public class DetailsController : ControllerBase
    {
        private readonly ApiContext _context;

        public DetailsController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/details
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Detail>>> GetDetails()
        //{
            //return await _context.Details.ToListAsync();
        //}

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Detail>>> getdet()
        //{
        //    return await _context.Details.ToListAsync();
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Detail>>> getdet()
        {
            return await _context.Details.OrderBy(d => d.Id)   
                                        .ToListAsync();
        }



        // GET: api/details/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Detail>> GetDetail(int id)
        //{
        //    var detail = await _context.Details.FindAsync(id);

        //    if (detail == null)
        //    {
        //        return NotFound();
        //    }

        //    return detail;
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<Detail>> gettid(int id)
        {
            //var detail = await _context.Details.FindAsync(id);

            var detail = await _context.Details.Where(i=>i.Id == id).FirstOrDefaultAsync();

            if (detail == null){
                return NotFound();
            }

            return detail;
        }

        // PUT: api/details/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetail(int id, Detail detail)
        {
            if (id != detail.Id)
            {
                return BadRequest();
            }

            _context.Entry(detail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }





        // POST: api/details
        //[HttpPost]
        //public async Task<ActionResult<Detail>> PostDetail(Detail detail)
        //{
        //    _context.Details.Add(detail);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetDetail), new { id = detail.Id }, detail);
        //}

        // DELETE: api/details/5




        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetail(int id)
        {
            var detail = await _context.Details.FindAsync(id);
            if (detail == null)
            {
                return NotFound();
            }

            _context.Details.Remove(detail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchDetail(int id, [FromBody] JsonPatchDocument<Detail> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var detail = await _context.Details.FindAsync(id);

            if (detail == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(detail, ModelState);

            if (!ModelState.IsValid)    
            {
                return BadRequest(ModelState);
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }




        private bool DetailExists(int id)
        {
            return _context.Details.Any(e => e.Id == id);
        }
    }
}
