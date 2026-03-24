using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelianordMCT.API.Data;
using SelianordMCT.API.Entities;

namespace SelianordMCT.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnquiriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EnquiriesController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enquiry>>> GetAll()
        {
            var enquiries = await _context.Enquiries
                .OrderByDescending(e => e.CreatedAt)
                .ToListAsync();

            return Ok(enquiries);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Enquiry>> GetById(int id)
        {
            var enquiry = await _context.Enquiries.FindAsync(id);

            if (enquiry == null)
                return NotFound();

            return Ok(enquiry);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<Enquiry>> Create(Enquiry enquiry)
        {
            enquiry.Status = "New";
            enquiry.CreatedAt = DateTime.UtcNow;

            _context.Enquiries.Add(enquiry);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = enquiry.Id }, enquiry);
        }

        [Authorize]
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
        {
            var enquiry = await _context.Enquiries.FindAsync(id);

            if (enquiry == null)
                return NotFound();

            enquiry.Status = status;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var enquiry = await _context.Enquiries.FindAsync(id);

            if (enquiry == null)
                return NotFound();

            _context.Enquiries.Remove(enquiry);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}